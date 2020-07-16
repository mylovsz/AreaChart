using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms.DataVisualization.Charting;

namespace AreaChart.Common
{
    public class PointXY
    {
        public double X;
        public double Y;

        public PointXY(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
    /// <summary>
    /// 图表的网格、X、Y轴，颜色粗细设置
    /// </summary>
    public class ChartGridXYSet
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
        private int xRed = 144;
        private int xGreen = 144;
        private int xBlue = 144;

        private int xLineWidth = 2;

        private double xMax = 15;
        private double xMin = 0;
        private double xInterval = 2.5;
        #endregion

        #region Y轴
        private int yAlpha = 255;
        private int yRed = 144;
        private int yGreen = 144;
        private int yBlue = 144;

        private int yLineWidth = 2;

        private double yMax = 72;
        private double yMin = 0;
        private double yInterval = 12;
        #endregion

        #region View 使用 不入数据库
        public int GridBackAlpha { get => gridBackAlpha; set => gridBackAlpha = value; }
        public int GridBackRed { get => gridBackRed; set => gridBackRed = value; }
        public int GridBackGreen { get => gridBackGreen; set => gridBackGreen = value; }
        public int GridBackBlue { get => gridBackBlue; set => gridBackBlue = value; }
        /// <summary>
        /// 获取网格背景色
        /// </summary>
        public Color GridBackColor { get{return Color.FromArgb(GridBackAlpha, GridBackRed, GridBackGreen, GridBackBlue); } }

        public int GridLineAlpha { get => gridLineAlpha; set => gridLineAlpha = value; }
        public int GridLineRed { get => gridLineRed; set => gridLineRed = value; }
        public int GridLineGreen { get => gridLineGreen; set => gridLineGreen = value; }
        public int GridLineBlue { get => gridLineBlue; set => gridLineBlue = value; }
        /// <summary>
        /// 获取网格线的颜色
        /// </summary>
        public Color GridLineColor { get { return Color.FromArgb(GridLineAlpha, GridLineRed, GridLineGreen, GridLineBlue); } }
        /// <summary>
        /// 网格线的粗细
        /// </summary>
        public int GridLineWidth { get => gridLineWidth; set => gridLineWidth = value; }


        public int XAlpha { get => xAlpha; set => xAlpha = value; }
        public int XRed { get => xRed; set => xRed = value; }
        public int XGreen { get => xGreen; set => xGreen = value; }
        public int XBlue { get => xBlue; set => xBlue = value; }
        /// <summary>
        /// X轴线颜色
        /// </summary>
        public Color XColor { get { return Color.FromArgb(XAlpha, XRed, XGreen, XBlue); } }
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
        /// X轴间隔
        /// </summary>
        public double XInterval { get => xInterval; set => xInterval = value; }

        public int YAlpha { get => yAlpha; set => yAlpha = value; }
        public int YRed { get => yRed; set => yRed = value; }
        public int YGreen { get => yGreen; set => yGreen = value; }
        public int YBlue { get => yBlue; set => yBlue = value; }
        /// <summary>
        /// Y轴颜色

        /// </summary>
        public Color YColor { get { return Color.FromArgb(YAlpha, YRed, YGreen, YBlue); } }
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
        #endregion
    }

    /// <summary>
    /// 数据点集形成的线，颜色粗细设置
    /// </summary>
    public class ChartConfigArea
    {
        private string name = "default";

        private int chartType = 3;


        private int borderAlpha = 255;
        private int borderRed = 255;
        private int borderGreen = 0;
        private int borderBlue = 0;

        private int borderWidth = 1;
        private int borderDashStyle = 1;

        private bool isValueShownAsLabel = false;
        private string label = "( #VALX A  ,  #VALY V )";

        private List<PointXY> points = new List<PointXY>();

        #region View 使用
        /// <summary>
        /// 数据线条的名字
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 数据展示的样式，默认是线
        /// </summary>
        public int ChartType { get => chartType; set => chartType = value; }
        
        public int BorderAlpha { get => borderAlpha; set => borderAlpha = value; }
        public int BorderRed { get => borderRed; set => borderRed = value; }
        public int BorderGreen { get => borderGreen; set => borderGreen = value; }
        public int BorderBlue { get => borderBlue; set => borderBlue = value; }
        /// <summary>
        /// 线条颜色
        /// </summary>
        public Color BorderColor { get { return Color.FromArgb(BorderAlpha, BorderRed, BorderGreen, BorderBlue); } }
        /// <summary>
        /// 线条粗细
        /// </summary>
        public int BorderWidth { get => borderWidth; set => borderWidth = value; }
        /// <summary>
        /// 线样式，默认实线
        /// </summary>
        public int BorderDashStyle { get => borderDashStyle; set => borderDashStyle = value; }
        /// <summary>
        /// 是否展示对应数据点的标签
        /// </summary>
        public bool IsValueShownAsLabel { get => isValueShownAsLabel; set => isValueShownAsLabel = value; }
        /// <summary>
        /// 标签展示格式 默认 (x,y)
        /// </summary>
        public string Label { get => label; set => label = value; }

        /// <summary>
        /// 数据点集
        /// </summary>
        public List<PointXY> Points { get => points; set => points = value; }
        #endregion
    }

    
    /// <summary>
    /// 
    /// </summary>
    public class ChartConfig
    {
        public ChartGridXYSet Gird = new ChartGridXYSet();
        public List<ChartConfigArea> Areas = new List<ChartConfigArea>();

        public void Test()
        {
            ChartConfigArea area = new ChartConfigArea();
            area.Name = "1";
            area.Points.Add(new PointXY(1, 60));
            area.Points.Add(new PointXY(10, 60));
            area.Points.Add(new PointXY(10, 24));
            area.Points.Add(new PointXY(1, 24));
            area.Points.Add(new PointXY(1, 60));
            Areas.Add(area);

            area = new ChartConfigArea();
            area.Name = "2";
            area.Points.Add(new PointXY(2, 61));
            area.Points.Add(new PointXY(10, 60));
            area.Points.Add(new PointXY(10, 24));
            area.Points.Add(new PointXY(1, 24));
            area.Points.Add(new PointXY(2, 61));
            area.BorderRed = 0;
            area.BorderGreen = 255;
            area.BorderBlue = 0;
            Areas.Add(area);
        }

        public void Move()
        {
            ChartConfigArea area = Areas.FirstOrDefault(a => a.Name == "2");
            for(int i = 0;i<area.Points.Count;i++)
            {
                area.Points[i].X += 0.5;
            }
        }
    }
}
