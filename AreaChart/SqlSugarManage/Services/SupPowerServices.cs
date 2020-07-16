using SqlSugarManage.Models;
using System;
using System.Collections.Generic;

namespace SqlSugarManage.Services
{
    public class SupPowerServices : BaseServices
    {
        public List<SupPowerSeries> GetAllSupPowerSeries()
        {
            return dao._Db.Queryable<SupPowerSeries>().ToList();
        }

        public SupPowerModel GetSupPowerModelByGuid(string guid)
        {
            return dao._Db.Queryable<SupPowerModel>().First(a => a.Guid == guid);
        }

        public List<SupPowerModel> GetAllSupPowerModelBySeriesGuid(string guid)
        {
            return dao._Db.Queryable<SupPowerModel>().Where(a => a.SupPowerSeriesGuid == guid).ToList();
        }

        public static List<SupPowerSeries> InitDB()
        {
            List<SupPowerSeries> list = new List<SupPowerSeries>();
            SupPowerSeries sps = null;
            SupPowerModel spm = null;

            #region HID


            #region 初始化LDC320系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDC320";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            #region LDC320U280
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC320U280HU001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 2.8;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 143;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 57;
                spmd.supPowerModelOutCurrent.OutputPower = 320.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 2.8;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 3.5;
                        cs.Grid.YMax = 160;
                        cs.Grid.XInterval = 0.5;//网格间隔
                        cs.Grid.YInterval = 40;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            CreateMode(sps, spm, "LDC320T028HE001", 2.8, 143, 57, 320, 3, 150, 0.6, 30, "P", 0.6);
            CreateMode(sps, spm, "LDC320T280HU001", 2.8, 114, 68, 320, 3, 120, 0.6, 30, "P", 0.6);

            CreateMode(sps, spm, "LDC320S190HU001", 1.9, 165, 150, 313.5, 2.5, 180, 0.5, 36, "P", 0.91);
            list.Add(sps);
            #endregion

            #region 初始化LDP400系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP400";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            CreateMode(sps, spm, "LDP400I024PE101", 16.7, 24, 12, 400, 18, 25, 3, 5, "P", 0.6);
            CreateMode(sps, spm, "LDP400I210PE101", 2.1, 286, 152, 400, 2.5, 300, 0.5, 60, "P", 0.8);

            list.Add(sps);
            #endregion

            #region 初始化LDP480系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP480";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            #region LDP480*030
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP480*030";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 20.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 30.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 12.0;
                spmd.supPowerModelOutCurrent.OutputPower = 480.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 20.0;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 25;
                        cs.Grid.YMax = 35;
                        cs.Grid.XInterval = 5;//网格间隔
                        cs.Grid.YInterval = 5;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDP480E054HE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP480E054HE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 10;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 24;
                spmd.supPowerModelOutCurrent.OutputPower = 480.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 10;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 12;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 3;//网格间隔
                        cs.Grid.YInterval = 12;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            //In 2020-04-02 14:36:28
            CreateMode(sps, spm, "LDP480T036HE001", 15.7, 36, 18, 480, 16, 40, 4, 10, "P", 0.85);
            CreateMode(sps, spm, "LDP480T060HE001", 9.4, 60, 30, 480, 10, 65, 2, 13, "P", 0.85);
            CreateMode(sps, spm, "LDP480T024HE001", 23.5, 24, 12, 480, 25, 25, 5, 5, "P", 0.6);

            list.Add(sps);
            #endregion

            #region 初始化LDC480系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDC480";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            #region LDC480*014
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC480*014";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.4;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 429.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 171.0;
                spmd.supPowerModelOutCurrent.OutputPower = 480.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.4;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.0;
                        cs.Grid.YMax = 480;
                        cs.Grid.XInterval = 0.5;//网格间隔
                        cs.Grid.YInterval = 80;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC480E014HE002
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC480E014HE002";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.4;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 375;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 171;
                spmd.supPowerModelOutCurrent.OutputPower = 480.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.4;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.0;
                        cs.Grid.YMax = 400;
                        cs.Grid.XInterval = 0.5;//网格间隔
                        cs.Grid.YInterval = 80;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC480T014HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC480T014HU001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.4;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 375;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 171;
                spmd.supPowerModelOutCurrent.OutputPower = 480.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.4;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.0;
                        cs.Grid.YMax = 400;
                        cs.Grid.XInterval = 0.5;//网格间隔
                        cs.Grid.YInterval = 80;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            CreateMode(sps, spm, "LDC480I042HE001", 4.2, 143, 57, 480, 5, 150, 1, 30, "P", 0.6);
            CreateMode(sps, spm, "LDC480I014HE001", 1.4, 429, 171, 480, 2, 450, 0.5, 50, "P", 0.6);

            CreateMode(sps, spm, "LDC480E100HE001", 4.2, 143, 57, 480, 5, 150, 1, 30, "P", 0.6);

            //CreateMode(sps, spm, "LDC480T028HE001", 2.8, 202, 120, 480, 3, 220, 0.6, 44, "P", 0.85);

            //In 2020-04-02 14:27:08
            CreateMode(sps, spm, "LDC480T014HE001", 1.4, 403, 240, 480, 2, 420, 0.5, 84, "P", 0.7);
            CreateMode(sps, spm, "LDC480T028HE001", 2.8, 202, 120, 480, 3, 220, 0.5, 44, "P", 0.7);
            CreateMode(sps, spm, "LDC480T056HE001", 5.6, 101, 60, 480, 6, 120, 1, 30, "P", 0.7);
            CreateMode(sps, spm, "LDC480T074HE001", 7.4, 76, 45, 480, 8, 80, 2, 20, "P", 0.7);

            //In 2020-04-13 16:27:44
            CreateMode(sps, spm, "LDC480T042HE001", 4.2, 134, 80, 480, 5, 140, 1, 26.8, "P", 0.7);

            CreateMode(sps, spm, "LDC480T080HE001", 8, 71, 42, 480, 10, 80, 2, 20, "P", 0.7);


            CreateMode(sps, spm, "LDC480T042HE002", 4.2, 134, 80, 480, 5, 150, 1, 30, "P", 0.7);

            list.Add(sps);
            #endregion

            #region 初始化LDV480系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDV480";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();
            sps.SeriesType = "V";

            //SupPowerModel spm = null;

            #region LDV480T343HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDV480T343HU001";
                spm.Version = "v1.0";
                spm.ModelType = "V";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.4;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 343;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 343;
                spmd.supPowerModelOutCurrent.OutputPower = 480.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 1) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 1) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.4;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.0;
                        cs.Grid.YMax = 480;
                        cs.Grid.XInterval = 0.5;//网格间隔
                        cs.Grid.YInterval = 80;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            list.Add(sps);
            #endregion

            #region 初始化LDC500系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDC500";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //CreateMode(sps, spm, "LDC500E052HE001", 5.2, 121, 48, 500, 5.5, 125, 1.1, 25, "P", 0.6);
            //U 2020-04-02 13:48:44更新
            CreateMode(sps, spm, "LDC500E052HE001", 5.2, 113, 67, 500, 5.5, 120, 1.1, 30, "P", 0.7);

            list.Add(sps);
            #endregion

            #region 初始化LDC570系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDC570";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            #region LDC570K020XE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC570K020XE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 2.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 285;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 170;
                spmd.supPowerModelOutCurrent.OutputPower = 570;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 2.0;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.5;
                        cs.Grid.YMax = 600;
                        cs.Grid.XInterval = 0.5;//网格间隔
                        cs.Grid.YInterval = 120;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            list.Add(sps);
            #endregion

            #region 初始化LDA600TA系列(旧的命名方式，部分型号保留)

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDA600TA";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            #region LDA600TA054DB001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDA600TA054DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 12.5;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 24.0;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 12.5;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 15;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 5;//网格间隔
                        cs.Grid.YInterval = 10;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion
            CreateMode(sps, spm, "LDA600TA054DB102", 12.5, 54, 24, 600, 15, 80, 5, 20, "P", 0.6);
            #region LDA600TA536DB001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDA600TA536DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.4;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 536.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 214.0;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.4;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2;
                        cs.Grid.YMax = 600;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 100;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDA600TA048DB001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDA600TA048DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 11.5;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 27;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 11.5;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 12;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 2;
                        cs.Grid.YInterval = 12;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDE600EA048DB001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDE600EA048DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 12.5;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 24.0;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 12.5;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 15;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 5;//网格间隔
                        cs.Grid.YInterval = 10;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            CreateMode(sps, spm, "LDA600TA048DB003", 12.5, 60, 30, 600, 15, 80, 5, 20, "P", 0.7);
            CreateMode(sps, spm, "LDA600TA048DB201", 11.5, 54, 27, 600, 12, 60, 3, 12, "P", 0.6);

            CreateMode(sps, spm, "LDA600TA054DB001", 12.5, 54, 24, 600, 15, 60, 3, 12, "P", 0.7);

            CreateMode(sps, spm, "LDE600EA024DB101", 25, 24, 24, 600, 30, 30, 6, 6, "V", 1);


            CreateMode(sps, spm, "LDA600TA048DB201", 11.5, 54, 27, 600, 12, 60, 3, 12, "P", 0.6);

            list.Add(sps);
            #endregion

            #region 初始化LD*600系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LD*600";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            #region LD*600**036
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD*600**036";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 16.67;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 45;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 18;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 16.67;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 20;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 5;
                        cs.Grid.YInterval = 10;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LD*600**048
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD*600**048";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 12.5;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 24.0;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 12.5;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 15;
                        cs.Grid.YMax = 63;
                        cs.Grid.XInterval = 5;
                        cs.Grid.YInterval = 9;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion



            list.Add(sps);
            #endregion

            #region 初始化LDC600系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDC600";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            #region LDC600*014
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600*014";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.4;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 536.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 214.0;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.4;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2;
                        cs.Grid.YMax = 600;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 100;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC600*074
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600*074";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 7.4;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 102.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 41.0;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 7.5;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 10;
                        cs.Grid.YMax = 120;
                        cs.Grid.XInterval = 2;
                        cs.Grid.YInterval = 20.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC600*056
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600*056";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 5.6;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 135.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 54;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 5.6;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 8;
                        cs.Grid.YMax = 160;
                        cs.Grid.XInterval = 2;
                        cs.Grid.YInterval = 40.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC600*042
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600*042";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 4.2;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 178.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 71.0;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 4.2;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 6;
                        cs.Grid.YMax = 200;
                        cs.Grid.XInterval = 1;
                        cs.Grid.YInterval = 40.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC600*028
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600*028";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 2.8;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 267.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 107.0;
                spmd.supPowerModelOutCurrent.OutputPower = 598.08;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 2.8;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 4;
                        cs.Grid.YMax = 300;
                        cs.Grid.XInterval = 1;
                        cs.Grid.YInterval = 50.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC600E056HE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600E056HE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 5.6;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 134;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 54;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 5.6;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 8;
                        cs.Grid.YMax = 160;
                        cs.Grid.XInterval = 2;
                        cs.Grid.YInterval = 40.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC600U056HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600U056HU001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 5.6;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 134;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 54;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 5.6;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 8;
                        cs.Grid.YMax = 160;
                        cs.Grid.XInterval = 2;
                        cs.Grid.YInterval = 40.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            //CreateMode(sps, spm, "LDC600U074HU001", 7.4, 102, 41, 600, 8, 120, 2, 20, "P", 0.7);

            #region LDC600U024HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600U024HU001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 25;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 28;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 12;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 25;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 30;
                        cs.Grid.YMax = 30;
                        cs.Grid.XInterval = 6;
                        cs.Grid.YInterval = 6;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC600E031HE001
            {
                //spm = new SupPowerModel();
                //spm.Guid = Guid.NewGuid().ToString();
                //spm.SupPowerSeriesGuid = sps.Guid;
                //spm.CreateTime = DateTime.Now;
                //spm.Name = "LDC600E031HE001";
                //spm.Version = "v1.0";

                //#region 初始化实际值
                //SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                //supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                //supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                //supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                //supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                //supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                //supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                //supPowerSetPRGMR.iTPRecoveryP = 100;
                //supPowerSetPRGMR.iTPProtectionP = 110;
                //supPowerSetPRGMR.iTPCurrent = 80;
                //supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                //supPowerSetPRGMR.timerNum = 6;//定时个数

                //supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                //supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                //supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                //supPowerSetPRGMR.timingPower2 = 0;
                //supPowerSetPRGMR.timingLength2 = 0;
                //supPowerSetPRGMR.timingGradientLength2 = 0;
                //supPowerSetPRGMR.timingPower3 = 0;
                //supPowerSetPRGMR.timingLength3 = 0;
                //supPowerSetPRGMR.timingGradientLength3 = 0;
                //supPowerSetPRGMR.timingPower4 = 0;
                //supPowerSetPRGMR.timingLength4 = 0;
                //supPowerSetPRGMR.timingGradientLength4 = 0;
                //supPowerSetPRGMR.timingPower5 = 0;
                //supPowerSetPRGMR.timingLength5 = 0;
                //supPowerSetPRGMR.timingGradientLength5 = 0;
                //supPowerSetPRGMR.timingPower6 = 0;
                //supPowerSetPRGMR.timingLength6 = 0;
                //supPowerSetPRGMR.timingGradientLength6 = 0;

                //supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                //supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                //supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                //supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                //supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                //supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                //supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                //supPowerSetPRGMR.dimRatio = 100;

                //spm.SetConfigPRGMR(supPowerSetPRGMR);

                //SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                //supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                //supPowerSetPower.maxCurrent = 100;//最大电流%
                //supPowerSetPower.maxVoltage = 89;//最大电压%
                //supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                //supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                //supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                //supPowerSetPower.iTPRecoveryP = 100;
                //supPowerSetPower.iTPProtectionP = 110;
                //supPowerSetPower.iTPCurrent = 80;
                //supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                //supPowerSetPower.timerNum = 6;//定时个数

                //supPowerSetPower.timingPower1 = 0;//定时1功率%
                //supPowerSetPower.timingLength1 = 0;//定时1时长min
                //supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                //supPowerSetPower.timingPower2 = 0;
                //supPowerSetPower.timingLength2 = 0;
                //supPowerSetPower.timingGradientLength2 = 0;
                //supPowerSetPower.timingPower3 = 0;
                //supPowerSetPower.timingLength3 = 0;
                //supPowerSetPower.timingGradientLength3 = 0;
                //supPowerSetPower.timingPower4 = 0;
                //supPowerSetPower.timingLength4 = 0;
                //supPowerSetPower.timingGradientLength4 = 0;
                //supPowerSetPower.timingPower5 = 0;
                //supPowerSetPower.timingLength5 = 0;
                //supPowerSetPower.timingGradientLength5 = 0;
                //supPowerSetPower.timingPower6 = 0;
                //supPowerSetPower.timingLength6 = 0;
                //supPowerSetPower.timingGradientLength6 = 0;

                //supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                //supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                //supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                //supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                //supPowerSetPower.ratedPower = 100;//额定功率 W
                //supPowerSetPower.rateCurrent = 100;//额定电流 A
                //supPowerSetPower.powerDeviation = 1;//功率偏差W
                //supPowerSetPower.dimRatio = 100;//调光比
                //spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                //#endregion

                //// 初始化基础值
                //SupPowerModelData spmd = new SupPowerModelData();
                ////输出电流的图表数据
                //spmd.supPowerModelOutCurrent.OutputCurrentMax = 3.1;
                //spmd.supPowerModelOutCurrent.OutputVoltageMax = 242;
                //spmd.supPowerModelOutCurrent.OutputVoltageMin = 97;
                //spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                //spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                //spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                //spmd.supPowerModelOutCurrent.OutputCurrent = 3.1;

                ////spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                ////spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                ////外部温度的图表数据
                //spmd.supPowerModelDataTemp.Orecover = 80;
                //spmd.supPowerModelDataTemp.OoutProtect = 90;
                //spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                //spmd.supPowerModelDataTemp.Irecover = 90;
                //spmd.supPowerModelDataTemp.IoutProtect = 100;
                //spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                //spm.SetData(spmd);
                //// 初始化图例
                //{
                //    List<ChartSet> lcs = new List<ChartSet>();
                //    {
                //        ChartSet cs = new ChartSet();

                //        cs.Name = "OutCurrentChart";
                //        cs.Grid.XMax = 4;
                //        cs.Grid.YMax = 250;
                //        cs.Grid.XInterval = 1;
                //        cs.Grid.YInterval = 50;
                //        //cs.InitOutputCurrent(spmd);
                //        lcs.Add(cs);

                //        cs = new ChartSet();
                //        cs.Name = "TempChart";
                //        cs.Grid.XMax = 110;
                //        cs.Grid.XInterval = 10;
                //        cs.Grid.XTitle = "℃";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.2;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";
                //        lcs.Add(cs);

                //        cs = new ChartSet();
                //        cs.Name = "TempInChart";
                //        cs.Grid.XMax = 110;
                //        cs.Grid.XInterval = 10;
                //        cs.Grid.XTitle = "℃";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.2;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";
                //        lcs.Add(cs);


                //        cs = new ChartSet();
                //        cs.Name = "TimeCtrlChart";
                //        cs.Grid.XMax = 24;
                //        cs.Grid.XInterval = 1;
                //        cs.Grid.XTitle = "( H )";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.1;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";

                //        lcs.Add(cs);
                //    }
                //    spm.SetCharts(lcs);
                //}
                //sps.SupPowerModels.Add(spm);
            }
            #endregion
            //U 2020-04-02 14:08:59
            CreateMode(sps, spm, "LDC600E031HE001", 3.1, 228, 135, 600, 3.5, 240, 0.7, 60, "P", 0.7);

            #region LDC600T060HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600T060HU001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 11.1;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 27;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 11.1;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 12;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 3;
                        cs.Grid.YInterval = 12;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC600U070HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600U070HU001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 7;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 107;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 43;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 7;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 8;
                        cs.Grid.YMax = 120;
                        cs.Grid.XInterval = 2;
                        cs.Grid.YInterval = 30;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC600E056HE002
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600E056HE002";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 5.15;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 121;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 49;
                spmd.supPowerModelOutCurrent.OutputPower = 500;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 5.15;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 6;
                        cs.Grid.YMax = 150;
                        cs.Grid.XInterval = 1.5;
                        cs.Grid.YInterval = 30;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC600U028HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC600U028HU001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 2.8;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 268;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 107;
                spmd.supPowerModelOutCurrent.OutputPower = 600;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 2.8;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 3;
                        cs.Grid.YMax = 280;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 70;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            CreateMode(sps, spm, "LDC600U017HU001", 1.7, 441, 177, 600, 2.0, 450, 0.5, 90, "P", 0.6);
            CreateMode(sps, spm, "LDC600U021HU001", 2.1, 357, 142, 600, 2.5, 370, 0.5, 74, "P", 0.6);
            CreateMode(sps, spm, "LDC600T042HE001", 4.2, 179, 71, 600, 4.5, 190, 0.9, 38, "P", 0.6);
            //CreateMode(sps, spm, "LDC600E074HE001", 7.4, 101, 41, 600, 8, 110, 2, 22, "P", 0.6);
            //U 2020-04-02 14:10:45
            CreateMode(sps, spm, "LDC600E074HE001", 7.4, 101, 41, 600, 8, 110, 2, 22, "P", 0.7);

            //CreateMode(sps, spm, "LDC600E014HE001", 1.4, 450, 214, 600, 1.5, 480, 0.3, 96, "P", 0.6);
            //U 2020-04-02 13:54:23
            CreateMode(sps, spm, "LDC600E014HE001", 1.4, 429, 300, 600, 1.5, 480, 0.3, 96, "P", 0.7);

            CreateMode(sps, spm, "LDC600E017HE001", 1.7, 442, 177, 600, 2.0, 450, 0.5, 90, "P", 0.6);

            CreateMode(sps, spm, "LDC600E042HE001", 4.2, 178, 71, 600, 4.5, 200, 0.9, 50, "P", 0.7);
            //CreateMode(sps, spm, "LDC600E028HE001", 2.8, 267, 107, 600, 3.0, 280, 0.6, 70, "P", 0.6);
            //U 2020-04-02 13:58:35
            CreateMode(sps, spm, "LDC600E028HE001", 2.8, 252, 150, 600, 3.0, 260, 0.6, 52, "P", 0.7);
            CreateMode(sps, spm, "LDC600E021HE001", 2.1, 358, 143, 600, 2.5, 360, 0.5, 60, "P", 0.6);

            //In 2020-04-02 14:48:27
            CreateMode(sps, spm, "LDC600D021HE001", 2.1, 336, 200, 600, 2.5, 360, 0.5, 60, "P", 0.7);
            CreateMode(sps, spm, "LDC600D017HE001", 1.7, 415, 247, 600, 2, 420, 0.5, 84, "P", 0.7);
            CreateMode(sps, spm, "LDC600D014HE001", 1.4, 429, 429, 600, 2, 440, 0.5, 88, "P", 1);

            CreateMode(sps, spm, "LDC600U063HU002", 7.4, 101, 41, 600, 8, 120, 2, 20, "P", 0.7);

            CreateMode(sps, spm, "LDC600U074HU001", 7.4, 101, 41, 600, 8, 120, 2, 20, "P", 0.7);

            CreateMode(sps, spm, "LDC600E042HE001", 4.2, 168, 100, 600, 5, 180, 1, 30, "P", 0.7);

            list.Add(sps);
            #endregion

            #region 初始化LDP600系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP600";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            #region LDP600*014
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP600*054";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 12.5;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 24;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 12.5;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 15;
                        cs.Grid.YMax = 63;
                        cs.Grid.XInterval = 2.5;
                        cs.Grid.YInterval = 9;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDP600E070CE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP600E070CE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 7;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 100;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 65;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.8) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.8) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 7;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 10;
                        cs.Grid.YMax = 120;
                        cs.Grid.XInterval = 2;
                        cs.Grid.YInterval = 20;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDP600U048HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP600U048HU001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 12.5;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 24;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 12.5;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 15;
                        cs.Grid.YMax = 80;
                        cs.Grid.XInterval = 3;
                        cs.Grid.YInterval = 20;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDP600U054HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP600U054HU001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 11.5;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 27;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 11.5;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 15;
                        cs.Grid.YMax = 80;
                        cs.Grid.XInterval = 3;
                        cs.Grid.YInterval = 20;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDP600U028HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP600U028HU001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 25;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 28;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 12;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 25;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 30;
                        cs.Grid.YMax = 30;
                        cs.Grid.XInterval = 6;
                        cs.Grid.YInterval = 6;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            CreateMode(sps, spm, "LDP600E070CE002", 6.5, 105, 65, 600, 7, 120, 1.4, 20, "P", 0.8);
            CreateMode(sps, spm, "LDP600D054HE001", 12.5, 54, 27, 600, 15, 60, 3, 12, "P", 0.6);

            list.Add(sps);
            #endregion

            #region 初始化LDV600系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDV600";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();
            sps.SeriesType = "V";
            #region LDV600T200HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDV600T200HU001";
                spm.Version = "v1.0";
                spm.ModelType = "V";
                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 3.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 200;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 200;
                spmd.supPowerModelOutCurrent.OutputPower = 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 1) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 1) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 3.0;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 4;
                        cs.Grid.YMax = 250;
                        cs.Grid.XInterval = 1;
                        cs.Grid.YInterval = 50;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            CreateMode(sps, spm, "LDV600E014HE001", 1.4, 429, 429, 600, 2, 450, 0.5, 90, "V", 1);
            list.Add(sps);
            #endregion

            #region 初始化LDC1K0系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDC1K0";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            #region LDC1K0E051HE001
            {
                //spm = new SupPowerModel();
                //spm.Guid = Guid.NewGuid().ToString();
                //spm.SupPowerSeriesGuid = sps.Guid;
                //spm.CreateTime = DateTime.Now;
                //spm.Name = "LDC1K0E051HE001";
                //spm.Version = "v1.0";

                //#region 初始化实际值
                //SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                //supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                //supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                //supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                //supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                //supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                //supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                //supPowerSetPRGMR.iTPRecoveryP = 100;
                //supPowerSetPRGMR.iTPProtectionP = 110;
                //supPowerSetPRGMR.iTPCurrent = 80;
                //supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                //supPowerSetPRGMR.timerNum = 6;//定时个数

                //supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                //supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                //supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                //supPowerSetPRGMR.timingPower2 = 0;
                //supPowerSetPRGMR.timingLength2 = 0;
                //supPowerSetPRGMR.timingGradientLength2 = 0;
                //supPowerSetPRGMR.timingPower3 = 0;
                //supPowerSetPRGMR.timingLength3 = 0;
                //supPowerSetPRGMR.timingGradientLength3 = 0;
                //supPowerSetPRGMR.timingPower4 = 0;
                //supPowerSetPRGMR.timingLength4 = 0;
                //supPowerSetPRGMR.timingGradientLength4 = 0;
                //supPowerSetPRGMR.timingPower5 = 0;
                //supPowerSetPRGMR.timingLength5 = 0;
                //supPowerSetPRGMR.timingGradientLength5 = 0;
                //supPowerSetPRGMR.timingPower6 = 0;
                //supPowerSetPRGMR.timingLength6 = 0;
                //supPowerSetPRGMR.timingGradientLength6 = 0;

                //supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                //supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                //supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                //supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                //supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                //supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                //supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                //supPowerSetPRGMR.dimRatio = 100;

                //spm.SetConfigPRGMR(supPowerSetPRGMR);

                //SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                //supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                //supPowerSetPower.maxCurrent = 100;//最大电流%
                //supPowerSetPower.maxVoltage = 80;//最大电压%
                //supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                //supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                //supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                //supPowerSetPower.iTPRecoveryP = 100;
                //supPowerSetPower.iTPProtectionP = 110;
                //supPowerSetPower.iTPCurrent = 80;
                //supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                //supPowerSetPower.timerNum = 6;//定时个数

                //supPowerSetPower.timingPower1 = 0;//定时1功率%
                //supPowerSetPower.timingLength1 = 0;//定时1时长min
                //supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                //supPowerSetPower.timingPower2 = 0;
                //supPowerSetPower.timingLength2 = 0;
                //supPowerSetPower.timingGradientLength2 = 0;
                //supPowerSetPower.timingPower3 = 0;
                //supPowerSetPower.timingLength3 = 0;
                //supPowerSetPower.timingGradientLength3 = 0;
                //supPowerSetPower.timingPower4 = 0;
                //supPowerSetPower.timingLength4 = 0;
                //supPowerSetPower.timingGradientLength4 = 0;
                //supPowerSetPower.timingPower5 = 0;
                //supPowerSetPower.timingLength5 = 0;
                //supPowerSetPower.timingGradientLength5 = 0;
                //supPowerSetPower.timingPower6 = 0;
                //supPowerSetPower.timingLength6 = 0;
                //supPowerSetPower.timingGradientLength6 = 0;

                //supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                //supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                //supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                //supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                //supPowerSetPower.ratedPower = 100;//额定功率 W
                //supPowerSetPower.rateCurrent = 100;//额定电流 A
                //supPowerSetPower.powerDeviation = 1;//功率偏差W
                //supPowerSetPower.dimRatio = 100;//调光比
                //spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                //#endregion

                //// 初始化基础值
                //SupPowerModelData spmd = new SupPowerModelData();
                ////输出电流的图表数据
                //spmd.supPowerModelOutCurrent.OutputCurrentMax = 5.1;
                //spmd.supPowerModelOutCurrent.OutputVoltageMax = 218;
                //spmd.supPowerModelOutCurrent.OutputVoltageMin = 92;
                //spmd.supPowerModelOutCurrent.OutputPower = 938.4;
                //spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                //spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                //spmd.supPowerModelOutCurrent.OutputCurrent = 5.1;

                ////spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                ////spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                ////外部温度的图表数据
                //spmd.supPowerModelDataTemp.Orecover = 80;
                //spmd.supPowerModelDataTemp.OoutProtect = 90;
                //spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                //spmd.supPowerModelDataTemp.Irecover = 90;
                //spmd.supPowerModelDataTemp.IoutProtect = 100;
                //spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                //spm.SetData(spmd);

                //// 初始化图例
                //{
                //    List<ChartSet> lcs = new List<ChartSet>();
                //    {
                //        ChartSet cs = new ChartSet();

                //        cs.Name = "OutCurrentChart";
                //        cs.Grid.XMax = 6;
                //        cs.Grid.YMax = 240;
                //        cs.Grid.XInterval = 1;
                //        cs.Grid.YInterval = 60;
                //        //cs.InitOutputCurrent(spmd);
                //        lcs.Add(cs);

                //        cs = new ChartSet();
                //        cs.Name = "TempChart";
                //        cs.Grid.XMax = 110;
                //        cs.Grid.XInterval = 10;
                //        cs.Grid.XTitle = "℃";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.2;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";
                //        lcs.Add(cs);

                //        cs = new ChartSet();
                //        cs.Name = "TempInChart";
                //        cs.Grid.XMax = 110;
                //        cs.Grid.XInterval = 10;
                //        cs.Grid.XTitle = "℃";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.2;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";
                //        lcs.Add(cs);


                //        cs = new ChartSet();
                //        cs.Name = "TimeCtrlChart";
                //        cs.Grid.XMax = 24;
                //        cs.Grid.XInterval = 1;
                //        cs.Grid.XTitle = "( H )";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.1;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";


                //        lcs.Add(cs);
                //    }
                //    spm.SetCharts(lcs);
                //}
                //sps.SupPowerModels.Add(spm);
            }
            #endregion
            //U 2020-04-02 14:13:57
            CreateMode(sps, spm, "LDC1K0E051HE001", 5.1, 231, 137, 1000, 6, 240, 1, 60, "P", 0.7);

            #region LDC1K0E044HE001
            {
                //spm = new SupPowerModel();
                //spm.Guid = Guid.NewGuid().ToString();
                //spm.SupPowerSeriesGuid = sps.Guid;
                //spm.CreateTime = DateTime.Now;
                //spm.Name = "LDC1K0E044HE001";
                //spm.Version = "v1.0";

                //#region 初始化实际值
                //SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                //supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                //supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                //supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                //supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                //supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                //supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                //supPowerSetPRGMR.iTPRecoveryP = 100;
                //supPowerSetPRGMR.iTPProtectionP = 110;
                //supPowerSetPRGMR.iTPCurrent = 80;
                //supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                //supPowerSetPRGMR.timerNum = 6;//定时个数

                //supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                //supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                //supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                //supPowerSetPRGMR.timingPower2 = 0;
                //supPowerSetPRGMR.timingLength2 = 0;
                //supPowerSetPRGMR.timingGradientLength2 = 0;
                //supPowerSetPRGMR.timingPower3 = 0;
                //supPowerSetPRGMR.timingLength3 = 0;
                //supPowerSetPRGMR.timingGradientLength3 = 0;
                //supPowerSetPRGMR.timingPower4 = 0;
                //supPowerSetPRGMR.timingLength4 = 0;
                //supPowerSetPRGMR.timingGradientLength4 = 0;
                //supPowerSetPRGMR.timingPower5 = 0;
                //supPowerSetPRGMR.timingLength5 = 0;
                //supPowerSetPRGMR.timingGradientLength5 = 0;
                //supPowerSetPRGMR.timingPower6 = 0;
                //supPowerSetPRGMR.timingLength6 = 0;
                //supPowerSetPRGMR.timingGradientLength6 = 0;

                //supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                //supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                //supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                //supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                //supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                //supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                //supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                //supPowerSetPRGMR.dimRatio = 100;

                //spm.SetConfigPRGMR(supPowerSetPRGMR);

                //SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                //supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                //supPowerSetPower.maxCurrent = 100;//最大电流%
                //supPowerSetPower.maxVoltage = 80;//最大电压%
                //supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                //supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                //supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                //supPowerSetPower.iTPRecoveryP = 100;
                //supPowerSetPower.iTPProtectionP = 110;
                //supPowerSetPower.iTPCurrent = 80;
                //supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                //supPowerSetPower.timerNum = 6;//定时个数

                //supPowerSetPower.timingPower1 = 0;//定时1功率%
                //supPowerSetPower.timingLength1 = 0;//定时1时长min
                //supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                //supPowerSetPower.timingPower2 = 0;
                //supPowerSetPower.timingLength2 = 0;
                //supPowerSetPower.timingGradientLength2 = 0;
                //supPowerSetPower.timingPower3 = 0;
                //supPowerSetPower.timingLength3 = 0;
                //supPowerSetPower.timingGradientLength3 = 0;
                //supPowerSetPower.timingPower4 = 0;
                //supPowerSetPower.timingLength4 = 0;
                //supPowerSetPower.timingGradientLength4 = 0;
                //supPowerSetPower.timingPower5 = 0;
                //supPowerSetPower.timingLength5 = 0;
                //supPowerSetPower.timingGradientLength5 = 0;
                //supPowerSetPower.timingPower6 = 0;
                //supPowerSetPower.timingLength6 = 0;
                //supPowerSetPower.timingGradientLength6 = 0;

                //supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                //supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                //supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                //supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                //supPowerSetPower.ratedPower = 100;//额定功率 W
                //supPowerSetPower.rateCurrent = 100;//额定电流 A
                //supPowerSetPower.powerDeviation = 1;//功率偏差W
                //supPowerSetPower.dimRatio = 100;//调光比
                //spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                //#endregion

                //// 初始化基础值
                //SupPowerModelData spmd = new SupPowerModelData();
                ////输出电流的图表数据
                //spmd.supPowerModelOutCurrent.OutputCurrentMax = 4.4;
                //spmd.supPowerModelOutCurrent.OutputVoltageMax = 244;
                //spmd.supPowerModelOutCurrent.OutputVoltageMin = 103;
                //spmd.supPowerModelOutCurrent.OutputPower = 950.4;
                //spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                //spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                //spmd.supPowerModelOutCurrent.OutputCurrent = 4.4;

                ////spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                ////spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                ////外部温度的图表数据
                //spmd.supPowerModelDataTemp.Orecover = 80;
                //spmd.supPowerModelDataTemp.OoutProtect = 90;
                //spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                //spmd.supPowerModelDataTemp.Irecover = 90;
                //spmd.supPowerModelDataTemp.IoutProtect = 100;
                //spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                //spm.SetData(spmd);

                //// 初始化图例
                //{
                //    List<ChartSet> lcs = new List<ChartSet>();
                //    {
                //        ChartSet cs = new ChartSet();

                //        cs.Name = "OutCurrentChart";
                //        cs.Grid.XMax = 5;
                //        cs.Grid.YMax = 250;
                //        cs.Grid.XInterval = 1;
                //        cs.Grid.YInterval = 50;
                //        //cs.InitOutputCurrent(spmd);
                //        lcs.Add(cs);

                //        cs = new ChartSet();
                //        cs.Name = "TempChart";
                //        cs.Grid.XMax = 110;
                //        cs.Grid.XInterval = 10;
                //        cs.Grid.XTitle = "℃";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.2;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";
                //        lcs.Add(cs);

                //        cs = new ChartSet();
                //        cs.Name = "TempInChart";
                //        cs.Grid.XMax = 110;
                //        cs.Grid.XInterval = 10;
                //        cs.Grid.XTitle = "℃";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.2;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";
                //        lcs.Add(cs);


                //        cs = new ChartSet();
                //        cs.Name = "TimeCtrlChart";
                //        cs.Grid.XMax = 24;
                //        cs.Grid.XInterval = 1;
                //        cs.Grid.XTitle = "( H )";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.1;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";


                //        lcs.Add(cs);
                //    }
                //    spm.SetCharts(lcs);
                //}
                //sps.SupPowerModels.Add(spm);
            }
            #endregion
            //U 2020-04-02 14:16:06
            CreateMode(sps, spm, "LDC1K0E044HE001", 4.4, 267, 159, 1000, 5, 280, 1, 70, "P", 0.7);

            //CreateMode(sps, spm, "LDC1K0E056HE001", 5.6, 244, 89, 1000, 6, 250, 1, 50, "P", 0.6);
            //CreateMode(sps, spm, "LDC1K0E056HE001", 5.3, 196, 100, 1039, 6, 220, 1, 44, "P", 0.6);
            //U 2020-04-02 14:18:24
            CreateMode(sps, spm, "LDC1K0E056HE001", 5.6, 210, 125, 1000, 6, 220, 1, 44, "P", 0.7);

            CreateMode(sps, spm, "LDC1K0E053HE001", 5.3, 196, 100, 1039, 6, 220, 1, 44, "P", 0.6);
            CreateMode(sps, spm, "LDC1K0A010HU001", 10, 105, 53, 1000, 12, 120, 2, 30, "P", 0.6);

            list.Add(sps);
            #endregion

            #region 初始化LDC1K0系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP1K0";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            CreateMode(sps, spm, "LDP1K0E054HE001", 19, 54, 27, 1026, 20, 60, 4, 12, "P", 0.5);

            list.Add(sps);
            #endregion

            #region 初始化LDA1K2TA系列(旧的命名方式，部分型号保留)

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDA1K2TA";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            #region LDA1K2TA054DB001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDA1K2TA054DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 25.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 24.0;
                spmd.supPowerModelOutCurrent.OutputPower = 1200.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 25.0;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 30;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 5;
                        cs.Grid.YInterval = 5;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDA1K2TA042DB001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDA1K2TA042DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 28;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 53;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 21;
                spmd.supPowerModelOutCurrent.OutputPower = 1200.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 28;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 30;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 5;
                        cs.Grid.YInterval = 5;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            list.Add(sps);
            #endregion

            #region 初始化LD*1K2系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LD*1K2";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();


            #region LD*1K2**036
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD*1K2**036";//"LDA1K2TA045DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 28.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 45.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 18;
                spmd.supPowerModelOutCurrent.OutputPower = 1000;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 28;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 35;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 5;
                        cs.Grid.YInterval = 10;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LD*1K2**048
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD*1K2**048";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 25.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 24.0;
                spmd.supPowerModelOutCurrent.OutputPower = 1200.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 25.0;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 30;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 5;
                        cs.Grid.YInterval = 10;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDE1K2TA048DB001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDE1K2TA048DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 25.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 24.0;
                spmd.supPowerModelOutCurrent.OutputPower = 1200.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 25.0;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 30;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 5;
                        cs.Grid.YInterval = 10;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDE1K2EA048DB003
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDE1K2EA048DB003";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 22.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 52.6;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 24.0;
                spmd.supPowerModelOutCurrent.OutputPower = 1000.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 22.0;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 30;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 5;
                        cs.Grid.YInterval = 10;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            list.Add(sps);
            #endregion

            #region 初始化LDC1K2系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDC1K2";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            #region LDC1K2*074
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC1K2*074";//"LDA1K2TA202DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 7.4;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 202.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 81.0;
                spmd.supPowerModelOutCurrent.OutputPower = 1200.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 7.4;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 8;
                        cs.Grid.YMax = 240;
                        cs.Grid.XInterval = 1;
                        cs.Grid.YInterval = 40;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC1K2*056
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC1K2*056";//"LDA1K2TA202DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 5.6;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 268.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 108.0;
                spmd.supPowerModelOutCurrent.OutputPower = 1200.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 5.6;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 8;
                        cs.Grid.YMax = 300;
                        cs.Grid.XInterval = 2;
                        cs.Grid.YInterval = 50;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC1K2*042
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC1K2*042";//"LDA1K2TA202DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 4.2;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 357.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 143;
                spmd.supPowerModelOutCurrent.OutputPower = 1200.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 4.2;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 6;
                        cs.Grid.YMax = 380;
                        cs.Grid.XInterval = 1;
                        cs.Grid.YInterval = 76;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDC1K2E042HE001
            {
                //spm = new SupPowerModel();
                //spm.Guid = Guid.NewGuid().ToString();
                //spm.SupPowerSeriesGuid = sps.Guid;
                //spm.CreateTime = DateTime.Now;
                //spm.Name = "LDC1K2E042HE001";//"LDA1K2TA202DB001";
                //spm.Version = "v1.0";

                //#region 初始化实际值
                //SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                //supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                //supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                //supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                //supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                //supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                //supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                //supPowerSetPRGMR.iTPRecoveryP = 100;
                //supPowerSetPRGMR.iTPProtectionP = 110;
                //supPowerSetPRGMR.iTPCurrent = 80;
                //supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                //supPowerSetPRGMR.timerNum = 6;//定时个数

                //supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                //supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                //supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                //supPowerSetPRGMR.timingPower2 = 0;
                //supPowerSetPRGMR.timingLength2 = 0;
                //supPowerSetPRGMR.timingGradientLength2 = 0;
                //supPowerSetPRGMR.timingPower3 = 0;
                //supPowerSetPRGMR.timingLength3 = 0;
                //supPowerSetPRGMR.timingGradientLength3 = 0;
                //supPowerSetPRGMR.timingPower4 = 0;
                //supPowerSetPRGMR.timingLength4 = 0;
                //supPowerSetPRGMR.timingGradientLength4 = 0;
                //supPowerSetPRGMR.timingPower5 = 0;
                //supPowerSetPRGMR.timingLength5 = 0;
                //supPowerSetPRGMR.timingGradientLength5 = 0;
                //supPowerSetPRGMR.timingPower6 = 0;
                //supPowerSetPRGMR.timingLength6 = 0;
                //supPowerSetPRGMR.timingGradientLength6 = 0;

                //supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                //supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                //supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                //supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                //supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                //supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                //supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                //supPowerSetPRGMR.dimRatio = 100;

                //spm.SetConfigPRGMR(supPowerSetPRGMR);

                //SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                //supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                //supPowerSetPower.maxCurrent = 100;//最大电流%
                //supPowerSetPower.maxVoltage = 80;//最大电压%
                //supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                //supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                //supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                //supPowerSetPower.iTPRecoveryP = 100;
                //supPowerSetPower.iTPProtectionP = 110;
                //supPowerSetPower.iTPCurrent = 80;
                //supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                //supPowerSetPower.timerNum = 6;//定时个数

                //supPowerSetPower.timingPower1 = 0;//定时1功率%
                //supPowerSetPower.timingLength1 = 0;//定时1时长min
                //supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                //supPowerSetPower.timingPower2 = 0;
                //supPowerSetPower.timingLength2 = 0;
                //supPowerSetPower.timingGradientLength2 = 0;
                //supPowerSetPower.timingPower3 = 0;
                //supPowerSetPower.timingLength3 = 0;
                //supPowerSetPower.timingGradientLength3 = 0;
                //supPowerSetPower.timingPower4 = 0;
                //supPowerSetPower.timingLength4 = 0;
                //supPowerSetPower.timingGradientLength4 = 0;
                //supPowerSetPower.timingPower5 = 0;
                //supPowerSetPower.timingLength5 = 0;
                //supPowerSetPower.timingGradientLength5 = 0;
                //supPowerSetPower.timingPower6 = 0;
                //supPowerSetPower.timingLength6 = 0;
                //supPowerSetPower.timingGradientLength6 = 0;

                //supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                //supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                //supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                //supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                //supPowerSetPower.ratedPower = 100;//额定功率 W
                //supPowerSetPower.rateCurrent = 100;//额定电流 A
                //supPowerSetPower.powerDeviation = 1;//功率偏差W
                //supPowerSetPower.dimRatio = 100;//调光比
                //spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                //#endregion

                //// 初始化基础值
                //SupPowerModelData spmd = new SupPowerModelData();
                ////输出电流的图表数据
                //spmd.supPowerModelOutCurrent.OutputCurrentMax = 4.2;
                //spmd.supPowerModelOutCurrent.OutputVoltageMax = 357;
                //spmd.supPowerModelOutCurrent.OutputVoltageMin = 142;
                //spmd.supPowerModelOutCurrent.OutputPower = 1200.0;
                //spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                //spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                //spmd.supPowerModelOutCurrent.OutputCurrent = 4.2;


                ////spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                ////spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                ////外部温度的图表数据
                //spmd.supPowerModelDataTemp.Orecover = 80;
                //spmd.supPowerModelDataTemp.OoutProtect = 90;
                //spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                //spmd.supPowerModelDataTemp.Irecover = 90;
                //spmd.supPowerModelDataTemp.IoutProtect = 100;
                //spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                //spm.SetData(spmd);

                //// 初始化图例
                //{
                //    List<ChartSet> lcs = new List<ChartSet>();
                //    {
                //        ChartSet cs = new ChartSet();

                //        cs.Name = "OutCurrentChart";
                //        cs.Grid.XMax = 5;
                //        cs.Grid.YMax = 380;
                //        cs.Grid.XInterval = 1;
                //        cs.Grid.YInterval = 76;
                //        //cs.InitOutputCurrent(spmd);
                //        lcs.Add(cs);

                //        cs = new ChartSet();
                //        cs.Name = "TempChart";
                //        cs.Grid.XMax = 110;
                //        cs.Grid.XInterval = 10;
                //        cs.Grid.XTitle = "℃";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.2;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";
                //        lcs.Add(cs);

                //        cs = new ChartSet();
                //        cs.Name = "TempInChart";
                //        cs.Grid.XMax = 110;
                //        cs.Grid.XInterval = 10;
                //        cs.Grid.XTitle = "℃";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.2;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";
                //        lcs.Add(cs);


                //        cs = new ChartSet();
                //        cs.Name = "TimeCtrlChart";
                //        cs.Grid.XMax = 24;
                //        cs.Grid.XInterval = 1;
                //        cs.Grid.XTitle = "( H )";
                //        cs.Grid.XLabelFormat = "0";

                //        cs.Grid.YMax = 1;
                //        cs.Grid.YInterval = 0.1;
                //        cs.Grid.YTitle = "";
                //        cs.Grid.YLabelFormat = "0%";


                //        lcs.Add(cs);
                //    }
                //    spm.SetCharts(lcs);
                //}
                //sps.SupPowerModels.Add(spm);
            }
            #endregion
            //U 2020-04-02 14:20:44
            CreateMode(sps, spm, "LDC1K2E042HE001", 4.2, 336, 200, 1200, 5, 340, 1, 68, "P", 0.7);

            #region LDC1K2T074HU001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDC1K2T074HU001";//"LDA1K2TA202DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 7.4;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 162;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 81;
                spmd.supPowerModelOutCurrent.OutputPower = 1200.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 7.4;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 8;
                        cs.Grid.YMax = 180;
                        cs.Grid.XInterval = 2;
                        cs.Grid.YInterval = 30;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            //CreateMode(sps, spm, "LDC1K2E074HE001", 7.4, 202, 81, 1200, 8, 210, 2, 42, "P", 0.6);
            //U 2020-04-02 14:23:37
            CreateMode(sps, spm, "LDC1K2E074HE001", 7.4, 191, 114, 1200, 8, 200, 2, 40, "P", 0.7);

            CreateMode(sps, spm, "LDC1K2E056HE001", 5.6, 267, 107, 1200, 6, 280, 1, 70, "P", 0.6);
            CreateMode(sps, spm, "LDC1K2E028HE001", 2.8, 428, 215, 1200, 3, 450, 0.6, 90, "P", 0.6);



            list.Add(sps);
            #endregion

            #region 初始化LDE1K2系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDE1K2";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            #region LDE1K2TA048DB002
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDE1K2TA048DB002";//"LDA1K2TA202DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 25;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 24;
                spmd.supPowerModelOutCurrent.OutputPower = 1200.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 25;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 30;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 6;
                        cs.Grid.YInterval = 12;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDE1K2E042HE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDE1K2E042HE001";//"LDA1K2TA202DB001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 4.2;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 357;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 142;
                spmd.supPowerModelOutCurrent.OutputPower = 1200.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 4.2;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 5;
                        cs.Grid.YMax = 380;
                        cs.Grid.XInterval = 1;
                        cs.Grid.YInterval = 76;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            list.Add(sps);
            #endregion

            #region 初始化LDP1K2系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP1K2";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            CreateMode(sps, spm, "LDP1K2E054HE001", 26.0, 54.0, 27.0, 1200, 30, 60, 6, 12, "P", 0.7);
            CreateMode(sps, spm, "LDP1K2E036HE001", 39.2, 36, 18, 1200, 40, 40, 5, 5, "P", 0.6);

            list.Add(sps);
            #endregion

            #region 初始化LDC1K5系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP1K5";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            #region LDP1K5E054HE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP1K5E054HE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 28.8;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 27;
                spmd.supPowerModelOutCurrent.OutputPower = 1526;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 28.8;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 30;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 6;
                        cs.Grid.YInterval = 10;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            list.Add(sps);
            #endregion
            #endregion

            #region LED
            #region 初始化LDP075I系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP075I";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            #region LDP075I105PE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP075I105PE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 107;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 43;
                spmd.supPowerModelOutCurrent.OutputPower = 75;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 120;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 20;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDP075I210PE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP075I210PE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 2.10;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 54;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 21;
                spmd.supPowerModelOutCurrent.OutputPower = 75;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 2.10;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.5;
                        cs.Grid.YMax = 60;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 15;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            CreateMode(sps, spm, "LDP075I210PE101", 2.1, 53, 24, 75, 2.5, 60, 0.5, 12, "P", 0.7);

            list.Add(sps);
            #endregion


            #region 初始化LDP075IC系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP075IC";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            #region LD075IC105W76AD3001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD075IC105W76AD3001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 107;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 43;
                spmd.supPowerModelOutCurrent.OutputPower = 75;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 120;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 20;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LD075IC105W76AD3101
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD075IC105W76AD3101";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 107;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 43;
                spmd.supPowerModelOutCurrent.OutputPower = 75;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 120;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 20;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            list.Add(sps);
            #endregion


            #region 初始化LDP096IC系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP096I";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            #region LDP096I140PE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP096I140PE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.40;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 95;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 43;
                spmd.supPowerModelOutCurrent.OutputPower = 100;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.40;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.0;
                        cs.Grid.YMax = 120;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 30.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            list.Add(sps);
            #endregion

            #region 初始化LDP096IC系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP096IC";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            #region LD096IC105W76AD3001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD096IC105W76AD3001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 137;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 55;
                spmd.supPowerModelOutCurrent.OutputPower = 96;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 160;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 40.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LD096IC105W76AD3101
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD096IC105W76AD3101";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 137;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 55;
                spmd.supPowerModelOutCurrent.OutputPower = 96;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 160;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 40.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDP096I140PE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP096I140PE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.40;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 95;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 50;
                spmd.supPowerModelOutCurrent.OutputPower = 96;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.0;
                        cs.Grid.YMax = 120;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 30.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            list.Add(sps);
            #endregion

            #region 初始化LDP100I系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP100I";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;


            #region LDP100I210PE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP100I210PE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 2.1;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 71;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 38;
                spmd.supPowerModelOutCurrent.OutputPower = 100;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 2.1;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.4;
                        cs.Grid.YMax = 80;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 20.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            CreateMode(sps, spm, "LDP100I210PE101", 2.1, 71, 33, 100, 2.5, 80, 0.5, 16, "P", 0.7);
            CreateMode(sps, spm, "LDP100I140PE101", 1.4, 95, 50, 100, 1.5, 100, 0.3, 20, "P", 0.7);

            list.Add(sps);
            #endregion

            #region 初始化LDP150I系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP150I";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;


            #region LDP150I140PE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP150I140PE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.4;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 142;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 64;
                spmd.supPowerModelOutCurrent.OutputPower = 150;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.4;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.0;
                        cs.Grid.YMax = 160;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 40.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDP150I280PE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP150I280PE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 2.8;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 71;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 32;
                spmd.supPowerModelOutCurrent.OutputPower = 150;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 2.8;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 3.0;
                        cs.Grid.YMax = 80;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 20;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            CreateMode(sps, spm, "LDP150I105PE101", 1.05, 214, 100, 150, 1.2, 220, 0.2, 44, "P", 0.7);

            list.Add(sps);
            #endregion

            #region 初始化LDP150IC系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP150IC";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            #region LD150IC105W76AD3001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD150IC105W76AD3001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 214.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 86.0;
                spmd.supPowerModelOutCurrent.OutputPower = 150;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 240;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 40.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LD150IC105W76AD3101
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD150IC105W76AD3101";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 214.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 86.0;
                spmd.supPowerModelOutCurrent.OutputPower = 150;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 240;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 40.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LDP150I140PE001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LDP150I140PE001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 214.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 86.0;
                spmd.supPowerModelOutCurrent.OutputPower = 150;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 240;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 40.0;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion


            list.Add(sps);
            #endregion

            #region 初始化LD150IC系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LD150IC";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            CreateMode(sps, spm, "LD150IC140W76AD3101", 1.4, 143, 64, 150, 1.6, 150, 0.4, 30, "P", 0.75);


            list.Add(sps);
            #endregion

            #region 初始化LDP200IC系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP200IC";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            #region LD200IC105W76AD3001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD200IC105W76AD3001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 286;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 114;
                spmd.supPowerModelOutCurrent.OutputPower = 200;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 300;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 50;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LD200IC105W76AD3101
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD200IC105W76AD3101";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 286;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 114;
                spmd.supPowerModelOutCurrent.OutputPower = 200;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 300;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 50;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            CreateMode(sps, spm, "LD200IC210W76AD3101", 2.1, 143, 71, 200, 2.5, 150, 0.5, 30, "P", 0.75);

            CreateMode(sps, spm, "LD200IC140W76AD3101", 1.4, 191, 71, 200, 1.5, 200, 0.5, 50, "P", 0.75);

            list.Add(sps);
            #endregion


            #region 初始化LDP240I系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP240I";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            CreateMode(sps, spm, "LDP240I210PE201", 2.1, 171, 91, 240, 2.5, 200, 0.5, 40, "P", 0.8);
            CreateMode(sps, spm, "LDP240I140PE101", 1.4, 228, 137, 240, 2, 240, 0.5, 60, "P", 0.8);
            CreateMode(sps, spm, "LDP240I300PE001", 3.0, 80, 60, 240, 5, 100, 1, 20, "P", 0.8);
            CreateMode(sps, spm, "LDP240I490PE201", 4.9, 62, 34, 240, 5, 80, 1, 20, "P", 0.7);
            CreateMode(sps, spm, "LDP240I630PE201", 6.3, 48, 27, 240, 7, 50, 1.4, 10, "P", 0.7);

            list.Add(sps);
            #endregion

            #region 初始化LDP240IC系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP240IC";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            #region LD240IC105W76AD3001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD240IC105W76AD3001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 343;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 137;
                spmd.supPowerModelOutCurrent.OutputPower = 250;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 360;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 60;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LD240IC105W76AD3101
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD240IC105W76AD3101";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 1.05;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 343;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 137;
                spmd.supPowerModelOutCurrent.OutputPower = 250;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 1.05;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 1.2;
                        cs.Grid.YMax = 360;
                        cs.Grid.XInterval = 0.2;
                        cs.Grid.YInterval = 60;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LD240IC105W76AD3001
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD240IC210W76AD3001";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 2.10;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 171;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 69;
                spmd.supPowerModelOutCurrent.OutputPower = 250;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 2.10;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.5;
                        cs.Grid.YMax = 200;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 40;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            #region LD240IC105W76AD3101
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD240IC210W76AD3101";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 2.10;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 171;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 69;
                spmd.supPowerModelOutCurrent.OutputPower = 250;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 2.10;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.5;
                        cs.Grid.YMax = 200;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 40;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            list.Add(sps);
            #endregion


            #region 初始化LD320IC系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LD320IC";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            #region LD320IC210W76AD3101
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD320IC210W76AD3101";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 2.10;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 229;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 91;
                spmd.supPowerModelOutCurrent.OutputPower = 320;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.7) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 2.10;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.5;
                        cs.Grid.YMax = 250;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 50;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            CreateMode(sps, spm, "LD320IC210W76AD3102", 2.1, 229, 91, 320, 2.5, 240, 0.5, 48, "P", 0.7);

            list.Add(sps);
            #endregion

            #region 初始化LDP320系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDP320";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            CreateMode(sps, spm, "LDP320I210PU001", 2.1, 178, 100, 320, 2.5, 200, 0.5, 40, "P", 0.85);

            CreateMode(sps, spm, "LDP320I210PE101", 2.1, 228, 122, 320, 2.5, 240, 0.5, 48, "P", 0.8);

            CreateMode(sps, spm, "LDP320I210PE201", 2.1, 228, 122, 320, 2.5, 240, 0.5, 48, "P", 0.8);
            CreateMode(sps, spm, "LDP320I280PE201", 2.8, 171, 91, 320, 3, 180, 0.6, 36, "P", 0.8);

            list.Add(sps);
            #endregion

            #region 初始化LD400IC系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LD400IC";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            #region LD400IC210W76AD3101
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = "LD400IC210W76AD3101";
                spm.Version = "v1.0";

                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 80;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 80;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = 2.1;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = 286;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = 69;
                spmd.supPowerModelOutCurrent.OutputPower = 400;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = 2.10;


                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 90;
                spmd.supPowerModelDataTemp.OoutProtect = 100;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 100;
                spmd.supPowerModelDataTemp.IoutProtect = 110;
                spmd.supPowerModelDataTemp.IprotectCurrent = 80;
                spm.SetData(spmd);

                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = 2.5;
                        cs.Grid.YMax = 350;
                        cs.Grid.XInterval = 0.5;
                        cs.Grid.YInterval = 70;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";


                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion

            list.Add(sps);
            #endregion

            #region 初始化LDC400I系列

            sps = new SupPowerSeries();
            sps.CreateTime = DateTime.Now;
            sps.Name = "LDC400I";
            sps.Version = "v1.0.0";
            sps.Guid = Guid.NewGuid().ToString();

            //SupPowerModel spm = null;

            CreateMode(sps, spm, "LDC400I240PU001", 2.4, 182, 140, 400, 3, 200, 0.5, 40, "P", 0.9);

            list.Add(sps);
            #endregion
            #endregion
            return list;

        }
        /// <summary>
        /// 创建模型
        /// </summary>
        /// <param name="sps">系列</param>
        /// <param name="spm">模型</param>
        /// <param name="Name">模型名称</param>
        /// <param name="OutputCurrentMax">最大输出电流</param>
        /// <param name="OutputVoltageMax">最大输出电压</param>
        /// <param name="OutputVoltageMin">最小输出电压</param>
        /// <param name="OutputPower">输出功率</param>
        /// <param name="XMax">图表X轴</param>
        /// <param name="YMax">图表Y轴</param>
        /// <param name="XInterval">图表X轴间隔</param>
        /// <param name="YInterval">图表Y轴间隔</param>
        /// <param name="ModelType">模型类型 P：恒功率 V：恒电压</param>
        /// <param name="Effective">有效值</param>
        private static void CreateMode(SupPowerSeries sps, SupPowerModel spm,
            string Name,
            double OutputCurrentMax, double OutputVoltageMax, double OutputVoltageMin, double OutputPower,
            double XMax, double YMax, double XInterval, double YInterval, string ModelType = "P", double Effective = 0.6)
        {
            #region 
            {
                spm = new SupPowerModel();
                spm.Guid = Guid.NewGuid().ToString();
                spm.SupPowerSeriesGuid = sps.Guid;
                spm.CreateTime = DateTime.Now;
                spm.Name = Name;// "LDC600*014";
                spm.Version = "v1.0";
                spm.ModelType = ModelType;
                #region 初始化实际值
                SupPowerSetPRGMR supPowerSetPRGMR = new SupPowerSetPRGMR();

                supPowerSetPRGMR.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPRGMR.maxCurrent = 100;//最大电流%
                supPowerSetPRGMR.maxVoltage = 89;//最大电压%
                supPowerSetPRGMR.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPRGMR.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPRGMR.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPRGMR.iTPRecoveryP = 100;
                supPowerSetPRGMR.iTPProtectionP = 110;
                supPowerSetPRGMR.iTPCurrent = 80;
                supPowerSetPRGMR.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPRGMR.timerNum = 6;//定时个数

                supPowerSetPRGMR.timingPower1 = 0;//定时1功率%
                supPowerSetPRGMR.timingLength1 = 0;//定时1时长min
                supPowerSetPRGMR.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPRGMR.timingPower2 = 0;
                supPowerSetPRGMR.timingLength2 = 0;
                supPowerSetPRGMR.timingGradientLength2 = 0;
                supPowerSetPRGMR.timingPower3 = 0;
                supPowerSetPRGMR.timingLength3 = 0;
                supPowerSetPRGMR.timingGradientLength3 = 0;
                supPowerSetPRGMR.timingPower4 = 0;
                supPowerSetPRGMR.timingLength4 = 0;
                supPowerSetPRGMR.timingGradientLength4 = 0;
                supPowerSetPRGMR.timingPower5 = 0;
                supPowerSetPRGMR.timingLength5 = 0;
                supPowerSetPRGMR.timingGradientLength5 = 0;
                supPowerSetPRGMR.timingPower6 = 0;
                supPowerSetPRGMR.timingLength6 = 0;
                supPowerSetPRGMR.timingGradientLength6 = 0;

                supPowerSetPRGMR.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPRGMR.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPRGMR.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPRGMR.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPRGMR.ratedPower = 100;//额定功率 W
                supPowerSetPRGMR.rateCurrent = 100;//额定电流 A
                supPowerSetPRGMR.powerDeviation = 1;//功率偏差W
                supPowerSetPRGMR.dimRatio = 100;

                spm.SetConfigPRGMR(supPowerSetPRGMR);

                SupPowerSetPower supPowerSetPower = new SupPowerSetPower();

                supPowerSetPower.workMode = 0;//（0、0-10V 、1 通讯、2 时控、3 pwm、4 恒功率 5、恒流 6 、pwm反向）
                supPowerSetPower.maxCurrent = 100;//最大电流%
                supPowerSetPower.maxVoltage = 89;//最大电压%
                supPowerSetPower.eTPRecoveryP = 90;//外部温度保护恢复点℃
                supPowerSetPower.eTPProtectionP = 100;//外部温度保护保护点℃
                supPowerSetPower.eTPCurrent = 60;//外部温度保护电流%
                supPowerSetPower.iTPRecoveryP = 100;
                supPowerSetPower.iTPProtectionP = 110;
                supPowerSetPower.iTPCurrent = 80;
                supPowerSetPower.timerMode = 0; //定时模式 （0传统定时 1自适应定时）
                supPowerSetPower.timerNum = 6;//定时个数

                supPowerSetPower.timingPower1 = 0;//定时1功率%
                supPowerSetPower.timingLength1 = 0;//定时1时长min
                supPowerSetPower.timingGradientLength1 = 0;//定时1渐变时间min
                supPowerSetPower.timingPower2 = 0;
                supPowerSetPower.timingLength2 = 0;
                supPowerSetPower.timingGradientLength2 = 0;
                supPowerSetPower.timingPower3 = 0;
                supPowerSetPower.timingLength3 = 0;
                supPowerSetPower.timingGradientLength3 = 0;
                supPowerSetPower.timingPower4 = 0;
                supPowerSetPower.timingLength4 = 0;
                supPowerSetPower.timingGradientLength4 = 0;
                supPowerSetPower.timingPower5 = 0;
                supPowerSetPower.timingLength5 = 0;
                supPowerSetPower.timingGradientLength5 = 0;
                supPowerSetPower.timingPower6 = 0;
                supPowerSetPower.timingLength6 = 0;
                supPowerSetPower.timingGradientLength6 = 0;

                supPowerSetPower.maxPowerMapVoltage = 1;//最大功率对应电压V 
                supPowerSetPower.currentSamplingResistance = 200;//电流采样电阻mΩ
                supPowerSetPower.voltageSamplingTotalResistance = 50;//电压采样电阻kΩ
                supPowerSetPower.voltageSamplingResistance = 5;//额定电流 A
                supPowerSetPower.ratedPower = 100;//额定功率 W
                supPowerSetPower.rateCurrent = 100;//额定电流 A
                supPowerSetPower.powerDeviation = 1;//功率偏差W
                supPowerSetPower.dimRatio = 100;//调光比
                spm.SetConfigPower(supPowerSetPower); // 其实没有意义
                #endregion

                // 初始化基础值
                SupPowerModelData spmd = new SupPowerModelData();
                //输出电流的图表数据
                spmd.supPowerModelOutCurrent.OutputCurrentMax = OutputCurrentMax;// 1.4;
                spmd.supPowerModelOutCurrent.OutputVoltageMax = OutputVoltageMax;// 536.0;
                spmd.supPowerModelOutCurrent.OutputVoltageMin = OutputVoltageMin;// 214.0;
                spmd.supPowerModelOutCurrent.OutputPower = OutputPower;// 600.0;
                spmd.supPowerModelOutCurrent.OutputCurrentLow = (spmd.supPowerModelOutCurrent.OutputPower * Effective) / spmd.supPowerModelOutCurrent.OutputVoltageMax;//(spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputVoltageMax;
                spmd.supPowerModelOutCurrent.OutputVoltageLow = (spmd.supPowerModelOutCurrent.OutputPower * Effective) / spmd.supPowerModelOutCurrent.OutputCurrentMax; //(spmd.supPowerModelOutCurrent.OutputPower * 0.6) / spmd.supPowerModelOutCurrent.OutputCurrentMax;
                spmd.supPowerModelOutCurrent.OutputCurrent = OutputCurrentMax;// 1.4;

                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(7.5, 48));
                //spmd.supPowerModelOutCurrent.OutputPowerPoints.Add(new ChartSetSeriesPoint(10, 36));

                //外部温度的图表数据
                spmd.supPowerModelDataTemp.Orecover = 80;
                spmd.supPowerModelDataTemp.OoutProtect = 90;
                spmd.supPowerModelDataTemp.OprotectCurrent = 60;

                spmd.supPowerModelDataTemp.Irecover = 90;
                spmd.supPowerModelDataTemp.IoutProtect = 100;
                spmd.supPowerModelDataTemp.IprotectCurrent = 20;
                spm.SetData(spmd);
                // 初始化图例
                {
                    List<ChartSet> lcs = new List<ChartSet>();
                    {
                        ChartSet cs = new ChartSet();

                        cs.Name = "OutCurrentChart";
                        cs.Grid.XMax = XMax;// 2;
                        cs.Grid.YMax = YMax;// 600;
                        cs.Grid.XInterval = XInterval;// 0.5;
                        cs.Grid.YInterval = YInterval;// 100;
                        //cs.InitOutputCurrent(spmd);
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);

                        cs = new ChartSet();
                        cs.Name = "TempInChart";
                        cs.Grid.XMax = 110;
                        cs.Grid.XInterval = 10;
                        cs.Grid.XTitle = "℃";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.2;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";
                        lcs.Add(cs);


                        cs = new ChartSet();
                        cs.Name = "TimeCtrlChart";
                        cs.Grid.XMax = 24;
                        cs.Grid.XInterval = 1;
                        cs.Grid.XTitle = "( H )";
                        cs.Grid.XLabelFormat = "0";

                        cs.Grid.YMax = 1;
                        cs.Grid.YInterval = 0.1;
                        cs.Grid.YTitle = "";
                        cs.Grid.YLabelFormat = "0%";

                        lcs.Add(cs);
                    }
                    spm.SetCharts(lcs);
                }
                sps.SupPowerModels.Add(spm);
            }
            #endregion
        }
        #region 一起组合用的
        /// <summary>
        /// 根据型号名称去数据库查找模型是否存在
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public SupPowerModel GetSupPowerModelByName(string name)
        {
            return dao._Db.Queryable<SupPowerModel>().First(a => a.Name == name);
        }
        ///// <summary>
        ///// 根据guid找系列
        ///// </summary>
        ///// <param name="guid"></param>
        ///// <returns></returns>
        //public SupPowerSeries GetSupPowerSeriesByGuid(string guid)
        //{
        //    return dao._Db.Queryable<SupPowerSeries>().First(a => a.Guid == guid);
        //}
        #endregion
    }
}
