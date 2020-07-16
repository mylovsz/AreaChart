using Newtonsoft.Json;
using SqlSugar;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugarManage.Models
{
    [SugarTable("SupPowerModel")]
    public class SupPowerModel
    {
        [SugarColumn(IsPrimaryKey = true)]
        public String Guid { get; set; }

        public string SupPowerSeriesGuid { get; set; }

        /// <summary>
        /// 型号
        /// </summary>
        public string Name { get; set; }

        /// <summary>
        /// 硬件版本
        /// </summary>
        public string Version { get; set; }

        /// <summary>
        /// 创建时间
        /// </summary>
        public DateTime CreateTime { get; set; }

        /// <summary>
        /// 界面的数据
        /// </summary>
        public string Data { get; set; }

        public SupPowerModelData data = null;

        /// <summary>
        /// 编程器的实际通讯协议内容
        /// </summary>
        public string ConfigPRGMR { get; set; }

        /// <summary>
        /// 电源的实际通讯协议内容
        /// </summary>
        public string ConfigPower { get; set; }

        string _type = "P";
        /// <summary>
        /// 系列类型 （P：恒功率 V：恒电压）
        /// </summary>
        public string ModelType { get { return _type; } set { _type = value; } }

        /// <summary>
        /// 图表图例
        /// </summary>
        [SugarColumn(Length = -1)]//最大存储容量
        public string Chart { get; set; }
        private List<ChartSet> chart = null;

        /// <summary>
        /// 获取图表的数据，设备的默认参数
        /// </summary>
        /// <returns></returns>
        public SupPowerModelData GetData()
        {
            if(data == null)
               data = JsonConvert.DeserializeObject<SupPowerModelData>(this.Data);
            return data;
        }

        public void SetData(SupPowerModelData lcs)
        {
            data = lcs;
            this.Data = JsonConvert.SerializeObject(lcs);
        }
        /// <summary>
        /// 获取图表
        /// </summary>
        /// <returns></returns>
        public List<ChartSet> GetCharts()
        {
            if(chart == null)
                chart = JsonConvert.DeserializeObject<List<ChartSet>>(this.Chart);
            return chart;
        }
        /// <summary>
        /// 设置图表
        /// </summary>
        /// <param name="lcs"></param>
        public void SetCharts(List<ChartSet> lcs)
        {
            chart = lcs;
            this.Chart = JsonConvert.SerializeObject(lcs);
        }
        /// <summary>
        /// 获取编程器的默认协议
        /// </summary>
        /// <returns></returns>
        public SupPowerSetPRGMR GetConfigPRGMR()
        {
            return JsonConvert.DeserializeObject<SupPowerSetPRGMR>(this.ConfigPRGMR);
        }
        /// <summary>
        /// 设置编程器的默认协议
        /// </summary>
        /// <param name="spmc"></param>
        public void SetConfigPRGMR(SupPowerSetPRGMR spmc)
        {
            this.ConfigPRGMR = JsonConvert.SerializeObject(spmc);
        }
        /// <summary>
        /// 获取电源的默认协议
        /// </summary>
        /// <returns></returns>
        public SupPowerSetPower GetConfigPower()
        {
            return JsonConvert.DeserializeObject<SupPowerSetPower>(this.ConfigPower);
        }
        /// <summary>
        /// 设置电源的默认协议
        /// </summary>
        /// <param name="spmc"></param>
        public void SetConfigPower(SupPowerSetPower spmc)
        {
            this.ConfigPower = JsonConvert.SerializeObject(spmc);
        }


        public void InitInTempDefault()
        {
            SupPowerModelData spmd = JsonConvert.DeserializeObject<SupPowerModelData>(this.Data);
            data.supPowerModelDataTemp.IoutProtect = spmd.supPowerModelDataTemp.IoutProtect;
            data.supPowerModelDataTemp.IprotectCurrent = spmd.supPowerModelDataTemp.IprotectCurrent;
            data.supPowerModelDataTemp.Irecover = spmd.supPowerModelDataTemp.Irecover;
        }

        public void InitOutTempDefault()
        {
            SupPowerModelData spmd = JsonConvert.DeserializeObject<SupPowerModelData>(this.Data);
            data.supPowerModelDataTemp.OoutProtect = spmd.supPowerModelDataTemp.OoutProtect;
            data.supPowerModelDataTemp.OprotectCurrent = spmd.supPowerModelDataTemp.OprotectCurrent;
            data.supPowerModelDataTemp.Orecover = spmd.supPowerModelDataTemp.Orecover;
        }
    }
}
