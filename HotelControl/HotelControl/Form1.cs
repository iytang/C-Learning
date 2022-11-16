using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Modbus.Device; // 引用NModbus4通信库
using HotelControl.Models;
using System.IO.Ports;
using System.Xml;
using static System.Windows.Forms.AxHost;
using System.Timers;
using HotelControl.UControls;

namespace HotelControl
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        #region 公共字段
        SerialPort serialPort = null;
        IModbusMaster master = null;
        bool blOpen = false;
        System.Timers.Timer readTimers = null;
        List<SlaveInfo> slaves = new List<SlaveInfo>(); // 从站信息列表
        List<ParaInfo> paraInfos = new List<ParaInfo>(); // 存储参数列表
        List<FanInfo> fanList = new List<FanInfo>(); // 风机信息列表
        Dictionary<string, bool> dicStates = new Dictionary<string, bool>();//存储设备的状态值
        Dictionary<string, decimal> dicTemperatures = new Dictionary<string, decimal>();//存储实时温度值 
        #endregion

        /// <summary>
        /// 窗体加载事件
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Form1_Load(object sender, EventArgs e)
        {
            // 加载配置信息
            LoadSlavetList();
            LoadParaList();
            LoadFanList();

            // 加载风机列表
            initFans();

            // 定时器初始化
            readTimers = new System.Timers.Timer();
            readTimers.AutoReset = true;
            readTimers.Interval = 1000;
            readTimers.Elapsed += ReadTimers_Elapsed;
        }

        /// <summary>
        /// 加载风机列表（动态添加风机控件）
        /// </summary>
        private void initFans()
        {
            flpList.Controls.Clear();
            int i = 0;
            foreach (FanInfo fanInfo in fanList)
            {
                i++;
                // 创建UFan对象，添加到控件中
                UFan fan = new UFan();
                fan.BackColor = SystemColors.ActiveBorder;
                fan.CurTemperature = 0.0m;
                fan.IsOn = false;
                fan.FanName = fanInfo.FanName;
                fan.Size = new Size(225, 190);
                fan.Name = "fan" + i.ToString();
                fan.Margin = new Padding(10);
                fan.StateParaName = fanInfo.StateParaName; // 风机的状态名
                fan.TemperParaName = fanInfo.TemperParaName; // 风机的温度状态名
                // 订阅风机启停事件
                fan.StartUpEvent += Fan_StartUpEvent;
                flpList.Controls.Add(fan); // 容器控件中添加UFan控件
            }
        }

        #region 加载配置文件
        private void LoadSlavetList()
        {
            XmlDocument doc = new XmlDocument();
            string xmlPath = Application.StartupPath + "/Configs/XSlave.xml";
            doc.Load(xmlPath); // 加载XML文档对象
            XmlElement root = doc.DocumentElement; // 根元素
            if (root != null)
            {
                foreach (XmlNode node in root.ChildNodes)
                {
                    // 读取配置文件
                    SlaveInfo slave = new SlaveInfo();
                    slave.SlaveId = byte.Parse(node.SelectSingleNode("SlaveId").InnerText);
                    slave.StartAddress = ushort.Parse(node.SelectSingleNode("StartAddress").InnerText);
                    slave.FunctionCode = byte.Parse(node.SelectSingleNode("FunctionCode").InnerText);
                    slave.Count = ushort.Parse(node.SelectSingleNode("Count").InnerText);
                    slaves.Add(slave);
                }
            }
        }

        private void LoadParaList()
        {
            XmlDocument doc = new XmlDocument();
            string xmlPath = Application.StartupPath + "/Configs/XParas.xml";
            doc.Load(xmlPath); // 加载XML文档对象
            XmlElement root = doc.DocumentElement; // 根元素
            if (root != null)
            {
                var paraNodeList = root.ChildNodes; // root根元素下一级
                foreach (XmlNode node in paraNodeList)
                {
                    ParaInfo paraInfo = new ParaInfo();
                    paraInfo.ParaName = node.SelectSingleNode("ParaName").InnerText;
                    paraInfo.SlaveId = byte.Parse(node.SelectSingleNode("SlaveId").InnerText);
                    paraInfo.Address = ushort.Parse(node.SelectSingleNode("Address").InnerText);
                    paraInfo.DataType = node.SelectSingleNode("DataType").InnerText;
                    paraInfo.Note = node.SelectSingleNode("Note").InnerText;
                    paraInfos.Add(paraInfo);
                }
            }
        }

        private void LoadFanList()
        {
            XmlDocument doc = new XmlDocument();
            string xmlPath = Application.StartupPath + "/Configs/XFans.xml";
            doc.Load(xmlPath); // 加载XML文档对象
            XmlElement root = doc.DocumentElement; // 根元素
            if (root != null)
            {
                var fanNodeList = root.ChildNodes; // root根元素下一级
                foreach (XmlNode node in fanNodeList)
                {
                    FanInfo fanInfo = new FanInfo();
                    fanInfo.FanName = node.SelectSingleNode("FanName").InnerText;
                    fanInfo.StateParaName = node.SelectSingleNode("StateParaName").InnerText;
                    fanInfo.TemperParaName = node.SelectSingleNode("TemperParaName").InnerText;
                    fanList.Add(fanInfo);
                }
            }
        }
        #endregion

        /// <summary>
        /// 连接
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnConnection_Click(object sender, EventArgs e)
        {
            if (serialPort == null)
            {
                // 96 N 8 1
                serialPort = new SerialPort("COM3", 9600, Parity.None, 8, StopBits.One);
            }
            if (serialPort != null)
            {
                try
                {
                    if (!blOpen)
                    {
                        serialPort.Open();
                        if (serialPort.IsOpen)
                        {
                            blOpen = true;
                            lblConnection.Text = "已连接";
                            btnConnection.Text = "断开";
                            btnConnection.BackColor = Color.Green;
                            if (master == null)
                            {
                                master = ModbusSerialMaster.CreateRtu(serialPort); //创建主站对象
                            }
                        }
                    }
                    else
                    {
                        serialPort.Close();
                        blOpen = false;
                        lblConnection.Text = "已断开";
                        btnConnection.Text = "连接";
                        btnConnection.BackColor = Color.Blue;
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message);
                    blOpen = false;
                }
            }
        }

        bool isStart = false; // 是否启动空调
        /// <summary>
        /// 一键启停
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnStartUp_Click(object sender, EventArgs e)
        {
            if (!isStart) // 没有启动空调
            {
                // 全部启动
                Start(true);
                isStart = true;
                btnStartUp.Text = "一键停止";
                lblStartState.Text = "已全部启动";
            }
            else
            {
                // 全部停止
                Start(false);
                isStart = false;
                btnStartUp.Text = "一键启动";
                lblStartState.Text = "已全部停止";
            }
        }

        /// <summary>
        /// 全部启动的方法
        /// </summary>
        /// <param name="b"></param>
        private void Start(bool b)
        {
            int count = fanList.Count + 1; // 风机数加总开关
            bool[] bls = new bool[count];
            for (int i = 0; i < count; i++)
            {
                bls[i] = b;
            }
            master.WriteMultipleCoils(1, 0, bls);
        }

        /// <summary>
        /// 风机的启停事件处理器
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void Fan_StartUpEvent(object sender, EventArgs e)
        {
            UFan fan = (UFan)sender;
            // 切换开关，开-->关   关-->开
            // 切换，所以要取反(xml文件中【XFan的StateParaName】对应【XParas的ParaName】
            StartFan(fan.StateParaName, !fan.IsOn);
            fan.IsOn = !fan.IsOn; // 取反后改变IsOn的状态
            if (!fan.IsOn)
            {
                dicTemperatures[fan.TemperParaName] = 0.0m;
            }
        }

        /// <summary>
        /// 启停单个风机（写入寄存器）
        /// </summary>
        /// <param name="paraName"></param>
        /// <param name="b1"></param>
        private void StartFan(string paraName, bool b1)
        {
            // 通过风机的参数名称寻找风机所属的从站地址和寄存器地址
            ParaInfo para = paraInfos.Find(p => p.ParaName == paraName);
            // 写入单个线圈
            master.WriteSingleCoil(para.SlaveId, para.Address, b1);
        }

        bool isCollection = false; // 当前是否正在采集
        /// <summary>
        /// 采集与停止(控制定时器)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void btnCollection_Click(object sender, EventArgs e)
        {
            if (!isCollection) // !false,当前没有采集
            {
                readTimers.Start(); // 开始采集
                isCollection = true;
                btnCollection.Text = "正在采集";
                btnCollection.BackColor = Color.Purple;
            }
            else
            {
                readTimers.Stop(); // 停止采集
                isCollection = false;
                btnCollection.Text = "开始采集";
                btnCollection.BackColor = Color.FromArgb(153, 180, 209);
            }
        }

        /// <summary>
        /// 定时操作---读取与加载
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ReadTimers_Elapsed(object sender, ElapsedEventArgs e)
        {
            // 定时读与加载
            ReadAndLoad();
        }

        bool isFirst = false;//标识是否是第一次采集完成 
        /// <summary>
        /// 读取与加载的方法
        /// </summary>
        private void ReadAndLoad()
        {
            // 每一次的执行都是由新的子线程来执行，上一次的操作不会影响下一次
            Task.Run(() =>
            {
                //数据读取过程
                foreach (var slave in slaves) // 遍历从站列表
                {
                    // 通过功能码判定读取哪个从站
                    if (slave.FunctionCode == 1) // 风机的启停状态从站
                    {
                        // NModbus4中的读取线圈方法返回bool[]
                        bool[] bls = master.ReadCoils(slave.SlaveId, slave.StartAddress, slave.Count);
                        if (bls.Length > 0)
                        {
                            // 解析与存储
                            // 从参数列表中 根据从站地址，选出其中的风机信息放到新的列表中
                            // 从站1存储风机的启停，从站2存储房间的温度
                            var paras = paraInfos.Where(p => p.SlaveId == slave.SlaveId).ToList();
                            foreach (var para in paras) // 遍历这个从站中的所有风机信息
                            {
                                ushort addr = para.Address; // 地址
                                bool b1 = bls[addr]; //参数para对应的数据---bool(对应风机的启停状态信息)
                                // 存储
                                if (!dicStates.ContainsKey(para.ParaName)) // ParaName风机的状态参数名称
                                {
                                    dicStates.Add(para.ParaName, b1); // 存储键值对
                                }
                                else dicStates[para.ParaName] = b1; // 替换
                            }
                        }
                    }
                    else if (slave.FunctionCode == 3) // 房间的温度从站
                    {
                        ushort[] uDatas = master.ReadHoldingRegisters(slave.SlaveId, slave.StartAddress, slave.Count);
                        if (uDatas.Length > 0)
                        {
                            var paras = paraInfos.Where(p => p.SlaveId == slave.SlaveId).ToList();
                            foreach (var para in paras)
                            {
                                ushort addr = para.Address;
                                ushort udata = uDatas[addr];
                                // 数据转换，转换为真实的温度
                                decimal temperature = (decimal)udata / (decimal)10;
                                // 存储
                                if (!dicTemperatures.ContainsKey(para.ParaName))
                                {
                                    dicTemperatures.Add(para.ParaName, temperature); // 添加
                                }
                                else dicTemperatures[para.ParaName] = temperature; // 替换
                            }
                        }
                    }
                }

                if (!isFirst)
                {
                    isFirst = true; // 第一次采集完成
                }

                // 加载   子线程不能直接操作控件 ----》 跨线程(子线程切换到主线程)  使用委托 this.Invoke(委托)
                if (isFirst)
                {
                    if (this.IsHandleCreated)
                    {
                        this.Invoke(new Action(() =>
                        {
                            foreach (Control control in flpList.Controls) // 遍历容器中的所有控件
                            {
                                if (control is UFan) // 如果控件时UFan控件
                                {
                                    UFan fan = (UFan)control; // 类型转换
                                    string runPName = fan.StateParaName; // 运行状态参数名
                                    string temperPName = fan.TemperParaName; // 温度参数名
                                    fan.IsOn = dicStates[runPName]; // 运行状态
                                    if (!fan.IsOn) // 如果风机没有运行
                                    {
                                        dicTemperatures[temperPName] = 0.0m; // 温度设置为0°
                                    }
                                    fan.CurTemperature = dicTemperatures[temperPName]; // 当前温度(数据绑定到控件上)
                                }
                            }
                        }));
                    }
                }
            });
        }

    }
}
