using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SqlSugarManage.Models
{
    /// <summary>
    /// 图表设置，网格xy轴，图例(要画的线)样式，
    /// </summary>
    public class ChartSet
    {
        /// <summary>
        /// 图表名称，如输出电流，定时器
        /// </summary>
        public string Name { get; set; }

        private ChartSetGrid grid = new ChartSetGrid();
        private List<ChartSetSerie> series = new List<ChartSetSerie>();
        /// <summary>
        /// 区域线
        /// </summary>
        public ChartSetGrid Grid { get => grid; set => grid = value; }
        /// <summary>
        /// 图例的样式初始化
        /// </summary>
        public List<ChartSetSerie> Series { get => series; set => series = value; }

        /// <summary>
        /// 输出电流图例的样式
        /// </summary>
        /// <param name="spmd"></param>
        public void InitOutputCurrent(SupPowerModelData spmd,bool HoldVoltageShow=true,bool VariableOutputRegion=true,double val=0.6)
        {
            Series.Clear();

            //虚线-工作区域
            ChartSetSerie css = new ChartSetSerie();
            css.LineColor = Color.Gray;
            css.BorderDashStyle = 1;
            css.Points.AddRange(spmd.supPowerModelOutCurrent.GetOutputWorkingPoint());
            Series.Add(css);

            //虚线-工作区域-标签
            ChartSetSerie css5 = new ChartSetSerie();
            css5.Name = "5";
            css5.LineColor = Color.Orange;
            //css5.IsValueShownAsLabel = false;//true;
            css5.Points.AddRange(spmd.supPowerModelOutCurrent.GetOutputWorkingPointLabel());
            Series.Add(css5);

            //圆弧梯形-最佳工作区域
            ChartSetSerie css1 = new ChartSetSerie();
            css1.Name = "1";
            css1.LineColor = Color.Blue;
            css1.Points.AddRange(spmd.supPowerModelOutCurrent.GetOutputBestWorkingPoint1());
            Series.Add(css1);

            //圆弧梯形-最佳工作区域
            ChartSetSerie css2 = new ChartSetSerie();
            css2.Name = "2";
            css2.ChartType = 4;
            css2.LineColor = Color.Blue;
            css2.Points.AddRange(spmd.supPowerModelOutCurrent.GetOutputBestWorkingPoint2(val));
            Series.Add(css2);

            if (VariableOutputRegion)
            {
                //橙色-可变输出区域
                ChartSetSerie css3 = new ChartSetSerie();
                css3.Name = "OutputCurrent";
                css3.LineColor = Color.Orange;
                css3.Points.AddRange(spmd.supPowerModelOutCurrent.GetOutputDimingPoint());
                Series.Add(css3);

                //橙色-可变输出区域-标签
                ChartSetSerie css4 = new ChartSetSerie();
                css4.Name = "OutputCurrentLabel";
                css4.LineColor = Color.Orange;
                css4.IsValueShownAsLabel = true;
                css4.Points.AddRange(spmd.supPowerModelOutCurrent.GetOutputDimingPointLabel());
                Series.Add(css4);
            }
            

            if (HoldVoltageShow)
            {
                //红色-可变输出区域-恒压
                ChartSetSerie css6 = new ChartSetSerie();
                css6.Name = "HoldVoltage";
                css6.LineColor = Color.Red;
                //css6.IsValueShownAsLabel = true;
                css6.Points.AddRange(spmd.supPowerModelOutCurrent.GetOutputHoldVoltagePoint());
                Series.Add(css6);
            }
        }
        /// <summary>
        /// 温度图例的样式 外部
        /// </summary>
        /// <param name="spmd"></param>
        public void InitDataTemp(SupPowerModelData spmd)
        {
            Series.Clear();

            ChartSetSerie css = new ChartSetSerie();
            css.LineColor = Color.Blue;
            css.ToolTip = "( #VALX   ,  #VALY  )";

            css.Points.AddRange(spmd.supPowerModelDataTemp.GetDataOTempPoint());
            Series.Add(css);
        }
        /// <summary>
        /// 温度图例的样式 内部
        /// </summary>
        /// <param name="spmd"></param>
        public void InitDataInTemp(SupPowerModelData spmd)
        {
            Series.Clear();

            ChartSetSerie css = new ChartSetSerie();
            css.LineColor = Color.Blue;
            css.ToolTip = "( #VALX   ,  #VALY  )";
            css.Points.AddRange(spmd.supPowerModelDataTemp.GetDataITempIrecoverPoint());//恢复点
            Series.Add(css);

            ChartSetSerie css1 = new ChartSetSerie();
            css1.Name = "css1";
            css1.LineColor = Color.Red;
            css1.ToolTip = "( #VALX   ,  #VALY  )";
            css1.Points.AddRange(spmd.supPowerModelDataTemp.GetDataITempIoutProtectPoint());//保护点
            Series.Add(css1);
        }

        /// <summary>
        /// 时控图例的样式
        /// </summary>
        /// <param name="spmd"></param>
        public void InitDataTimeCtrl(SupPowerModelData spmd)
        {
            Series.Clear();

            ChartSetSerie css = new ChartSetSerie();
            css.LineColor = Color.Orange;
            css.ToolTip = "( #VALX   ,  #VALY )";
            css.Points.AddRange(spmd.supPowerModelDataTimeCtrl.GetTimeCtrlPoint());
            Series.Add(css);
        }
    }
}
