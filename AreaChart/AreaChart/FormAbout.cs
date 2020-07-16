using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Windows.Forms;
using CCWin;

namespace AreaChart
{
    public partial class FormAbout : Skin_DevExpress
    {
        public FormAbout()
        {
            InitializeComponent();
        }

        private void FormAbout_Load(object sender, EventArgs e)
        {
            //this.BackColor = Color.FromArgb(34, 34, 34);
            label1.Text = "软件版本：" + Assembly.GetExecutingAssembly().GetName().Version.ToString();
        }
    }
}
