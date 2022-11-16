namespace LibraryManagerment
{
    partial class frmMain
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frmMain));
            this.menuStrip1 = new System.Windows.Forms.MenuStrip();
            this.用户管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加用户ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.修改密码ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.编辑图书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.添加图书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.查询图书ToolStripMenuItem1 = new System.Windows.Forms.ToolStripMenuItem();
            this.借阅管理ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.借书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.还书ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.续借ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.排行榜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.图书借阅排行榜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.个人借阅排行榜ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.退出ToolStripMenuItem = new System.Windows.Forms.ToolStripMenuItem();
            this.menuStrip1.SuspendLayout();
            this.SuspendLayout();
            // 
            // menuStrip1
            // 
            this.menuStrip1.Items.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.用户管理ToolStripMenuItem,
            this.图书管理ToolStripMenuItem,
            this.借阅管理ToolStripMenuItem,
            this.排行榜ToolStripMenuItem,
            this.退出ToolStripMenuItem});
            this.menuStrip1.Location = new System.Drawing.Point(0, 0);
            this.menuStrip1.Name = "menuStrip1";
            this.menuStrip1.Size = new System.Drawing.Size(800, 24);
            this.menuStrip1.TabIndex = 0;
            this.menuStrip1.Text = "menuStrip1";
            // 
            // 用户管理ToolStripMenuItem
            // 
            this.用户管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.查询用户ToolStripMenuItem,
            this.添加用户ToolStripMenuItem,
            this.修改密码ToolStripMenuItem});
            this.用户管理ToolStripMenuItem.Name = "用户管理ToolStripMenuItem";
            this.用户管理ToolStripMenuItem.Size = new System.Drawing.Size(87, 20);
            this.用户管理ToolStripMenuItem.Text = "用户管理(&U)";
            // 
            // 查询用户ToolStripMenuItem
            // 
            this.查询用户ToolStripMenuItem.Name = "查询用户ToolStripMenuItem";
            this.查询用户ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.查询用户ToolStripMenuItem.Text = "查询用户";
            this.查询用户ToolStripMenuItem.Click += new System.EventHandler(this.查询用户ToolStripMenuItem_Click);
            // 
            // 添加用户ToolStripMenuItem
            // 
            this.添加用户ToolStripMenuItem.Name = "添加用户ToolStripMenuItem";
            this.添加用户ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加用户ToolStripMenuItem.Text = "添加用户";
            this.添加用户ToolStripMenuItem.Click += new System.EventHandler(this.添加用户ToolStripMenuItem_Click);
            // 
            // 修改密码ToolStripMenuItem
            // 
            this.修改密码ToolStripMenuItem.Name = "修改密码ToolStripMenuItem";
            this.修改密码ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.修改密码ToolStripMenuItem.Text = "修改密码";
            this.修改密码ToolStripMenuItem.Click += new System.EventHandler(this.修改密码ToolStripMenuItem_Click);
            // 
            // 图书管理ToolStripMenuItem
            // 
            this.图书管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.编辑图书ToolStripMenuItem,
            this.添加图书ToolStripMenuItem,
            this.查询图书ToolStripMenuItem1});
            this.图书管理ToolStripMenuItem.Name = "图书管理ToolStripMenuItem";
            this.图书管理ToolStripMenuItem.Size = new System.Drawing.Size(86, 20);
            this.图书管理ToolStripMenuItem.Text = "图书管理(&B)";
            // 
            // 编辑图书ToolStripMenuItem
            // 
            this.编辑图书ToolStripMenuItem.Name = "编辑图书ToolStripMenuItem";
            this.编辑图书ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.编辑图书ToolStripMenuItem.Text = "编辑图书";
            this.编辑图书ToolStripMenuItem.Click += new System.EventHandler(this.编辑图书ToolStripMenuItem_Click);
            // 
            // 添加图书ToolStripMenuItem
            // 
            this.添加图书ToolStripMenuItem.Name = "添加图书ToolStripMenuItem";
            this.添加图书ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.添加图书ToolStripMenuItem.Text = "添加图书";
            this.添加图书ToolStripMenuItem.Click += new System.EventHandler(this.添加图书ToolStripMenuItem_Click);
            // 
            // 查询图书ToolStripMenuItem1
            // 
            this.查询图书ToolStripMenuItem1.Name = "查询图书ToolStripMenuItem1";
            this.查询图书ToolStripMenuItem1.Size = new System.Drawing.Size(180, 22);
            this.查询图书ToolStripMenuItem1.Text = "查询图书";
            this.查询图书ToolStripMenuItem1.Click += new System.EventHandler(this.查询图书ToolStripMenuItem1_Click);
            // 
            // 借阅管理ToolStripMenuItem
            // 
            this.借阅管理ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.借书ToolStripMenuItem,
            this.还书ToolStripMenuItem,
            this.续借ToolStripMenuItem});
            this.借阅管理ToolStripMenuItem.Name = "借阅管理ToolStripMenuItem";
            this.借阅管理ToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.借阅管理ToolStripMenuItem.Text = "借阅管理(&F)";
            // 
            // 借书ToolStripMenuItem
            // 
            this.借书ToolStripMenuItem.Name = "借书ToolStripMenuItem";
            this.借书ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.借书ToolStripMenuItem.Text = "借书";
            this.借书ToolStripMenuItem.Click += new System.EventHandler(this.借书ToolStripMenuItem_Click);
            // 
            // 还书ToolStripMenuItem
            // 
            this.还书ToolStripMenuItem.Name = "还书ToolStripMenuItem";
            this.还书ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.还书ToolStripMenuItem.Text = "还书";
            this.还书ToolStripMenuItem.Click += new System.EventHandler(this.还书ToolStripMenuItem_Click);
            // 
            // 续借ToolStripMenuItem
            // 
            this.续借ToolStripMenuItem.Name = "续借ToolStripMenuItem";
            this.续借ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.续借ToolStripMenuItem.Text = "续借";
            this.续借ToolStripMenuItem.Click += new System.EventHandler(this.续借ToolStripMenuItem_Click);
            // 
            // 排行榜ToolStripMenuItem
            // 
            this.排行榜ToolStripMenuItem.DropDownItems.AddRange(new System.Windows.Forms.ToolStripItem[] {
            this.图书借阅排行榜ToolStripMenuItem,
            this.个人借阅排行榜ToolStripMenuItem});
            this.排行榜ToolStripMenuItem.Name = "排行榜ToolStripMenuItem";
            this.排行榜ToolStripMenuItem.Size = new System.Drawing.Size(73, 20);
            this.排行榜ToolStripMenuItem.Text = "排行榜(&B)";
            // 
            // 图书借阅排行榜ToolStripMenuItem
            // 
            this.图书借阅排行榜ToolStripMenuItem.Name = "图书借阅排行榜ToolStripMenuItem";
            this.图书借阅排行榜ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.图书借阅排行榜ToolStripMenuItem.Text = "图书借阅排行榜";
            this.图书借阅排行榜ToolStripMenuItem.Click += new System.EventHandler(this.图书借阅排行榜ToolStripMenuItem_Click);
            // 
            // 个人借阅排行榜ToolStripMenuItem
            // 
            this.个人借阅排行榜ToolStripMenuItem.Name = "个人借阅排行榜ToolStripMenuItem";
            this.个人借阅排行榜ToolStripMenuItem.Size = new System.Drawing.Size(180, 22);
            this.个人借阅排行榜ToolStripMenuItem.Text = "个人借阅排行榜";
            this.个人借阅排行榜ToolStripMenuItem.Click += new System.EventHandler(this.个人借阅排行榜ToolStripMenuItem_Click);
            // 
            // 退出ToolStripMenuItem
            // 
            this.退出ToolStripMenuItem.Name = "退出ToolStripMenuItem";
            this.退出ToolStripMenuItem.Size = new System.Drawing.Size(85, 20);
            this.退出ToolStripMenuItem.Text = "退出系统(&E)";
            this.退出ToolStripMenuItem.Click += new System.EventHandler(this.退出ToolStripMenuItem_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = ((System.Drawing.Image)(resources.GetObject("$this.BackgroundImage")));
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.menuStrip1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MainMenuStrip = this.menuStrip1;
            this.MaximizeBox = false;
            this.Name = "frmMain";
            this.Text = "图书馆管理系统";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.frmMain_FormClosing);
            this.Load += new System.EventHandler(this.frmMain_Load);
            this.menuStrip1.ResumeLayout(false);
            this.menuStrip1.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.MenuStrip menuStrip1;
        private System.Windows.Forms.ToolStripMenuItem 用户管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借阅管理ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 排行榜ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 退出ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加用户ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 编辑图书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 添加图书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 借书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 还书ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 续借ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 图书借阅排行榜ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 个人借阅排行榜ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 修改密码ToolStripMenuItem;
        private System.Windows.Forms.ToolStripMenuItem 查询图书ToolStripMenuItem1;
    }
}