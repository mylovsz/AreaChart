using SqlSugarManage.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace Common.Common
{
    public class ChartHelper
    {
        /// <summary>
        /// 图表对象初始化
        /// </summary>
        /// <param name="chart"></param>
        /// <param name="ChartSet"></param>
        /// <returns></returns>
        public static void ChartInit(Chart chart, ChartSet cs)
        {
            // 清空所有内容
            chart.Series.Clear();
            chart.Legends.Clear();

            //整体背景色
            chart.ChartAreas[0].BackColor = cs.Grid.GridBackColor;
            
            #region 网格XY轴初始化
            Axis[] axes = chart.ChartAreas[0].Axes;//获取图表的两个轴对象 x y
            // axes[0] 代表X轴
            axes[0].MajorGrid.LineColor = cs.Grid.GridLineColor;
            axes[0].MajorGrid.LineWidth = cs.Grid.GridLineWidth;
            axes[0].LineWidth = cs.Grid.XLineWidth;
            axes[0].LineColor = cs.Grid.XColor;
            axes[0].Maximum = cs.Grid.XMax;
            axes[0].Minimum = cs.Grid.XMin;
            axes[0].Interval = cs.Grid.XInterval;
            axes[0].Title = cs.Grid.XTitle;
            axes[0].TitleAlignment = (StringAlignment)cs.Grid.XTitleAlignment;
            axes[0].TextOrientation = (TextOrientation)cs.Grid.XTextOrientation;
            axes[0].LabelStyle.Format = cs.Grid.XLabelFormat;

            // axes[1] 代表Y轴
            axes[1].MajorGrid.LineColor = cs.Grid.GridLineColor;
            axes[1].MajorGrid.LineWidth = cs.Grid.GridLineWidth;
            axes[1].LineWidth = cs.Grid.YLineWidth;
            axes[1].LineColor = cs.Grid.YColor;
            axes[1].Maximum = cs.Grid.YMax;
            axes[1].Minimum = cs.Grid.YMin;
            axes[1].Interval = cs.Grid.YInterval;
            axes[1].Title = cs.Grid.YTitle;
            axes[1].TitleAlignment = (StringAlignment)cs.Grid.YTitleAlignment;
            axes[1].TextOrientation = (TextOrientation)cs.Grid.YTextOrientation;
            axes[1].LabelStyle.Format = cs.Grid.YLabelFormat;
            #endregion

            #region 初始图例
            foreach(ChartSetSerie seriesSet in cs.Series)
            {
                Series series = new Series();
                series.Name = seriesSet.Name;
                series.ChartType = (SeriesChartType)seriesSet.ChartType;
                series.Color = seriesSet.LineColor;
                series.BorderWidth = seriesSet.BorderWidth;
                series.BorderDashStyle = (ChartDashStyle)seriesSet.BorderDashStyle;
                //series.ToolTip = seriesSet.ToolTip;//取消不相关的点显示（去除原因，放在线上，会显示就近点的值，会造成误解）
                if (seriesSet.IsValueShownAsLabel == true)
                {
                    series.Label = seriesSet.ToolTip;
                }
                foreach(ChartSetSeriesPoint point in seriesSet.Points)
                {
                    series.Points.AddXY(Math.Round(point.X, 2), Math.Round(point.Y, 2));
                }
                chart.Series.Add(series);
            }
            #endregion

        }
    }
}
