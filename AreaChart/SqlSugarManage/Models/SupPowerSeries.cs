using SqlSugar;
using System;
using System.Collections.Generic;

namespace SqlSugarManage.Models
{

    [SugarTable("SupPowerSeries")]
    public class SupPowerSeries
    {
        [SugarColumn(IsPrimaryKey = true)]
        public string Guid { get; set; }
        /// <summary>
        /// 系列的名称，600W，1000W
        /// </summary>
        public string Name { get; set; }
        /// <summary>
        /// 版本？
        /// </summary>
        public string Version { get; set; }

        public DateTime CreateTime { get; set; }
        
        
        string _type = "P";
        /// <summary>
        /// 系列类型 （P：恒功率 V：恒电压）
        /// </summary>
        public string SeriesType { get => _type; set => _type = value; }

        /// <summary>
        /// 在初始化数据使用，其他地方不可使用
        /// </summary>
        public List<SupPowerModel> SupPowerModels = new List<SupPowerModel>();
    }
}
