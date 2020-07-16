using Common.Common;
using Modbus.Device;
using SqlSugarManage.Models;
using System;
using System.Diagnostics;
using System.IO.Ports;
using System.Linq;
using System.Net.Sockets;
using System.Threading;
using System.Threading.Tasks;

namespace ModbusManage
{
    public class BaseModbus
    {
        private IModbusSerialMaster master=null;
        /// <summary>
        /// 初始化
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="client"></param>
        /// <returns></returns>
        public BaseModbus InstallRtu<T>(object client)
        {

            if (typeof(T) == typeof(SerialPort))
            {
                master = ModbusSerialMaster.CreateRtu((SerialPort)client);
            }
            if (typeof(T) == typeof(TcpClient))
            {
                master = ModbusSerialMaster.CreateRtu((TcpClient)client);
            }
            if (typeof(T) == typeof(UdpClient))
            {
                master = ModbusSerialMaster.CreateRtu((UdpClient)client);
            }
            if (null == master)
            {
                throw new Exception("未成功初始化 BaseModbus");
            }

            master.Transport.Retries = 0;
            master.Transport.ReadTimeout = 500;
            master.Transport.WriteTimeout = 500;

            return this;
        }

        /// <summary>
        /// 检查modbus对象是否存在
        /// </summary>
        public bool IsInstallOK
        {
            get { return master == null ? false : true; }
        }

        public BaseModbus InstallAscii<T>(object client)
        {

            if (typeof(T) == typeof(SerialPort))
            {
                master = ModbusSerialMaster.CreateAscii((SerialPort)client);
            }
            if (typeof(T) == typeof(TcpClient))
            {
                master = ModbusSerialMaster.CreateAscii((TcpClient)client);
            }
            if (typeof(T) == typeof(UdpClient))
            {
                master = ModbusSerialMaster.CreateAscii((UdpClient)client);
            }
            if (null == master)
            {
                throw new Exception("未成功初始化 BaseModbus");
            }

            return this;
        }


        /// <summary>
        /// 释放
        /// </summary>
        public void Dispose()
        {
            if (master != null)
            {
                master.Dispose();
            }
        }

        #region 此处写相关协议

        /// <summary>
        /// 读取寄存器所有数据,原始数据
        /// </summary>
        /// <param name="slaveAddress">设备地址</param>
        /// <param name="startAddress">寄存器开始地址</param>
        /// <param name="numberOfPoints">读取寄存器个数</param>
        /// <returns>返回原始数据</returns>
        public ushort[] ReadAll(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            return master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
        }
        /// <summary>
        /// 读取寄存器所有数据，并映射到结构体
        /// </summary>
        /// <param name="slaveAddress">设备地址</param>
        /// <param name="startAddress">寄存器开始地址</param>
        /// <param name="numberOfPoints">读取寄存器个数</param>
        /// <returns>返回结构体对象</returns>
        public SupPowerSetPower? ReadAllToPowerStuct(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {
            try
            {
                ushort[] udatas = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
                short[] datas = StructToShortTool.UshortsToshorts(udatas);
                return (SupPowerSetPower)StructToShortTool.ShortToStuct(datas, typeof(SupPowerSetPower));
            }
            catch (Exception ex)
            {
                //master.Dispose();
                Console.WriteLine(ex.Message);
                return null;
            }
        }
        /// <summary>
        /// 读取寄存器所有数据，并映射到结构体
        /// </summary>
        /// <param name="slaveAddress">设备地址</param>
        /// <param name="startAddress">寄存器开始地址</param>
        /// <param name="numberOfPoints">读取寄存器个数</param>
        /// <returns>返回结构体对象</returns>
        public SupPowerSetPRGMR? ReadAllToPRGMRStuct(byte slaveAddress, ushort startAddress, ushort numberOfPoints)
        {

            Debug.WriteLine("1-发送命令：" + DateTime.Now);
            ushort[] udatas = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
            Debug.WriteLine("2-发送命令：" + DateTime.Now);
            short[] datas = StructToShortTool.UshortsToshorts(udatas);
            return (SupPowerSetPRGMR)StructToShortTool.ShortToStuct(datas, typeof(SupPowerSetPRGMR));
        }
        /// <summary>
        /// 读取寄存器所有数据，并映射到结构体
        /// </summary>
        /// <param name="slaveAddress">设备地址</param>
        /// <param name="startAddress">寄存器开始地址</param>
        /// <param name="numberOfPoints">读取寄存器个数</param>
        /// <returns>返回结构体对象</returns>
        public object ReadAllToObjStuct(byte slaveAddress, ushort startAddress, ushort numberOfPoints,Type type)
        {
            try
            {
                ushort[] udatas = master.ReadHoldingRegisters(slaveAddress, startAddress, numberOfPoints);
                short[] datas = StructToShortTool.UshortsToshorts(udatas);
                return StructToShortTool.ShortToStuct(datas, type);
            }
            catch (Exception ex)
            {
                //master.Dispose();
                Console.WriteLine(ex.Message);
                return null;
            }
        }

        /// <summary>
        /// 写入全部数据到寄存器
        /// </summary>
        /// <param name="slaveAddress">设备地址</param>
        /// <param name="startAddress">寄存器开始地址</param>
        /// <param name="supPowerStruct">数据的结构体</param>
        public bool WriteAll(byte slaveAddress, ushort startAddress, object obj)
        {
            try
            {
                if (obj==null)
                {
                    return false;
                }
                short[] datas = StructToShortTool.StructToShort(obj);
                ushort[] udatas = StructToShortTool.shortsToUshorts(datas);
                Task task =  master.WriteMultipleRegistersAsync(slaveAddress, startAddress, udatas);
                Trace.WriteLine("123456");
                for (; ; )
                {
                    if (task.IsCompleted)
                    {
                        return true;
                    }
                    Thread.Sleep(100);
                }
                
            }
            catch (Exception ex)
            {
                //master.Dispose();
                Console.WriteLine(ex.Message);
                return false;
            }
        }

        #endregion
    }
}
