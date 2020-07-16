using Newtonsoft.Json;
using SqlSugarManage.Models;
using SqlSugarManage.Services;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace ExpectData
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        

        private void button1_Click(object sender, EventArgs e)
        {
            SupPowerServices supPowerServices = new SupPowerServices();
            var lsSupPowerSeries = supPowerServices.GetAllSupPowerSeries();
            string path = $"{Application.StartupPath}/数据.xls";
            string title = $"SeriesName\tProductName\tType\tI-Min\tI-Max\tV-Min\tV-Max\tPower\tscale\r\n";
            File.AppendAllText(path, title);
            foreach (var item in lsSupPowerSeries)
            {
                var lsSupPowerModels = supPowerServices.GetAllSupPowerModelBySeriesGuid(item.Guid);//获取这个系列下的多个模型supPowerModels
                foreach (var supPowerMode in lsSupPowerModels)
                {
                    //var supPowerModelData = supPowerMode.GetData();
                    var data = JsonConvert.DeserializeObject<SupPowerModelData>(supPowerMode.Data);
                    double scalc =Math.Round(data.supPowerModelOutCurrent.OutputVoltageMax * data.supPowerModelOutCurrent.OutputCurrentLow / data.supPowerModelOutCurrent.OutputPower,2);
                    string msg = $"{item.Name}\t{supPowerMode.Name}\t{supPowerMode.ModelType}\t{data.supPowerModelOutCurrent.OutputCurrentMin}\t{data.supPowerModelOutCurrent.OutputCurrentMax}\t{data.supPowerModelOutCurrent.OutputVoltageMin}\t{data.supPowerModelOutCurrent.OutputVoltageMax}\t{data.supPowerModelOutCurrent.OutputPower}\t{scalc}\r\n";
                    File.AppendAllText(path, msg,Encoding.UTF8);
                }
            }
        }
    }
}
