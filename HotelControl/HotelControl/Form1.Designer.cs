namespace HotelControl
{
    partial class Form1
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

        #region Windows 窗体设计器生成的代码

        /// <summary>
        /// 设计器支持所需的方法 - 不要修改
        /// 使用代码编辑器修改此方法的内容。
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.flpList = new System.Windows.Forms.FlowLayoutPanel();
            this.uFan1 = new HotelControl.UControls.UFan();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.lblStartState = new System.Windows.Forms.Label();
            this.lblConnection = new System.Windows.Forms.Label();
            this.btnStartUp = new System.Windows.Forms.Button();
            this.btnCollection = new System.Windows.Forms.Button();
            this.btnConnection = new System.Windows.Forms.Button();
            this.flpList.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // flpList
            // 
            this.flpList.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.flpList.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.flpList.Controls.Add(this.uFan1);
            this.flpList.Location = new System.Drawing.Point(21, 135);
            this.flpList.Margin = new System.Windows.Forms.Padding(2);
            this.flpList.Name = "flpList";
            this.flpList.Size = new System.Drawing.Size(959, 404);
            this.flpList.TabIndex = 12;
            // 
            // uFan1
            // 
            this.uFan1.BackColor = System.Drawing.Color.Silver;
            this.uFan1.CurTemperature = new decimal(new int[] {
            240,
            0,
            0,
            65536});
            this.uFan1.FanName = "1#风机";
            this.uFan1.IsOn = false;
            this.uFan1.Location = new System.Drawing.Point(3, 3);
            this.uFan1.Name = "uFan1";
            this.uFan1.Size = new System.Drawing.Size(224, 177);
            this.uFan1.StateParaName = null;
            this.uFan1.TabIndex = 0;
            this.uFan1.TemperParaName = null;
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.lblStartState);
            this.groupBox1.Controls.Add(this.lblConnection);
            this.groupBox1.Controls.Add(this.btnStartUp);
            this.groupBox1.Controls.Add(this.btnCollection);
            this.groupBox1.Controls.Add(this.btnConnection);
            this.groupBox1.Location = new System.Drawing.Point(18, 11);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(962, 72);
            this.groupBox1.TabIndex = 11;
            this.groupBox1.TabStop = false;
            // 
            // lblStartState
            // 
            this.lblStartState.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblStartState.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblStartState.ForeColor = System.Drawing.Color.Blue;
            this.lblStartState.Location = new System.Drawing.Point(664, 22);
            this.lblStartState.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblStartState.Name = "lblStartState";
            this.lblStartState.Size = new System.Drawing.Size(118, 29);
            this.lblStartState.TabIndex = 1;
            this.lblStartState.Text = "已停止";
            this.lblStartState.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblConnection
            // 
            this.lblConnection.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.lblConnection.Font = new System.Drawing.Font("微软雅黑", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.lblConnection.ForeColor = System.Drawing.Color.Green;
            this.lblConnection.Location = new System.Drawing.Point(109, 25);
            this.lblConnection.Margin = new System.Windows.Forms.Padding(2, 0, 2, 0);
            this.lblConnection.Name = "lblConnection";
            this.lblConnection.Size = new System.Drawing.Size(118, 29);
            this.lblConnection.TabIndex = 1;
            this.lblConnection.Text = "未连接";
            this.lblConnection.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // btnStartUp
            // 
            this.btnStartUp.BackColor = System.Drawing.Color.DarkGoldenrod;
            this.btnStartUp.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnStartUp.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnStartUp.ForeColor = System.Drawing.Color.White;
            this.btnStartUp.Location = new System.Drawing.Point(558, 19);
            this.btnStartUp.Margin = new System.Windows.Forms.Padding(2);
            this.btnStartUp.Name = "btnStartUp";
            this.btnStartUp.Size = new System.Drawing.Size(93, 34);
            this.btnStartUp.TabIndex = 0;
            this.btnStartUp.Text = "一键启动";
            this.btnStartUp.UseVisualStyleBackColor = false;
            this.btnStartUp.Click += new System.EventHandler(this.btnStartUp_Click);
            // 
            // btnCollection
            // 
            this.btnCollection.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(153)))), ((int)(((byte)(180)))), ((int)(((byte)(209)))));
            this.btnCollection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnCollection.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnCollection.ForeColor = System.Drawing.Color.White;
            this.btnCollection.Location = new System.Drawing.Point(286, 19);
            this.btnCollection.Margin = new System.Windows.Forms.Padding(2);
            this.btnCollection.Name = "btnCollection";
            this.btnCollection.Size = new System.Drawing.Size(93, 34);
            this.btnCollection.TabIndex = 0;
            this.btnCollection.Text = "开始采集";
            this.btnCollection.UseVisualStyleBackColor = false;
            this.btnCollection.Click += new System.EventHandler(this.btnCollection_Click);
            // 
            // btnConnection
            // 
            this.btnConnection.BackColor = System.Drawing.SystemColors.ActiveCaption;
            this.btnConnection.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnConnection.Font = new System.Drawing.Font("微软雅黑", 10.8F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(134)));
            this.btnConnection.ForeColor = System.Drawing.Color.White;
            this.btnConnection.Location = new System.Drawing.Point(32, 22);
            this.btnConnection.Margin = new System.Windows.Forms.Padding(2);
            this.btnConnection.Name = "btnConnection";
            this.btnConnection.Size = new System.Drawing.Size(64, 32);
            this.btnConnection.TabIndex = 0;
            this.btnConnection.Text = "连接";
            this.btnConnection.UseVisualStyleBackColor = false;
            this.btnConnection.Click += new System.EventHandler(this.btnConnection_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(998, 550);
            this.Controls.Add(this.flpList);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "空调控制系统";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.flpList.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.FlowLayoutPanel flpList;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblStartState;
        private System.Windows.Forms.Label lblConnection;
        private System.Windows.Forms.Button btnCollection;
        private System.Windows.Forms.Button btnConnection;
        private System.Windows.Forms.Button btnStartUp;
        private UControls.UFan uFan1;
    }
}

