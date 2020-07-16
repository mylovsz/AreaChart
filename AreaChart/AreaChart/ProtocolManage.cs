using Common.Common;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace AreaChart
{
    /// <summary>
    /// 协议管理
    /// </summary>
    public class ProtocolManage
    {
        /// <summary>
        /// 生成读取保持寄存器数据的命令
        /// </summary>
        /// <param name="deviceID">设备地址</param>
        /// <param name="startAddress">内存位置</param>
        /// <param name="length">读取长度</param>
        /// <returns>生成读取数据的命令</returns>
        public static byte[] RevModbusFun3(byte deviceID, int startAddress, int length)
        {
            length /= 2;
            byte[] sendData = new byte[] { 0x01, 0x03, 0x01, 0x00, 0x00, 0x3E, 0xC5, 0xE6 };
            sendData[0] = deviceID;
            sendData[2] = (byte)(startAddress >> 8);
            sendData[3] = (byte)(startAddress);
            sendData[4] = (byte)(length >> 8);
            sendData[5] = (byte)(length);

            ushort crc = CRCHelper.CalculateCrc16(sendData, sendData.Length - 2);
            sendData[sendData.Length-2] = (byte)(crc >> 8);
            sendData[sendData.Length-1] = (byte)(crc);

            return sendData;
        }
        /// <summary>
        /// 生成读取输入寄存器数据的命令
        /// </summary>
        /// <param name="deviceID">设备地址</param>
        /// <param name="startAddress">内存位置</param>
        /// <param name="length">读取长度</param>
        /// <returns>生成读取数据的命令</returns>
        public static byte[] RevModbusFun4(byte deviceID, int startAddress, int length)
        {
            length /= 2;
            byte[] sendData = new byte[] { 0x01, 0x04, 0x01, 0x00, 0x00, 0x3E, 0xC5, 0xE6 };
            sendData[0] = deviceID;
            sendData[2] = (byte)(startAddress >> 8);
            sendData[3] = (byte)(startAddress);
            sendData[4] = (byte)(length >> 8);
            sendData[5] = (byte)(length);

            ushort crc = CRCHelper.CalculateCrc16(sendData, sendData.Length - 2);
            sendData[sendData.Length - 2] = (byte)(crc >> 8);
            sendData[sendData.Length - 1] = (byte)(crc);

            return sendData;
        }
        /// <summary>
        /// 生成设置设备的命令数据
        /// </summary>
        /// <param name="deviceID">设备地址</param>
        /// <param name="startAddress">内存地址</param>
        /// <param name="datas">要下放的数据</param>
        /// <returns></returns>
        public static byte[] SendModbusFun10(byte deviceID, int startAddress, byte[] datas)
        {
            DataParityFlip(datas, 20);//前20个数据不需要翻转

            int length = datas.Length / 2;
            byte[] sendData = new byte[] { deviceID, 0x10, 0x01, 0x00, 0x00, 0x3E , 0x00};
            sendData[2] = (byte)(startAddress >> 8);
            sendData[3] = (byte)(startAddress);
            
            sendData[4] = (byte)(length >> 8);
            sendData[5] = (byte)(length);
            sendData[6] = (byte)(datas.Length);

            sendData = sendData.Concat(datas).Concat(new byte[2]).ToArray();

            ushort crc = CRCHelper.CalculateCrc16(sendData, sendData.Length - 2);
            sendData[sendData.Length - 2] = (byte)(crc >> 8);
            sendData[sendData.Length - 1] = (byte)(crc);

            return sendData;
        }
        /// <summary>
        /// 数据奇偶互换位置，处理数据大小端的问题
        /// </summary>
        /// <param name="datas">带转换的数据</param>
        /// <param name="offset">偏移</param>
        public static void DataParityFlip(byte[] datas, int offset)
        {
            int l = datas.Length;
            byte a;
            for (int i = offset; i < l; i += 2)
            {
                a = datas[i];
                datas[i] = datas[i + 1];
                datas[i + 1] = a;
            }
        }
        /// <summary>
        /// 读取结构体大小数据
        /// </summary>
        /// <param name="serialPort">串口</param>
        /// <param name="timeout">读写超时时间</param>
        /// <param name="deviceID">从机地址</param>
        /// <param name="startAddress">内存开始地址</param>
        /// <param name="structType">定义的结构体</param>
        /// <returns></returns>
        public static object ReadDeviceToStruct(SerialPortHelper serialPort, int timeout, byte deviceID, ushort startAddress, Type structType)
        {
            try
            {
                int length = Marshal.SizeOf(structType);
                byte[] sendData = RevModbusFun3(deviceID, startAddress, length);
                byte[] revData = new byte[length + 5];//+5是命令格式的头和尾
                if (serialPort.SendCommand(sendData, ref revData, timeout) == revData.Length)
                {
                    Console.WriteLine(DataConverter.ByteArrayToHexString(revData));
                    // CRC校验
                    int crc = CRCHelper.CalculateCrc16(revData, revData.Length - 2);
                    if (revData[1] == 0x03 && crc == (revData[revData.Length - 1] + revData[revData.Length - 2] * 256))//匹配回复的数据是否正确
                    {
                        DataParityFlip(revData, 43);//偏移43个数据(命令格式头3个+软件版本20个+型号20个)，然后后面的数据都要翻转，数据 大小端 的问题
                        return StructToShortTool.ByteToStuct(revData, 3, length, structType);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        public static object ReadDeviceToStruct4(SerialPortHelper serialPort, int timeout, byte deviceID, ushort startAddress, Type structType)
        {
            try
            {
                int length = Marshal.SizeOf(structType);
                byte[] sendData = RevModbusFun4(deviceID, startAddress, length);
                byte[] revData = new byte[length + 5];//+5是命令格式的头和尾
                Console.WriteLine("发送数据：" + DataConverter.ByteArrayToHexString(revData));
                LogManage.LogHelper.Info("发送数据：" + DataConverter.ByteArrayToHexString(revData));
                if (serialPort.SendCommand(sendData, ref revData, timeout) == revData.Length)
                {
                    Console.WriteLine("接收数据："+DataConverter.ByteArrayToHexString(revData));
                    LogManage.LogHelper.Info("接收数据：" + DataConverter.ByteArrayToHexString(revData));
                    // CRC校验
                    int crc = CRCHelper.CalculateCrc16(revData, revData.Length - 2);
                    if (revData[1] == 0x04 && crc == (revData[revData.Length - 1] + revData[revData.Length - 2] * 256))//匹配回复的数据是否正确
                    {
                        DataParityFlip(revData, 3);//偏移43个数据(命令格式头3个+软件版本20个+型号20个)，然后后面的数据都要翻转，数据 大小端 的问题
                        return StructToShortTool.ByteToStuct(revData, 3, length, structType);
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }

        /// <summary>
        /// 读取输入寄存器数据
        /// </summary>
        /// <param name="serialPort">串口</param>
        /// <param name="timeout">读写超时时间</param>
        /// <param name="deviceID">从机地址</param>
        /// <param name="startAddress">内存开始地址</param>
        /// <param name="structType">定义的结构体</param>
        /// <returns></returns>
        public static byte[] ReadDeviceToBytes(SerialPortHelper serialPort, int timeout, byte deviceID, ushort startAddress,int length)
        {
            try
            {
                //int length = 10;
                byte[] sendData = RevModbusFun4(deviceID, startAddress, length);
                byte[] revData = new byte[length + 5];//+5是命令格式的头和尾
                if (serialPort.SendCommand(sendData, ref revData, timeout) == revData.Length)
                {
                    // CRC校验
                    int crc = CRCHelper.CalculateCrc16(revData, revData.Length - 2);
                    if (revData[1] == 0x04 && crc == (revData[revData.Length - 1] + revData[revData.Length - 2] * 256))//匹配回复的数据是否正确
                    {
                        DataParityFlip(revData, 3);
                        return revData;
                    }
                }
                return null;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return null;
        }
        /// <summary>
        /// 写入结构体大小数据
        /// </summary>
        /// <param name="serialPort">串口</param>
        /// <param name="timeout">读写超时时间</param>
        /// <param name="deviceID">从机地址</param>
        /// <param name="startAddress">内存开始地址</param>
        /// <param name="obj">定义的结构体</param>
        /// <param name="offset">因为软件版本不可修改，要偏移10个</param>
        /// <returns>是否发送完成</returns>
        public static bool WriteStructToDevice(SerialPortHelper serialPort, int timeout, byte deviceID, ushort startAddress, object obj, int offset)
        {
            try
            {
                byte[] datas = StructToShortTool.StructToByte(obj);
                byte[] sendData = SendModbusFun10(deviceID, startAddress+offset, datas.Skip(offset*2).ToArray());
                byte[] revData = new byte[8];
                //Console.WriteLine("写入数据：" + DataConverter.ByteArrayToHexString(sendData));
                LogManage.LogHelper.Info("写入数据：" + DataConverter.ByteArrayToHexString(sendData));
                if (serialPort.SendCommand(sendData, ref revData, timeout) == revData.Length)
                {
                    // CRC校验
                    //Console.WriteLine("接受数据：" + DataConverter.ByteArrayToHexString(revData));
                    LogManage.LogHelper.Info("接受数据：" + DataConverter.ByteArrayToHexString(sendData));
                    int crc = CRCHelper.CalculateCrc16(revData, revData.Length - 2);
                    if (revData[1] == 0x10 && crc == (revData[revData.Length - 1] + revData[revData.Length - 2] * 256))
                    {
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
        /// <summary>
        /// 写入结构体大小数据
        /// </summary>
        /// <param name="serialPort">串口</param>
        /// <param name="timeout">读写超时时间</param>
        /// <param name="deviceID">从机地址</param>
        /// <param name="startAddress">内存开始地址</param>
        /// <param name="datas">定义的结构体</param>
        /// <returns>是否发送完成</returns>
        public static bool WriteBytesToDevice(SerialPortHelper serialPort, int timeout, byte deviceID, ushort startAddress,byte[] datas)
        {
            try
            {
                
                byte[] sendData = SendModbusFun10(deviceID, startAddress, datas);
                byte[] revData = new byte[8];
                if (serialPort.SendCommand(sendData, ref revData, timeout) == revData.Length)
                {
                    // CRC校验
                    int crc = CRCHelper.CalculateCrc16(revData, revData.Length - 2);
                    if (revData[1] == 0x10 && crc == (revData[revData.Length - 1] + revData[revData.Length - 2] * 256))
                    {
                        return true;
                    }
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        #region 升级固件
        /// <summary>
        /// 进入固件升级模式
        /// </summary>
        /// <param name="serialPort">串口</param>
        /// <param name="timeout">超时时间</param>
        /// <param name="deviceID">设备地址</param>
        /// <param name="startAddress">内存地址</param>
        /// <param name="datas">数据</param>
        /// <returns></returns>
        public static bool FOATMode(SerialPortHelper serialPort, int timeout)
        {
            try
            {
                byte[] sendData = new byte[] { 0x01, 0x05, 0x00, 0x01, 0xff, 0x00, 0x00, 0x00 };

                ushort crc = CRCHelper.CalculateCrc16(sendData, sendData.Length - 2);
                sendData[sendData.Length - 2] = (byte)(crc >> 8);
                sendData[sendData.Length - 1] = (byte)(crc);

                byte[] revData = new byte[8];
                if (serialPort.SendCommand(sendData, ref revData, timeout) == revData.Length)
                {
                    // CRC校验
                    int revcrc = CRCHelper.CalculateCrc16(revData, revData.Length - 2);
                    if (revData[1] == 0x05 && revcrc == (revData[revData.Length - 1] + revData[revData.Length - 2] * 256))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }
        /// <summary>
        /// 重启编程器
        /// </summary>
        /// <param name="serialPort"></param>
        /// <param name="timeout"></param>
        /// <returns></returns>
        public static bool Reset(SerialPortHelper serialPort, int timeout)
        {
            try
            {
                byte[] sendData = new byte[] { 0x01, 0x05, 0x00, 0x02, 0x00, 0x01, 0x00, 0x00 };

                ushort crc = CRCHelper.CalculateCrc16(sendData, sendData.Length - 2);
                sendData[sendData.Length - 2] = (byte)(crc >> 8);
                sendData[sendData.Length - 1] = (byte)(crc);

                byte[] revData = new byte[8];
                if (serialPort.SendCommand(sendData, ref revData, timeout) == revData.Length)
                {
                    // CRC校验
                    int revcrc = CRCHelper.CalculateCrc16(revData, revData.Length - 2);
                    if (revData[1] == 0x05 && revcrc == (revData[revData.Length - 1] + revData[revData.Length - 2] * 256))
                    {
                        return true;
                    }
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
            return false;
        }

        #endregion

    }
}
