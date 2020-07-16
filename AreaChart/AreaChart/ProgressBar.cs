using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;
using Common.Common;

namespace AreaChart
{
    public partial class ProgressBar : Skin_DevExpress
    {
        SerialPortHelper serialPort = null;
        string fileName = "";
        BackgroundWorker _demoBGWorker = new BackgroundWorker();

        public ProgressBar()
        {
            InitializeComponent();
        }

        public ProgressBar(SerialPortHelper serialPort, string fileName):this()
        {
            this.serialPort = serialPort;
            this.fileName = fileName;
        }
        //启动
        private void ProgressBar_Load(object sender, EventArgs e)
        {
            button1.Visible = false;
            _demoBGWorker.DoWork += _demoBGWorker_DoWork;
            _demoBGWorker.WorkerReportsProgress = true;
            _demoBGWorker.ProgressChanged += _demoBGWorker_ProgressChanged;
            _demoBGWorker.RunWorkerCompleted += _demoBGWorker_RunWorkerCompleted;
            _demoBGWorker.RunWorkerAsync();

            
        }

        
        //干活
        private void _demoBGWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            SendCMD sendCMD = SendCMD.GetInstance();
            sendCMD.DataWriteRequest(serialPort, 2000, fileName);
            int i = sendCMD.DataSent(serialPort, 10000, fileName, sender);
            e.Result = i;
        }
        //干活进度
        private void _demoBGWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            this.progressBar1.Value = e.ProgressPercentage;
            this.labpb.Text = e.ProgressPercentage + "%";
        }
        //完成
        private void _demoBGWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if ((int)e.Result == 1)
            {
                this.labpb.Text = "Success";
            }
            else
            {
                this.labpb.Text = "Failed";
            }
            button1.Visible = true;
        }
        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
