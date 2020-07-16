using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace SqlSugarManage.Services
{

    /// <summary>
    /// 数据库操作对象
    /// </summary>
    public class BaseServices : IDisposable
    {
        protected Datas.Dao dao;
        public BaseServices() {
            dao =  new Datas.Dao();
        }

        public void Dispose()
        {
            if (null!=dao)
            {
                dao.Dispose();
            }
        }
    }
}
