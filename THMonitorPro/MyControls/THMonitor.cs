using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace MyControls
{
    public partial class THMonitor : UserControl // 用户控件
    {
        public THMonitor()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 设置和读取站点序号
        /// </summary>
        private int _titleNum;
        public int TitleNum
        {
            get { return _titleNum; }
            set 
            { 
                this.lblTitle.Text = value + "号站点"; 
                _titleNum = value;
            }
        }
        /// <summary>
        /// 温度警示值（默认40度）
        /// </summary>
        public int TemperatureWaring { get; set; } = 40;

        /// <summary>
        /// 设置温度柱状显示和实际温度数字显示
        /// </summary>
        private int tempBarHeight = 92;
        public double TemperatureValue
        {
            set
            {
                if (value < 0 || value > 100)
                {
                    MessageBox.Show("温度值必须在0~100之间！", "信息提示");
                }
                else
                {
                    // 实际温度要显示的蓝色条状高度
                    double realValue = (tempBarHeight / 100.0) * value;
                    // 实际温度显示要遮罩的高度
                    int showValue = tempBarHeight - Convert.ToInt32(realValue);
                    this.lblTempBar.Height = showValue; // 设置label的高度
                    this.lbl_Temp.Text = value.ToString("f1"); //保留一位小数

                    // 判断是否需要警示
                    if (value >= TemperatureWaring)
                    {
                        lbl_Temp.BackColor = Color.Red;
                    }
                    else
                    {
                        lbl_Temp.BackColor = Color.FromArgb(192, 192, 0);
                    }
                }
            }
        }

        /// <summary>
        /// 湿度警示值（默认40度）
        /// </summary>
        public int HumidityWaring { get; set; } = 45;
        /// <summary>
        /// 设置湿度柱状显示和实际湿度数字显示
        /// </summary>
        private int humidityBarHeight = 125;
        public double HumidityValue
        {
            set
            {
                if (value < 0.0 || value > 100.0)
                {
                    MessageBox.Show("湿度值必须在0~100之间！", "信息提示");
                }
                else
                {
                    double realValue = (humidityBarHeight / 100.0) * value;
                    int showValue = humidityBarHeight - Convert.ToInt32(realValue);
                    this.lblHumidityBar.Height = showValue;
                    this.lbl_Rumidity.Text = value.ToString("f1");

                    // 判断是否需要警示
                    if (value >= HumidityWaring)
                    {
                        lbl_Rumidity.BackColor = Color.Red;
                    }
                    else
                    {
                        lbl_Rumidity.BackColor = Color.FromArgb(192, 192, 0);
                    }
                }
            }
        }
    }
}
