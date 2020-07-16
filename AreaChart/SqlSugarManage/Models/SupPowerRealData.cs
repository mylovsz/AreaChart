using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;

namespace SqlSugarManage.Models
{
    [StructLayoutAttribute(LayoutKind.Sequential, CharSet = CharSet.Ansi, Pack = 1)]
    public struct SupPowerRealData
    {
        public ushort Voltage;
        public ushort Current;
        public ushort FaultCode;
        public ushort InTemp;
        public ushort OutTemp;
        public ushort RunTimesH;
        public ushort RunTimesL;
        public ushort RunTimeH;
        public ushort RunTimeL;

        public ushort LastRunTimeH;
        public ushort LastRunTimeL;
        public ushort LastLastRunTimeH;
        public ushort LastLastRunTimeL;

        public UInt32 RunTimes
        {
            get
            {
                return RunTimesH * (UInt32)65536 + RunTimesL;
            }
        }
        public UInt32 RunTime
        {
            get
            {
                return RunTimeH * (UInt32)65536 + RunTimeL;
            }
        }

        public UInt32 LastRunTime
        {
            get
            {
                return LastRunTimeH * (UInt32)65536 + LastRunTimeL;
            }
        }
        public UInt32 LastLastRunTime
        {
            get
            {
                return LastLastRunTimeH * (UInt32)65536 + LastLastRunTimeL;
            }
        }
    }
}
