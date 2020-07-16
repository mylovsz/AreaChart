
using CCWin;
using Common.Common;
using FSLib.App.SimpleUpdater;
using LogManage;
using SqlSugarManage.Models;
using SqlSugarManage.Services;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.IO.Ports;
using System.Linq;
using System.Windows.Forms;
using System.Xml.Serialization;
using static Common.Common.LanguageHelper;

namespace AreaChart
{
    public partial class FormMain : Skin_DevExpress
    {
        #region 全局对象声明
        private ViewModel viewModel = new ViewModel();
        private SerialPortHelper serialPort = null;
        private SupPowerServices supPowerServices = null;
        private List<SupPowerSeries> lsSupPowerSeries = null;
        private List<SupPowerModel> lsSupPowerModels = null;
        //控制输出电流的红色线_恒压 是否显示
        bool HoldVoltageShow = true;
        //可变输出区域
        bool VariableOutputRegion = true;
        #endregion

        /// <summary>
        /// 展示消息
        /// </summary>
        /// <param name="msg"></param>
        public void ShowMsg(string msg)
        {
            Console.WriteLine(DateTime.Now.ToLongTimeString() + ": " + msg);
            labState.Text = LanguageHelper.getResources(msg);
            Application.DoEvents();
            LogHelper.Info(msg);
        }


        #region Form相关
        public FormMain()
        {
            InitializeComponent();
            this.Shown += new EventHandler(this.FormMain_Shown);
        }

        private void FormMain_Load(object sender, EventArgs e)
        {
            ShowMsg("启动成功");
            ATEButton();
            // 标签页，默认选择概况页面
            tcData.SelectedIndex = 0;
            tcData.TabPages.Remove(skinTabPage13);
            stbcWorkMode.SelectedIndex = 0;
            // 初始化串口，当前无需这么做，因为在下拉的时候，串口会自动更新
            cbxPort_DropDown(null, null);

            // 默认为编程器
            combTagType.SelectedIndex = 0;
            cbMode.SelectedIndex = 0;
            // 拉去数据库数据，放入全局数据中，并初始化Series列表
            if (supPowerServices == null)
            {
                supPowerServices = new SupPowerServices();
            }

            lsSupPowerSeries = supPowerServices.GetAllSupPowerSeries();

            // 初始化系列控件，并默认选择第一个数据
            combSeries.DisplayMember = "Name";
            combSeries.DataSource = lsSupPowerSeries;
            combSeries.SelectedIndex = 0;

            // 默认外部温度不可编辑
            sckboxOutCtr.Checked = false;//温度修改的启用
            sckboxOutCtr_Click(null, null);

            // 默认内部温度不可编辑
            sckboxInCtr.Checked = false;
            sckboxInCtr_Click(null, null);

            // 默认定时不可编辑
            scbxTimeCtrl1.Checked = false;//定时修改的启用
            scbxTimeCtrl_CheckedChanged(null, null);

            gbOutputCurrent.Click += Focus_Click;
            gbTempOut.Click += Focus_Click;
            gbTempIn.Click += Focus_Click;
            gbTimeCtrl.Click += Focus_Click;
            gbxDimRadio.Click += Focus_Click;
            ShowMsg("初始化界面控件完成");
        }

        private void Focus_Click(object sender, EventArgs e)
        {
            if (sender == null) return;
            Control c = sender as Control;
            c.Focus();
        }
        /// <summary>
        /// 中英文帮助文档用
        /// </summary>
        string languageHelp = null;
        private void FormMain_Shown(object sender, EventArgs e)
        {
            LogHelper.Info("语言初始化");


            //界面多语言  要一起修改
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(LanguageType.en.ToString());//中文界面 
            languageHelp = "英文";


            //窗体加载并显示后，对窗体实现多语言处理
            if (!this.DesignMode)
            {
                if (!LanguageHelper.InitLanguage(this))
                {
                    LanguageHelper.updateFile();
                    LanguageHelper.InitLanguage(this);
                }
                MenuitemLanguage();
                LogHelper.Info("语言初始化完成");
            }
        }

        private void MenuitemLanguage()
        {
            文件ToolStripMenuItem.Text = LanguageHelper.getResources("文件ToolStripMenuItem");
            语言ToolStripMenuItem.Text = LanguageHelper.getResources("语言ToolStripMenuItem");
            帮助ToolStripMenuItem.Text = LanguageHelper.getResources("帮助ToolStripMenuItem");

            读取配置文件ToolStripMenuItem.Text = LanguageHelper.getResources("读取配置文件ToolStripMenuItem");
            保存配置文件ToolStripMenuItem.Text = LanguageHelper.getResources("保存配置文件ToolStripMenuItem");
            退出ToolStripMenuItem.Text = LanguageHelper.getResources("退出ToolStripMenuItem");

            更新日志ToolStripMenuItem.Text = LanguageHelper.getResources("更新日志ToolStripMenuItem");
            帮助ToolStripMenuItem1.Text = LanguageHelper.getResources("帮助ToolStripMenuItem1");
            关于ToolStripMenuItem.Text = LanguageHelper.getResources("关于ToolStripMenuItem");
            检测更新ToolStripMenuItem.Text = LanguageHelper.getResources("检测更新ToolStripMenuItem");
            升级固件ToolStripMenuItem.Text = LanguageHelper.getResources("升级固件ToolStripMenuItem");
            labDimFaultCode.Text = LanguageHelper.getResources(FaultCode);

        }
        #endregion

        #region 串口操作
        /// <summary>
        /// 初始化串口
        /// </summary>
        /// <returns>返回串口状态是否打开</returns>
        private bool InitSerialPort()
        {
            string portName = cbxPort.SelectedItem == null ? "" : cbxPort.SelectedItem.ToString();
            LogHelper.Info("串口名:" + portName);
            try
            {
                if (serialPort == null)
                {
                    serialPort = new SerialPortHelper();
                }

                if (serialPort.IsOpen())//尝试关闭串口对象
                {
                    serialPort.Close();//如果无法关闭就会异常，否则一定是关闭的
                }
                if (!string.IsNullOrWhiteSpace(portName))
                {
                    serialPort.PortName = portName;
                    serialPort.Open();

                    if (serialPort != null && serialPort.IsOpen())
                    {
                        ShowMsg("已打开串口");
                        return true;
                    }
                }
                else
                {
                    ShowMsg("已关闭串口");
                }
                return false;
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                LogHelper.Info(ex.Message);
                serialPort = null;
                return false;
            }
        }

        /// <summary>
        /// 获取串口状态，是否可以直接使用
        /// </summary>
        /// <returns></returns>
        private bool GetSerialPortState()
        {
            if (serialPort != null && serialPort.IsOpen())
            {
                ATEButton(true);
                return true;
            }

            cbxPort.SelectedIndex = 0;
            ATEButton(false);
            return false;
        }

        //加载系统串口资源
        private void cbxPort_DropDown(object sender, EventArgs e)
        {
            cbxPort.Items.Clear();
            cbxPort.Items.Add("");
            string[] ports = SerialPort.GetPortNames();
            if (ports != null && ports.Length > 0)
            {
                cbxPort.Items.AddRange(ports);
            }
        }

        //
        private void cbxPort_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (InitSerialPort())
            {
                pbSerialState.Image = Properties.Resources.usb;
                ShowMsg("串口打开成功");
                ATEButton(true);
            }
            else
            {
                pbSerialState.Image = Properties.Resources.error;
                ShowMsg("串口打开失败");
                ATEButton(false);
            }
        }
        #endregion

        #region modbus读取与设置设备的方法
        /// <summary>
        /// 读取和写入时更新UI启用状态，防止误操作
        /// </summary>
        /// <param name="IsSend"></param>
        private void UIState(bool IsSend)
        {
            combSeries.Enabled = IsSend;
            combTagType.Enabled = IsSend;
            combModel.Enabled = IsSend;
            btnReadConfig.Enabled = IsSend;
            btnSaveConfig.Enabled = IsSend;
            cbxPort.Enabled = IsSend;
        }

        //编程器读取按钮
        private void btnReadPRGMR_Click(object sender, EventArgs e)
        {
            LogHelper.Info("编程器读取按钮开始");
            try
            {
                if (GetSerialPortState())
                {
                    ShowMsg("编程器数据读取中...");
                    //UIState(false);
                    btnReadPRGMR.Enabled = false;

                    try
                    {
                        object obj = ProtocolManage.ReadDeviceToStruct(serialPort, 2000, 1, 256, typeof(SupPowerSetPRGMR));
                        try
                        {
                            string s = XMLSerializerHelper.Serializer(typeof(SupPowerSetPRGMR), obj);
                            LogHelper.Info("编程器读取的数据：" + s);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Info("编程器读取的数据序列化异常：" + ex.Message);
                        }
                        if (obj != null)
                        {
                            viewModel.IsPower = false;
                            viewModel.InitDefaultPRGMR((SupPowerSetPRGMR)obj);
                            //InitModelToUI(true);
                            ShowMsg(LanguageHelper.getResources("编程器数据读取成功, 型号：") + viewModel.PRGMR.ProductTypeName.Trim().Replace("\0", "") + LanguageHelper.getResources(" 版本：") + viewModel.PRGMR.SoftVersion);
                            string file = FOTAPath + viewModel.PRGMR.SoftVersion + ".bin";
                            if (File.Exists(file))
                            {//有这个文件，不用升级

                            }
                            else
                            {//没有这个文件，要提示升级
                                MessageBox.Show(LanguageHelper.getResources("编程器有新固件,请升级"));
                            }
                            if (string.IsNullOrWhiteSpace(viewModel.PRGMR.ProductTypeName.Trim().Replace("\0", "")))
                            {
                                MessageBox.Show(LanguageHelper.getResources("请先初始化设备"));
                                btnReadPRGMR.Enabled = true;
                                return;
                            }
                            SupPowerModel supPowerModel = supPowerServices.GetSupPowerModelByName(viewModel.PRGMR.ProductTypeName.Trim().Replace("\0", ""));
                            if (supPowerModel != null)
                            {
                                SupPowerSeries sps = lsSupPowerSeries.FirstOrDefault(a => a.Guid == supPowerModel.SupPowerSeriesGuid);
                                if (sps != null)
                                {
                                    combSeries.SelectedItem = sps;
                                    combSeries_SelectedIndexChanged(null, null);
                                    combModel.SelectedItem = lsSupPowerModels.FirstOrDefault(b => b.Guid == supPowerModel.Guid);

                                    viewModel.IsPower = false;
                                    viewModel.InitDefaultPRGMR((SupPowerSetPRGMR)obj);
                                    InitModelToUI(true);
                                }
                            }
                            else
                            {
                                MessageBox.Show(LanguageHelper.getResources("当前软件版本不支持此型号"));
                            }
                        }
                        else
                        {
                            ShowMsg("编程器数据读取超时");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        ShowMsg("编程器数据读取失败");
                        LogHelper.Info(ex.Message);
                    }

                    //UIState(true);
                    btnReadPRGMR.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                LogHelper.Info(ex.Message);
            }
            LogHelper.Info("编程器读取按钮结束");
        }
        //编程器写入按钮
        private void btnWritePRGMR_Click(object sender, EventArgs e)
        {
            LogHelper.Info("编程器写入按钮开始");
            try
            {
                if (GetSerialPortState())
                {
                    ShowMsg("编程器数据写入中...");
                    //UIState(false);
                    btnWritePRGMR.Enabled = false;

                    try
                    {
                        if (MessageBox.Show(LanguageHelper.getResources("下放配置？"), LanguageHelper.getResources("提示"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SupPowerModel spm = combModel.SelectedItem as SupPowerModel;
                            SupPowerSeries sps = combSeries.SelectedItem as SupPowerSeries;
                            viewModel.PRGMR.ProductTypeName = spm.Name;
                            viewModel.PRGMR.SoftVersion = sps.Name;
                            try
                            {
                                string s = XMLSerializerHelper.Serializer(typeof(SupPowerSetPRGMR), viewModel.PRGMR);
                                LogHelper.Info("编程器写入的数据：" + s);
                            }
                            catch (Exception ex)
                            {
                                LogHelper.Info("编程器写入的数据序列化异常：" + ex.Message);
                            }
                            bool obj = ProtocolManage.WriteStructToDevice(serialPort, 2000, 1, 256, viewModel.PRGMR, 10);
                            if (obj == true)
                            {
                                ShowMsg("编程器数据写入成功");
                            }
                            else
                            {
                                ShowMsg("编程器数据写入超时");
                            }
                        }
                        else
                        {
                            ShowMsg("写入已取消");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        ShowMsg("编程器数据写入失败");
                        LogHelper.Info(ex.Message);
                    }

                    //UIState(true);
                    btnWritePRGMR.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                LogHelper.Info(ex.Message);
            }
            LogHelper.Info("编程器写入按钮结束");
        }
        //电源读取按钮
        private void btnReadDrive_Click(object sender, EventArgs e)
        {
            LogHelper.Info("电源读取按钮开始");
            try
            {
                if (GetSerialPortState())
                {
                    ShowMsg("电源数据读取中...");
                    //UIState(false);
                    btnReadDrive.Enabled = false;

                    try
                    {
                        object obj = ProtocolManage.ReadDeviceToStruct(serialPort, 2000, 1, 1024, typeof(SupPowerSetPower));
                        try
                        {
                            string s = XMLSerializerHelper.Serializer(typeof(SupPowerSetPower), obj);
                            LogHelper.Info("电源读取的数据序列化异常：" + s);
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Info("电源读取的数据序列化异常：" + ex.Message);
                        }
                        if (obj != null)
                        {
                            viewModel.IsPower = true;
                            viewModel.InitDefaultPower((SupPowerSetPower)obj);
                            //InitModelToUI(true);
                            ShowMsg(LanguageHelper.getResources("电源数据读取成功, 型号：") + viewModel.Power.ProductTypeName.Trim().Replace("\0", "") + LanguageHelper.getResources(" 版本：") + viewModel.Power.SoftVersion);

                            if (string.IsNullOrWhiteSpace(viewModel.Power.ProductTypeName.Trim().Replace("\0", "")))
                            {
                                MessageBox.Show(LanguageHelper.getResources("请先初始化设备"));
                                btnReadDrive.Enabled = true;
                                return;
                            }
                            SupPowerModel supPowerModel = supPowerServices.GetSupPowerModelByName(viewModel.Power.ProductTypeName.Trim().Replace("\0", ""));
                            if (supPowerModel != null)
                            {
                                SupPowerSeries sps = lsSupPowerSeries.FirstOrDefault(a => a.Guid == supPowerModel.SupPowerSeriesGuid);
                                if (sps != null)
                                {
                                    combSeries.SelectedItem = sps;
                                    combSeries_SelectedIndexChanged(null, null);
                                    combModel.SelectedItem = lsSupPowerModels.FirstOrDefault(b => b.Guid == supPowerModel.Guid);

                                    viewModel.IsPower = true;
                                    viewModel.InitDefaultPower((SupPowerSetPower)obj);
                                    InitModelToUI(true);
                                }
                            }
                            else
                            {
                                MessageBox.Show(LanguageHelper.getResources("当前软件版本不支持此型号"));
                            }
                        }
                        else
                        {
                            ShowMsg("电源数据读取超时");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        ShowMsg("电源数据读取失败");
                        LogHelper.Info(ex.Message);
                    }

                    //UIState(true);
                    btnReadDrive.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                LogHelper.Info(ex.Message);
            }
            LogHelper.Info("电源读取按钮结束");
        }
        //电源写入按钮
        private void btnWriteDrive_Click(object sender, EventArgs e)
        {
            LogHelper.Info("电源写入按钮开始");
            try
            {
                if (GetSerialPortState())
                {
                    ShowMsg("电源数据写入中...");
                    //UIState(false);
                    btnWriteDrive.Enabled = false;

                    try
                    {
                        if (MessageBox.Show(LanguageHelper.getResources("下放配置？"), LanguageHelper.getResources("提示"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                        {
                            SupPowerModel spm = combModel.SelectedItem as SupPowerModel;
                            SupPowerSeries sps = combSeries.SelectedItem as SupPowerSeries;
                            viewModel.Power.ProductTypeName = spm.Name;
                            viewModel.Power.SoftVersion = sps.Name;
                            try
                            {
                                string s = XMLSerializerHelper.Serializer(typeof(SupPowerSetPower), viewModel.Power);
                                LogHelper.Info("电源写入的数据：" + s);
                            }
                            catch (Exception ex)
                            {
                                LogHelper.Info("电源写入的数据：" + ex.Message);
                            }

                            bool obj = ProtocolManage.WriteStructToDevice(serialPort, 2000, 1, 1024, viewModel.Power, 10);
                            if (obj == true)
                            {
                                ShowMsg("电源数据写入成功");
                            }
                            else
                            {
                                ShowMsg("电源数据写入超时");
                            }
                        }
                        else
                        {
                            ShowMsg("写入已取消");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        ShowMsg("电源数据写入失败");
                        LogHelper.Info(ex.Message);
                    }

                    //UIState(true);
                    btnWriteDrive.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                LogHelper.Info(ex.Message);
            }
            LogHelper.Info("电源写入按钮结束");
        }

        #endregion


        #region 访问数据库，初始化模型
        /// <summary>
        /// 系列的选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combSeries_SelectedIndexChanged(object sender, EventArgs e)
        {
            SupPowerSeries sps = combSeries.SelectedItem as SupPowerSeries;

            lsSupPowerModels = supPowerServices.GetAllSupPowerModelBySeriesGuid(sps.Guid);//获取这个系列下的多个模型supPowerModels

            combModel.DisplayMember = "Name";
            combModel.DataSource = lsSupPowerModels;//将多个模型添加到控件
            if (sender != null)
            {
                combModel.SelectedIndex = 0;
            }
        }
        /// <summary>
        /// 模型的选择与初始化
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combModel_SelectedIndexChanged(object sender, EventArgs e)
        {
            
            switch (combModel.Text)
            {
                case "LDC1K2*074":
                    LDC1K2T074();
                    break;
                case "LDC600*074":
                    LDC600T074();
                    break;

                #region LED
                case "LD075IC105W76AD3001":
                    LD150IC105W76AD3001();
                    break;
                case "LD096IC105W76AD3001":
                    LD150IC105W76AD3001();
                    break;
                case "LD150IC105W76AD3001":
                    LD150IC105W76AD3001();
                    break;
                case "LD200IC105W76AD3001":
                    LD150IC105W76AD3001();
                    break;
                case "LD240IC105W76AD3001":
                    LD150IC105W76AD3001();
                    break;
                case "LDP100I210PE001":
                    LD150IC105W76AD3001();
                    break;
                case "LDP150I140PE001":
                    LD150IC105W76AD3001();
                    break;
                case "LDP096I140PE001":
                    LD150IC105W76AD3001();
                    break;
                case "LD240IC210W76AD3001":
                    LD150IC105W76AD3001();
                    break;
                case "LDP075I105PE001":
                    LD150IC105W76AD3001();
                    break;
                case "LDP075I210PE001":
                    LD150IC105W76AD3001();
                    break;
                case "LD075IC105W76AD3101":
                    LD150IC105W76AD3001();
                    break;
                case "LD096IC105W76AD3101":
                    LD150IC105W76AD3001();
                    break;
                case "LD150IC105W76AD3101":
                    LD150IC105W76AD3001();
                    break;
                case "LD200IC105W76AD3101":
                    LD150IC105W76AD3001();
                    break;
                case "LD240IC105W76AD3101":
                    LD150IC105W76AD3001();
                    break;
                case "LD240IC210W76AD3101":
                    LD150IC105W76AD3001();
                    break;
                case "LD320IC210W76AD3101":
                    LD150IC105W76AD3001();
                    break;
                case "LD400IC210W76AD3101":
                    LD150IC105W76AD3001();
                    break;
                case "LD320IC210W76AD3102":
                    LD320IC210W76AD3102(true);
                    break;
                #endregion

                default:
                    LD320IC210W76AD3102(false);
                    LDC1K2T074(true);
                    LDC600T074(true);
                    LD150IC105W76AD3001(true);
                    break;
            }
            
            if (sender != null)//控件触发的，将从数据库中获取默认数据
            {
                SupPowerModel supPowerModel = combModel.SelectedItem as SupPowerModel;//控件触发的，将获取当前选中模型 从系列中找到的模型
                supPowerModel = supPowerServices.GetSupPowerModelByGuid(supPowerModel.Guid);//根据GUID从数据库中获取当前模型
                viewModel.SupPowerModel = supPowerModel;//将默认模型数据绑定到视图
                viewModel.InitDefault();//用默认的模型数据初始化协议 模型转结构
                viewModel.SoftVersion = supPowerModel.Version;
                viewModel.ProductTypeName = supPowerModel.Name;
                if (supPowerModel.ModelType == "V")
                {
                    VModeView(false);
                }
                if (supPowerModel.ModelType == "P")
                {
                    PModeView(true);
                }
            }

            InitModelToUI();
        }
        /// <summary>
        /// 电源、编程器类型切换
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void combTagType_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (combTagType.SelectedIndex == 0)
            {
                btnReadDrive.Visible = false;
                btnWriteDrive.Visible = false;
                btnReadPRGMR.Visible = true;
                btnWritePRGMR.Visible = true;

                viewModel.IsPower = false;
                //viewModel.InitDefault(); 
            }
            else
            {
                btnReadDrive.Visible = true;
                btnWriteDrive.Visible = true;
                btnReadPRGMR.Visible = false;
                btnWritePRGMR.Visible = false;

                viewModel.IsPower = true;
                //viewModel.InitDefault();
            }
            if (sender != null)
            {
                //viewModel.InitDefault();
            }
            InitModelToUI();
            if (viewModel.IsPower && rdbtnCommunicate.Checked)
            {
                //gbxDimRadio.Visible = rdbtnCommunicate.Checked;
                gbxDimRadio.Enabled = rdbtnCommunicate.Checked;
            }
            else
            {
                gbxDimRadio.Enabled = false;
            }
        }
        #region 模型初始化到控件
        /// <summary>
        /// 初始化所有页面的相关控件的值
        /// </summary>
        private void InitModelToUI(bool isCheck = false)
        {
            if (viewModel.SupPowerModel == null)
            {
                // 提示未存在该模型
                return;
            }
            LogHelper.Info("数据绑定界面");
            Debug.WriteLine("All-1");
            SupPowerModelData supPowerModelData = viewModel.SupPowerModel.GetData();//从模型中获取不同图表的数据，然后用数据初始化界面
            Debug.WriteLine("All-2");
            InitOutputModelUI(supPowerModelData, isCheck);//输出电流
            Debug.WriteLine("All-3");
            InitDataModolToUI(viewModel.ViewWorkMode);//工作模式
            Debug.WriteLine("All-4");
            InitDataTempUI();//外部温度
            Debug.WriteLine("All-5");
            InitDataTempInUI();//内部温度
            Debug.WriteLine("All-6");
            InitDataTimeCtrlUI();//定时
            Debug.WriteLine("All-7");
            InitDescribeUI();
            Debug.WriteLine("All-8");
            LogHelper.Info("数据绑定界面完成");
        }

        #endregion
        #endregion
        #region skinTabControl页面切换处理
        private void tcData_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (tcData.SelectedIndex)
            {
                case 0:
                    //Debug.WriteLine("TC-0");
                    InitDescribeUI();
                    break;
                case 1:
                    // Debug.WriteLine("TC-1");
                    break;
                case 2:
                    //Debug.WriteLine("TC-2");
                    break;
                case 3:
                    //Debug.WriteLine("TC-3");
                    break;
                case 4:
                    //Debug.WriteLine("TC-4");
                    break;
                //default:
                    //Debug.WriteLine("TC-default");
                  //  break;
            }
        }
        #endregion

        /// <summary>
        /// 更新概述界面，如果当前未处于概况界面，则不会更新数据
        /// </summary>
        private void InitDescribeUI()
        {
            // 如果当前未处于概况界面，则不会更新数据
            if (tcData.SelectedIndex != 0)
            {
                return;
            }
            #region 工作模式
            if (true)
            {
                string mode = "N/A";
                switch (viewModel.ViewWorkMode)
                {
                    case 0:
                        mode = "0-10V";
                        break;
                    case 1:
                        mode = "通讯";
                        break;
                    case 2:
                        mode = "定时模式";
                        break;
                    case 3:
                        mode = "PWM 正向";
                        break;
                    case 4:
                        mode = "恒功率";
                        break;
                    case 5:
                        mode = "恒压";
                        break;
                    case 6:
                        mode = "PWM 反向";
                        break;
                    default:
                        break;
                }
                labWorkMode.Text = LanguageHelper.getResources(mode);
            }
            #endregion
            #region 输出设置
            labNowCurrent.Text = viewModel.ViewOutputCurrent.ToString("0.00") + " A";
            labMaxCurrent.Text = viewModel.ViewOutputCurrentMax.ToString("0.00") + " A";
            labMaxVoltage.Text = viewModel.ViewOutputVoltageMax.ToString("0.00") + " V";
            labMinvoltage.Text = viewModel.ViewOutputVoltageMin.ToString("0.00") + " V";
            #endregion
            #region 温度设置
            //内部
            labInProtect.Text = viewModel.ViewInTempProtection.ToString("0") + " ℃";
            labInRecover.Text = viewModel.ViewInTempRecover.ToString("0") + " ℃";
            labInCurrent.Text = viewModel.ViewInTempCurrent.ToString("0") + " %";
            //外部
            labOutProtect.Text = viewModel.ViewOutTempProtection.ToString("0") + " ℃";
            labOutRecover.Text = viewModel.ViewOutTempRecover.ToString("0") + " ℃";
            labOutCurrent.Text = viewModel.ViewOutTempCurrent.ToString("0") + " %";
            #endregion
            #region 定时参数
            if (viewModel.ViewWorkMode == 2)
            {
                labTimeCtrlState.Text = LanguageHelper.getResources("已启用");
            }
            else
            {
                labTimeCtrlState.Text = LanguageHelper.getResources("未启用");
            }

            if (viewModel.TimeCtrlMode == 0)
            {
                labTimeCtrlMode.Text = LanguageHelper.getResources("标准模式");
            }
            if (viewModel.TimeCtrlMode == 1)
            {
                labTimeCtrlMode.Text = LanguageHelper.getResources("自适应定时模式");
            }

            labHoldTime1.Text = viewModel.TimeCtrlArgs1.Hold.ToString();// ushortToTimeFormat(viewModel.TimeCtrlArgs1.Hold);
            labHoldTime2.Text = viewModel.TimeCtrlArgs2.Hold.ToString();//ushortToTimeFormat(viewModel.TimeCtrlArgs2.Hold);
            labHoldTime3.Text = viewModel.TimeCtrlArgs3.Hold.ToString();//ushortToTimeFormat(viewModel.TimeCtrlArgs3.Hold);
            labHoldTime4.Text = viewModel.TimeCtrlArgs4.Hold.ToString();//ushortToTimeFormat(viewModel.TimeCtrlArgs4.Hold);
            labHoldTime5.Text = viewModel.TimeCtrlArgs5.Hold.ToString();//ushortToTimeFormat(viewModel.TimeCtrlArgs5.Hold);
            //labHoldTime6.Text = viewModel.TimeCtrlArgs6.Hold.ToString();//ushortToTimeFormat(viewModel.TimeCtrlArgs6.Hold);

            labShadeTime1.Text = viewModel.TimeCtrlArgs1.Tran.ToString();// ushortToTimeFormat(viewModel.TimeCtrlArgs1.Tran);
            labShadeTime2.Text = viewModel.TimeCtrlArgs2.Tran.ToString();//ushortToTimeFormat(viewModel.TimeCtrlArgs2.Tran);
            labShadeTime3.Text = viewModel.TimeCtrlArgs3.Tran.ToString();//ushortToTimeFormat(viewModel.TimeCtrlArgs3.Tran);
            labShadeTime4.Text = viewModel.TimeCtrlArgs4.Tran.ToString();//ushortToTimeFormat(viewModel.TimeCtrlArgs4.Tran);
            labShadeTime5.Text = viewModel.TimeCtrlArgs5.Tran.ToString();//ushortToTimeFormat(viewModel.TimeCtrlArgs5.Tran);
            //labShadeTime6.Text = viewModel.TimeCtrlArgs6.Tran.ToString();//ushortToTimeFormat(viewModel.TimeCtrlArgs6.Tran);

            labDimRatio1.Text = viewModel.TimeCtrlArgs1.Level.ToString();
            labDimRatio2.Text = viewModel.TimeCtrlArgs2.Level.ToString();
            labDimRatio3.Text = viewModel.TimeCtrlArgs3.Level.ToString();
            labDimRatio4.Text = viewModel.TimeCtrlArgs4.Level.ToString();
            labDimRatio5.Text = viewModel.TimeCtrlArgs5.Level.ToString();
            labDimRatio6.Text = viewModel.TimeCtrlArgs6.Level.ToString();
            #endregion

            string s = XMLSerializerHelper.Serializer(typeof(ViewModel), viewModel);
            s = s.Replace("&#x0;", "");
            LogHelper.Info("概述：" + s);
        }

        /// <summary>
        /// ushort转时间格式
        /// </summary>
        /// <param name="time"></param>
        private string ushortToTimeFormat(ushort minutes)
        {
            return (minutes / 60).ToString("00") + ":" + (minutes % 60).ToString("00");
        }

        #region 输出电流页面---输出图表
        //模型初始化控件
        private void InitOutputModelUI(SupPowerModelData supPowerModelData, bool isCheck = false)
        {
            // 防止赋值超过，上一次的上下限 2019年1月28日 08:21:23 
            nudOutputCurrent.Maximum = 65535;
            nudOutputCurrent.Minimum = 0;
            var temp = nudOutputCurrent.Value;
            nudOutputCurrent.Value = (decimal)viewModel.ViewOutputCurrent;  // 间接的触发nudOutputCurrent_ValueChanged
            if(temp == nudOutputCurrent.Value)
            {
                nudOutputCurrent_ValueChanged(null, null);
            }
            nudOutputCurrent.Maximum = (decimal)supPowerModelData.supPowerModelOutCurrent.OutputCurrentMax;
            nudOutputCurrent.Minimum = (decimal)supPowerModelData.supPowerModelOutCurrent.OutputCurrentMin;
            nudOutputCurrent.Increment = (decimal)(supPowerModelData.supPowerModelOutCurrent.OutputCurrentMax * 0.005);
            nudOutputCurrentMax.Value = (decimal)supPowerModelData.supPowerModelOutCurrent.OutputCurrentMax;
            nudOutputVoltageMin.Value = (decimal)supPowerModelData.supPowerModelOutCurrent.OutputVoltageMin;

            // 2019年1月24日 08:28:20 wanglm
            // 在数据读取时，会出现电压和电流都是100%的情况，导致，获取的电压与实际计算的电压不一致
            // 增加电压判断，试数据一致
            double voltageMax = supPowerModelData.supPowerModelOutCurrent.GetOutputCurrentVoltageMax((double)nudOutputCurrent.Value);
            nudOutputVoltageMax.Value = (decimal)voltageMax;
            if (viewModel.ViewOutputVoltageMax != voltageMax)
            {
                if (isCheck)
                    MessageBox.Show(LanguageHelper.getResources("最大输出电压不符合推荐值，已自动修改为推荐值，写入即可生效！"));
                viewModel.ViewOutputVoltageMax = (double)nudOutputVoltageMax.Value;
            }
        }

        /// <summary>
        /// 控件初始化模型
        /// </summary>
        private void UIToOutputModel()
        {
            List<ChartSet> lscs = viewModel.SupPowerModel.GetCharts();
            ChartSet cs = lscs.FirstOrDefault(a => a.Name == "OutCurrentChart");
            if (cs != null)
            {
                double val = 0.6;

                if (combModel.Text.Contains("IC"))
                {
                    val = 0.7;
                }
                if (viewModel.SupPowerModel.ModelType=="V")
                {
                    val = 1;
                }

                switch (combModel.Text)
                {
                    case "LD400IC210W76AD3101":
                        val = 0.6;
                        break;
                    case "LDP100I210PE001":
                        val = 0.7;
                        break;
                    case "LDP150I140PE001":
                        val = 0.7;
                        break;
                    case "LDP600E070CE001":
                        val = 0.8;
                        break;
                    case "LDP096I140PE001":
                        val = 0.7;
                        break;
                    case "LDP075I105PE001":
                        val = 0.7;
                        break;
                    case "LDP075I210PE001":
                        val = 0.7;
                        break;
                    case "LDV480T343HU001":
                        val = 1;
                        break;
                    case "LDP150I280PE001":
                        val = 0.7;
                        break;
                    case "LDP600E070CE002":
                        val = 0.8;
                        break;
                    case "LDA600TA048DB003":
                        val = 0.7;
                        break;
                    case "LDP240I300PE001":
                        val = 0.8;
                        break;
                    case "LD200IC210W76AD3101":
                        val = 0.75;
                        break;
                    case "LD200IC140W76AD3101":
                        val = 0.75;
                        break;
                    case "LDP320I210PU001":
                        val = 0.85;
                        break;
                    case "LD150IC140W76AD3101":
                        val = 0.75;
                        break;
                    case "LDC400I240PU001":
                        val = 0.9;
                        break;
                    case "LDC320S190HU001":
                        val = 0.91;
                        break;
                    case "LDP1K0E054HE001":
                        val = 0.5;
                        break;
                    case "LDP240I210PE201":
                        val = 0.8;
                        break;

                    case "LDC500E052HE001":
                        val = 0.7;
                        break;
                    case "LDC600E014HE001":
                        val = 0.7;
                        break;
                    case "LDC600E028HE001":
                        val = 0.7;
                        break;
                    case "LDC600E031HE001":
                        val = 0.7;
                        break;
                    case "LDC600E074HE001":
                        val = 0.7;
                        break;
                    case "LDC1K0E051HE001":
                        val = 0.7;
                        break;
                    case "LDC1K0E044HE001":
                        val = 0.7;
                        break;
                    case "LDC1K0E056HE001":
                        val = 0.7;
                        break;
                    case "LDC1K2E042HE001":
                        val = 0.7;
                        break;
                    case "LDC1K2E074HE001":
                        val = 0.7;
                        break;
                    case "LDC480T014HE001":
                        val = 0.7;
                        break;
                    case "LDC480T028HE001":
                        val = 0.7;
                        break;
                    case "LDC480T056HE001":
                        val = 0.7;
                        break;
                    case "LDC480T074HE001":
                        val = 0.7;
                        break;
                    case "LDP480T036HE001":
                        val = 0.85;
                        break;
                    case "LDP480T060HE001":
                        val = 0.85;
                        break;
                    case "LDC600D021HE001":
                        val = 0.7;
                        break;
                    case "LDC600D017HE001":
                        val = 0.7;
                        break;
                    case "LDC600D014HE001":
                        val = 1;
                        break;
                    case "LDC480T042HE001":
                        val = 0.7;
                        break;
                    case "LDC480T080HE001":
                        val = 0.7;
                        break;
                    case "LDC600U063HU002":
                        val = 0.7;
                        break;
                    case "LDP320I210PE201":
                        val = 0.8;
                        break;
                    case "LDP320I280PE201":
                        val = 0.8;
                        break;
                    case "LDA600TA054DB001":
                        val = 0.7;
                        break;
                    case "LDP1K2E054HE001":
                        val = 0.7;
                        break;
                    case "LDC600U074HU001":
                        val = 0.7;
                        break;
                    case "LDP240I490PE201":
                        val = 0.7;
                        break;
                    case "LDE600EA024DB101":
                        val = 1;
                        break;
                    case "LD320IC210W76AD3102":
                        val = 0.7;
                        break;


                    case "LDP320I210PE101":
                        val = 0.8;
                        break;
                    case "LDP240I140PE101":
                        val = 0.8;
                        break;
                    case "LDC600E042HE001":
                        val = 0.7;
                        break;
                    case "LDC480T042HE002":
                        val = 0.7;
                        break;
                    case "LDP400I024PE101":
                        val = 0.6;
                        break;
                    case "LDP400I210PE101":
                        val = 0.8;
                        break;
                    case "LDA600TA048DB201":
                        val = 0.6;
                        break;


                    case "LDP075I210PE101":
                        val = 0.7;
                        break;
                    case "LDP100I210PE101":
                        val = 0.7;
                        break;
                    case "LDP100I140PE101":
                        val = 0.7;
                        break;
                    case "LDP150I105PE101":
                        val = 0.7;
                        break;
                    case "LDP240I630PE201":
                        val = 0.7;
                        break;
                    default:
                        break;
                }
                cs.InitOutputCurrent(viewModel.SupPowerModel.GetData(), HoldVoltageShow, VariableOutputRegion, val);
                ChartHelper.ChartInit(chartOutputCurrent, cs);
            }
        }

        private void nudOutputCurrent_ValueChanged(object sender, EventArgs e)
        {
            SupPowerModelData supPowerModelData = viewModel.SupPowerModel.GetData();
            if (supPowerModelData != null)
            {
                try
                {
                    nudOutputVoltageMax.Value = (decimal)supPowerModelData.supPowerModelOutCurrent.GetOutputCurrentVoltageMax((double)nudOutputCurrent.Value);
                }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    nudOutputVoltageMax.Value = nudOutputVoltageMax.Minimum;//赋值失败，使用最小值
                }
                supPowerModelData.supPowerModelOutCurrent.OutputCurrent = (double)nudOutputCurrent.Value;
                UIToOutputModel();

                viewModel.ViewOutputCurrent = (double)nudOutputCurrent.Value;
                viewModel.ViewOutputVoltageMax = (double)nudOutputVoltageMax.Value;
            }
        }
        #endregion

        #region 模式设置页面--设备工作模式设置
        /// <summary>
        /// 模型数据初始化UI
        /// </summary>
        /// <param name="i"></param>
        private void InitDataModolToUI(int i)
        {
            switch (i)
            {
                case 0:
                    rdbtnVol.Checked = true;
                    break;
                case 1:
                    rdbtnCommunicate.Checked = true;
                    break;
                case 2:
                    rdbtnTimeCtr.Checked = true;
                    break;
                case 3:
                    rdbtnPWMA.Checked = true;
                    break;
                case 4:
                    rdbtnConstantPower.Checked = true;
                    break;
                case 5:
                    rdbtnConstantCurrent.Checked = true;
                    break;
                case 6:
                    rdbtnPWMB.Checked = true;
                    break;
                case 7:
                    rdbtnVolF.Checked = true;
                    break;
                default:
                    break;
            }
        }
        /// <summary>
        /// 设备工作模式选择
        /// 0：0-10V（默认）
        /// 1：通讯
        /// 2：时控
        /// 3：PWM正向
        /// 4：恒功率
        /// 5：恒电流
        /// 6：PWM返向
        /// </summary>
        /// <returns></returns>
        public ushort SelectionOperationMode()
        {
            //2019年1月26日 08:24:39
            //“通讯”模式下的附加内容 应在“在线电源”模式下才展示启用
            //判断当前模式不是在线电源模式
            if (viewModel.IsPower)
            {
                gbxDimRadio.Enabled = rdbtnCommunicate.Checked;
                //gbxDimRadio.Visible = rdbtnCommunicate.Checked;
            }
            else
            {
                gbxDimRadio.Enabled = false;
            }
            scbxTimeCtrl1.Checked = rdbtnTimeCtr.Checked;
            if (rdbtnVol.Checked) return 0;//0-10V
            if (rdbtnCommunicate.Checked) return 1;//通讯

            if (rdbtnPWMA.Checked) return 3;//PWM正向
            if (rdbtnPWMB.Checked) return 6;//PWM返向
            if (rdbtnConstantPower.Checked) return 4;//恒功率
            if (rdbtnConstantCurrent.Checked) return 5;//恒压
            if (rdbtnTimeCtr.Checked)
            {
                tcData.SelectedIndex = 4;
                return 2;//时控
            }
            if (rdbtnVolF.Checked) return 7;//0-10V 反逻辑
            //2019年1月24日 10:19:47
            //修复读取数据时，非时控模式，时控界面可更改
            //判断当前模式不是时控模式，就把时控不启用
            rdbtnVol.Checked = true; return 0;//没有一个选中的
        }
        private void rdbtnWorkMode_CheckedChanged(object sender, EventArgs e)
        {
            viewModel.ViewWorkMode = SelectionOperationMode();
            int i = 0;
            switch (viewModel.ViewWorkMode)
            {
                case 0://0-10V
                    i = 0;
                    break;
                case 1://通讯
                    i = 1;
                    break;
                case 2://时控
                    i = 6;
                    break;
                case 3://PWM正向
                    i = 2;
                    break;
                case 4://恒功率
                    i = 3;
                    break;
                case 5://恒压
                    i = 4;
                    break;
                case 6://PWM返向
                    i = 5;
                    break;
                case 7://0-10V 反逻辑
                    i = 7;
                    break;
            }
            stbcWorkMode.SelectedIndex = i;

            Debug.WriteLine("模式设置：" + viewModel.ViewWorkMode);
            LogHelper.Info("模式设置：" + viewModel.ViewWorkMode);
        }

        #region 模式设置-通讯
        private string MinuteToLocalTime(uint minutes)
        {
            //minutes = 100*24 * 60 + 2 * 60 + 30;
            uint day = minutes / 60 / 24;
            uint hour = minutes / 60 % 24;
            uint min = minutes % 60;
            return day.ToString("00") + " day " + hour.ToString("00") + " hour " + min.ToString("00") + " minute";
            //return (minutes / 60).ToString("00") + ":" + (minutes % 60).ToString("00");
        }
        string FaultCode = "N/A";
        //读取电源状态
        void InitDimRadioStateInfo(SupPowerRealData bts)
        {
            try
            {
                string s = XMLSerializerHelper.Serializer(typeof(SupPowerRealData), bts);
                LogHelper.Info("模式设置-通讯-读取电源状态info:" + s);
            }
            catch (Exception ex)
            {
                LogHelper.Info("模式设置-通讯-读取电源状态info序列化异常:" + ex.Message);
            }


            labDimVoltage.Text = bts.Voltage.ToString() + " V";//电压
            labDimCurrent.Text = (bts.Current / 1000.0).ToString() + " A";//电流
            labDimOutTemp.Text = ((short)bts.OutTemp / 10.0).ToString("0.0") + " ";//外部温度
            labDimInTemp.Text = ((short)bts.InTemp / 10.0).ToString("0.0");//内部温度
            labDimRunTimes.Text = bts.RunTimes.ToString();//运行次数
            labDimRunTime.Text = MinuteToLocalTime(bts.RunTime);//bts.RunTime.ToString()+" min";//运行时长
            labDimRunTime1.Text = MinuteToLocalTime(bts.LastRunTime);//bts.LastRunTime.ToString()+" min";//运行时长
            labDimRunTime2.Text = MinuteToLocalTime(bts.LastLastRunTime);//bts.LastLastRunTime.ToString()+" min";//运行时长

            switch (bts.FaultCode)
            {
                case 0:
                    FaultCode = "正常工作";
                    break;
                case 1:
                    FaultCode = "短路或者负载电压过低";
                    break;
                case 2:
                    FaultCode = "温度过高";
                    break;
                case 3:
                    FaultCode = "输出电流过冲";
                    break;
                case 4:
                    FaultCode = "输入电压低";
                    break;
                default:
                    break;
            }
            labDimFaultCode.Text = LanguageHelper.getResources(FaultCode);
        }
        private void stbDimRadio_Scroll(object sender, EventArgs e)
        {
            nudDimradio.Value = stbDimRadio.Value;
        }

        private void nudDimradio_ValueChanged(object sender, EventArgs e)
        {
            stbDimRadio.Value = (int)nudDimradio.Value;
        }

        //调光
        private void btnDimRadio_Click(object sender, EventArgs e)
        {
            LogHelper.Info("模式设置-通讯-调光控制");
            try
            {
                if (GetSerialPortState())
                {
                    ShowMsg("电源数据写入中...");
                    //UIState(false);
                    btnWriteDrive.Enabled = false;

                    try
                    {
                        SupPowerModel spm = combModel.SelectedItem as SupPowerModel;
                        SupPowerSeries sps = combSeries.SelectedItem as SupPowerSeries;
                        viewModel.Power.ProductTypeName = spm.Name;
                        viewModel.Power.SoftVersion = sps.Name;
                        int val = (int)nudDimradio.Value;
                        LogHelper.Info("模式设置-通讯-调光值" + val);
                        bool obj = ProtocolManage.WriteBytesToDevice(serialPort, 2000, 1, 1080, new byte[] { (byte)(val >> 8), (byte)(val) });
                        if (obj == true)
                        {
                            ShowMsg("电源数据写入成功");
                        }
                        else
                        {
                            ShowMsg("电源数据写入超时");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        ShowMsg("电源数据写入失败");
                    }

                    //UIState(true);
                    btnWriteDrive.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                LogHelper.Info(ex.Message);
            }
            LogHelper.Info("模式设置-通讯-调光控制完成");
        }
        //关灯
        private void btnDimradioOff_Click(object sender, EventArgs e)
        {
            LogHelper.Info("模式设置-通讯-关灯控制");
            try
            {
                if (GetSerialPortState())
                {
                    ShowMsg("电源数据写入中...");
                    //UIState(false);
                    btnWriteDrive.Enabled = false;

                    try
                    {
                        SupPowerModel spm = combModel.SelectedItem as SupPowerModel;
                        SupPowerSeries sps = combSeries.SelectedItem as SupPowerSeries;
                        viewModel.Power.ProductTypeName = spm.Name;
                        viewModel.Power.SoftVersion = sps.Name;
                        bool obj = ProtocolManage.WriteBytesToDevice(serialPort, 2000, 1, 1080, new byte[] { 0x00, 0x00 });
                        if (obj == true)
                        {
                            ShowMsg("电源数据写入成功");
                        }
                        else
                        {
                            ShowMsg("电源数据写入超时");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        ShowMsg("电源数据写入失败");
                    }

                    //UIState(true);
                    btnWriteDrive.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                LogHelper.Info(ex.Message);
            }
            LogHelper.Info("模式设置-通讯-关灯控制完成");
        }

        private void btnDimReadStateInfo_Click(object sender, EventArgs e)
        {
            LogHelper.Info("模式设置-通讯-读取电源状态");
            try
            {
                if (GetSerialPortState())
                {
                    ShowMsg("电源状态数据读取中...");
                    //UIState(false);
                    btnDimReadStateInfo.Enabled = false;

                    try
                    {
                        object obj = ProtocolManage.ReadDeviceToStruct4(serialPort, 2000, 1, 1, typeof(SupPowerRealData));
                        if (obj != null)
                        {
                            SupPowerRealData sprd = (SupPowerRealData)obj;
                            InitDimRadioStateInfo(sprd);
                            ShowMsg("电源状态数据读取成功");
                        }
                        else
                        {
                            ShowMsg("电源状态数据读取超时");
                        }
                    }
                    catch (Exception ex)
                    {
                        Debug.WriteLine(ex.Message);
                        ShowMsg("电源状态数据读取失败");
                    }
                    //UIState(true);
                    btnDimReadStateInfo.Enabled = true;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
                LogHelper.Info(ex.Message);
            }
            LogHelper.Info("模式设置-通讯-读取电源状态完成");
        }
        #endregion
        #endregion


        #region 温度保护页面----外部、内部
        #region 外部
        //初始化温度页面的控件 外部
        private void InitDataTempUI()
        {
            try
            {
                //外部
                try { numudOutProtect.Value = (decimal)viewModel.ViewOutTempProtection; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numudOutProtect.Value = numudOutProtect.Minimum;
                    throw ex;
                }
                try { numudOutRecover.Value = (decimal)viewModel.ViewOutTempRecover; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numudOutRecover.Value = numudOutRecover.Minimum;
                    throw ex;
                }
                try { numudOutProtectCurrent.Value = (decimal)viewModel.ViewOutTempCurrent; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numudOutProtectCurrent.Value = numudOutProtectCurrent.Minimum;
                    throw ex;
                }
                try { stbOutProtect.Value = (int)viewModel.ViewOutTempProtection; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    stbOutProtect.Value = stbOutProtect.Minimum;
                    throw ex;
                }
                try { stbOutRecover.Value = (int)viewModel.ViewOutTempRecover; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    stbOutRecover.Value = stbOutRecover.Minimum;
                    throw ex;
                }
                try { stbOutProtectCurrent.Value = (int)viewModel.ViewOutTempCurrent; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    stbOutProtectCurrent.Value = stbOutProtectCurrent.Minimum;
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                LogHelper.Info(ex.Message);
            }

            //sckboxOutCtr.Checked = false;//温度修改的启用

            UIToOutTemp();
        }

        /// <summary>
        /// 控件初始化模型
        /// </summary>
        private void UIToOutTemp()
        {
            List<ChartSet> lscs = viewModel.SupPowerModel.GetCharts();
            ChartSet cs = lscs.FirstOrDefault(a => a.Name == "TempChart");
            if (cs != null)
            {
                cs.InitDataTemp(viewModel.SupPowerModel.GetData());
                ChartHelper.ChartInit(chartTemperatureProtection, cs);
            }
        }

        //绑定控件是否启用
        private void sckboxOutCtr_Click(object sender, EventArgs e)
        {
            stbOutRecover.Enabled = sckboxOutCtr.Checked;
            stbOutProtect.Enabled = sckboxOutCtr.Checked;
            stbOutProtectCurrent.Enabled = sckboxOutCtr.Checked;
            numudOutRecover.Enabled = sckboxOutCtr.Checked;
            numudOutProtect.Enabled = sckboxOutCtr.Checked;
            numudOutProtectCurrent.Enabled = sckboxOutCtr.Checked;
            btnOutTempDefault.Enabled = sckboxOutCtr.Checked;
        }
        //外部默认值按钮
        private void sbtnOutTempDefault_Click(object sender, EventArgs e)
        {
            // 初始所有控件为最大最小值，解决大小判断问题
            numudOutRecover.Value = numudOutRecover.Minimum;
            numudOutProtect.Value = numudOutProtect.Maximum;

            viewModel.ViewInitOutTempDefault();
            InitDataTempUI();
        }
        #endregion

        #region 内部
        //初始化温度页面的控件 内部
        private void InitDataTempInUI()
        {
            try
            {
                //内部
                try { stbInRecover.Value = (int)viewModel.ViewInTempRecover; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    stbInRecover.Value = stbInRecover.Minimum;
                    throw ex;
                }
                try { stbInProtect.Value = (int)viewModel.ViewInTempProtection; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    stbInProtect.Value = stbInProtect.Minimum;
                    throw ex;
                }
                try { stbInProtectCurrent.Value = (int)viewModel.ViewInTempCurrent; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    stbInProtectCurrent.Value = stbInProtectCurrent.Minimum;
                    throw ex;
                }
                try { numudInRecover.Value = (int)viewModel.ViewInTempRecover; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numudInRecover.Value = numudInRecover.Minimum;
                    throw ex;
                }
                try { numudInProtect.Value = (int)viewModel.ViewInTempProtection; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numudInProtect.Value = numudInProtect.Minimum;
                    throw ex;
                }
                try { numudInProtectCurrent.Value = (int)viewModel.ViewInTempCurrent; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numudInProtectCurrent.Value = numudInProtectCurrent.Minimum;
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Info(ex.Message);
            }
            UIToInTemp();
        }

        /// <summary>
        /// 控件初始化模型
        /// </summary>
        private void UIToInTemp()
        {
            List<ChartSet> lscs = viewModel.SupPowerModel.GetCharts();
            ChartSet cs = lscs.FirstOrDefault(a => a.Name == "TempInChart");
            if (cs != null)
            {
                cs.InitDataInTemp(viewModel.SupPowerModel.GetData());
                ChartHelper.ChartInit(chartInTemperatureProtection, cs);
            }
        }
        //绑定控件是否启用
        private void sckboxInCtr_Click(object sender, EventArgs e)
        {
            stbInRecover.Enabled = sckboxInCtr.Checked;
            stbInProtect.Enabled = sckboxInCtr.Checked;
            stbInProtectCurrent.Enabled = sckboxInCtr.Checked;
            numudInRecover.Enabled = sckboxInCtr.Checked;
            numudInProtect.Enabled = sckboxInCtr.Checked;
            numudInProtectCurrent.Enabled = sckboxInCtr.Checked;
            btnInTempDefault.Enabled = sckboxInCtr.Checked;
        }


        //内部默认按钮
        private void sbtnInTempDefault_Click(object sender, EventArgs e)
        {
            // 初始所有控件为最大最小值，解决大小判断问题
            numudInRecover.Value = numudInRecover.Minimum;
            numudInProtect.Value = numudInProtect.Maximum;

            viewModel.ViewInitInTempDefault();
            InitDataTempInUI();
        }
        #endregion
        #region 滑块与文本控件值相互绑定
        /// <summary>
        /// 文本框控制滑块
        /// </summary>
        /// <param name="numericUpDown"></param>
        /// <param name="skinTrackBar"></param>
        public void numericUpDownChangBar(NumericUpDown numericUpDown, CCWin.SkinControl.SkinTrackBar skinTrackBar)
        {
            skinTrackBar.Value = (int)numericUpDown.Value;
        }
        /// <summary>
        /// 滑块控制文本框
        /// </summary>
        /// <param name="numericUpDown"></param>
        /// <param name="skinTrackBar"></param>
        public void TrackBarScrollChangnumericUpDown(NumericUpDown numericUpDown, CCWin.SkinControl.SkinTrackBar skinTrackBar)
        {
            numericUpDown.Value = skinTrackBar.Value;
        }

        /// <summary>
        /// 滑块值改变处理
        /// </summary>
        /// <param name="sender"></param>
        private void TrackBar_Scroll(object sender)
        {
            CCWin.SkinControl.SkinTrackBar skinTrackBar = (CCWin.SkinControl.SkinTrackBar)sender;

            switch (skinTrackBar.Name)
            {
                case "stbOutRecover":
                    if (skinTrackBar.Value > numudOutProtect.Value)
                    {
                        skinTrackBar.Value = (int)numudOutProtect.Value;
                    }
                    TrackBarScrollChangnumericUpDown(numudOutRecover, skinTrackBar);
                    break;
                case "stbOutProtect":
                    if (skinTrackBar.Value < numudOutRecover.Value)
                    {
                        skinTrackBar.Value = (int)numudOutRecover.Value;
                    }
                    TrackBarScrollChangnumericUpDown(numudOutProtect, skinTrackBar);
                    break;
                case "stbOutProtectCurrent":
                    TrackBarScrollChangnumericUpDown(numudOutProtectCurrent, skinTrackBar);
                    break;
                case "stbInRecover":
                    if (skinTrackBar.Value > numudInProtect.Value)
                    {
                        skinTrackBar.Value = (int)numudInProtect.Value;
                    }
                    TrackBarScrollChangnumericUpDown(numudInRecover, skinTrackBar);
                    break;
                case "stbInProtect":
                    if (skinTrackBar.Value < numudInRecover.Value)
                    {
                        skinTrackBar.Value = (int)numudInRecover.Value;
                    }
                    TrackBarScrollChangnumericUpDown(numudInProtect, skinTrackBar);
                    break;
                case "stbInProtectCurrent":
                    TrackBarScrollChangnumericUpDown(numudInProtectCurrent, skinTrackBar);
                    break;
                default:
                    break;
            }
        }
        //滑块事件
        private void skinTrackBar_Scroll(object sender, EventArgs e)
        {
            TrackBar_Scroll(sender);
        }
        /// <summary>
        /// 文本框值改变处理
        /// </summary>
        /// <param name="sender"></param>
        private void NumUD_VolueChanged(object sender)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;
            LogHelper.Info("温度保护页面控件：" + numericUpDown.Name + " = " + numericUpDown.Value);
            switch (numericUpDown.Name)
            {
                case "numudOutRecover":
                    if (numericUpDown.Value > (decimal)viewModel.ViewOutTempProtection - 10)//stbOutProtect.Value)
                    {
                        numericUpDown.Value = (decimal)viewModel.ViewOutTempProtection - 10;
                    }
                    numericUpDownChangBar(numericUpDown, stbOutRecover);
                    // 实体数据
                    viewModel.ViewOutTempRecover = (double)numericUpDown.Value;

                    break;
                case "numudOutProtect":
                    if (numericUpDown.Value < (decimal)viewModel.ViewOutTempRecover + 10)
                    {
                        numericUpDown.Value = (decimal)viewModel.ViewOutTempRecover + 10;
                    }
                    numericUpDownChangBar(numericUpDown, stbOutProtect);
                    viewModel.ViewOutTempProtection = (double)numericUpDown.Value;
                    break;
                case "numudOutProtectCurrent":
                    numericUpDownChangBar(numericUpDown, stbOutProtectCurrent);
                    viewModel.ViewOutTempCurrent = (double)numericUpDown.Value;
                    break;
                //内部的值改变
                case "numudInRecover":
                    if (numericUpDown.Value > (decimal)viewModel.ViewInTempProtection - 10)
                    {
                        numericUpDown.Value = (decimal)viewModel.ViewInTempProtection - 10;
                    }
                    numericUpDownChangBar(numericUpDown, stbInRecover);
                    viewModel.ViewInTempRecover = (double)numericUpDown.Value;
                    break;
                case "numudInProtect":
                    if (numericUpDown.Value < (decimal)viewModel.ViewInTempRecover + 10)
                    {
                        numericUpDown.Value = (decimal)viewModel.ViewInTempRecover + 10;
                    }
                    numericUpDownChangBar(numericUpDown, stbInProtect);
                    viewModel.ViewInTempProtection = (double)numericUpDown.Value;
                    break;
                case "numudInProtectCurrent":
                    numericUpDownChangBar(numericUpDown, stbInProtectCurrent);
                    viewModel.ViewInTempCurrent = (double)numericUpDown.Value;
                    break;
                default:
                    break;
            }
        }
        //外部文本框事件
        private void numericUpDown_ValueChanged(object sender, EventArgs e)
        {
            NumUD_VolueChanged(sender);
            UIToOutTemp();

        }
        //内部文本框事件
        private void numericUpDownIn_ValueChanged(object sender, EventArgs e)
        {
            NumUD_VolueChanged(sender);
            UIToInTemp();
        }
        #endregion

        #endregion


        #region 定时设置页面
        private bool TimeCtrlstate = false;

        //初始化温度页面的控件
        private void InitDataTimeCtrlUI(SupPowerModelData supPowerModelData = null)
        {
            if (supPowerModelData != null)
            {
                TimeCtrlArg tca;
                // 1
                tca = new TimeCtrlArg();
                tca.Hold = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.hold1;
                tca.Level = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.level1;
                tca.Tran = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.tran1;
                viewModel.TimeCtrlArgs1 = tca;
                // 2
                tca = new TimeCtrlArg();
                tca.Hold = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.hold2;
                tca.Level = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.level2;
                tca.Tran = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.tran2;
                viewModel.TimeCtrlArgs2 = tca;
                // 3
                tca = new TimeCtrlArg();
                tca.Hold = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.hold3;
                tca.Level = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.level3;
                tca.Tran = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.tran3;
                viewModel.TimeCtrlArgs3 = tca;
                // 4
                tca = new TimeCtrlArg();
                tca.Hold = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.hold4;
                tca.Level = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.level4;
                tca.Tran = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.tran4;
                viewModel.TimeCtrlArgs4 = tca;
                // 5
                tca = new TimeCtrlArg();
                tca.Hold = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.hold5;
                tca.Level = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.level5;
                tca.Tran = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.tran5;
                viewModel.TimeCtrlArgs5 = tca;
                // 6
                tca = new TimeCtrlArg();
                tca.Hold = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.hold6;
                tca.Level = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.level6;
                tca.Tran = (ushort)supPowerModelData.supPowerModelDataTimeCtrl.tran6;
                viewModel.TimeCtrlArgs6 = tca;
            }
            TimeCtrlstate = false;
            try
            {
                //保持
                TimeCtrlArg tca;
                // 1
                tca = viewModel.TimeCtrlArgs1;
                try { numUDDuration1.Value = (int)tca.Hold; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDuration1.Value = numUDDuration1.Minimum;
                    throw ex;
                }
                try { numUDShade1.Value = (int)tca.Tran; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDShade1.Value = numUDShade1.Minimum;
                    throw ex;
                }
                try { numUDDimPower1.Value = (int)tca.Level; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDimPower1.Value = numUDDimPower1.Minimum;
                    throw ex;
                }

                // 2
                tca = viewModel.TimeCtrlArgs2;
                try { numUDDuration2.Value = (int)tca.Hold; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDuration2.Value = numUDDuration2.Minimum;
                    throw ex;
                }
                try { numUDShade2.Value = (int)tca.Tran; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDShade2.Value = numUDShade2.Minimum;
                    throw ex;
                }
                try { numUDDimPower2.Value = (int)tca.Level; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDimPower2.Value = numUDDimPower2.Minimum;
                    throw ex;
                }

                // 3
                tca = viewModel.TimeCtrlArgs3;
                try { numUDDuration3.Value = (int)tca.Hold; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDuration3.Value = numUDDuration3.Minimum;
                    throw ex;
                }
                try { numUDShade3.Value = (int)tca.Tran; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDShade3.Value = numUDShade3.Minimum;
                    throw ex;
                }
                try { numUDDimPower3.Value = (int)tca.Level; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDimPower3.Value = numUDDimPower3.Minimum;
                    throw ex;
                }

                // 4
                tca = viewModel.TimeCtrlArgs4;
                try { numUDDuration4.Value = (int)tca.Hold; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDuration4.Value = numUDDuration4.Minimum;
                    throw ex;
                }
                try { numUDShade4.Value = (int)tca.Tran; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDShade4.Value = numUDShade4.Minimum;
                    throw ex;
                }
                try { numUDDimPower4.Value = (int)tca.Level; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDimPower4.Value = numUDDimPower4.Minimum;
                    throw ex;
                }

                // 5
                tca = viewModel.TimeCtrlArgs5;
                try { numUDDuration5.Value = (int)tca.Hold; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDuration5.Value = numUDDuration5.Minimum;
                    throw ex;
                }
                try { numUDShade5.Value = (int)tca.Tran; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDShade5.Value = numUDShade5.Minimum;
                    throw ex;
                }
                try { numUDDimPower5.Value = (int)tca.Level; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDimPower5.Value = numUDDimPower5.Minimum;
                    throw ex;
                }

                // 6
                tca = viewModel.TimeCtrlArgs6;
                try { numUDDuration6.Value = (int)tca.Hold; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDuration6.Value = numUDDuration6.Minimum;
                    throw ex;
                }
                try { numUDShade6.Value = (int)tca.Tran; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDShade6.Value = numUDShade6.Minimum;
                    throw ex;
                }
                try { numUDDimPower6.Value = (int)tca.Level; }
                catch (Exception ex)
                {
                    Debug.WriteLine(ex.Message);
                    numUDDimPower6.Value = numUDDimPower6.Minimum;
                    throw ex;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Info(ex.ToString());
            }

            if (viewModel.TimeCtrlMode == 0)
            {
                rdbtnNormTimeCtrl.Checked = true;
                rdbtnAutoTimeCtrl.Checked = false;
            }
            if (viewModel.TimeCtrlMode == 1)
            {
                rdbtnNormTimeCtrl.Checked = false;
                rdbtnAutoTimeCtrl.Checked = true;
            }
            TimeCtrlstate = true;
            numUDTimeCtr_ValueChanged(numUDDimPower6, null);
        }

        /// <summary>
        /// 控件初始化模型
        /// </summary>
        private void UIToOutTimeCtrl()
        {
            SupPowerModelData supPowerModelData = viewModel.SupPowerModel.GetData();
            #region MyRegion
            //保持
            //supPowerModelData.supPowerModelDataTimeCtrl.hold1 = (ushort)numUDDuration1.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.hold2 = (ushort)numUDDuration2.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.hold3 = (ushort)numUDDuration3.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.hold4 = (ushort)numUDDuration4.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.hold5 = (ushort)numUDDuration5.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.hold6 = (ushort)numUDDuration6.Value;
            ////渐变              
            //supPowerModelData.supPowerModelDataTimeCtrl.tran1 = (ushort)numUDShade1.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.tran2 = (ushort)numUDShade2.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.tran3 = (ushort)numUDShade3.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.tran4 = (ushort)numUDShade4.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.tran5 = (ushort)numUDShade5.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.tran6 = (ushort)numUDShade6.Value;
            ////功率              
            //supPowerModelData.supPowerModelDataTimeCtrl.level1 = (ushort)numUDDimPower1.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.level2 = (ushort)numUDDimPower2.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.level3 = (ushort)numUDDimPower3.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.level4 = (ushort)numUDDimPower4.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.level5 = (ushort)numUDDimPower5.Value;
            //supPowerModelData.supPowerModelDataTimeCtrl.level6 = (ushort)numUDDimPower6.Value; 
            #endregion

            if (rdbtnNormTimeCtrl.Checked)
            {
                viewModel.TimeCtrlMode = 0;
                //supPowerModelData.supPowerModelDataTimeCtrl.TimeCtrlMode = 0;
            }
            if (rdbtnAutoTimeCtrl.Checked)
            {
                viewModel.TimeCtrlMode = 1;
                //supPowerModelData.supPowerModelDataTimeCtrl.TimeCtrlMode = 1;
            }

            #region MyRegion
            TimeCtrlArg timeCtrlArg = new TimeCtrlArg();
            timeCtrlArg.ID = 1;
            timeCtrlArg.Hold = (ushort)numUDDuration1.Value;
            timeCtrlArg.Tran = (ushort)numUDShade1.Value;
            timeCtrlArg.Level = (ushort)numUDDimPower1.Value;
            viewModel.TimeCtrlArgs1 = timeCtrlArg;

            TimeCtrlArg timeCtrlArg2 = new TimeCtrlArg();
            timeCtrlArg2.ID = 2;
            timeCtrlArg2.Hold = (ushort)numUDDuration2.Value;
            timeCtrlArg2.Tran = (ushort)numUDShade2.Value;
            timeCtrlArg2.Level = (ushort)numUDDimPower2.Value;
            viewModel.TimeCtrlArgs2 = timeCtrlArg2;

            TimeCtrlArg timeCtrlArg3 = new TimeCtrlArg();
            timeCtrlArg3.ID = 3;
            timeCtrlArg3.Hold = (ushort)numUDDuration3.Value;
            timeCtrlArg3.Tran = (ushort)numUDShade3.Value;
            timeCtrlArg3.Level = (ushort)numUDDimPower3.Value;
            viewModel.TimeCtrlArgs3 = timeCtrlArg3;

            TimeCtrlArg timeCtrlArg4 = new TimeCtrlArg();
            timeCtrlArg4.ID = 4;
            timeCtrlArg4.Hold = (ushort)numUDDuration4.Value;
            timeCtrlArg4.Tran = (ushort)numUDShade4.Value;
            timeCtrlArg4.Level = (ushort)numUDDimPower4.Value;
            viewModel.TimeCtrlArgs4 = timeCtrlArg4;

            TimeCtrlArg timeCtrlArg5 = new TimeCtrlArg();
            timeCtrlArg5.ID = 5;
            timeCtrlArg5.Hold = (ushort)numUDDuration5.Value;
            timeCtrlArg5.Tran = (ushort)numUDShade5.Value;
            timeCtrlArg5.Level = (ushort)numUDDimPower5.Value;
            viewModel.TimeCtrlArgs5 = timeCtrlArg5;

            TimeCtrlArg timeCtrlArg6 = new TimeCtrlArg();
            timeCtrlArg6.ID = 6;
            timeCtrlArg6.Hold = (ushort)numUDDuration6.Value;
            timeCtrlArg6.Tran = (ushort)numUDShade6.Value;
            timeCtrlArg6.Level = (ushort)numUDDimPower6.Value;
            viewModel.TimeCtrlArgs6 = timeCtrlArg6;
            #endregion

            List<ChartSet> lscs = viewModel.SupPowerModel.GetCharts();
            ChartSet cs = lscs.FirstOrDefault(a => a.Name == "TimeCtrlChart");
            if (cs != null)
            {
                cs.InitDataTimeCtrl(supPowerModelData);
                ChartHelper.ChartInit(chartTimeControl, cs);
            }
        }


        /// <summary>
        /// 求出剩余活动时间
        /// </summary>
        /// <param name="numericUpDowns">与时间有关的控件</param>
        /// <returns></returns>
        public decimal TimeRemaining(NumericUpDown[] numericUpDowns)
        {
            decimal a = 24 * 60;
            //求出剩余活动时间
            for (int i = 0; i < numericUpDowns.Length; i++)
            {
                a -= numericUpDowns[i].Value;
            }
            return a;
        }
        /// <summary>
        /// 抢劫底层控件的值
        /// </summary>
        /// <param name="numericUpDowns"></param>
        /// <param name="numtimeCtr"></param>
        public void RobTimeRemaining(NumericUpDown[] numericUpDowns, int numtimeCtr)
        {
            if (TimeRemaining(numericUpDowns) < 0)//剩余空间不够，从其他控件抢否则随便托,从6到1的顺序
            {
                for (int i = (numericUpDowns.Length - numtimeCtr); i > 0; i--)//有多少个控件的值可以抢
                {
                    if (TimeRemaining(numericUpDowns) > 0)//抢完后判断是否有空间
                    {
                        break;
                    }
                    numericUpDowns[i + numtimeCtr - 1].Value = 0;
                }
            }

            if ((numtimeCtr - 1) != 0)//判断是不是第0个
            {
                decimal aa = TimeRemaining(numericUpDowns);
                if (aa < 0)//抢完吐出多抢的
                {
                    if (numericUpDowns[numtimeCtr - 1].Value > 0)
                    {
                        if (numericUpDowns[numtimeCtr - 1].Value >= Math.Abs(aa))
                        {
                            numericUpDowns[numtimeCtr - 1].Value -= Math.Abs(aa);
                        }
                    }
                }
            }
        }
        /// <summary>
        /// 当前抢时间的控件
        /// </summary>
        /// <param name="sender"></param>
        public void TimeLength(object sender)
        {
            NumericUpDown numericUpDown = (NumericUpDown)sender;//当前对象
            //所有时间控件对象
            NumericUpDown[] numericUpDowns = {
                numUDDuration1,
                numUDShade1,
                numUDDuration2,
                numUDShade2,
                numUDDuration3,
                numUDShade3,
                numUDDuration4,
                numUDShade4,
                numUDDuration5,
                numUDShade5,
                numUDDuration6,
                numUDShade6
            };

            switch (numericUpDown.Name)
            {
                //保持时长
                case "numUDDuration1":
                    RobTimeRemaining(numericUpDowns, 1);
                    break;
                case "numUDDuration2":
                    RobTimeRemaining(numericUpDowns, 3);
                    break;
                case "numUDDuration3":
                    RobTimeRemaining(numericUpDowns, 5);
                    break;
                case "numUDDuration4":
                    RobTimeRemaining(numericUpDowns, 7);
                    break;
                case "numUDDuration5":
                    RobTimeRemaining(numericUpDowns, 9);
                    break;
                case "numUDDuration6":
                    RobTimeRemaining(numericUpDowns, 11);
                    break;

                //渐变
                case "numUDShade1":
                    RobTimeRemaining(numericUpDowns, 2);
                    break;
                case "numUDShade2":
                    RobTimeRemaining(numericUpDowns, 4);
                    break;
                case "numUDShade3":
                    RobTimeRemaining(numericUpDowns, 6);
                    break;
                case "numUDShade4":
                    RobTimeRemaining(numericUpDowns, 8);
                    break;
                case "numUDShade5":
                    RobTimeRemaining(numericUpDowns, 10);
                    break;
                case "numUDShade6":
                    //RobTimeRemaining(numericUpDowns, 12);//最后一个，没有可抢对象
                    break;

                //调光比
                case "numUDDimPower1":
                    if (numericUpDown.Value < 10)
                    {
                        numUDDimPower1.Value = 0;
                    }
                    numUDDimPower1.Value = numericUpDown.Value;
                    break;
                case "numUDDimPower2":
                    if (numericUpDown.Value < 10)
                    {
                        numUDDimPower2.Value = 0;
                    }
                    numUDDimPower2.Value = numericUpDown.Value;
                    break;
                case "numUDDimPower3":
                    if (numericUpDown.Value < 10)
                    {
                        numUDDimPower3.Value = 0;
                    }
                    numUDDimPower3.Value = numericUpDown.Value;
                    break;
                case "numUDDimPower4":
                    if (numericUpDown.Value < 10)
                    {
                        numUDDimPower4.Value = 0;
                    }
                    numUDDimPower4.Value = numericUpDown.Value;
                    break;
                case "numUDDimPower5":
                    if (numericUpDown.Value < 10)
                    {
                        numUDDimPower5.Value = 0;
                    }
                    numUDDimPower5.Value = numericUpDown.Value;
                    break;
                case "numUDDimPower6":
                    if (numericUpDown.Value < 10)
                    {
                        numUDDimPower6.Value = 0;
                    }
                    numUDDimPower6.Value = numericUpDown.Value;
                    break;
                default:
                    break;
            }
        }


        //控件触发事件
        private void numUDTimeCtr_ValueChanged(object sender, EventArgs e)
        {
            if (TimeCtrlstate)
            {
                TimeLength(sender);
                UIToOutTimeCtrl();
            }
        }
        //时控参数是否允许修改
        private void scbxTimeCtrl_CheckedChanged(object sender, EventArgs e)
        {
            if (scbxTimeCtrl1.Checked)
            {
                if (MessageBox.Show(LanguageHelper.getResources("启用定时模式,覆盖当前模式"), LanguageHelper.getResources("提示"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                {
                    scbxTimeCtrl1.Checked = true;
                    rdbtnTimeCtr.Checked = true;
                }
                else
                {
                    scbxTimeCtrl1.Checked = false;
                }
            }
            if (sender != null)
            {
                if (scbxTimeCtrl1.Checked == false)
                {
                    //MessageBox.Show(LanguageHelper.getResources("取消定时模式,当前模式0-10V"), LanguageHelper.getResources("提示"));
                    rdbtnTimeCtr.Checked = false;
                }
            }
            btnTimeCtrlDefault.Enabled = scbxTimeCtrl1.Checked;
            btnTimeCtrlFullPower.Enabled = scbxTimeCtrl1.Checked;
            rdbtnNormTimeCtrl.Enabled = scbxTimeCtrl1.Checked;
            rdbtnAutoTimeCtrl.Enabled = scbxTimeCtrl1.Checked;

            numUDDuration1.Enabled = scbxTimeCtrl1.Checked;
            numUDDuration2.Enabled = scbxTimeCtrl1.Checked;
            numUDDuration3.Enabled = scbxTimeCtrl1.Checked;
            numUDDuration4.Enabled = scbxTimeCtrl1.Checked;
            numUDDuration5.Enabled = scbxTimeCtrl1.Checked;
            numUDDuration6.Enabled = scbxTimeCtrl1.Checked;


            numUDShade1.Enabled = scbxTimeCtrl1.Checked;
            numUDShade2.Enabled = scbxTimeCtrl1.Checked;
            numUDShade3.Enabled = scbxTimeCtrl1.Checked;
            numUDShade4.Enabled = scbxTimeCtrl1.Checked;
            numUDShade5.Enabled = scbxTimeCtrl1.Checked;
            numUDShade6.Enabled = scbxTimeCtrl1.Checked;


            numUDDimPower1.Enabled = scbxTimeCtrl1.Checked;
            numUDDimPower2.Enabled = scbxTimeCtrl1.Checked;
            numUDDimPower3.Enabled = scbxTimeCtrl1.Checked;
            numUDDimPower4.Enabled = scbxTimeCtrl1.Checked;
            numUDDimPower5.Enabled = scbxTimeCtrl1.Checked;
            numUDDimPower6.Enabled = scbxTimeCtrl1.Checked;
        }
        /// <summary>
        /// 时控模式选择
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void rdbtnTimeCtrlMode_Click(object sender, EventArgs e)
        {
            if (rdbtnNormTimeCtrl.Checked)
            {
                viewModel.TimeCtrlMode = 0;
            }
            if (rdbtnAutoTimeCtrl.Checked)
            {
                viewModel.TimeCtrlMode = 1;
            }
            UIToOutTimeCtrl();
        }
        //默认值的按钮
        private void btnTimeCtrlDefault_Click(object sender, EventArgs e)
        {
            InitDataTimeCtrlUI(new SupPowerModelData());
            UIToOutTimeCtrl();
        }
        //满功率曲线
        private void btnTimeCtrlFullPower_Click(object sender, EventArgs e)
        {
            SupPowerModelData supPowerModelData = new SupPowerModelData();
            supPowerModelData.supPowerModelDataTimeCtrl.level1 = 100;
            supPowerModelData.supPowerModelDataTimeCtrl.level2 = 100;
            supPowerModelData.supPowerModelDataTimeCtrl.level3 = 100;
            supPowerModelData.supPowerModelDataTimeCtrl.level4 = 100;
            supPowerModelData.supPowerModelDataTimeCtrl.level5 = 100;
            supPowerModelData.supPowerModelDataTimeCtrl.level6 = 100;
            InitDataTimeCtrlUI(supPowerModelData);
            UIToOutTimeCtrl();
        }
        #endregion


        #region 读取或保存当前配置,中引文切换
        //配置文件默认保存路径
        private string circuitPath = Application.StartupPath + @"\Config\";
        //读取配置
        private void btnReadConfig_Click(object sender, EventArgs e)
        {
            try
            {
                OpenFileDialog file = new OpenFileDialog();
                file.Filter = "config|*.set";
                file.InitialDirectory = circuitPath;
                if (file.ShowDialog() == DialogResult.OK)
                {
                    ViewModel c;
                    using (FileStream fs = new FileStream(file.FileName, FileMode.Open))
                    {
                        XmlSerializer serializer = new XmlSerializer(typeof(ViewModel));
                        object obj = serializer.Deserialize(fs);
                        c = obj as ViewModel;
                    }
                    if (c != null)
                    {

                        SupPowerSeries sps = lsSupPowerSeries.FirstOrDefault(a => a.Guid == c.supPowerModel.SupPowerSeriesGuid);
                        if (sps != null)
                        {
                            combSeries.SelectedItem = sps;
                            combSeries_SelectedIndexChanged(null, null);
                            SupPowerModel spm = lsSupPowerModels.FirstOrDefault(b => b.Guid == c.supPowerModel.Guid);
                            if (spm != null)
                            {
                                //supPowerModel = viewModel.supPowerModel;
                                combModel.SelectedItem = spm;

                                viewModel = c;
                                combModel_SelectedIndexChanged(null, null);

                                int index = combTagType.SelectedIndex;
                                if (c.IsPower)
                                {
                                    combTagType.SelectedIndex = 1;
                                }
                                else
                                {
                                    combTagType.SelectedIndex = 0;
                                }
                                if (index == combTagType.SelectedIndex)
                                {
                                    combTagType_SelectedIndexChanged(null, null);
                                }
                                MessageBox.Show(LanguageHelper.getResources("读取成功"));
                                return;
                            }
                        }
                        MessageBox.Show(LanguageHelper.getResources("模型不存在"));
                    }
                    MessageBox.Show(LanguageHelper.getResources("读取失败"));
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show(LanguageHelper.getResources("无效配置文件"));
                LogHelper.Info(ex.Message);
            }
        }
        //保存配置
        private void btnSaveConfig_Click(object sender, EventArgs e)
        {
            try
            {
                //string path = circuitPath + DateTime.Now.ToString("yyyyMMddhhmmss")+ @".config";

                SaveFileDialog saveFile = new SaveFileDialog();
                saveFile.InitialDirectory = circuitPath;
                saveFile.Title = "Save";
                saveFile.Filter = "config|*.set";
                saveFile.FileName = combModel.Text.Trim() + "_" + DateTime.Now.ToString("HHmmss") + ".set";
                if (saveFile.ShowDialog() == DialogResult.OK)
                {
                    string path = saveFile.FileName;
                    string s = XMLSerializerHelper.Serializer(typeof(ViewModel), viewModel);
                    s = s.Replace("&#x0;", "");
                    File.WriteAllText(path, s);
                    MessageBox.Show(LanguageHelper.getResources("保存成功"));
                }

            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
                MessageBox.Show(LanguageHelper.getResources("保存失败"));
                LogHelper.Info(ex.Message);
            }
        }
        private void 读取配置文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnReadConfig_Click(null, null);
        }

        private void 保存配置文件ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            btnSaveConfig_Click(null, null);
        }
        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            this.Dispose();
            this.Close();
        }
        
        private void 中文ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //界面多语言
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(LanguageType.zh.ToString());//中文界面 
            //窗体加载并显示后，对窗体实现多语言处理
            if (!this.DesignMode)
            {
                if (!LanguageHelper.InitLanguage(this))
                {
                    LanguageHelper.updateFile();
                    LanguageHelper.InitLanguage(this);
                }
            }
            MenuitemLanguage();
            languageHelp = "中文";
        }
        private void englishToolStripMenuItem_Click(object sender, EventArgs e)
        {

            //界面多语言
            System.Threading.Thread.CurrentThread.CurrentUICulture = new System.Globalization.CultureInfo(LanguageType.en.ToString());// 
            if (!LanguageHelper.InitLanguage(this))
            {
                LanguageHelper.updateFile();
                LanguageHelper.InitLanguage(this);
            }
            MenuitemLanguage();
            languageHelp = "英文";
        }

        private void 更新日志ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //string circuitPath = Application.StartupPath + @"\log\";
            //System.Diagnostics.Process.Start("explorer.exe", circuitPath);
            FormUpdateLog formUpdateLog = new FormUpdateLog();
            formUpdateLog.ShowDialog();
        }
        private void 关于ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            FormAbout formAbout = new FormAbout();
            formAbout.ShowDialog();
        }
        private void 帮助ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            try
            {
                string circuitPath = null;
                switch (languageHelp)
                {
                    case "中文":
                        circuitPath = Application.StartupPath + @"\Resources\help_zh.pdf";
                        break;
                    case "英文":
                        circuitPath = Application.StartupPath + @"\Resources\help_en.pdf";
                        break;
                    default:
                        break;
                }
                Process.Start(circuitPath);
            }
            catch (Exception)
            {
            }
            //string circuitPath = Application.StartupPath + @"\Resources\help.pdf";
            //Process.Start(circuitPath);
            //Process.Start("explorer.exe", circuitPath);//打开资源管理器
        }
        private string FOTAPath = Application.StartupPath + @"\FOTA\";
        private void 升级固件ToolStripMenuItem_Click(object sender, EventArgs e)
        {

            if (GetSerialPortState())
            {
                OpenFileDialog ofd = new OpenFileDialog();
                ofd.Filter = "(*.bin)|*.bin";
                ofd.InitialDirectory = FOTAPath;
                if (ofd.ShowDialog() == DialogResult.OK)
                {
                    if (MessageBox.Show(LanguageHelper.getResources("升级固件？"), LanguageHelper.getResources("提示"), MessageBoxButtons.YesNo) == DialogResult.Yes)
                    {
                        try
                        {
                            LogHelper.Info("升级固件开始");
                            ProtocolManage.FOATMode(serialPort, 1000);
                            ProgressBar progressBar = new ProgressBar(serialPort, ofd.FileName);
                            progressBar.Show();
                        }
                        catch (Exception ex)
                        {
                            LogHelper.Info("升级固件：" + ex.Message);
                            MessageBox.Show(LanguageHelper.getResources("升级固件失败"));
                        }
                    }
                    else
                    {
                        ShowMsg("升级已取消");
                        MessageBox.Show(LanguageHelper.getResources("升级已取消"));
                    }
                }
            }
        }
        //打开CSA协议说明
        private void toolStripMenuItem1_Click(object sender, EventArgs e)
        {
            string circuitPath = Application.StartupPath + @"\Resources\csa.pdf";
            Process.Start(circuitPath);
        }





        #region 软件更新

        private void 检测更新ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            Updater updater = Updater.Instance;

            updater.NoUpdatesFound += Updater_NoUpdatesFound;
            updater.Error += Updater_Error;
            updater.MinmumVersionRequired += Updater_MinmumVersionRequired;

            Updater.CheckUpdateSimple("http://222.92.212.62:1218/{0}", "update.xml");
        }

        private void Updater_Error(object sender, EventArgs e)
        {
            Updater updater = Updater.Instance;
            MessageBox.Show(LanguageHelper.getResources("更新发生了错误：") + updater.Context.Exception.Message);

            updater.NoUpdatesFound -= Updater_NoUpdatesFound;
            updater.Error -= Updater_Error;
            updater.MinmumVersionRequired -= Updater_MinmumVersionRequired;
        }

        private void Updater_MinmumVersionRequired(object sender, EventArgs e)
        {
            Updater updater = Updater.Instance;
            MessageBox.Show(LanguageHelper.getResources("当前版本过低无法使用自动更新！"));

            updater.NoUpdatesFound -= Updater_NoUpdatesFound;
            updater.Error -= Updater_Error;
            updater.MinmumVersionRequired -= Updater_MinmumVersionRequired;
        }

        private void Updater_NoUpdatesFound(object sender, EventArgs e)
        {
            MessageBox.Show(LanguageHelper.getResources("已是最新版本"));
            Updater updater = Updater.Instance;

            //string LocalVer = Assembly.GetExecutingAssembly().GetName().Version.ToString();
            //string serverVer= Updater.UpdaterClientVersion;
            //MessageBox.Show(LanguageHelper.getResources("当前版本:" + LocalVer + "\r\n" + "服务器版本:" + serverVer));

            updater.NoUpdatesFound -= Updater_NoUpdatesFound;
            updater.Error -= Updater_Error;
            updater.MinmumVersionRequired -= Updater_MinmumVersionRequired;
        }
        #endregion

        #endregion

        private void nud_Leave(object sender, EventArgs e)
        {
            if (sender == null) return;

            NumericUpDown nud = sender as NumericUpDown;
            nud.Text = nud.Value.ToString();
        }

        #region 型号改变，隐藏或改变界面现实

        public void LD320IC210W76AD3102(bool show = false)
        {
            rdbtnVolF.Visible = show;
        }

        public void LDC600T074(bool show = false)
        {
            rdbtnConstantCurrent.Visible = show;
            skinLine4.Visible = show;
            label60.Visible = show;
            HoldVoltageShow = show;
        }

        public void LDC1K2T074(bool show=false)
        {
            rdbtnConstantCurrent.Visible = show;
            skinLine4.Visible = show;
            label60.Visible = show;
            HoldVoltageShow = show;
        }

        public void LD150IC105W76AD3001(bool show = false)
        {
            #region 模式
            rdbtnConstantCurrent.Visible = show;
            rdbtnConstantPower.Visible = show;
            label22.Visible = show;
            labDimInTemp.Visible = show;
            label33.Visible = show;
            labDimRunTimes.Visible = show;
            label39.Visible = show;
            labDimRunTime.Visible = show;
            labeltl1.Visible = show;
            labDimRunTime2.Visible = show;
            labeltl2.Visible = show;
            labDimRunTime1.Visible = show;
            #endregion
            #region 温度设置
            gbTempIn.Visible = show;
            #endregion
            rdbtnAutoTimeCtrl.Visible = show;
            panel2.Visible = show;

            //控制输出电流的红色线_恒压 是否显示
            skinLine4.Visible = show;
            label60.Visible = show;
            HoldVoltageShow = show;

            //skinLine2.Visible = show;
            //label50.Visible = show;
            //VariableOutputRegion = show;
        }

        /// <summary>
        /// 恒功率视图
        /// </summary>
        public void PModeView(bool show)
        {
            skinLabel6.Visible = show;
            nudOutputCurrentMax.Visible = show;
            skinLabel5.Visible = show;
            nudOutputVoltageMin.Visible = show;
            skinLabel4.Visible = show;
            nudOutputVoltageMax.Visible = show;
        }
        /// <summary>
        /// 恒压视图
        /// </summary>
        public void VModeView(bool show)
        {
            skinLabel6.Visible = show;
            nudOutputCurrentMax.Visible = show;
            skinLabel5.Visible = show;
            nudOutputVoltageMin.Visible = show;
            skinLabel4.Visible = show;
            nudOutputVoltageMax.Visible = show;
        }

        #endregion

        #region ATE校准相关
        
        public void ATEButton(bool show=false)
        {
            btndim.Enabled = show;
            btnmode.Enabled = show;

            btnIup.Enabled = show;
            btnIdown.Enabled = show;
            btnIsave.Enabled = show;
            btnuup.Enabled = show;
            btnudown.Enabled = show;
            btnusave.Enabled = show;
            btnReadk.Enabled = show;
            btnSetk.Enabled = show;
        }
        public void ATEShowInfo(string msg)
        {
            msg=$@"{DateTime.Now.ToString("HH:mm:ss:fff")}-> {msg}"+"\r\n";
            if (txtMessage.InvokeRequired)
            {
                txtMessage.Invoke((Action)(() => {
                    txtMessage.AppendText(msg);
                }));
            }
            else
            {
                txtMessage.AppendText(msg);
            }
        }
        private static string byteTostr(byte[] cmd)
        {
            string cmdstr = "";
            for (int i = 0; i < cmd.Length; i++)
            {
                cmdstr += cmd[i].ToString("x2") + " ";
            }
            return cmdstr;
        }
        /// <summary>
        /// ATE串口通讯的超时时间设置
        /// </summary>
        int Overtime = 1000;
        private void btnmode_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetSerialPortState())
                {
                    byte[] cmd = ATECMD.SetMode(cbMode.SelectedIndex);
                    byte[] refbuf = new byte[7];
                    int state = serialPort.SendCommand(cmd, ref refbuf, Overtime);
                    ATEShowInfo($"发送：{byteTostr(cmd)}");
                    switch (state)
                    {
                        case 0:
                            ATEShowInfo("通讯超时！");
                            break;
                        case -1:
                            ATEShowInfo("串口未打开！");
                            break;
                        case -2:
                            ATEShowInfo("通讯异常！");
                            break;
                        default:
                            string msg = $"接收：{byteTostr(refbuf)} - {ATECMD.DealData(refbuf)}";
                            ATEShowInfo(msg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ATEShowInfo(ex.Message);
            }
        }

        private void btndim_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetSerialPortState())
                {
                    byte[] cmd = ATECMD.SetDimVal(txtdim.Text);
                    byte[] refbuf = new byte[7];
                    int state = serialPort.SendCommand(cmd, ref refbuf, Overtime);
                    ATEShowInfo($"发送：{byteTostr(cmd)}");
                    switch (state)
                    {
                        case 0:
                            ATEShowInfo("通讯超时！");
                            break;
                        case -1:
                            ATEShowInfo("串口未打开！");
                            break;
                        case -2:
                            ATEShowInfo("通讯异常！");
                            break;
                        default:
                            string msg = $"接收：{byteTostr(refbuf)} - {ATECMD.DealData(refbuf)}";
                            ATEShowInfo(msg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ATEShowInfo(ex.Message);
            }
        }

        private void btnuup_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetSerialPortState())
                {
                    byte[] cmd = ATECMD.VOUp(txtu.Text);
                    byte[] refbuf = new byte[7];
                    int state = serialPort.SendCommand(cmd, ref refbuf, Overtime);
                    ATEShowInfo($"发送：{byteTostr(cmd)}");
                    switch (state)
                    {
                        case 0:
                            ATEShowInfo("通讯超时！");
                            break;
                        case -1:
                            ATEShowInfo("串口未打开！");
                            break;
                        default:
                            string msg = $"接收：{byteTostr(refbuf)} - {ATECMD.DealData(refbuf)}";
                            ATEShowInfo(msg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ATEShowInfo(ex.Message);
            }
        }

        private void btnudown_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetSerialPortState())
                {
                    byte[] cmd = ATECMD.VODown(txtu.Text);
                    byte[] refbuf = new byte[7];
                    int state = serialPort.SendCommand(cmd, ref refbuf, Overtime);
                    ATEShowInfo($"发送：{byteTostr(cmd)}");
                    switch (state)
                    {
                        case -1:
                            ATEShowInfo("通讯超时！");
                            break;
                        case -2:
                            ATEShowInfo("通讯异常！");
                            break;
                        default:
                            string msg = $"接收：{byteTostr(refbuf)} - {ATECMD.DealData(refbuf)}";
                            ATEShowInfo(msg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ATEShowInfo(ex.Message);
            }
        }
        private void btnusave_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetSerialPortState())
                {
                    byte[] cmd = ATECMD.SaveVal();
                    byte[] refbuf = new byte[7];
                    int state = serialPort.SendCommand(cmd, ref refbuf, Overtime);
                    ATEShowInfo($"发送：{byteTostr(cmd)}");
                    switch (state)
                    {
                        case 0:
                            ATEShowInfo("通讯超时！");
                            break;
                        case -1:
                            ATEShowInfo("串口未打开！");
                            break;
                        default:
                            string msg = $"接收：{byteTostr(refbuf)} - {ATECMD.DealData(refbuf)}";
                            ATEShowInfo(msg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ATEShowInfo(ex.Message);
            }
        }

        private void btnIsave_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetSerialPortState())
                {
                    byte[] cmd = ATECMD.SaveVal();
                    byte[] refbuf = new byte[7];
                    int state = serialPort.SendCommand(cmd, ref refbuf, Overtime);
                    ATEShowInfo($"发送：{byteTostr(cmd)}");
                    switch (state)
                    {
                        case 0:
                            ATEShowInfo("通讯超时！");
                            break;
                        case -1:
                            ATEShowInfo("串口未打开！");
                            break;
                        default:
                            string msg = $"接收：{byteTostr(refbuf)} - {ATECMD.DealData(refbuf)}";
                            ATEShowInfo(msg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ATEShowInfo(ex.Message);
            }
        }

        private void btnIup_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetSerialPortState())
                {
                    byte[] cmd = ATECMD.IOUp(txtI.Text);
                    byte[] refbuf = new byte[7];
                    int state = serialPort.SendCommand(cmd, ref refbuf, Overtime);
                    ATEShowInfo($"发送：{byteTostr(cmd)}");
                    switch (state)
                    {
                        case 0:
                            ATEShowInfo("通讯超时！");
                            break;
                        case -1:
                            ATEShowInfo("串口未打开！");
                            break;
                        default:
                            string msg = $"接收：{byteTostr(refbuf)} - {ATECMD.DealData(refbuf)}";
                            ATEShowInfo(msg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ATEShowInfo(ex.Message);
            }
        }

        private void btnIdown_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetSerialPortState())
                {
                    byte[] cmd = ATECMD.IODown(txtI.Text);
                    byte[] refbuf = new byte[7];
                    int state = serialPort.SendCommand(cmd, ref refbuf, Overtime);
                    ATEShowInfo($"发送：{byteTostr(cmd)}");
                    switch (state)
                    {
                        case 0:
                            ATEShowInfo("通讯超时！");
                            break;
                        case -1:
                            ATEShowInfo("串口未打开！");
                            break;
                        default:
                            string msg = $"接收：{byteTostr(refbuf)} - {ATECMD.DealData(refbuf)}";
                            ATEShowInfo(msg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ATEShowInfo(ex.Message);
            }
        }

        private void btnSetk_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetSerialPortState())
                {
                    byte[] cmd = ATECMD.KSetVal(txtVnow.Text, txtInow.Text, txtV.Text, txtVdir.Text, txtIdir.Text, textBox2.Text);
                    byte[] refbuf = new byte[7];
                    int state = serialPort.SendCommand(cmd, ref refbuf, Overtime);
                    ATEShowInfo($"发送：{byteTostr(cmd)}");
                    switch (state)
                    {
                        case 0:
                            ATEShowInfo("通讯超时！");
                            break;
                        case -1:
                            ATEShowInfo("串口未打开！");
                            break;
                        default:
                            string msg = $"接收：{byteTostr(refbuf)} - 设置K值";
                            ATEShowInfo(msg);
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ATEShowInfo(ex.Message);
            }
        }

        private void btnReadk_Click(object sender, EventArgs e)
        {
            try
            {
                if (GetSerialPortState())
                {
                    byte[] cmd = ATECMD.KGetVal();
                    byte[] refbuf = new byte[7];
                    int state = serialPort.SendCommand(cmd, ref refbuf, Overtime);
                    ATEShowInfo($"发送：{byteTostr(cmd)}");
                    switch (state)
                    {
                        case 0:
                            ATEShowInfo("通讯超时！");
                            break;
                        case -1:
                            ATEShowInfo("串口未打开！");
                            break;
                        default:
                            string msg = $"接收：{byteTostr(refbuf)} - 读取K值";
                            if (refbuf[1]==0x08)
                            {
                                txtVnow.Text = (refbuf[9] * 256 + refbuf[10]).ToString();
                                txtInow.Text = ((Convert.ToDouble(refbuf[11] * 256 + refbuf[12])) / 1000.0).ToString("0.000");
                                txtV.Text = (refbuf[5] * 256 + refbuf[6]).ToString();
                                textBox2.Text = (refbuf[7] * 256 + refbuf[8]).ToString();
                            }
                            else
                            {
                                ATEShowInfo("回复命令错误！");
                            }
                            break;
                    }
                }
            }
            catch (Exception ex)
            {
                ATEShowInfo(ex.Message);
            }
        }
        /// <summary>
        /// 显示与隐藏 ATE校准页面
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void 快捷键ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (tcData.TabPages.Contains(skinTabPage13))
            {
                tcData.TabPages.Remove(skinTabPage13);
            }
            else
            {
                tcData.TabPages.Add(skinTabPage13);
            }
        }

        #endregion

        private void button1_Click(object sender, EventArgs e)
        {
            txtMessage.Clear();
        }
    }
}
