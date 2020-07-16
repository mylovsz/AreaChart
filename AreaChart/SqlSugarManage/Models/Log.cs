using SqlSugar;
using System;

namespace SqlSugarManage.Models
{
    [SugarTable("Log")]
    public class Log
    {
        [SugarColumn(IsPrimaryKey = true, IsIdentity = true)]
        public int Id { get; set; }

        public DateTime? CreateDate { get; set; }
        public string Value { get; set; }
        public int Level { get; set; }
    }
}
