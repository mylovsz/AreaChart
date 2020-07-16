using LogManage;
using Newtonsoft.Json;
using SqlSugar;
using SqlSugarManage.Models;
using SqlSugarManage.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugarManage.Datas
{
    public class Dao
    {
        public  SqlSugarClient _Db;
        //private SqlSugarClient _LogDb;
        public static string ConnectionString
        {
            get
            {
                string reval = PubConstant.ConnectionString;
                return reval;
            }
        }
        /// <summary>
        /// 数据库连接
        /// </summary>
        public Dao()
        {
            //LogHelper.Info(ConnectionString);

            _Db = new SqlSugarClient(new ConnectionConfig()
            {
                ConnectionString = ConnectionString,//必填, 数据库连接字符串
                DbType = DbType.Sqlite,         //必填, 数据库类型
                IsAutoCloseConnection = false,       //默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
                //InitKeyType = InitKeyType.SystemTable,   //默认SystemTable, 字段信息读取, 如：该属性是不是主键，是不是标识列等等信息
                InitKeyType = InitKeyType.Attribute
                //ConfigureExternalServices = new ConfigureExternalServices()
                //{
                //    DataInfoCacheService = new HttpRuntimeCache() //RedisCache是继承ICacheService自已实现的一个类
                //}
            });

            //_LogDb = new SqlSugarClient(new ConnectionConfig() {
            //    ConnectionString = ConnectionString,//必填, 数据库连接字符串
            //    IsAutoCloseConnection = false,       //默认false, 时候知道关闭数据库连接, 设置为true无需使用using或者Close操作
            //    DbType = DbType.Sqlite,
            //});
            //SimpleClient<Log> LogClient = new SimpleClient<Log>(_LogDb); 

            #region 生成表 并添加数据

            // 创建数据库
            bool isExist = false;
            if (!_Db.DbMaintenance.IsAnyTable(typeof(SupPowerSeries).Name))//||true)
            {
                _Db.CodeFirst.InitTables(typeof(SupPowerSeries));
                isExist = true;
            }
            if (!_Db.DbMaintenance.IsAnyTable(typeof(SupPowerModel).Name))//||true)
            {
                _Db.CodeFirst.InitTables(typeof(SupPowerModel));
                isExist = true;
            }


            // 初始化数据库
            // 当前只有600w产品，仅需一次创建
            if (isExist)
            {
                List<SupPowerSeries> list = SupPowerServices.InitDB();
                _Db.Insertable<SupPowerSeries>(list).ExecuteCommand();

                foreach(SupPowerSeries sps in list)
                {
                    _Db.Insertable<SupPowerModel>(sps.SupPowerModels).ExecuteCommand();
                }   
            }

            //保持类名与表明一致
            //if (!_Db.DbMaintenance.IsAnyTable(typeof(test).Name))
            //{
            //    _Db.CodeFirst.InitTables(typeof(test));
            //    //添加数据
            //    //_Db.Insertable<Table>(new Table {... }).ExecuteCommand();
            //}

            #endregion


            _Db.Aop.OnDiffLogEvent = it =>
            {
                var editBeforeData = it.BeforeData;
                var editAfterData = it.AfterData;
                var sql = it.Sql;
                var parameter = it.Parameters;
                var data = it.BusinessData;
                var time = it.Time;
                var diffType = it.DiffType;//枚举值 insert 、update 和 delete 用来作业务区分

                SqlLog(editBeforeData, editAfterData, sql, parameter, data, time, diffType);
            };
            //日志
            _Db.Aop.OnLogExecuted = (sql, pars) =>
            {
                foreach (var item in pars)
                {
                    try
                    {
                        sql = sql.Replace(item.ParameterName, item.Value.ToString());
                    }
                    catch (Exception e)
                    {
                        LogHelper.Info("------Sql_Parameter ==|||" + e.Message);
                    }
                }

                //LogClient.Insert(new Log
                //{
                //    CreateDate = DateTime.Now,
                //    Level = 0,
                //    Value = sql+ "--||SqlExecutionTime:"+ _Db.Ado.SqlExecutionTime
                //});

                //LogHelper.Info("------Sql==|||" + sql);
                //LogHelper.Info("------执行时间：" + _Db.Ado.SqlExecutionTime);
            };


        }
        //日志
        private static void SqlLog(List<DiffLogTableInfo> editBeforeData, List<DiffLogTableInfo> editAfterData, string sql, SugarParameter[] parameter, object data, TimeSpan? time, DiffType diffType)
        {
            foreach (var item in parameter)
            {
                try
                {
                    sql = sql.Replace(item.ParameterName, item.Value.ToString());
                }
                catch (Exception e)
                {
                    LogHelper.Error("SqlLogError",e);
                }
            }
            //你可以在这里面写日志方法
            LogHelper.Info("--------------数据库日志----------------------------------------------------");
            LogHelper.Info("------");
            LogHelper.Info("------" + JsonConvert.SerializeObject(editBeforeData));
            LogHelper.Info("------" + JsonConvert.SerializeObject(editAfterData));
            LogHelper.Info("------" + JsonConvert.SerializeObject(sql));
            LogHelper.Info("------" + JsonConvert.SerializeObject(data));
            LogHelper.Info("------" + JsonConvert.SerializeObject(time));
            LogHelper.Info("------" + JsonConvert.SerializeObject(diffType));
            LogHelper.Info("------");
            LogHelper.Info("----------------------------------------------------------------------------");
        }
               
        //释放资源
        public void Dispose()
        {
            if (_Db != null)
            {
                //LogHelper.Info("注销掉了");
                _Db.Dispose();
            }
            //if (_LogDb!=null)
            //{
            //    _LogDb.Dispose();
            //}
        }
    }
}
