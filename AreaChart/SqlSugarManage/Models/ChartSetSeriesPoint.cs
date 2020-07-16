using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugarManage.Models
{
    public class ChartSetSeriesPoint
    {
        public double X;
        public double Y;
        public ChartSetSeriesPoint(double x, double y)
        {
            X = x;
            Y = y;
        }
    }
}
