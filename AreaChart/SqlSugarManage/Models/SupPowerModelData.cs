using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugarManage.Models
{
    public class SupPowerModelData
    {
        public SupPowerModelOutCurrent supPowerModelOutCurrent=new SupPowerModelOutCurrent();
        public SupPowerModelDataTemp supPowerModelDataTemp=new SupPowerModelDataTemp();
        public SupPowerModelDataTimeCtrl supPowerModelDataTimeCtrl=new SupPowerModelDataTimeCtrl();

    }

    /// <summary>
    /// 输出电流的图表配置
    /// </summary>
    public class SupPowerModelOutCurrent
    {
        #region 仅针对输出电流
        /// <summary>
        /// 最大输出电流 12.5
        /// </summary>
        public double OutputCurrentMax { get; set; }
        /// <summary>
        /// 最小输出电流  1.0
        /// </summary>
        public double OutputCurrentMin { get { return Math.Round(OutputPower / OutputVoltageMax / 10, 2); } }
        /// <summary>
        /// 最大输出电压60
        /// </summary>
        public double OutputVoltageMax { get; set; }
        /// <summary>
        /// 最小输出电压
        /// </summary>
        public double OutputVoltageMin { get; set; }
        /// <summary>
        /// 最大输出功率 600w
        /// </summary>
        public double OutputPower { get; set; }
        /// <summary>
        ///  蓝线 弧线区电压 等硬件告知的值 最大功率的60%
        /// </summary>
        public double OutputVoltageLow { get; set; }
        /// <summary>
        /// 蓝线 弧线区 y 最大功率的60%
        /// </summary>
        public double OutputCurrentLow { get; set; }
        /// <summary>
        /// 外部输入电流值 1-12.5
        /// </summary>
        public double OutputCurrent { get; set; }

        ///// <summary>
        ///// 最佳区域 蓝线左下 弧线图
        ///// </summary>
        ////public List<ChartSetSeriesPoint> OutputPowerPoints = new List<ChartSetSeriesPoint>();
        
        /// <summary>
        /// 获取当前电流下最大电压值
        /// </summary>
        /// <param name="current">当前电流</param>
        /// <returns></returns>
        public double GetOutputCurrentVoltageMax(double current)
        {
            if (current == 0) return OutputVoltageMax;

            double voltage = OutputPower / current;//  (600/12)   (600/6)
            if (voltage > OutputVoltageMax)
                return OutputVoltageMax;
            else
            {
                return Math.Round((Math.Round(voltage / OutputVoltageMax * 100)) * OutputVoltageMax / 100.0, 2);
            }
            //return Math.Round(voltage, 2);
        }
        
        //所有点都是从右上角开始的

        /// <summary>
        /// 工作区-虚线
        /// </summary>
        /// <returns></returns>
        public List<ChartSetSeriesPoint> GetOutputWorkingPoint()
        {
            List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();
            double a = OutputPower / OutputVoltageMax;
            double v = OutputPower / OutputCurrentMax;
            points.Add(new ChartSetSeriesPoint(a, OutputVoltageMax));

            double xx = a;
            // 此处为工作曲线
            while (xx< OutputCurrentMax)
            {
                points.Add(new ChartSetSeriesPoint(xx, Math.Round(OutputPower/xx,2)));
                xx += 0.01;
            }
            
            points.Add(new ChartSetSeriesPoint(OutputCurrentMax, v));
            points.Add(new ChartSetSeriesPoint(OutputCurrentMax, OutputVoltageMin));
            points.Add(new ChartSetSeriesPoint(OutputCurrentMax / 10, OutputVoltageMin));
            points.Add(new ChartSetSeriesPoint(a / 10, OutputVoltageLow));
            points.Add(new ChartSetSeriesPoint(a / 10, OutputVoltageMax));
            points.Add(new ChartSetSeriesPoint(a, OutputVoltageMax));

            return points;
        }
        /// <summary>
        /// 虚线的右下标签
        /// </summary>
        /// <returns></returns>
        public List<ChartSetSeriesPoint> GetOutputWorkingPointLabel()
        {
            List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();
            points.Add(new ChartSetSeriesPoint(OutputCurrentMax, OutputVoltageMin));
            return points;
        }
        /// <summary>
        /// 最佳工作区，蓝线-右上的
        /// </summary>
        /// <returns></returns>
        public List<ChartSetSeriesPoint> GetOutputBestWorkingPoint1()
        {
            List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();
            double a = OutputPower / OutputVoltageMax;
            double v = OutputPower / OutputCurrentMax;
            points.Add(new ChartSetSeriesPoint(OutputCurrentLow, OutputVoltageMax));
            points.Add(new ChartSetSeriesPoint(a, OutputVoltageMax));
            // 此处为工作曲线

            double aa = OutputCurrentMax - a;
            double xx = a;
            // 此处为工作曲线
            while (xx < OutputCurrentMax)
            {
                points.Add(new ChartSetSeriesPoint(xx, Math.Round(OutputPower / xx, 2)));
                xx += 0.01;
            }

            points.Add(new ChartSetSeriesPoint(OutputCurrentMax, v));
            points.Add(new ChartSetSeriesPoint(OutputCurrentMax, OutputVoltageLow));
            return points;
        }
        /// <summary>
        /// 最佳工作区  -蓝线圆弧 左下    val = HID为0.6 LED为 0.7
        /// </summary>
        /// <returns></returns>
        public List<ChartSetSeriesPoint> GetOutputBestWorkingPoint2(double val)
        {
            List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();
            //points.Add(new ChartSetSeriesPoint(OutputCurrentLow, OutputVoltageMax));
            // 此处为工作曲线
            //foreach (ChartSetSeriesPoint p in OutputPowerPoints)
            //{
            //    points.Add(p);
            //}
            //points.Add(new ChartSetSeriesPoint(OutputCurrentMax, OutputVoltageLow));

            double ai = (OutputPower * val) / OutputVoltageMax;
            
            points.Add(new ChartSetSeriesPoint(ai, OutputVoltageMax));
            while (ai<= OutputCurrentMax)
            {
                ai += 0.01;
                double av = (OutputPower* val) / ai;
                if (ai> OutputCurrentMax)
                {
                    points.Add(new ChartSetSeriesPoint(OutputCurrentMax, av));
                    break;
                }
                points.Add(new ChartSetSeriesPoint(ai, av));
            }
            return points;
        }
        /// <summary>
        /// 最佳调光区 橙色
        /// </summary>
        /// <returns></returns>
        public List<ChartSetSeriesPoint> GetOutputDimingPoint()
        {
            List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();
            double a = OutputPower / OutputVoltageMax;//  600/60=10
            double v = OutputPower / OutputCurrentMax;//  600/12.5=48
            double cv = GetOutputCurrentVoltageMax(OutputCurrent);//

            points.Add(new ChartSetSeriesPoint(OutputCurrent, cv));  //1

            double x, y;
            if (OutputCurrent > a || OutputCurrent <= (OutputCurrentMax / 10))
            {
                if (OutputCurrent <= (OutputCurrentMax / 10))
                    x = OutputCurrent;
                else
                    x = OutputCurrent / 10;
                {
                    double c = a / 10;
                    double d = OutputVoltageLow;
                    double e = OutputCurrentMax / 10;
                    double f = OutputVoltageMin;
                    y = (d - f) * (x - c) / (c - e) + d;
                }
            }
            else
            {
                x = a / 10;
                y = OutputVoltageLow;
            }
            if (OutputCurrent > (OutputCurrentMax / 10))
            {
                points.Add(new ChartSetSeriesPoint(OutputCurrent, OutputVoltageMin)); // 2
                points.Add(new ChartSetSeriesPoint(OutputCurrentMax / 10, OutputVoltageMin)); //3
                points.Add(new ChartSetSeriesPoint(x, y));   //4
                points.Add(new ChartSetSeriesPoint(x, cv));  //5
            }
            else
            {
                points.Add(new ChartSetSeriesPoint(x, y));   //2
                points.Add(new ChartSetSeriesPoint(a / 10, OutputVoltageLow));  //3
                points.Add(new ChartSetSeriesPoint(a / 10, OutputVoltageMax));  //4
            }

            points.Add(new ChartSetSeriesPoint(OutputCurrent, cv));//6
            return points;
        }
        /// <summary>
        /// 恒压工作区 上边线，红色
        /// </summary>
        /// <returns></returns>
        public List<ChartSetSeriesPoint> GetOutputHoldVoltagePoint()
        {
            List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();
            double a = OutputPower / OutputVoltageMax;//  600/60=10
            double v = OutputPower / OutputCurrentMax;//  600/12.5=48
            double cv = GetOutputCurrentVoltageMax(OutputCurrent);//

            points.Add(new ChartSetSeriesPoint(OutputCurrent, cv));  //1

            double x, y;
            if (OutputCurrent > a || OutputCurrent <= (OutputCurrentMax / 10))
            {
                if (OutputCurrent <= (OutputCurrentMax / 10))
                    x = OutputCurrent;
                else
                    x = OutputCurrent / 10;
                {
                    double c = a / 10;
                    double d = OutputVoltageLow;
                    double e = OutputCurrentMax / 10;
                    double f = OutputVoltageMin;
                    y = (d - f) * (x - c) / (c - e) + d;
                }
            }
            else
            {
                x = a / 10;
                y = OutputVoltageLow;
            }
            if (OutputCurrent > (OutputCurrentMax / 10))
            {
                points.Add(new ChartSetSeriesPoint(x, cv));  //2
            }
            else
            {
                points.Add(new ChartSetSeriesPoint(a / 10, OutputVoltageMax));  //2
            }
            return points;
        }
        /// <summary>
        /// 最佳调光 橙色 右上标签
        /// </summary>
        /// <returns></returns>
        public List<ChartSetSeriesPoint> GetOutputDimingPointLabel()
        {
            List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();
            double cv = GetOutputCurrentVoltageMax(OutputCurrent);
            points.Add(new ChartSetSeriesPoint(OutputCurrent, cv));
            return points;
        }
        
        #endregion
    }

    /// <summary>
    /// 外部温度的图表配置
    /// </summary>
    public class SupPowerModelDataTemp
    {
        /// <summary>
        /// 外部恢复点
        /// </summary>
        public double Orecover = 80;
        /// <summary>
        /// 外部保护点
        /// </summary>
        public double OoutProtect = 90;
        /// <summary>
        /// 外部输出电流
        /// </summary>
        public double OprotectCurrent = 60;

        public List<ChartSetSeriesPoint> GetDataOTempPoint()
        {
            List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();

            points.Add(new ChartSetSeriesPoint(0, 1));
            points.Add(new ChartSetSeriesPoint(Orecover, 1));
            points.Add(new ChartSetSeriesPoint(OoutProtect, OprotectCurrent/100));
            points.Add(new ChartSetSeriesPoint(110, OprotectCurrent/100));
            return points;
        }

        /// <summary>
        /// 内部恢复点
        /// </summary>
        public double Irecover = 80;
        /// <summary>
        /// 内部保护点
        /// </summary>
        public double IoutProtect = 100;
        /// <summary>
        /// 内部输出电流
        /// </summary>
        public double IprotectCurrent = 20;

        public double Iinterval = 10;

        public List<ChartSetSeriesPoint> GetDataITempIrecoverPoint()
        {
            List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();

            points.Add(new ChartSetSeriesPoint(0, 1));
            points.Add(new ChartSetSeriesPoint(Irecover, 1));
            points.Add(new ChartSetSeriesPoint(Irecover, IprotectCurrent / 100));
            points.Add(new ChartSetSeriesPoint(110, IprotectCurrent / 100));

            //points.Add(new ChartSetSeriesPoint(0, 1));
            //points.Add(new ChartSetSeriesPoint(Irecover, 1));
            //points.Add(new ChartSetSeriesPoint(IoutProtect, IprotectCurrent/100));
            //points.Add(new ChartSetSeriesPoint(100, IprotectCurrent/100));
            return points;

        }
        public List<ChartSetSeriesPoint> GetDataITempIoutProtectPoint()
        {
            List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();

            points.Add(new ChartSetSeriesPoint(0, 1));
            points.Add(new ChartSetSeriesPoint(IoutProtect, 1));
            points.Add(new ChartSetSeriesPoint(IoutProtect, IprotectCurrent / 100));
            points.Add(new ChartSetSeriesPoint(110, IprotectCurrent / 100));

            //points.Add(new ChartSetSeriesPoint(0, 1));
            //points.Add(new ChartSetSeriesPoint(Irecover, 1));
            //points.Add(new ChartSetSeriesPoint(IoutProtect, IprotectCurrent/100));
            //points.Add(new ChartSetSeriesPoint(100, IprotectCurrent/100));
            return points;

        }
    }

    /// <summary>
    /// 定时控制的图表
    /// </summary>
    public class SupPowerModelDataTimeCtrl
    {
        double starttime = 0;
        double endtime = 24 * 60;

        /// <summary>
        /// 汇总6个点
        /// </summary>
        /// <returns></returns>
        public List<ChartSetSeriesPoint> GetTimeCtrlPoint()
        {
            List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();

            points.AddRange(Point1);
            points.AddRange(Point2);
            points.AddRange(Point3);
            points.AddRange(Point4);
            points.AddRange(Point5);
            points.AddRange(Point6);
            return points;
        }

        public int TimeCtrlMode=0;
        /// <summary>
        /// 调光值
        /// </summary>
        public double level1 = 100;
        /// <summary>
        /// 保持时间
        /// </summary>
        public double hold1 = 60;
        /// <summary>
        /// 渐变时间
        /// </summary>
        public double tran1 = 60;

        

        List<ChartSetSeriesPoint> Point1
        {
            get
            {
                List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();
                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(starttime), level1/100));
                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1), level1/100));
                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1), level2/100));

                return points;
            }
        }

        public double level2 = 90;
        public double hold2 = 60;
        public double tran2 = 60;
        List<ChartSetSeriesPoint> Point2
        {
            get
            {
                List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();

                //points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1), level2));
                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1 + hold2), level2/100));
                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1 + hold2 + tran2), level3/100));

                return points;
            }
        }

        public double level3 = 80;
        public double hold3 = 60;
        public double tran3 = 60;
        List<ChartSetSeriesPoint> Point3
        {
            get
            {
                List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();

                //points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1 + hold2 + tran2), level3));
                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1 + hold2 + tran2 + hold3), level3/100));
                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1 + hold2 + tran2 + hold3 + tran3), level4/100));

                return points;
            }
        }

        public double level4 = 70;
        public double hold4 = 60;
        public double tran4 = 60;
        List<ChartSetSeriesPoint> Point4
        {
            get
            {
                List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();

                //points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1 + hold2 + tran2 + hold3 + tran3), level4));
                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1 + hold2 + tran2 + hold3 + tran3 + hold4), level4/100));
                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1 + hold2 + tran2 + hold3 + tran3 + hold4 + tran4), level5/100));

                return points;
            }
        }

        public double level5 = 60;
        public double hold5 = 60;
        public double tran5 = 60;
        List<ChartSetSeriesPoint> Point5
        {
            get
            {
                List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();

                //points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1 + hold2 + tran2 + hold3 + tran3 + hold4 + tran4), level5));
                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1 + hold2 + tran2 + hold3 + tran3 + hold4 + tran4 + hold5), level5/100));
                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(hold1 + tran1 + hold2 + tran2 + hold3 + tran3 + hold4 + tran4 + hold5 + tran5), level6/100));

                return points;
            }
        }

        public double level6 = 50;
        public double hold6 =  60;
        public double tran6 = 60;
        List<ChartSetSeriesPoint> Point6
        {
            get
            {
                List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();

                points.Add(new ChartSetSeriesPoint(ConvertToDecHour(endtime), level6/100));

                return points;
            }
        }

        double ConvertToDecHour(double min)
        {
            return min / 60;
        }

        
    }
}
