using System;
using System.Collections.Generic;
using System.IO.Ports;
using System.Linq;
using System.Text;

namespace Common.Common
{
    public class SerialPortHelper
    {
        public event PortDataReceivedEventHandle Received;
        public event SerialErrorReceivedEventHandler Error;
        private SerialPort port;
        public bool ReceiveEventFlag = false;  //接收事件是否有效 false表示有效

        public string PortName
        {
            get
            {
                if (Port == null) return "";
                return Port.PortName;
            }
            set
            {
                if (Port != null)
                    Port.PortName = value;
            }
        }

        public SerialPort Port { get => port; set => port = value; }

        public SerialPortHelper()
            : this("COM1", 9600, Parity.None)
        {

        }

        public SerialPortHelper(string sPortName, int baudrate, Parity parity)
        {
            Port = new SerialPort(sPortName, baudrate, parity, 8, StopBits.One);
            Port.RtsEnable = true;
            Port.ReadTimeout = 1000;
            //port.DataReceived += new SerialDataReceivedEventHandler(DataReceived);
            //port.ErrorReceived += new SerialErrorReceivedEventHandler(ErrorEvent);
        }
        public SerialPortHelper(string sPortName, int baudrate, Parity parity, int dataBits, StopBits stopBits)
            : this(sPortName, baudrate, parity)
        {
            Port.DataBits = dataBits;
            Port.StopBits = stopBits;
        }


        ~SerialPortHelper()
        {
            Close();
        }

        public bool Open()
        {
            if (!Port.IsOpen)
            {
                try
                {
                    Port.Open();
                }
                catch (Exception e)
                {

                }
            }
            return Port.IsOpen;
        }

        public void Close()
        {
            if (Port.IsOpen)
            {
                try
                {
                    Port.Close();
                    Port.Dispose();
                }
                catch (Exception e)
                {
                }
            }
        }
        /// <summary>
        /// 获取当前可用串口
        /// </summary>
        /// <param name="data"></param>
        public SerialPort GetPort()
        {
            if (Port.IsOpen)
            {
                return Port;
            }
            else
            {
                return null;
            }
        }

        //数据发送
        public void SendData(byte[] data)
        {
            if (Port.IsOpen)
            {
                Port.Write(data, 0, data.Length);
            }
        }
        public void SendData(byte[] data, int offset, int count)
        {
            if (Port.IsOpen)
            {
                Port.Write(data, offset, count);
            }
        }
        //发送命令
        //public int SendCommand(byte[] SendData, ref byte[] ReceiveData, double Overtime)
        //{

        //    if (port.IsOpen)
        //    {
        //        ReceiveEventFlag = true;        //关闭接收事件
        //        port.DiscardInBuffer();         //清空接收缓冲区                 
        //        port.Write(SendData, 0, SendData.Length);

        //        int ret = 0;
        //        int num = 0;
        //        Overtime = Overtime * 1000;
        //        DateTime start = DateTime.Now;
        //        while ((DateTime.Now - start).TotalMilliseconds < Overtime)
        //        {
        //            if (port.BytesToRead >= ReceiveData.Length) break;
        //            System.Threading.Thread.Sleep(1);
        //            num = port.BytesToRead;
        //            if(num > 0 && num != ret)
        //                break;
        //            ret = num;
        //            System.Threading.Thread.Sleep(100);
        //        }
        //        if (num > 0)
        //        {
        //            ReceiveData = new byte[num];
        //            ReceiveEventFlag = false;
        //            return port.Read(ReceiveData, 0, num);
        //        }
        //        ReceiveEventFlag = false;       //打开事件
        //    }
        //    return -1;
        //}

        //发送命令
        public int SendCommand(byte[] SendData, ref byte[] ReceiveData, int Overtime)
        {
            try
            {
                if (Port.IsOpen)
                {
                    ReceiveEventFlag = true;        //关闭接收事件
                    Port.DiscardInBuffer();         //清空接收缓冲区                 
                    Port.Write(SendData, 0, SendData.Length);
                    int num = 0, ret = 0;
                    //Overtime = Overtime * 1000;
                    TimeSpan t;
                    DateTime start = DateTime.Now;
                    t = DateTime.Now - start;
                    while (t.TotalMilliseconds < Overtime)
                    {
                        if (Port.BytesToRead >= ReceiveData.Length) break;
                        System.Threading.Thread.Sleep(1);
                        t = DateTime.Now - start;
                    }
                    //while (num++ < Overtime)
                    //{
                    //    if (port.BytesToRead >= ReceiveData.Length) break;
                    //    System.Threading.Thread.Sleep(1);
                    //}
                    if (Port.BytesToRead >= ReceiveData.Length)
                    {
                        ret = Port.Read(ReceiveData, 0, ReceiveData.Length);
                    }
                    else
                    {
                        ret = Port.Read(ReceiveData, 0, Port.BytesToRead);
                    }
                    ReceiveEventFlag = false;       //打开事件
                    return ret;
                }
                return -1;
            }
            catch (Exception e)
            {

                return -2;
            }
        }

        public void ErrorEvent(object sender, SerialErrorReceivedEventArgs e)
        {
            if (Error != null) Error(sender, e);
        }
        //数据接收
        public void DataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            //禁止接收事件时直接退出
            if (ReceiveEventFlag) return;

            byte[] data = new byte[Port.BytesToRead];
            Port.Read(data, 0, data.Length);
            if (Received != null) Received(sender, new PortDataReciveEventArgs(data));
        }

        public bool IsOpen()
        {
            return Port.IsOpen;
        }
    }
    public delegate void PortDataReceivedEventHandle(object sender, PortDataReciveEventArgs e);
    public class PortDataReciveEventArgs : EventArgs
    {
        public PortDataReciveEventArgs()
        {
            this.data = null;
        }

        public PortDataReciveEventArgs(byte[] data)
        {
            this.data = data;
        }

        private byte[] data;

        public byte[] Data
        {
            get { return data; }
            set { data = value; }
        }
    }
}
