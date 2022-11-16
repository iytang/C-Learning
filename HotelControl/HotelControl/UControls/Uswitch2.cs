using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace HotelControl.UControls
{
    public partial class Uswitch2 : UserControl
    {
        public Uswitch2()
        {
            InitializeComponent();
            this.SetStyle(ControlStyles.AllPaintingInWmPaint, true);
            this.SetStyle(ControlStyles.DoubleBuffer, true);
            this.SetStyle(ControlStyles.ResizeRedraw, true);
            this.SetStyle(ControlStyles.Selectable, true);
            this.SetStyle(ControlStyles.SupportsTransparentBackColor, true);
            this.SetStyle(ControlStyles.UserPaint, true);
            //注册鼠标按下事件
            this.MouseDown += UCSwitch_MouseDown;
        }

        [Description("选中改变事件"), Category("自定义")]
        public event EventHandler CheckedChanged; // 定义选中改变事件属性

        private Color m_trueColor = Color.FromArgb(34, 163, 169);

        [Description("选中时颜色"), Category("自定义")]
        public Color TrueColor
        {
            get { return m_trueColor; }
            set
            {
                m_trueColor = value;
                Invalidate();
            }
        }

        private Color m_falseColor = Color.FromArgb(111, 122, 126);

        [Description("没有选中时颜色"), Category("自定义")]
        public Color FalseColor
        {
            get { return m_falseColor; }
            set
            {
                m_falseColor = value;
                Invalidate();
            }
        }

        private bool m_checked;

        [Description("是否选中"), Category("自定义")]
        public bool Checked
        {
            get { return m_checked; }
            set
            {
                m_checked = value;
                Invalidate();

            }
        }

        private string[] m_texts;

        [Description("文本值，当选中或没有选中时显示，必须是长度为2的数组"), Category("自定义")]
        public string[] Texts
        {
            get { return m_texts; }
            set
            {
                m_texts = value;
                Invalidate();
            }
        }
        private SwitchType m_switchType = SwitchType.Ellipse;

        [Description("显示类型"), Category("自定义")]
        public SwitchType SwitchType
        {
            get { return m_switchType; }
            set
            {
                m_switchType = value;
                Invalidate();
            }
        }

        public override Font Font
        {
            get
            {
                return base.Font;
            }
            set
            {
                base.Font = value;
                Invalidate();
            }
        }


        void UCSwitch_MouseDown(object sender, MouseEventArgs e) // 鼠标按钮触发
        {
            if (CheckedChanged != null) //
            {
                CheckedChanged(this, null);
            }
        }

        /// <summary>
        /// 重绘控件
        /// </summary>
        /// <param name="e"></param>
        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);
            var g = e.Graphics;
            //设置呈现质量
            g.SmoothingMode = SmoothingMode.AntiAlias;
            //如果开关样式是椭圆
            if (m_switchType == SwitchType.Ellipse)
            {
                //获取背景填充色
                var fillColor = m_checked ? m_trueColor : m_falseColor;
                //路径 
                GraphicsPath path = new GraphicsPath();
                //添加上边直线到路径中，起点的X坐标：1/2高度   
                path.AddLine(new Point(this.Height / 2, 1), new Point(this.Width - this.Height / 2, 1));
                //添加右半圆圆弧到路径中  
                //圆弧所在矩形的x坐标：宽-高-1  y坐标:1    旋转：-90，180
                path.AddArc(new Rectangle(this.Width - this.Height - 1, 1, this.Height - 2, this.Height - 2), -90, 180);
                //添加下边直线到路径中  
                path.AddLine(new Point(this.Width - this.Height / 2, this.Height - 1), new Point(this.Height / 2, this.Height - 1));
                //添加左半圆圆弧到路径中     旋转：90，180
                path.AddArc(new Rectangle(1, 1, this.Height - 2, this.Height - 2), 90, 180);
                //填充当前路径   
                g.FillPath(new SolidBrush(fillColor), path);

                string strText = string.Empty;
                //获取开关文本
                if (m_texts != null && m_texts.Length == 2)
                {
                    if (m_checked)
                    {
                        strText = m_texts[0];
                    }
                    else
                    {
                        strText = m_texts[1];
                    }
                }
                //绘制开的外观
                if (m_checked)
                {
                    //填充右边正圆  直径：Height-2-4
                    g.FillEllipse(Brushes.White, new Rectangle(this.Width - this.Height - 1 + 2, 1 + 2, this.Height - 2 - 4, this.Height - 2 - 4));
                    //如果文本为空
                    if (string.IsNullOrEmpty(strText))
                    {
                        //左边画白色边框的小圆 直径：右边圆的一半
                        //小圆的矩形左上角坐标：x:1/2右圆半径-1/2小圆半径
                        // y:1/2右圆半径-1/2小圆半径+1
                        //用白色边框画小圆
                        g.DrawEllipse(new Pen(Color.White, 2), new Rectangle((this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                    }
                    else
                    {
                        //画开的文本
                        //获取文本的尺寸
                        System.Drawing.SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                        //计算文本所绘画位置的左上角y坐标值 
                        int intTextY = (this.Height - (int)sizeF.Height) / 2 + 2;
                        //给文本  x:1/2半径处
                        g.DrawString(strText, Font, Brushes.White, new Point((this.Height - 2 - 4) / 2, intTextY));
                    }
                }
                else //绘制关的外观
                {
                    //填充左边正圆 
                    g.FillEllipse(Brushes.White, new Rectangle(1 + 2, 1 + 2, this.Height - 2 - 4, this.Height - 2 - 4));
                    if (string.IsNullOrEmpty(strText))
                    {
                        //右边画小圆 x:宽-高-2-大圆半径-1/2小圆半径
                        //y:（高-2-1/2大圆半径)/2+1-->大圆半径/2+1
                        //半径：大圆半径/2
                        g.DrawEllipse(new Pen(Color.White, 2), new Rectangle(this.Width - 2 - (this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                    }
                    else
                    {
                        //绘制关的文本
                        System.Drawing.SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                        //绘制文本矩形的左上角y坐标
                        int intTextY = (this.Height - (int)sizeF.Height) / 2 + 2;
                        //x坐标：this.Width - 2 - this.Height / 2  - ((int)sizeF.Width)+4
                        // 宽-2-右边半径宽-文字的宽度+4
                        g.DrawString(strText, Font, Brushes.White, new Point(this.Width - 2 - this.Height / 2 - ((int)sizeF.Width) + 4, intTextY));
                    }
                }
            }
            else if (m_switchType == SwitchType.Quadrilateral)//四边形
            {
                //填充颜色
                var fillColor = m_checked ? m_trueColor : m_falseColor;
                GraphicsPath path = new GraphicsPath();
                //圆角正方形边长
                int intRadius = 5;
                //左上角圆弧 
                path.AddArc(0, 0, intRadius, intRadius, 180f, 90f);
                //右上角圆弧 
                path.AddArc(this.Width - intRadius - 1, 0, intRadius, intRadius, 270f, 90f);
                //右下角圆弧
                path.AddArc(this.Width - intRadius - 1, this.Height - intRadius - 1, intRadius, intRadius, 0f, 90f);
                //左下角圆弧
                path.AddArc(0, this.Height - intRadius - 1, intRadius, intRadius, 90f, 90f);
                //填充圆角矩形
                g.FillPath(new SolidBrush(fillColor), path);

                //获取文本
                string strText = string.Empty;
                if (m_texts != null && m_texts.Length == 2)
                {
                    if (m_checked)
                    {
                        strText = m_texts[0];
                    }
                    else
                    {
                        strText = m_texts[1];
                    }
                }

                if (m_checked)
                {
                    //右边正方形圆角
                    GraphicsPath path2 = new GraphicsPath();
                    //左上角圆弧
                    path2.AddArc(this.Width - this.Height - 1 + 2, 1 + 2, intRadius, intRadius, 180f, 90f);
                    //右上角圆弧
                    path2.AddArc(this.Width - 1 - 2 - intRadius, 1 + 2, intRadius, intRadius, 270f, 90f);
                    //右下角圆弧
                    path2.AddArc(this.Width - 1 - 2 - intRadius, this.Height - 2 - intRadius - 1, intRadius, intRadius, 0f, 90f);
                    //右下角圆弧 
                    path2.AddArc(this.Width - this.Height - 1 + 2, this.Height - 2 - intRadius - 1, intRadius, intRadius, 90f, 90f);
                    //填充圆角正方形
                    g.FillPath(Brushes.White, path2);

                    if (string.IsNullOrEmpty(strText))
                    {
                        //左边画个小圆
                        //小圆所在矩形左上角坐标 ：x 1/2边长-1/2小圆半径
                        //y: 1/2边长-1/2小圆半径+1
                        //半径：1/2 正方形边长
                        g.DrawEllipse(new Pen(Color.White, 2), new Rectangle((this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                    }
                    else
                    {
                        //画文本
                        System.Drawing.SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                        //y坐标
                        int intTextY = (this.Height - (int)sizeF.Height) / 2 + 2;
                        //x:1/2边长处
                        g.DrawString(strText, Font, Brushes.White, new Point((this.Height - 2 - 4) / 2, intTextY));
                    }
                }
                else//画关的外观
                {
                    //圆角正方形路径  左边
                    GraphicsPath path2 = new GraphicsPath();
                    path2.AddArc(1 + 2, 1 + 2, intRadius, intRadius, 180f, 90f);
                    path2.AddArc(this.Height - 2 - intRadius, 1 + 2, intRadius, intRadius, 270f, 90f);
                    path2.AddArc(this.Height - 2 - intRadius, this.Height - 2 - intRadius - 1, intRadius, intRadius, 0f, 90f);
                    path2.AddArc(1 + 2, this.Height - 2 - intRadius - 1, intRadius, intRadius, 90f, 90f);
                    //填充圆角正方形
                    g.FillPath(Brushes.White, path2);
                    if (string.IsNullOrEmpty(strText))
                    {
                        //无文本，画右边小圆
                        //小圆所在矩形左上角坐标 ：x  宽度-2-1/2边长-1/2小圆半径
                        //y: 1/2边长-1/2小圆半径+1
                        //半径：1/2 正方形边长
                        g.DrawEllipse(new Pen(Color.White, 2), new Rectangle(this.Width - 2 - (this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                    }
                    else
                    {
                        //画文本
                        System.Drawing.SizeF sizeF = g.MeasureString(strText.Replace(" ", "A"), Font);
                        //y坐标
                        int intTextY = (this.Height - (int)sizeF.Height) / 2 + 2;
                        //x坐标  宽-2-1/2正方形边长-文字宽度+4
                        g.DrawString(strText, Font, Brushes.White, new Point(this.Width - 2 - (this.Height - 2 - 4) / 2 - (int)sizeF.Width + 4, intTextY));
                    }
                }
            }
            else //线型
            {
                //填充色
                var fillColor = m_checked ? m_trueColor : m_falseColor;
                //线高
                int intLineHeight = (this.Height - 2 - 4) / 2;
                //路径 
                GraphicsPath path = new GraphicsPath();
                // 上边直线    点 ：高度,(高度-线高)/2    点：宽-高/2, (高度-线高)/2 
                path.AddLine(new Point(this.Height / 2, (this.Height - intLineHeight) / 2), new Point(this.Width - this.Height / 2, (this.Height - intLineHeight) / 2));
                //右边半圆弧  半径是 1/2线高
                path.AddArc(new Rectangle(this.Width - this.Height / 2 - intLineHeight - 1, (this.Height - intLineHeight) / 2, intLineHeight, intLineHeight), -90, 180);
                //下边直线 
                path.AddLine(new Point(this.Width - this.Height / 2, (this.Height - intLineHeight) / 2 + intLineHeight), new Point(this.Width - this.Height / 2, (this.Height - intLineHeight) / 2 + intLineHeight));
                //左边半圆弧
                path.AddArc(new Rectangle(this.Height / 2, (this.Height - intLineHeight) / 2, intLineHeight, intLineHeight), 90, 180);
                //填充线
                g.FillPath(new SolidBrush(fillColor), path);

                if (m_checked)//绘制开时的外观
                {
                    //填充右边外圆
                    g.FillEllipse(new SolidBrush(fillColor), new Rectangle(this.Width - this.Height - 1 + 2, 1 + 2, this.Height - 2 - 4, this.Height - 2 - 4));
                    //填充右边内圆 
                    //x坐标：宽-2-1/2外圆半径-1/2内圆半径-4   y坐标：高-2-1/2内圆半径+1
                    //内圆直径：(this.Height - 2 - 4) / 2  (高-2-4)/2
                    g.FillEllipse(Brushes.White, new Rectangle(this.Width - 2 - (this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2 - 4, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                }
                else //关时的外观
                {
                    //填充左边外圆
                    g.FillEllipse(new SolidBrush(fillColor), new Rectangle(1 + 2, 1 + 2, this.Height - 2 - 4, this.Height - 2 - 4));
                    //填充左贺内圆
                    //x坐标：1/2外圆半径-1/2内圆半径+4   y坐标：1/2外圆半径-1/2内圆半径+1
                    //内圆直径：(this.Height - 2 - 4) / 2  (高-2-4)/2
                    g.FillEllipse(Brushes.White, new Rectangle((this.Height - 2 - 4) / 2 - ((this.Height - 2 - 4) / 2) / 2 + 4, (this.Height - 2 - (this.Height - 2 - 4) / 2) / 2 + 1, (this.Height - 2 - 4) / 2, (this.Height - 2 - 4) / 2));
                }
            }
        }

    }

    public enum SwitchType
    {
        /// <summary>
        /// 椭圆
        /// </summary>
        Ellipse,
        /// <summary>
        /// 四边形
        /// </summary>
        Quadrilateral,
        /// <summary>
        /// 横线
        /// </summary>
        Line
    }
}