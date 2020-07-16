using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace SqlSugarManage.Models
{
    /// <summary>
    /// 数据点集形成的线，颜色粗细设置
    /// </summary>
    public class ChartSetSerie
    {
        private string name = "default";

        private int chartType = 3;

        private int alpha = 255;
        private int red = 255;
        private int green = 0;
        private int blue = 0;

        private int borderWidth = 2;
        private int borderDashStyle = 5;
        private string toolTip = "( #VALX A  ,  #VALY V )";

        private bool isValueShownAsLabel = false;
        //private string label = "( #VALX A  ,  #VALY V )";
        private List<ChartSetSeriesPoint> points = new List<ChartSetSeriesPoint>();

        /// <summary>
        /// 数据点集
        /// </summary>
        public List<ChartSetSeriesPoint> Points { get => points; set => points = value; }

        #region View 使用
        /// <summary>
        /// 数据线条的名字
        /// </summary>
        public string Name { get => name; set => name = value; }
        /// <summary>
        /// 数据展示的样式，默认是线
        /// </summary>
        public int ChartType { get => chartType; set => chartType = value; }

        //public int BorderAlpha { get => alpha; set => alpha = value; }
        //public int BorderRed { get => red; set => red = value; }
        //public int BorderGreen { get => green; set => green = value; }
        //public int BorderBlue { get => blue; set => blue = value; }
        /// <summary>
        /// 线条颜色
        /// </summary>
        public Color LineColor
        {
            get { return Color.FromArgb(alpha, red, green, blue); }
            set
            {
                Color color = value;
                alpha = color.A;
                red = color.R;
                green = color.G;
                blue = color.B;
            }
        }
        /// <summary>
        /// 线条粗细
        /// </summary>
        public int BorderWidth { get => borderWidth; set => borderWidth = value; }
        /// <summary>
        /// 线样式，默认实线
        /// </summary>
        public int BorderDashStyle { get => borderDashStyle; set => borderDashStyle = value; }
        /// <summary>
        /// 数据点提示
        /// </summary>
        public string ToolTip { get => toolTip; set => toolTip = value; }
        /// <summary>
        /// 是否展示对应数据点的标签
        /// </summary>
        public bool IsValueShownAsLabel { get => isValueShownAsLabel; set => isValueShownAsLabel = value; }
        ///// <summary>
        ///// 标签展示格式 默认 (x,y)
        ///// </summary>
        //public string Label { get => label; set => label = value; }
        #endregion
    }
}
