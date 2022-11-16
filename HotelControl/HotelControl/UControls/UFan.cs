using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelControl.UControls
{
    public partial class UFan : UserControl
    {
        public UFan()
        {
            InitializeComponent();
        }

        /// <summary>
        /// 运行状态
        /// </summary>
        public bool IsOn
        {
            get { return swStart.Checked; }
            set
            {
                swStart.Checked = value;
                lblState.Text = value? "运行":"停止";
                lblState.ForeColor = value ? Color.Green : Color.Red;
            }
        }


        /// <summary>
        /// 当前温度
        /// </summary>
        private decimal curTemperature;
        public decimal CurTemperature
        {
            get { return curTemperature; }
            set { curTemperature = value;
                // 温度显示在参数信息框中
                txtCurTemperature.DataVal = curTemperature.ToString();
            }
        }

        /// <summary>
        /// 风机名属性
        /// </summary>
        public string FanName
        {
            get { return lblFanName.Text; }
            set { lblFanName.Text = value; }
        }

        /// <summary>
        /// 状态参数名
        /// </summary>
        private string stateParaName;

        public string StateParaName
        {
            get { return stateParaName; }
            set { stateParaName = value; }
        }

        /// <summary>
        /// 温度参数名
        /// </summary>
        private string temperParaName;
        public string TemperParaName
        {
            get { return temperParaName; }
            set { temperParaName = value; }
        }


        public event EventHandler StartUpEvent; // 定义启停事件
        /// <summary>
        /// Uswitch控件CheckedChanged事件（切换）
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void swStart_CheckedChanged(object sender, EventArgs e)
        {
            StartUpEvent?.Invoke(this, new EventArgs()); //事件的调用
        }
    }
}
