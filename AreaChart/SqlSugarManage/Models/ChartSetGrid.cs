using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace SqlSugarManage.Models
{
    /// <summary>
    /// 图表的网格、X、Y轴，颜色粗细设置
    /// </summary>
    public class ChartSetGrid
    {
        #region 网格
        private int gridBackAlpha = 255;
        private int gridBackRed = 255;
        private int gridBackGreen = 255;
        private int gridBackBlue = 255;

        private int gridLineAlpha = 255;
        private int gridLineRed = 206;
        private int gridLineGreen = 206;
        private int gridLineBlue = 206;

        private int gridLineWidth = 1;
        #endregion

        #region X轴
        private int xAlpha = 255;
        private int xRed = 181;
        private int xGreen = 181;
        private int xBlue = 181;

        private int xLineWidth = 2;

        private double xMax = 15;
        private double xMin = 0;
        private double xInterval = 2.5;

        private string xTitle = "(A)";
        private int xTitleAlignment = 2;
        private int xTextOrientation = 1;
        private string xLabelFormat = "0.0";//这个值会影响xInterval的显示
        #endregion

        #region Y轴
        private int yAlpha = 255;
        private int yRed = 181;
        private int yGreen = 181;
        private int yBlue = 181;

        private int yLineWidth = 2;

        private double yMax = 72;
        private double yMin = 0;
        private double yInterval = 12;

        private string yTitle = "(V)";
        private int yTitleAlignment = 2;
        private int yTextOrientation = 1;
        private string yLabelFormat = "0";
        #endregion

        #region View 使用 不入数据库

        /// <summary>
        /// 获取网格背景色
        /// </summary>
        public Color GridBackColor { get { return Color.FromArgb(gridBackAlpha, gridBackRed, gridBackGreen, gridBackBlue); } }
        /// <summary>
        /// 获取网格线的颜色
        /// </summary>
        public Color GridLineColor
        {
            get { return Color.FromArgb(gridLineAlpha, gridLineRed, gridLineGreen, gridLineBlue); }
            set
            {
                Color color = value;
                gridLineAlpha = color.A;
                gridLineRed = color.R;
                gridLineGreen = color.G;
                gridLineBlue = color.B;
            }
        }
        /// <summary>
        /// 网格线的粗细
        /// </summary>
        public int GridLineWidth { get => gridLineWidth; set => gridLineWidth = value; }
        /// <summary>
        /// X轴线颜色
        /// </summary>
        public Color XColor
        {
            get { return Color.FromArgb(xAlpha, xRed, xGreen, xBlue); }
            set
            {
                Color color = value;
                xAlpha = color.A;
                xRed = color.R;
                xGreen = color.G;
                xBlue = color.B;
            }
        }
        /// <summary>
        /// X轴粗细
        /// </summary>
        public int XLineWidth { get => xLineWidth; set => xLineWidth = value; }
        /// <summary>
        /// X轴最大值
        /// </summary>
        public double XMax { get => xMax; set => xMax = value; }
        /// <summary>
        /// X轴最小值
        /// </summary>
        public double XMin { get => xMin; set => xMin = value; }
        /// <summary>
        /// X轴间隔，这个值会被XLabelFormat影响显示
        /// </summary>
        public double XInterval { get => xInterval; set => xInterval = value; }

        /// <summary>
        /// X轴标题
        /// </summary>
        public string XTitle { get => xTitle; set => xTitle = value; }
        /// <summary>
        /// X轴标题显示位置
        /// </summary>
        public int XTitleAlignment { get => xTitleAlignment; set => xTitleAlignment = value; }
        /// <summary>
        /// X轴标题显示方向
        /// </summary>
        public int XTextOrientation { get => xTextOrientation; set => xTextOrientation = value; }
        /// <summary>
        /// X轴标签显示格式，这个值会影响xInterval的显示
        /// </summary>
        public string XLabelFormat { get => xLabelFormat; set => xLabelFormat = value; }

        /// <summary>
        /// Y轴颜色

        /// </summary>
        public Color YColor
        {
            get { return Color.FromArgb(yAlpha, yRed, yGreen, yBlue); }
            set
            {
                Color color = value;
                yAlpha = color.A;
                yRed = color.R;
                yGreen = color.G;
                yBlue = color.B;
            }
        }
        /// <summary>
        /// Y轴粗细
        /// </summary>
        public int YLineWidth { get => yLineWidth; set => yLineWidth = value; }
        /// <summary>
        /// Y轴最大值
        /// </summary>
        public double YMax { get => yMax; set => yMax = value; }
        /// <summary>
        /// Y轴最小值
        /// </summary>
        public double YMin { get => yMin; set => yMin = value; }
        /// <summary>
        /// Y轴间隔
        /// </summary>
        public double YInterval { get => yInterval; set => yInterval = value; }

        /// <summary>
        /// X轴标题
        /// </summary>
        public string YTitle { get => yTitle; set => yTitle = value; }
        /// <summary>
        /// X轴标题显示位置
        /// </summary>
        public int YTitleAlignment { get => yTitleAlignment; set => yTitleAlignment = value; }
        /// <summary>
        /// X轴标题显示方向
        /// </summary>
        public int YTextOrientation { get => yTextOrientation; set => yTextOrientation = value; }
        /// <summary>
        /// Y轴标签显示格式
        /// </summary>
        public string YLabelFormat { get => yLabelFormat; set => yLabelFormat = value; }

        #endregion
    }

}
