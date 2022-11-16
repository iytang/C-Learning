namespace P2PChat
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
            this.components = new System.ComponentModel.Container();
            this.rtbReceive = new System.Windows.Forms.RichTextBox();
            this.rtbSend = new System.Windows.Forms.RichTextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txtIPAddress = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txtNickName = new System.Windows.Forms.TextBox();
            this.btnClear = new System.Windows.Forms.Button();
            this.btnSend = new System.Windows.Forms.Button();
            this.btnClose = new System.Windows.Forms.Button();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.SuspendLayout();
            // 
            // rtbReceive
            // 
            this.rtbReceive.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbReceive.Location = new System.Drawing.Point(12, 12);
            this.rtbReceive.Name = "rtbReceive";
            this.rtbReceive.Size = new System.Drawing.Size(599, 262);
            this.rtbReceive.TabIndex = 0;
            this.rtbReceive.Text = "";
            // 
            // rtbSend
            // 
            this.rtbSend.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.rtbSend.Location = new System.Drawing.Point(12, 280);
            this.rtbSend.Name = "rtbSend";
            this.rtbSend.Size = new System.Drawing.Size(599, 116);
            this.rtbSend.TabIndex = 1;
            this.rtbSend.Text = "";
            this.rtbSend.KeyPress += new System.Windows.Forms.KeyPressEventHandler(this.rtbSend_KeyPress);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 419);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(65, 12);
            this.label1.TabIndex = 1;
            this.label1.Text = "对方主机：";
            // 
            // txtIPAddress
            // 
            this.txtIPAddress.Location = new System.Drawing.Point(85, 416);
            this.txtIPAddress.Name = "txtIPAddress";
            this.txtIPAddress.Size = new System.Drawing.Size(149, 21);
            this.txtIPAddress.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(245, 419);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(41, 12);
            this.label2.TabIndex = 1;
            this.label2.Text = "昵称：";
            // 
            // txtNickName
            // 
            this.txtNickName.Location = new System.Drawing.Point(292, 416);
            this.txtNickName.Name = "txtNickName";
            this.txtNickName.Size = new System.Drawing.Size(102, 21);
            this.txtNickName.TabIndex = 3;
            // 
            // btnClear
            // 
            this.btnClear.Location = new System.Drawing.Point(409, 416);
            this.btnClear.Name = "btnClear";
            this.btnClear.Size = new System.Drawing.Size(57, 23);
            this.btnClear.TabIndex = 4;
            this.btnClear.Text = "清屏";
            this.btnClear.UseVisualStyleBackColor = true;
            this.btnClear.Click += new System.EventHandler(this.btnClear_Click);
            // 
            // btnSend
            // 
            this.btnSend.Location = new System.Drawing.Point(482, 415);
            this.btnSend.Name = "btnSend";
            this.btnSend.Size = new System.Drawing.Size(57, 23);
            this.btnSend.TabIndex = 5;
            this.btnSend.Text = "发送";
            this.btnSend.UseVisualStyleBackColor = true;
            this.btnSend.Click += new System.EventHandler(this.btnSend_Click);
            // 
            // btnClose
            // 
            this.btnClose.Location = new System.Drawing.Point(554, 416);
            this.btnClose.Name = "btnClose";
            this.btnClose.Size = new System.Drawing.Size(57, 23);
            this.btnClose.TabIndex = 6;
            this.btnClose.Text = "关闭";
            this.btnClose.UseVisualStyleBackColor = true;
            this.btnClose.Click += new System.EventHandler(this.btnClose_Click);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(623, 450);
            this.Controls.Add(this.btnClose);
            this.Controls.Add(this.btnSend);
            this.Controls.Add(this.btnClear);
            this.Controls.Add(this.txtNickName);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtIPAddress);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.rtbSend);
            this.Controls.Add(this.rtbReceive);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "Form1";
            this.Text = "点对点聊天";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.RichTextBox rtbReceive;
        private System.Windows.Forms.RichTextBox rtbSend;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtIPAddress;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txtNickName;
        private System.Windows.Forms.Button btnClear;
        private System.Windows.Forms.Button btnSend;
        private System.Windows.Forms.Button btnClose;
        private System.Windows.Forms.Timer timer1;
    }
}

