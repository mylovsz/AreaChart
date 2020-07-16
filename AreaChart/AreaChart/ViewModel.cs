using SqlSugarManage.Models;
using System;

namespace AreaChart
{
    /// <summary>
    /// 界面数据与协议数据处理
    /// </summary>
    [Serializable]
    public class ViewModel
    {
        /// <summary>
        /// 界面模型
        /// </summary>
        public SupPowerModel SupPowerModel
        {
            get
            {
                return supPowerModel;
            }
            set
            {
                supPowerModel = value;
                viewPowerOutputCurrent = null;
                viewPRGMROutputCurrent = null;
                viewPowerOutputVoltageMax = null;
                viewPRGMROutputVoltageMax = null;
            }
        }
        public SupPowerModel supPowerModel;

        /// <summary>
        /// 当前设备类型
        /// true：电源
        /// false：编程器
        /// </summary>
        public bool IsPower;

        /// <summary>
        /// 编程数据相关
        /// </summary>
        public SupPowerSetPRGMR PRGMR;

        /// <summary>
        /// 电源数据相关
        /// </summary>
        public SupPowerSetPower Power;

        public string SoftVersion
        {
            get
            {
                if(IsPower)
                {
                    return Power.SoftVersion;
                }
                else
                {
                    return PRGMR.SoftVersion;
                }
            }
            set
            {
                if (IsPower)
                {
                    Power.SoftVersion = value;
                }
                else
                {
                    PRGMR.SoftVersion = value;
                }
            }
        }

        public string ProductTypeName
        {
            get
            {
                if (IsPower)
                {
                    return Power.ProductTypeName;
                }
                else
                {
                    return PRGMR.ProductTypeName;
                }
            }
            set
            {
                if (IsPower)
                {
                    Power.ProductTypeName = value;
                }
                else
                {
                    PRGMR.ProductTypeName = value;
                }
            }
        }

        /// <summary>
        /// 将数据库存储的默认值，初始化到模型的数据中
        /// </summary>
        public void InitDefault()
        {

            //if (IsPower)
            {
                if(SupPowerModel != null)
                    Power = SupPowerModel.GetConfigPower();
            }
            //else
            {
                if (SupPowerModel != null)
                    PRGMR = SupPowerModel.GetConfigPRGMR();
            }
            Init();
        }
        /// <summary>
        /// 将从编程器读取的数据，初始化到模型
        /// </summary>
        /// <param name="prgmr"></param>
        public void InitDefaultPRGMR(SupPowerSetPRGMR prgmr)
        {
            PRGMR = prgmr;
            viewPowerOutputCurrent = null;
            viewPRGMROutputCurrent = null;
            viewPowerOutputVoltageMax = null;
            viewPRGMROutputVoltageMax = null;
            Init();
        }
        /// <summary>
        /// 将从电源读取的数据，初始化到模型
        /// </summary>
        /// <param name="prgmr"></param>
        public void InitDefaultPower(SupPowerSetPower prgmr)
        {
            Power = prgmr;

            Init();
        }

        /// <summary>
        /// 将结构体中的实际参数，与界面绑定的数据进行同步
        /// </summary>
        void Init()
        {
            viewPowerOutputCurrent = null;
            viewPRGMROutputCurrent = null;
            viewPowerOutputVoltageMax = null;
            viewPRGMROutputVoltageMax = null;

            if (SupPowerModel != null)
            {
                SupPowerModelData spmd = SupPowerModel.GetData();
                // 温度
                spmd.supPowerModelDataTemp.IoutProtect = ViewInTempProtection;
                spmd.supPowerModelDataTemp.IprotectCurrent = ViewInTempCurrent;
                spmd.supPowerModelDataTemp.Irecover = ViewInTempRecover;

                spmd.supPowerModelDataTemp.OoutProtect = ViewOutTempProtection;
                spmd.supPowerModelDataTemp.OprotectCurrent = ViewOutTempCurrent;
                spmd.supPowerModelDataTemp.Orecover = ViewOutTempRecover;

                // 输出电流
                spmd.supPowerModelOutCurrent.OutputCurrent = ViewOutputCurrent;

                // 时控
                //保持
                spmd.supPowerModelDataTimeCtrl.hold1 = TimeCtrlArgs1.Hold;
                spmd.supPowerModelDataTimeCtrl.hold2 = TimeCtrlArgs2.Hold;
                spmd.supPowerModelDataTimeCtrl.hold3 = TimeCtrlArgs3.Hold;
                spmd.supPowerModelDataTimeCtrl.hold4 = TimeCtrlArgs4.Hold;
                spmd.supPowerModelDataTimeCtrl.hold5 = TimeCtrlArgs5.Hold;
                spmd.supPowerModelDataTimeCtrl.hold6 = TimeCtrlArgs6.Hold;
                //渐变              
                spmd.supPowerModelDataTimeCtrl.tran1 = TimeCtrlArgs1.Tran;
                spmd.supPowerModelDataTimeCtrl.tran2 = TimeCtrlArgs2.Tran;
                spmd.supPowerModelDataTimeCtrl.tran3 = TimeCtrlArgs3.Tran;
                spmd.supPowerModelDataTimeCtrl.tran4 = TimeCtrlArgs4.Tran;
                spmd.supPowerModelDataTimeCtrl.tran5 = TimeCtrlArgs5.Tran;
                spmd.supPowerModelDataTimeCtrl.tran6 = TimeCtrlArgs6.Tran;
                //功率              
                spmd.supPowerModelDataTimeCtrl.level1 = TimeCtrlArgs1.Level;
                spmd.supPowerModelDataTimeCtrl.level2 = TimeCtrlArgs2.Level;
                spmd.supPowerModelDataTimeCtrl.level3 = TimeCtrlArgs3.Level;
                spmd.supPowerModelDataTimeCtrl.level4 = TimeCtrlArgs4.Level;
                spmd.supPowerModelDataTimeCtrl.level5 = TimeCtrlArgs5.Level;
                spmd.supPowerModelDataTimeCtrl.level6 = TimeCtrlArgs6.Level;
                // 模式
                spmd.supPowerModelDataTimeCtrl.TimeCtrlMode = TimeCtrlMode;
            }
        }


        #region 模式设置
        /// <summary>
        /// 获取或设置工作模式，定时、0-10v
        /// </summary>
        public ushort ViewWorkMode
        {
            get
            {
                if (IsPower)
                {
                    return Power.workMode;
                }
                else
                {
                    return PRGMR.workMode;
                }
            }
            set
            {
                if (IsPower)
                {
                    Power.workMode = value;
                }
                else
                {
                    PRGMR.workMode = value;
                }
            }
        }
        #endregion

        #region 输出电流相关
        double? viewPowerOutputCurrent = null;
        double? viewPRGMROutputCurrent = null;
        /// <summary>
        /// 获取或设置当前可控输出电流
        /// </summary>
        public double ViewOutputCurrent
        {
            get
            {
                if (IsPower)
                {
                    if (SupPowerModel != null)
                    {
                        if(viewPowerOutputCurrent == null)
                            viewPowerOutputCurrent = Power.maxCurrent / 100.0 * SupPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax;
                        //return a;
                        if (viewPowerOutputCurrent < supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMin)
                            return supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMin;
                        if (viewPowerOutputCurrent > supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax)
                            return supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax;
                        return (double)viewPowerOutputCurrent;
                    }
                }
                else
                {
                    if (SupPowerModel != null)
                    {
                        if(viewPRGMROutputCurrent == null)
                            viewPRGMROutputCurrent = PRGMR.maxCurrent / 100.0 * SupPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax;
                        //return a;
                        if (viewPRGMROutputCurrent < supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMin)
                            return supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMin;
                        if (viewPRGMROutputCurrent > supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax)
                            return supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax;
                        return (double)viewPRGMROutputCurrent;
                    }
                }

                return 0;
            }
            set
            {
                if (IsPower)
                {
                    if (SupPowerModel != null)
                    {
                        viewPowerOutputCurrent = value;
                        if (viewPowerOutputCurrent < supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMin)
                            viewPowerOutputCurrent = supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMin;
                        if (viewPowerOutputCurrent > supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax)
                            viewPowerOutputCurrent = supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax;
                        Power.maxCurrent = (ushort)Math.Round(((double)viewPowerOutputCurrent / SupPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax * 100));
                    }
                }
                else
                {
                    if (SupPowerModel != null)
                    {
                        viewPRGMROutputCurrent = value;
                        if (viewPRGMROutputCurrent < supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMin)
                            viewPRGMROutputCurrent = supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMin;
                        if (viewPRGMROutputCurrent > supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax)
                            viewPRGMROutputCurrent = supPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax;
                        PRGMR.maxCurrent = (ushort)Math.Round(((double)viewPRGMROutputCurrent / SupPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax * 100));
                    }
                }
            }
        }
        /// <summary>
        /// 最大输出电流
        /// </summary>
        public double ViewOutputCurrentMax
        {
            get
            {
                if (SupPowerModel != null)
                {
                    return SupPowerModel.GetData().supPowerModelOutCurrent.OutputCurrentMax;
                }
                return 0;
            }
        }

        double? viewPowerOutputVoltageMax = null;
        double? viewPRGMROutputVoltageMax = null;
        /// <summary>
        /// 最大输出电压
        /// </summary>
        public double ViewOutputVoltageMax
        {
            get
            {
                if (IsPower)
                {
                    if (SupPowerModel != null)
                    {
                        if(viewPowerOutputVoltageMax == null)
                            viewPowerOutputVoltageMax = Power.maxVoltage / 100.0 * SupPowerModel.GetData().supPowerModelOutCurrent.OutputVoltageMax;
                        //return a;
                        return (double)viewPowerOutputVoltageMax;
                    }
                }
                else
                {
                    if (SupPowerModel != null)
                    {
                        if(viewPRGMROutputVoltageMax == null)
                            viewPRGMROutputVoltageMax = PRGMR.maxVoltage / 100.0 * SupPowerModel.GetData().supPowerModelOutCurrent.OutputVoltageMax;
                        //return a;
                        return (double)viewPRGMROutputVoltageMax;
                    }
                }

                return 0;
            }
            set
            {
                if (IsPower)
                {
                    if (SupPowerModel != null)
                    {
                        viewPowerOutputVoltageMax = value;
                        Power.maxVoltage = (ushort)Math.Round((value / SupPowerModel.GetData().supPowerModelOutCurrent.OutputVoltageMax * 100));
                    }
                }
                else
                {
                    if (SupPowerModel != null)
                    {
                        viewPRGMROutputVoltageMax = value;
                        PRGMR.maxVoltage = (ushort)Math.Round(value / SupPowerModel.GetData().supPowerModelOutCurrent.OutputVoltageMax * 100);
                    }
                }
            }
        }
        /// <summary>
        /// 最小输出电压
        /// </summary>
        public double ViewOutputVoltageMin
        {
            get
            {
                if (SupPowerModel != null)
                {
                    return SupPowerModel.GetData().supPowerModelOutCurrent.OutputVoltageMin;
                }
                return 0;
            }
        }


        #endregion

        #region 温度保护相关
        public void ViewInitInTempDefault()
        {
            supPowerModel.InitInTempDefault();

            ViewInTempCurrent = supPowerModel.GetData().supPowerModelDataTemp.IprotectCurrent;
            ViewInTempProtection = supPowerModel.GetData().supPowerModelDataTemp.IoutProtect;
            ViewInTempRecover = supPowerModel.GetData().supPowerModelDataTemp.Irecover;
        }
        public void ViewInitOutTempDefault()
        {
            supPowerModel.InitOutTempDefault();

            ViewOutTempCurrent = supPowerModel.GetData().supPowerModelDataTemp.OprotectCurrent;
            ViewOutTempProtection = supPowerModel.GetData().supPowerModelDataTemp.OoutProtect;
            ViewOutTempRecover = supPowerModel.GetData().supPowerModelDataTemp.Orecover;
        }
        /// <summary>
        /// 获取或设置外部温度恢复点
        /// </summary>
        public double ViewOutTempRecover
        {
            get
            {
                if (IsPower)
                {
                    return Power.eTPRecoveryP;
                }
                else
                {
                    return PRGMR.eTPRecoveryP;
                }
            }
            set
            {
                if (IsPower)
                {

                    Power.eTPRecoveryP = (ushort)(value);
                }
                else
                {
                    PRGMR.eTPRecoveryP = (ushort)(value);
                }

                SupPowerModel.GetData().supPowerModelDataTemp.Orecover = value;
            }
        }
        /// <summary>
        /// 获取或设置外部温度保护点
        /// </summary>
        public double ViewOutTempProtection
        {
            get
            {
                if (IsPower)
                {
                    return Power.eTPProtectionP;
                }
                else
                {
                    return PRGMR.eTPProtectionP;
                }
            }
            set
            {
                if (IsPower)
                {

                    Power.eTPProtectionP = (ushort)(value);
                }
                else
                {
                    PRGMR.eTPProtectionP = (ushort)(value);
                }

                SupPowerModel.GetData().supPowerModelDataTemp.OoutProtect = value;
            }
        }
        /// <summary>
        /// 获取或设置外部温度电流值
        /// </summary>
        public double ViewOutTempCurrent
        {
            get
            {
                if (IsPower)
                {
                    return Power.eTPCurrent;
                }
                else
                {
                    return PRGMR.eTPCurrent;
                }
            }
            set
            {
                if (IsPower)
                {

                    Power.eTPCurrent = (ushort)(value);
                }
                else
                {
                    PRGMR.eTPCurrent = (ushort)(value);
                }

                SupPowerModel.GetData().supPowerModelDataTemp.OprotectCurrent = value;
            }
        }
        /// <summary>
        /// 获取或设置内部温度恢复点
        /// </summary>
        public double ViewInTempRecover
        {
            get
            {
                if (IsPower)
                {
                    return Power.iTPRecoveryP;
                }
                else
                {
                    return PRGMR.iTPRecoveryP;
                }
            }
            set
            {
                if (IsPower)
                {

                    Power.iTPRecoveryP = (ushort)(value);
                }
                else
                {
                    PRGMR.iTPRecoveryP = (ushort)(value);
                }
                SupPowerModel.GetData().supPowerModelDataTemp.Irecover = value;
            }
        }
        /// <summary>
        /// 获取或设置内部温度保护点
        /// </summary>
        public double ViewInTempProtection
        {
            get
            {
                if (IsPower)
                {
                    return Power.iTPProtectionP;
                }
                else
                {
                    return PRGMR.iTPProtectionP;
                }
            }
            set
            {
                if (IsPower)
                {

                    Power.iTPProtectionP = (ushort)(value);
                }
                else
                {
                    PRGMR.iTPProtectionP = (ushort)(value);
                }
                SupPowerModel.GetData().supPowerModelDataTemp.IoutProtect = value;
            }
        }
        /// <summary>
        /// 获取或设置内部温度电流值
        /// </summary>
        public double ViewInTempCurrent
        {
            get
            {
                if (IsPower)
                {
                    return Power.iTPCurrent;
                }
                else
                {
                    return PRGMR.iTPCurrent;
                }
            }
            set
            {
                if (IsPower)
                {

                    Power.iTPCurrent = (ushort)(value);
                }
                else
                {
                    PRGMR.iTPCurrent = (ushort)(value);
                }
                SupPowerModel.GetData().supPowerModelDataTemp.IprotectCurrent = value;
            }
        }

        #endregion

        #region 定时控制
        /// <summary>
        /// 获取或设置定时控制模式，标准模式，自适应模式
        /// </summary>
        public ushort TimeCtrlMode
        {
            get
            {
                if (IsPower)
                {
                    return Power.timerMode;
                }
                else
                {
                    return PRGMR.timerMode;
                }
            }
            set
            {
                if (IsPower)
                {

                    Power.timerMode = (ushort)(value);
                }
                else
                {
                    PRGMR.timerMode = (ushort)(value);
                }

                SupPowerModel.GetData().supPowerModelDataTimeCtrl.TimeCtrlMode = value;
            }
        }
        /// <summary>
        /// 获取或设置定时1的参数
        /// </summary>
        public TimeCtrlArg TimeCtrlArgs1
        {
            get
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 1;
                    tca.Level = Power.timingPower1;
                    tca.Tran = Power.timingGradientLength1;
                    tca.Hold = Power.timingLength1;
                    return tca;
                }
                else
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 1;
                    tca.Level = PRGMR.timingPower1;
                    tca.Tran = PRGMR.timingGradientLength1;
                    tca.Hold = PRGMR.timingLength1;
                    return tca;
                }
            }
            set
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    Power.timingPower1 = tca.Level;
                    Power.timingGradientLength1 = tca.Tran;
                    Power.timingLength1 = tca.Hold;
                }
                else
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    PRGMR.timingPower1 = tca.Level;
                    PRGMR.timingGradientLength1 = tca.Tran;
                    PRGMR.timingLength1 = tca.Hold;
                }
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.hold1 = value.Hold;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.level1 = value.Level;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.tran1 = value.Tran;
            }
        }
        /// <summary>
        /// 获取或设置定时2的参数
        /// </summary>
        public TimeCtrlArg TimeCtrlArgs2
        {
            get
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 2;
                    tca.Level = Power.timingPower2;
                    tca.Tran = Power.timingGradientLength2;
                    tca.Hold = Power.timingLength2;
                    return tca;
                }
                else
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 2;
                    tca.Level = PRGMR.timingPower2;
                    tca.Tran = PRGMR.timingGradientLength2;
                    tca.Hold = PRGMR.timingLength2;
                    return tca;
                }
            }
            set
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    Power.timingPower2 = tca.Level;
                    Power.timingGradientLength2 = tca.Tran;
                    Power.timingLength2 = tca.Hold;
                }
                else
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    PRGMR.timingPower2 = tca.Level;
                    PRGMR.timingGradientLength2 = tca.Tran;
                    PRGMR.timingLength2 = tca.Hold;
                }
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.hold2 = value.Hold;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.level2 = value.Level;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.tran2 = value.Tran;
            }
        }
        /// <summary>
        /// 获取或设置定时3的参数
        /// </summary>
        public TimeCtrlArg TimeCtrlArgs3
        {
            get
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 3;
                    tca.Level = Power.timingPower3;
                    tca.Tran = Power.timingGradientLength3;
                    tca.Hold = Power.timingLength3;
                    return tca;
                }
                else
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 3;
                    tca.Level = PRGMR.timingPower3;
                    tca.Tran = PRGMR.timingGradientLength3;
                    tca.Hold = PRGMR.timingLength3;
                    return tca;
                }
            }
            set
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    Power.timingPower3 = tca.Level;
                    Power.timingGradientLength3 = tca.Tran;
                    Power.timingLength3 = tca.Hold;
                }
                else
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    PRGMR.timingPower3 = tca.Level;
                    PRGMR.timingGradientLength3 = tca.Tran;
                    PRGMR.timingLength3 = tca.Hold;
                }
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.hold3 = value.Hold;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.level3 = value.Level;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.tran3 = value.Tran;
            }
        }
        /// <summary>
        /// 获取或设置定时4的参数
        /// </summary>
        public TimeCtrlArg TimeCtrlArgs4
        {
            get
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 4;
                    tca.Level = Power.timingPower4;
                    tca.Tran = Power.timingGradientLength4;
                    tca.Hold = Power.timingLength4;
                    return tca;
                }
                else
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 4;
                    tca.Level = PRGMR.timingPower4;
                    tca.Tran = PRGMR.timingGradientLength4;
                    tca.Hold = PRGMR.timingLength4;
                    return tca;
                }
            }
            set
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    Power.timingPower4 = tca.Level;
                    Power.timingGradientLength4 = tca.Tran;
                    Power.timingLength4 = tca.Hold;
                }
                else
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    PRGMR.timingPower4 = tca.Level;
                    PRGMR.timingGradientLength4 = tca.Tran;
                    PRGMR.timingLength4 = tca.Hold;
                }
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.hold4 = value.Hold;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.level4 = value.Level;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.tran4 = value.Tran;
            }
        }
        /// <summary>
        /// 获取或设置定时5的参数
        /// </summary>
        public TimeCtrlArg TimeCtrlArgs5
        {
            get
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 5;
                    tca.Level = Power.timingPower5;
                    tca.Tran = Power.timingGradientLength5;
                    tca.Hold = Power.timingLength5;
                    return tca;
                }
                else
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 5;
                    tca.Level = PRGMR.timingPower5;
                    tca.Tran = PRGMR.timingGradientLength5;
                    tca.Hold = PRGMR.timingLength5;
                    return tca;
                }
            }
            set
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    Power.timingPower5 = tca.Level;
                    Power.timingGradientLength5 = tca.Tran;
                    Power.timingLength5 = tca.Hold;
                }
                else
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    PRGMR.timingPower5 = tca.Level;
                    PRGMR.timingGradientLength5 = tca.Tran;
                    PRGMR.timingLength5 = tca.Hold;
                }
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.hold5 = value.Hold;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.level5 = value.Level;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.tran5 = value.Tran;
            }
        }
        /// <summary>
        /// 获取或设置定时6的参数
        /// </summary>
        public TimeCtrlArg TimeCtrlArgs6
        {
            get
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 6;
                    tca.Level = Power.timingPower6;
                    tca.Tran = Power.timingGradientLength6;
                    tca.Hold = Power.timingLength6;
                    return tca;
                }
                else
                {
                    TimeCtrlArg tca = new TimeCtrlArg();
                    tca.ID = 6;
                    tca.Level = PRGMR.timingPower6;
                    tca.Tran = PRGMR.timingGradientLength6;
                    tca.Hold = PRGMR.timingLength6;
                    return tca;
                }
            }
            set
            {
                if (IsPower)
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    Power.timingPower6 = tca.Level;
                    Power.timingGradientLength6 = tca.Tran;
                    Power.timingLength6 = tca.Hold;
                }
                else
                {
                    TimeCtrlArg tca = (TimeCtrlArg)value;
                    PRGMR.timingPower6 = tca.Level;
                    PRGMR.timingGradientLength6 = tca.Tran;
                    PRGMR.timingLength6 = tca.Hold;
                }
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.hold6 = value.Hold;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.level6 = value.Level;
                SupPowerModel.GetData().supPowerModelDataTimeCtrl.tran6 = value.Tran;
            }
        }

        #endregion
    }
    public class TimeCtrlArg
    {
        public ushort ID;
        public ushort Hold;
        public ushort Tran;
        public ushort Level;
    }
}

