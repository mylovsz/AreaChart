using Common.Common;
using System;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace AreaChart
{
    public enum UPDATEType
    {

        /// <summary>
        /// 发起者请求更新 
        /// </summary>
        RequestCMD = 0x19,
        /// <summary>
        /// 接收者回应发起者 
        /// </summary>
        ResponseReqCMD = 0x1A,

        /// <summary>
        /// 接收者主动通知开始发数据
        /// </summary>
        ResponseCMD = 0x1B,
        /// <summary>
        /// 发起者回应
        /// </summary>
        ReadyCMD = 0x1C,
        /// <summary>
        /// 分发数据
        /// </summary>
        PostDataCMD = 0x1D,
        /// <summary>
        /// 接收数据
        /// </summary>
        AskDataCMD = 0x1E,
        /// <summary>
        /// 发起者通知取消
        /// </summary>
        ServerCancelCMD = 0x1F,
        /// <summary>
        /// 接收者接收取消
        /// </summary>
        ClientAskCMD = 0x20,
        /// <summary>
        /// 接收者通知取消
        /// </summary>
        ClientCancelCMD = 0x27,
        /// <summary>
        /// 发起者接收取消
        /// </summary>
        ServerAskCMD = 0x28,
        /// <summary>
        /// 传输成功
        /// </summary>
        UpdateOKCMD = 0x29
    }
    public partial class SendCMD
    {
        private static SendCMD sendCmd = null;

        public static SendCMD GetInstance()
        {
            if (sendCmd == null)
            {
                sendCmd = new SendCMD();
            }
            return sendCmd;
        }
        /// <summary>
        /// 请求写入数据，等待回复
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="timeout"></param>
        /// <param name="filePath"></param>
        /// <returns></returns>
        public bool DataWriteRequest(SerialPortHelper serialPort, int timeout, string filePath)
        {
            byte[] datas = new byte[] { 0xff, 0xff };//包头, 0x00, 0x00, 0x19, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,0x00,0x00 };
            datas = datas.Concat(new byte[] { 0x00, 0x00 }).ToArray();//包长度
            datas = datas.Concat(new byte[] { (byte)UPDATEType.RequestCMD }).ToArray();//命令
            datas = datas.Concat(new byte[] { 0x00 }).ToArray();//包序号
            datas = datas.Concat(new byte[] { 0x00, 0x00 }).ToArray();//Flags
            byte[] fileDatas = ReadFile(filePath);//读取文件转字节
            datas = datas.Concat(new byte[] { (byte)(fileDatas.Length >> 24), (byte)(fileDatas.Length >> 16), (byte)(fileDatas.Length >> 8), (byte)fileDatas.Length }).ToArray();//数据大小
            byte[] dataCheck = HexHelper.StringToByteArray(GetFileHash(filePath));//数据校验
            datas = datas.Concat(new byte[] { (byte)(dataCheck.Length >> 8), (byte)(dataCheck.Length) }).ToArray();//数据校验码长度
            datas = datas.Concat(dataCheck).ToArray();//文件校验码

            datas = datas.Concat(new byte[] { 0x00 }).ToArray();//校验和
            datas[2] = (byte)((datas.Length - 4) >> 8);
            datas[3] = (byte)((datas.Length - 4));
            datas[datas.Length - 1] = SumCheck(datas);//校验和

            byte[] revData = new byte[54];//8个回应，45个接受者告知发起者可以发送数据
            if (serialPort.SendCommand(datas, ref revData, timeout) == revData.Length)
            {
                if (revData[4] == (byte)UPDATEType.ResponseReqCMD && revData[13] == (byte)UPDATEType.ResponseCMD)
                {
                    SponsoReply(serialPort);
                    return true;
                }
            }
            return false;
        }
        /// <summary>
        /// 发起者回应接收者
        /// </summary>
        /// <param name="serial"></param>
        /// <returns></returns>
        private void SponsoReply(SerialPortHelper serialPort)
        {
            byte[] datas = new byte[] { 0xff, 0xff };//包头, 0x00, 0x00, 0x1C, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,0x00,0x00 };
            datas = datas.Concat(new byte[] { 0x00, 0x00 }).ToArray();//包长度
            datas = datas.Concat(new byte[] { (byte)UPDATEType.ReadyCMD }).ToArray();//命令
            datas = datas.Concat(new byte[] { 0x00 }).ToArray();//包序号
            datas = datas.Concat(new byte[] { 0x00, 0x00 }).ToArray();//Flags
            datas = datas.Concat(new byte[] { 0x00 }).ToArray();//校验和
            datas[2] = (byte)((datas.Length - 4) >> 8);
            datas[3] = (byte)((datas.Length - 4));
            datas[datas.Length - 1] = SumCheck(datas);//校验和

            serialPort.SendData(datas);
        }

        public int DataSent(SerialPortHelper serialPort, int timeout, string filePath, object sender)
        {
            BackgroundWorker bgWorker = sender as BackgroundWorker;

            //var res = Task<int>.Factory.StartNew(() =>
            //{
            byte[] fileDatas = ReadFile(filePath);
            int zoneNum = 1, zoneCount = 0;//分片序号，分片总数
            if (fileDatas.Length % 128 == 0)
                zoneCount = fileDatas.Length / 256;
            else
                zoneCount = fileDatas.Length / 256 + 1;
            while (true)
            {
                byte[] datas = new byte[] { 0xff, 0xff };//包头, 0x00, 0x00, 0x19, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,0x00,0x00 };
                datas = datas.Concat(new byte[] { 0x00, 0x00 }).ToArray();//包长度
                datas = datas.Concat(new byte[] { (byte)UPDATEType.PostDataCMD }).ToArray();//命令
                datas = datas.Concat(new byte[] { 0x00 }).ToArray();//包序号
                datas = datas.Concat(new byte[] { 0x00, 0x00 }).ToArray();//Flags
                                                                          //此处为分片数据内容处理
                if (zoneNum == zoneCount)//最后一次
                    datas[7] = (byte)(2);//Flags
                datas = datas.Concat(new byte[] { (byte)(zoneNum >> 8), (byte)(zoneNum) }).ToArray();//分片序号
                datas = datas.Concat(new byte[] { (byte)(zoneCount >> 8), (byte)(zoneCount) }).ToArray();//总分片数
                byte[] bag = fileDatas.Skip((zoneNum - 1) * 256).Take(256).ToArray();
                datas = datas.Concat(bag).ToArray();//数据内容
                datas = datas.Concat(new byte[] { 0x00 }).ToArray();//校验和
                datas[2] = (byte)((datas.Length - 4) >> 8);
                datas[3] = (byte)((datas.Length - 4));
                datas[datas.Length - 1] = SumCheck(datas);//校验和

                byte[] revData = new byte[9];
                if (serialPort.SendCommand(datas, ref revData, timeout) == revData.Length)
                {
                    Console.WriteLine("revData[4]:" + revData[4]);
                    if (revData[4] == (byte)UPDATEType.AskDataCMD)//完成一次分片通讯
                    {
                        SponsoReply(serialPort);
                        if (zoneNum == zoneCount)//最后一次发完(最后一帧有回复)
                        {
                            return 1;//发送完成
                        }
                    }
                    else if (revData[4] == (byte)UPDATEType.ClientCancelCMD)//接受者通知取消
                    {
                        SponsoCancelReply(serialPort);
                        return -1;//接受者通知取消
                    }
                    else if (revData[4] == (byte)UPDATEType.UpdateOKCMD)//MCU重启
                    {
                        if (zoneNum == zoneCount)
                        {
                            return 1;//发送完成
                        }
                        else
                        {
                            return -4;//MCU重启或其他问题
                        }
                    }
                    else//未知协议[目前的未知是重启造成的乱码，时有时无]
                    {
                        return -3;//不是最后一次的未知回复
                    }
                }
                else
                {
                    return -2;//通讯超时
                }
                zoneNum++;
                double pv = zoneNum * 1.0 / zoneCount;
                bgWorker.ReportProgress((int)(pv * 100));
                Console.WriteLine("zoneNum:" + zoneNum);
            }
            //});

            //return res.Result;
        }

        /// <summary>
        /// 发起者向接受者通知取消数据下放
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public bool InitiativeCancel(SerialPortHelper serialPort, int timeout)
        {
            byte[] datas = new byte[] { 0xff, 0xff };//包头, 0x00, 0x00, 0x19, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,0x00,0x00 };
            datas = datas.Concat(new byte[] { 0x00, 0x00 }).ToArray();//包长度
            datas = datas.Concat(new byte[] { (byte)UPDATEType.ServerAskCMD }).ToArray();//命令
            datas = datas.Concat(new byte[] { 0x00 }).ToArray();//包序号
            datas = datas.Concat(new byte[] { 0x00, 0x00 }).ToArray();//Flags
            datas = datas.Concat(new byte[] { 0x00 }).ToArray();//校验和
            datas[2] = (byte)((datas.Length - 4) >> 8);
            datas[3] = (byte)((datas.Length - 4));
            datas[datas.Length - 1] = SumCheck(datas);//校验和

            byte[] revData = new byte[9];
            if (serialPort.SendCommand(datas, ref revData, timeout) == revData.Length)
            {
                if (revData[4] == (byte)UPDATEType.ClientAskCMD)
                {
                    return true;
                }
            }
            return false;
        }

        /// <summary>
        /// 接受者向发起者通知取消数据下放，发起者回复接受者
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public void SponsoCancelReply(SerialPortHelper serialPort)
        {
            byte[] datas = new byte[] { 0xff, 0xff };//包头, 0x00, 0x00, 0x19, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00, 0x00,0x00,0x00 };
            datas = datas.Concat(new byte[] { 0x00, 0x00 }).ToArray();//包长度
            datas = datas.Concat(new byte[] { (byte)UPDATEType.ServerAskCMD }).ToArray();//命令
            datas = datas.Concat(new byte[] { 0x00 }).ToArray();//包序号
            datas = datas.Concat(new byte[] { 0x00, 0x00 }).ToArray();//Flags
            datas = datas.Concat(new byte[] { 0x00 }).ToArray();//校验和
            datas[2] = (byte)((datas.Length - 4) >> 8);
            datas[3] = (byte)((datas.Length - 4));
            datas[datas.Length - 1] = SumCheck(datas);//校验和

            serialPort.SendData(datas);
        }



        private byte[] ReadFile(string fileName)
        {
            FileStream pFileStream = null;
            byte[] pReadByte = new byte[0];
            try
            {
                pFileStream = new FileStream(fileName, FileMode.Open, FileAccess.Read);
                BinaryReader r = new BinaryReader(pFileStream);
                r.BaseStream.Seek(0, SeekOrigin.Begin);    //将文件指针设置到文件开
                pReadByte = r.ReadBytes((int)r.BaseStream.Length);
                return pReadByte;
            }
            catch
            {
                return pReadByte;
            }
            finally
            {
                if (pFileStream != null)
                    pFileStream.Close();
            }
        }
        /// <summary>
        /// 通过Hash值来验证文件是否被篡改
        /// </summary>
        /// <param name="argFilePath">文件路径</param>
        /// <returns>输出Hash值</returns>
        public static string GetFileHash(string argFilePath)
        {
            string hash = "";
            using (MD5CryptoServiceProvider md5 = new MD5CryptoServiceProvider())
            using (FileStream fs = new FileStream(argFilePath, FileMode.Open, FileAccess.Read, FileShare.Read))
            {
                hash = BitConverter.ToString(md5.ComputeHash(fs));
                //TLLog.Instance.Write(BitConverter.ToString(md5.ComputeHash(fs)));
                //return BitConverter.ToString(md5.ComputeHash(fs)).Replace("-", "");
            }

            return hash.Replace("-", "");
        }
        /// <summary>
        /// 校验和
        /// </summary>
        /// <param name="bs"></param>
        /// <returns></returns>
        private static byte SumCheck(byte[] bs)
        {
            int num = 0;
            //所有字节累加
            for (int i = 2; i < bs.Length; i++)
            {
                num = num + bs[i];
            }
            byte ret = (byte)(num & 0xff);//只要最后一个字节
            return ret;
        }
    }
}
