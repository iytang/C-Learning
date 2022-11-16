namespace HotelControl.UControls
{
    partial class UFan
    {
        /// <summary> 
        /// 必需的设计器变量。
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// 清理所有正在使用的资源。
        /// </summary>
        /// <param name="disposing">如果应释放托管资源，为 true；否则为 false。</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region 组件设计器生成的代码

        /// <summary> 
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(UFan));
            this.lblState = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.lblFanName = new System.Windows.Forms.Label();
            this.swStart = new HotelControl.UControls.Uswitch2();
            this.txtCurTemperature = new HotelControl.UControls.ParaTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // lblState
            // 
            this.lblState.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
            this.lblState.AutoSize = true;
            this.lblState.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblState.ForeColor = System.Drawing.Color.DarkOliveGreen;
            this.lblState.Location = new System.Drawing.Point(159, 15);
            this.lblState.Name = "lblState";
            this.lblState.Size = new System.Drawing.Size(39, 19);
            this.lblState.TabIndex = 1;
            this.lblState.Text = "运行";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.pictureBox1.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("pictureBox1.BackgroundImage")));
            this.pictureBox1.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pictureBox1.Location = new System.Drawing.Point(7, 46);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(191, 108);
            this.pictureBox1.TabIndex = 2;
            this.pictureBox1.TabStop = false;
            // 
            // lblFanName
            // 
            this.lblFanName.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
            this.lblFanName.AutoSize = true;
            this.lblFanName.Font = new System.Drawing.Font("微软雅黑", 11.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblFanName.Location = new System.Drawing.Point(16, 161);
            this.lblFanName.Name = "lblFanName";
            this.lblFanName.Size = new System.Drawing.Size(58, 19);
            this.lblFanName.TabIndex = 1;
            this.lblFanName.Text = "1#风机";
            // 
            // swStart
            // 
            this.swStart.Checked = false;
            this.swStart.FalseColor = System.Drawing.Color.FromArgb(((int)(((byte)(111)))), ((int)(((byte)(122)))), ((int)(((byte)(126)))));
            this.swStart.Location = new System.Drawing.Point(7, 9);
            this.swStart.Name = "swStart";
            this.swStart.Size = new System.Drawing.Size(67, 31);
            this.swStart.SwitchType = HotelControl.UControls.SwitchType.Ellipse;
            this.swStart.TabIndex = 3;
            this.swStart.Texts = null;
            this.swStart.TrueColor = System.Drawing.Color.FromArgb(((int)(((byte)(34)))), ((int)(((byte)(163)))), ((int)(((byte)(169)))));
            this.swStart.CheckedChanged += new System.EventHandler(this.swStart_CheckedChanged);
            // 
            // txtCurTemperature
            // 
            this.txtCurTemperature.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
            this.txtCurTemperature.BackColor = System.Drawing.Color.Transparent;
            this.txtCurTemperature.DataVal = "25.6";
            this.txtCurTemperature.Location = new System.Drawing.Point(148, 160);
            this.txtCurTemperature.Name = "txtCurTemperature";
            this.txtCurTemperature.Size = new System.Drawing.Size(50, 20);
            this.txtCurTemperature.TabIndex = 4;
            this.txtCurTemperature.Unit = "°C";
            this.txtCurTemperature.ValName = null;
            // 
            // UFan
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Inherit;
            this.BackColor = System.Drawing.Color.Silver;
            this.Controls.Add(this.txtCurTemperature);
            this.Controls.Add(this.swStart);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.lblFanName);
            this.Controls.Add(this.lblState);
            this.Name = "UFan";
            this.Size = new System.Drawing.Size(217, 186);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Label lblState;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label lblFanName;
        private Uswitch2 swStart;
        private ParaTextBox txtCurTemperature;
    }
}
