using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SqlSugarManage.Models
{
    /// <summary>
    /// 设备通过 在线的配置模型
    /// 设备地址：1
    /// 寄存器开始地址：256
    /// 长度：95
    /// B
    /// </summary>
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SupPowerSetPower
    {
        #region 字段
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] softVersion;
        [MarshalAs(UnmanagedType.ByValArray, SizeConst = 20)]
        public byte[] productTypeName;
        /// <summary>
        /// 软件版本
        /// </summary>
        public string SoftVersion
        {
            get
            {
                if (softVersion == null)
                    return "";
                return System.Text.Encoding.ASCII.GetString(softVersion);
            }
            set
            {
                softVersion = System.Text.Encoding.ASCII.GetBytes(value.Trim());
                if (softVersion.Length > 20)
                {
                    softVersion = softVersion.Take(20).ToArray();
                }
                else if (softVersion.Length < 20)
                {
                    byte[] b = new byte[20 - softVersion.Length];
                    softVersion = softVersion.Concat(b).ToArray();
                }
            }
        }
        /// <summary>
        /// 型号名称
        /// </summary>
        public string ProductTypeName
        {
            get
            {
                if (productTypeName == null)
                    return "";
                return System.Text.Encoding.ASCII.GetString(productTypeName);
            }
            set
            {
                productTypeName = System.Text.Encoding.ASCII.GetBytes(value.Trim());
                if (productTypeName.Length > 20)
                {
                    productTypeName = productTypeName.Take(20).ToArray();
                }
                else if (productTypeName.Length < 20)
                {
                    byte[] b = new byte[20 - productTypeName.Length];
                    productTypeName = productTypeName.Concat(b).ToArray();
                }
            }
        }

        /// <summary>
        /// 软件版本
        /// A 256-265
        /// B 1024-1033
        /// </summary>
        //public ushort softVersion0;
        //public ushort softVersion1;
        //public ushort softVersion2;
        //public ushort softVersion3;
        //public ushort softVersion4;
        //public ushort softVersion5;
        //public ushort softVersion6;
        //public ushort softVersion7;
        //public ushort softVersion8;
        //public ushort softVersion9;

        /// <summary>
        /// 产品型号、名称
        /// A 266-275
        /// B 1034-1043
        /// </summary>
        //public ushort productTypeName10;
        //public ushort productTypeName11;
        //public ushort productTypeName12;
        //public ushort productTypeName13;
        //public ushort productTypeName14;
        //public ushort productTypeName15;
        //public ushort productTypeName16;
        //public ushort productTypeName17;
        //public ushort productTypeName18;
        //public ushort productTypeName19;
        /// <summary>
        /// 工作模式
        /// 0 （0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
        /// A 276
        /// B 1044
        /// </summary>
        public ushort workMode;
        /// <summary>
        /// 最大电流%
        /// 100（范围0-100）
        /// A 277
        /// B 1045
        /// </summary>
        public ushort maxCurrent;
        /// <summary>
        /// 最大电压%
        /// 100（范围0-100）
        /// A 278
        /// B 1046
        /// </summary>
        public ushort maxVoltage;
        /// <summary>
        /// 外部温度保护恢复点
        /// 80℃（0-255）
        /// A 279
        /// B 1047
        /// </summary>
        public ushort eTPRecoveryP;
        /// <summary>
        /// 外部温度保护保护点
        /// 100℃（0-255）
        /// A 280
        /// B 1048
        /// </summary>
        public ushort eTPProtectionP;
        /// <summary>
        /// 外部温度保护电流%
        /// 60%（范围0-100）
        /// A 281
        /// B 1049
        /// </summary>
        public ushort eTPCurrent;
        /// <summary>
        /// 内部温度保护恢复点
        /// 80℃（0-255）
        /// A 282
        /// B 1050
        /// </summary>
        public ushort iTPRecoveryP;
        /// <summary>
        /// 内部温度保护保护点
        /// 100℃（0-255）
        /// A 283
        /// B 1051
        /// </summary>
        public ushort iTPProtectionP;
        /// <summary>
        /// 内部温度保护电流%
        /// 60%（范围0-100）
        /// A 284
        /// B 1052
        /// </summary>
        public ushort iTPCurrent;
        /// <summary>
        /// 定时模式
        /// 0（0传统定时 1自适应定时）
        /// A 285
        /// B 1053
        /// </summary>
        public ushort timerMode;
        /// <summary>
        /// 定时个数
        /// 0（范围0-6）
        /// A 286
        /// B 1054
        /// </summary>
        public ushort timerNum;

        /// <summary>
        /// 定时参数
        /// A 287  288  289  ...304 
        /// B 1055 1056 1057 ...1072 
        /// </summary>

        /// <summary>
        /// 定时1功率%
        /// 默认值：0（范围0-100）
        /// </summary>
        public ushort timingPower1;
        /// <summary>
        /// 定时1时长min
        /// 默认值：0（范围0-65535）
        /// </summary>
        public ushort timingLength1;
        /// <summary>
        /// 定时1渐变时间min
        /// 默认值：0（范围0-60）
        /// </summary>
        public ushort timingGradientLength1;
        public ushort timingPower2;
        public ushort timingLength2;
        public ushort timingGradientLength2;
        public ushort timingPower3;
        public ushort timingLength3;
        public ushort timingGradientLength3;
        public ushort timingPower4;
        public ushort timingLength4;
        public ushort timingGradientLength4;
        public ushort timingPower5;
        public ushort timingLength5;
        public ushort timingGradientLength5;
        public ushort timingPower6;
        public ushort timingLength6;
        public ushort timingGradientLength6;
        /// <summary>
        /// 最大功率对应电压V 
        /// 1（0-10.0）小数点1位
        /// A 305
        /// B 1073
        /// </summary>
        public ushort maxPowerMapVoltage;
        /// <summary>
        /// 电流采样电阻mΩ
        /// 200（0-65535）
        /// A 306
        /// B 1074
        /// </summary>
        public ushort currentSamplingResistance;
        /// <summary>
        /// 电压采样总电阻kΩ
        /// 50（0-65535）
        /// A 307
        /// B 1075
        /// </summary>
        public ushort voltageSamplingTotalResistance;
        /// <summary>
        /// 电压采样电阻kΩ
        /// 5（0-65535）
        /// A 308
        /// B 1076
        /// </summary>
        public ushort voltageSamplingResistance;
        /// <summary>
        /// 额定功率 W
        /// 100（0-65535）
        /// A 309
        /// B 1077
        /// </summary>
        public ushort ratedPower;
        /// <summary>
        /// 额定电流 A
        /// 100(0-655.35)小数点2位
        /// A 310
        /// B 1078
        /// </summary>
        public ushort rateCurrent;
        /// <summary>
        /// 功率偏差W
        /// 1（0-65535）
        /// A 311
        /// B 1079
        /// </summary>
        public ushort powerDeviation;

        //[MarshalAs(UnmanagedType.ByValArray, SizeConst = 38)]
        //public ushort[] reserveField;
        #region 备用字段
        /// <summary>
        /// 调光比
        /// 默认值：100
        /// A 312,未定义 值为0
        /// B 1080
        /// </summary>
        public ushort dimRatio; 
        public ushort reserveField2;
        public ushort reserveField3;
        public ushort reserveField4;
        public ushort reserveField5;
        public ushort reserveField6;
        //public ushort reserveField7;
        //public ushort reserveField8;
        //public ushort reserveField9;
        //public ushort reserveField10;
        //public ushort reserveField11;
        //public ushort reserveField12;
        //public ushort reserveField13;
        //public ushort reserveField14;
        //public ushort reserveField15;
        //public ushort reserveField16;
        //public ushort reserveField17;
        //public ushort reserveField18;
        //public ushort reserveField19;
        //public ushort reserveField20;
        //public ushort reserveField21;
        //public ushort reserveField22;
        //public ushort reserveField23;
        //public ushort reserveField24;
        //public ushort reserveField25;
        //public ushort reserveField26;
        //public ushort reserveField27;
        //public ushort reserveField28;
        //public ushort reserveField29;
        //public ushort reserveField30;
        //public ushort reserveField31;
        //public ushort reserveField32;
        //public ushort reserveField33;
        //public ushort reserveField34;
        //public ushort reserveField35;
        //public ushort reserveField36;
        //public ushort reserveField37;
        //public ushort reserveField38;
        //public ushort reserveField39;
        #endregion
        #endregion

        /// <summary>
        /// 带参数的构造函数
        /// </summary>
        /// <param name="data"></param>
        //public SupPowerSetPRGMR(ushort[] data)
        //{
        //    //this.softVersion = new byte[20];
        //    //this.productTypeName = new byte[20];

        //    //this.workMode = data[20];
        //    //this.maxCurrent = data[21];
        //    //this.maxVoltage = data[22];
        //    //this.eTPRecoveryP = data[23];
        //    //this.eTPProtectionP = data[24];
        //    //this.eTPCurrent = data[25];
        //    //this.iTPRecoveryP = data[26];
        //    //this.iTPProtectionP = data[27];
        //    //this.iTPCurrent = data[28];
        //    //this.timerMode = data[29];
        //    //this.timerNum = data[30];

        //    //this.timingPower1 = data[31];
        //    //this.timingLength1 = data[32];
        //    //this.timingGradientLength1 = data[33];
        //    //this.timingPower2 = data[34];
        //    //this.timingLength2 = data[35];
        //    //this.timingGradientLength2 = data[36];
        //    //this.timingPower3 = data[37];
        //    //this.timingLength3 = data[38];
        //    //this.timingGradientLength3 = data[39];
        //    //this.timingPower4 = data[40];
        //    //this.timingLength4 = data[41];
        //    //this.timingGradientLength4 = data[42];
        //    //this.timingPower5 = data[43];
        //    //this.timingLength5 = data[44];
        //    //this.timingGradientLength5 = data[45];
        //    //this.timingPower6 = data[46];
        //    //this.timingLength6 = data[47];
        //    //this.timingGradientLength6 = data[48];

        //    //this.maxPowerMapVoltage = data[49];
        //    //this.currentSamplingResistance = data[50];
        //    //this.voltageSamplingTotalResistance = data[51];
        //    //this.voltageSamplingResistance = data[52];
        //    //this.ratedPower = data[53];
        //    //this.rateCurrent = data[54];
        //    //this.powerDeviation = data[55];

        //    //this.reserveField1 = data[56];
        //    //this.reserveField2 = data[57];
        //    //this.reserveField3 = data[58];
        //    //this.reserveField4 = data[59];
        //    //this.reserveField5 = data[60];
        //    //this.reserveField6 = data[61];
        //    //this.reserveField7 = data[62];
        //    //this.reserveField8 = data[63];
        //    //this.reserveField9 = data[64];
        //    //this.reserveField10 = data[65];
        //    //this.reserveField11 = data[66];
        //    //this.reserveField12 = data[67];
        //    //this.reserveField13 = data[68];
        //    //this.reserveField14 = data[69];
        //    //this.reserveField15 = data[70];
        //    //this.reserveField16 = data[71];
        //    //this.reserveField17 = data[72];
        //    //this.reserveField18 = data[73];
        //    //this.reserveField19 = data[74];
        //    //this.reserveField20 = data[75];
        //    //this.reserveField21 = data[76];
        //    //this.reserveField22 = data[77];
        //    //this.reserveField23 = data[78];
        //    //this.reserveField24 = data[79];
        //    //this.reserveField25 = data[80];
        //    //this.reserveField26 = data[81];
        //    //this.reserveField27 = data[82];
        //    //this.reserveField28 = data[83];
        //    //this.reserveField29 = data[84];
        //    //this.reserveField30 = data[85];
        //    //this.reserveField31 = data[86];
        //    //this.reserveField32 = data[87];
        //    //this.reserveField33 = data[88];
        //    //this.reserveField34 = data[89];
        //    //this.reserveField35 = data[90];
        //    //this.reserveField36 = data[91];
        //    //this.reserveField37 = data[92];
        //    //this.reserveField38 = data[93];
        //    //this.reserveField39 = data[94];
        //}

    }
}
