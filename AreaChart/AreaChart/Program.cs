using FSLib.App.SimpleUpdater;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace AreaChart
{
    static class Program
    {
        /// <summary>
        /// 应用程序的主入口点。
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            try
            {
                //方式1 222.92.212.62:1218
                var updater = Updater.CreateUpdaterInstance("http://222.92.212.62:1218/{0}", "update.xml");
                updater.Error += (s, e) => {
                    //MessageBox.Show("更新发生了错误：" + updater.Context.Exception.Message);
                    //updater.Dispose();
                };
                updater.UpdatesFound += (s, e) => {
                    //MessageBox.Show("发现了新版本：" + updater.Context.UpdateInfo.AppVersion);
                };
                updater.NoUpdatesFound += (s, e) => {
                    //MessageBox.Show("没有新版本！");
                };
                updater.MinmumVersionRequired += (s, e) => {
                    //MessageBox.Show("当前版本过低无法使用自动更新！");
                };
                //updater.EnsureNoUpdate();//阻塞运行,会导致软件不运行
                Updater.CheckUpdateSimple();//非阻塞运行
                
            }
            catch (Exception ex)
            {
                LogManage.LogHelper.Error(ex.Message);
            }

            Application.Run(new FormMain());
        }

    }
}
