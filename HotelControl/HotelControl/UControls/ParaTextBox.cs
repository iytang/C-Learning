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
    public partial class ParaTextBox : UserControl
    {
        /// <summary>
        /// 数值显示控件，在原来label控件的基础上加上了单位
        /// </summary>
        public ParaTextBox()
        {
            InitializeComponent();
        }

        //参数值
        private string dataVal;
        public string DataVal
        {
            get { return dataVal; }
            set 
            {
                if (dataVal != value)
                {
                    dataVal = value;
                    lblText.Text = dataVal + " " + unit;
                }
            }
        }

        // 单位
        private string unit;
        public string Unit
        {
            get { return unit; }
            set 
            {
                unit = value;
                lblText.Text = dataVal + " " + unit;
            }
        }

        // 参数名
        private string valName;
        public string ValName
        {
            get { return valName; }
            set { valName = value; }
        }

        /// <summary>
        /// 控件Font改变时改变控件内标签的Font
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void ParaTextBox_FontChanged(object sender, EventArgs e)
        {
            lblText.Font = this.Font;
        }
    }
}
