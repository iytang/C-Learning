using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagerment
{
    public partial class frmLogin : Form
    {
        public frmLogin()
        {
            InitializeComponent();
        }

        private void btnLogin_Click(object sender, EventArgs e)
        {
            // 先判断用户名和密码是否为空
            if (txtUserName.Text != "" && txtUserPwd.Text != "") // 不能写null
            {
                string sql = $"select count(*) from myuser where username = '{txtUserName.Text}' collate Chinese_PRC_CS_AS" +
                    $" and password = '{txtUserPwd.Text}' collate Chinese_PRC_CS_AS";
                DBOperate db = new DBOperate();
                if (db.HumanNum(sql) > 0)
                {
                    this.Hide(); // 隐藏登录窗体(会在后台运行,如果关闭了程序会直接退出)
                    frmMain main = new frmMain(); // 创建主窗体对象
                    main.userName = txtUserName.Text; // 为主窗体字段赋值
                    main.Show(); // 弹出主窗体
                }
                else
                {
                    txtUserName.Text = null; // 清空用户名
                    txtUserPwd.Text = null;
                    MessageBox.Show("用户名或密码错误，请重新输入", "提示", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else MessageBox.Show("用户名或密码不能为空");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 清空文本框
            txtUserName.Text = null;
            txtUserPwd.Text = null;
            //this.Close(); // 关闭窗体
        }
        // 输入密码后按Enter触发登录
        private void txtUserPwd_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                btnLogin.PerformClick();
            }
        }
    }
}
