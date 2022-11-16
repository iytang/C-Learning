using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using ModbusLib;
using Models;
using Timer = System.Windows.Forms.Timer;

namespace THMonitorPro
{
    public partial class FrmMain : Form
    {
        // 窗体初始化
        public FrmMain()
        {
            InitializeComponent();
            // 读取配置文件，转换成对象
            // txt ini json ...

            //config = new Config();
            //config.PortName = "COM3";

            config = new Config() // 项目配置参数初始化
            {
                PortName = "COM3",
                BaudRate = 9600,
                Parity = System.IO.Ports.Parity.None,
                DataBits = 8,
                StopBits = System.IO.Ports.StopBits.One,
                SlaveId1 = 1,
                SlaveId2 = 2,
                SlaveId3 = 3,
                SlaveId4 = 4
            };
            this.thMonitor1.TitleNum = 1;
            this.thMonitor2.TitleNum = 2;
            this.thMonitor3.TitleNum = 3;
            this.thMonitor4.TitleNum = 4;

            try
            {
                // 连接串口
                modbus.Connect(config.PortName, config.BaudRate, config.Parity, config.DataBits, config.StopBits);
            }
            catch (Exception ex)
            {
                MessageBox.Show("连接失败" + ex.Message);
                return; // return，无条件跳出（不会执行后面的MessgeBox.Show）
            }
            MessageBox.Show("连接成功");

            // 通信
            // 使用多线程（主线程是用来显示界面的，如果主线程也做通信，就会显得很卡）
            // 涉及到和设备进行交互，尽量不要用定时器timer
            cts = new CancellationTokenSource();
            Task.Run(new Action(() => { Communication();}), cts.Token);

            updateTimer.Interval = 200;
            updateTimer.Tick += UpdateTimer_Tick;
            updateTimer.Start();
        }

        #region 通用字段
        // 创建一个通信对象
        private ModbusRTU modbus = new ModbusRTU();

        // 创建一个配置实体对象 
        private Config config = new Config();

        // 创建一个取消线程源
        private CancellationTokenSource cts;

        // 创建字典（用来存放各个从站的温度值、湿度值）
        private Dictionary<byte, THMonitorDB> CurrentValue = new Dictionary<byte, THMonitorDB>();

        // 创建一个定时器
        private Timer updateTimer = new Timer();
        #endregion
        // 定义定时器定时事件
        private void UpdateTimer_Tick(object sender, EventArgs e)
        {
            // 绑定用户控件和字典的值
            if (CurrentValue.ContainsKey(config.SlaveId1))
            {
                THMonitorDB data = CurrentValue[config.SlaveId1];
                this.thMonitor1.TemperatureValue = data.TemperatureValue;
                this.thMonitor1.HumidityValue = data.HumidityValue;
            }
            if (CurrentValue.ContainsKey(config.SlaveId2))
            {
                THMonitorDB data = CurrentValue[config.SlaveId2];
                this.thMonitor2.TemperatureValue = data.TemperatureValue;
                this.thMonitor2.HumidityValue = data.HumidityValue;
            }
            if (CurrentValue.ContainsKey(config.SlaveId3))
            {
                THMonitorDB data = CurrentValue[config.SlaveId3];
                this.thMonitor3.TemperatureValue = data.TemperatureValue;
                this.thMonitor3.HumidityValue = data.HumidityValue;
            }
            if (CurrentValue.ContainsKey(config.SlaveId4))
            {
                THMonitorDB data = CurrentValue[config.SlaveId4];
                this.thMonitor4.TemperatureValue = data.TemperatureValue;
                this.thMonitor4.HumidityValue = data.HumidityValue;
            }
        }

        // 多线程读取方法
        private void Communication()
        {
            // 关键是看这里代码怎么写
            // 通过委托执行线程（否则直接执行会报错：跨线程操作无效）
            // this.Text = "测试多线程"; // 会报错
            //this.Invoke(new Action(() =>
            //{
            //    this.Text = "测试多线程";
            //}));

            while (!cts.IsCancellationRequested) // 判断线程是否取消 !false = true, 循环进行
            {
                // 读取第一个从站
                GetSlaveData(config.SlaveId1);
                // 读取第二个从站
                GetSlaveData(config.SlaveId2);
                // 读取第三个从站
                GetSlaveData(config.SlaveId3);
                // 读取第四个从站
                GetSlaveData(config.SlaveId4);
            }
        }

        /// <summary>
        /// 读取设备数据的通用方法
        /// </summary>
        /// <param name="slaveId"></param>
        /// <returns>s是否成功</returns>
        private bool GetSlaveData(byte slaveId)
        {
            // 读取从站
            byte[] res = modbus.ReadInputRegs(slaveId, 1, 2);
            if (res != null && res.Length == 4)
            {
                // 温度湿度
                float temp = (res[0] * 256 + res[1]) * 0.1f;
                float humidity = (res[2] * 256 + res[3]) * 0.1f;

                // 判断字典是否包含键
                if (CurrentValue.ContainsKey(slaveId))
                {
                    // 替换
                    CurrentValue[slaveId] = new THMonitorDB()
                    {
                        TemperatureValue = temp,
                        HumidityValue = humidity
                    };
                }
                else
                {
                    // 增加
                    CurrentValue.Add(slaveId, new THMonitorDB()
                    {
                        TemperatureValue = temp,
                        HumidityValue = humidity
                    });
                }
                return true;
            }
            return false;
        }

        // 定义退出label双击事件
        private void lblExit_DoubleClick(object sender, EventArgs e)
        {
            DialogResult dr = MessageBox.Show("确认退出？", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dr == DialogResult.OK)
            {
                this.Close();
            }
        }
        
        // 定义窗体关闭事件（关闭多线程）
        private void FrmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            // 窗体关闭的时候，取消线程源
            // ?语法糖：表示可空类型
            // （比如说连接失败，就没有建立线程，如果不可空，这时候运行cts.Cancle就会报错）
            cts?.Cancel(); // IsCancellationRequested属性返回true
        }

        #region 实现鼠标移动窗体

        Point mPoint;

        private void Form_MouseDown(object sender, MouseEventArgs e)
        {
            mPoint = new Point(e.X, e.Y);
        }

        private void Form_MouseMove(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                this.Location = new Point(this.Location.X + e.X - mPoint.X, this.Location.Y + e.Y - mPoint.Y);

            }
        }

        #endregion
    }
}
