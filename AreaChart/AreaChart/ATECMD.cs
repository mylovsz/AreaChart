using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AreaChart
{
    /// <summary>
    /// ATE通讯协议
    /// </summary>
    public class ATECMD
    {


        private static string State(byte[] revdata)
        {
            string msg;
            if (revdata[5] == 1)//成功
            {
                msg = "成功";
            }
            else//失败
            {
                msg = "失败";
            }
            return msg;
        }
        /// <summary>
        /// 数据处理
        /// </summary>
        /// <returns></returns>
        public static string DealData(byte[] revdata)
        {
            string msg=null;
            switch (revdata[1])
            {
                case 2://模式设置回复
                    msg = "模式设置回复: " + State(revdata);
                    break;
                case 4:
                    msg = "电压校准回复: " + State(revdata);
                    break;
                case 6:
                    msg = "电流校准回复: " + State(revdata);
                    break;
                case 10:
                    msg = "保存校准回复: " + State(revdata);
                    break;
                case 12:
                    msg = "调光回复: " + State(revdata);
                    break;
            }
            return msg; 
        }

        

        /// <summary>
        /// 和校验
        /// </summary>
        /// <param name="buf">数组</param>
        /// <returns></returns>
        private static byte sum(byte[] buf, byte num)
        {
            byte i = 0, j = 0;
            for (i = 0; i < num; i++)
            {
                j = (byte)(j + buf[i]);
            }
            return j;
        }
        
        /// <summary>
        /// 模式设置
        /// </summary>
        /// <param name="index">模式索引值</param>
        /// <returns></returns>
        public static byte[] SetMode(int index)
        {
            byte[] buf = new byte[7];
            buf[0] = 0xAA;
            buf[1] = 0x01;
            buf[2] = 0x00;
            buf[3] = 1;
            buf[4] = 0xAA;
            buf[5] = (byte)index;
            buf[6] = sum(buf, 6);
            return buf;
        }

        /// <summary>
        /// 设置调光值
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] SetDimVal(string val)
        {
            byte[] buf = new byte[7];
            buf[0] = 0xAA;
            buf[1] = 11;
            buf[2] = 0x00;
            buf[3] = 01;
            buf[4] = 0xaa;
            buf[5] = byte.Parse(val);
            buf[6] = sum(buf, 6);
            return buf;
        }

        /// <summary>
        /// 校准值保存
        /// </summary>
        /// <returns></returns>
        public static byte[] SaveVal()
        {
            byte[] buf = new byte[6];
            buf[0] = 0xAA;
            buf[1] = 0x09;
            buf[2] = 0x00;
            buf[3] = 0x00;
            buf[4] = 0xAA;
            buf[5] = sum(buf, 5);
            return buf;
        }

        #region 电压环校准
        /// <summary>
        /// 电压环向上校准
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] VOUp(string val)
        {
            byte[] buf = new byte[8];
            buf[0] = 0xAA;
            buf[1] = 0x03;
            buf[2] = 0x00;
            buf[3] = 0x02;
            buf[4] = 0xAA;
            buf[5] = 0x01;
            buf[6] = (byte)(double.Parse(val));
            buf[7] = sum(buf, 7);
            return buf;
        }

        /// <summary>
        /// 电压环向下校准
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] VODown(string val)
        {
            byte[] buf = new byte[8];
            buf[0] = 0xAA;
            buf[1] = 0x03;
            buf[2] = 0x00;
            buf[3] = 0x02;
            buf[4] = 0xAA;
            buf[5] = 0x00;
            buf[6] = (byte)(double.Parse(val));
            buf[7] = sum(buf, 7);
            return buf;
        }
        #endregion

        #region 电流环校准
        /// <summary>
        /// 电流环向上校准
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] IOUp(string val)
        {
            byte[] buf = new byte[8];
            buf[0] = 0xAA;
            buf[1] = 0x05;
            buf[2] = 0x00;
            buf[3] = 0x02;
            buf[4] = 0xAA;
            buf[5] = 0x01;
            buf[6] = (byte)(double.Parse(val));
            buf[7] = sum(buf, 7);
            return buf;
        }

        /// <summary>
        /// 电流环向下校准
        /// </summary>
        /// <param name="val"></param>
        /// <returns></returns>
        public static byte[] IODown(string val)
        {
            byte[] buf = new byte[8];
            buf[0] = 0xAA;
            buf[1] = 0x05;
            buf[2] = 0x00;
            buf[3] = 0x02;
            buf[4] = 0xAA;
            buf[5] = 0x00;
            buf[6] = (byte)(double.Parse(val));
            buf[7] = sum(buf, 7);
            return buf;
        }
        #endregion

        /// <summary>
        /// 读取K值
        /// </summary>
        /// <returns></returns>
        public static byte[] KGetVal()
        {
            byte[] buf = new byte[10];
            buf[0] = 0xAA;
            buf[1] = 0x07;
            buf[2] = 0x00;
            buf[3] = 0x04;
            buf[4] = 0xAA;
            buf[5] = 0x00;
            buf[6] = 0x00;
            buf[7] = 0x00;
            buf[8] = 0x00;
            buf[9] = sum(buf, 9);
            return buf;
        }

        /// <summary>
        /// 设置K值
        /// </summary>
        /// <param name="Vnow">实际电压</param>
        /// <param name="Inow">实际电流</param>
        /// <param name="Know">电压K</param>
        /// <param name="Vdir">校准电压</param>
        /// <param name="Idir">校准电流</param>
        /// <param name="Kdir">电流K</param>
        /// <returns></returns>
        public static byte[] KSetVal(string Vnow,string Inow,string Kv,string Vdir,string Idir,string Ki)
        {
            byte[] buf = new byte[10];
            uint V = 0, I = 0, i = 0, u = 0, ki = 0, kv = 0;
            V = uint.Parse(Vnow);
            I = Convert.ToUInt16(double.Parse(Inow) * 1000.0);
            u = uint.Parse(Vdir);
            i = Convert.ToUInt16(double.Parse(Idir) * 1000.0);
            kv = uint.Parse(Kv);
            ki = uint.Parse(Ki);
            ki = ki * i / I;
            kv = kv * u / V;
            buf[0] = 0xAA;
            buf[1] = 0x07;
            buf[2] = 0x00;
            buf[3] = 0x04;
            buf[4] = 0xAA;
            buf[5] = (byte)(kv >> 8);
            buf[6] = (byte)kv;
            buf[7] = (byte)(ki >> 8);
            buf[8] = (byte)ki;
            buf[9] = sum(buf, 9);
            return buf;
        }
    }
}
