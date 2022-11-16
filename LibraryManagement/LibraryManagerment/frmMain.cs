using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class frmMain : Form
    {
        public frmMain()
        {
            InitializeComponent();
        }
        public string userName; // 声明用户名称字段
        DBOperate db = new DBOperate(); // 创建数据库操作对象

        private void frmMain_Load(object sender, EventArgs e)
        {
            // 设置数据库查询字符串
            string sql = $"select * from myuser where username='{userName}'";
            DataSet ds = db.GetTable(sql);
            string role = ds.Tables[0].Rows[0][3].ToString(); //得到用户权限字符串
            if (role == "管理员") // 判断用户角色
            {
                续借ToolStripMenuItem.Enabled = false; // 禁用续借功能
            }
            else
            {
                查询用户ToolStripMenuItem.Enabled = false; // 禁用查询用户功能
                添加用户ToolStripMenuItem.Enabled = false;
                添加图书ToolStripMenuItem.Enabled = false;
                编辑图书ToolStripMenuItem.Enabled = false;
                借书ToolStripMenuItem.Enabled = false;
                还书ToolStripMenuItem.Enabled = false;
            }
        }

        private void frmMain_FormClosing(object sender, FormClosingEventArgs e)
        {
            DialogResult dlgRe = MessageBox.Show("确定退出系统？", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (dlgRe == DialogResult.OK)
            {
                //Application.Exit(); // 会提示两次退出
                Application.ExitThread();// 退出所有窗体（托管线程(非主线程)会保留）
            }
            else e.Cancel = true; // 取消关闭
        }

        private void 查询用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserQuery form = new frmUserQuery();
            form.Show();
        }

        private void 添加用户ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmUserAdd form = new frmUserAdd();
            form.Show();
        }

        private void 修改密码ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmChangePwd form = new frmChangePwd();
            form.userName = userName; // 给frmChangePwd窗体的全局字段赋值
            form.Show();
        }

        private void 编辑图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookEdit form = new frmBookEdit();
            form.Show();
        }

        private void 添加图书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBookAdd form = new frmBookAdd();
            form.Show();
        }
        private void 查询图书ToolStripMenuItem1_Click(object sender, EventArgs e)
        {
            frmBookQuery form = new frmBookQuery();
            form.Show();
        }

        private void 借书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmBorrow form = new frmBorrow();
            form.Show();
        }

        private void 还书ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmReturn form = new frmReturn();
            form.Show();
        }

        private void 续借ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRenew form = new frmRenew();
            form.userName=userName;
            form.Show();
        }

        private void 图书借阅排行榜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRankBook form = new frmRankBook();
            form.Show();
        }

        private void 个人借阅排行榜ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            frmRankPerson form = new frmRankPerson();
            form.Show();
        }

        private void 退出ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            DialogResult result = MessageBox.Show("是否退出系统", "退出提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Question);
            if (result == DialogResult.OK)
            {
                Application.ExitThread();
            }
        }
    }
}
