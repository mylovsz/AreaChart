using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace AreaChart
{
    public partial class FormUpdateLog : Skin_DevExpress
    {
        public FormUpdateLog()
        {
            InitializeComponent();
        }

        private void FormUpdateLog_Load(object sender, EventArgs e)
        {
            string circuitPath = Application.StartupPath + @"\log\Updateddetails.txt";
            using (StreamReader reader = new StreamReader(circuitPath, Encoding.GetEncoding("utf-8")))
            {
                textBox1.Text = reader.ReadToEnd();
            }
           
           // label1.Focus();
        }
    }
}
