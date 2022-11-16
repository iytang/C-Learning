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
    public partial class frmChangePwd : Form
    {
        public frmChangePwd()
        {
            InitializeComponent();
        }
        public string userName;
        DBOperate db = new DBOperate();
        private void frmChangePwd_Load(object sender, EventArgs e)
        {
            this.Text = $"修改[{userName}]的密码"; // 设置窗体标题
            lblUserName.Text = userName;
            // 根据用户名查询信息
            string sql = $"select * from myuser where username='{userName}'";
            DataSet ds = db.GetTable(sql);
            txtName.Text = ds.Tables[0].Rows[0][2].ToString();
            txtRole.Text = ds.Tables[0].Rows[0][3].ToString();
            txtBorrowNum.Text = ds.Tables[0].Rows[0][4].ToString();
            txtMaxBorrowNum.Text = ds.Tables[0].Rows[0][5].ToString();
            txtBorrowedNum.Text = ds.Tables[0].Rows[0][6].ToString();
            // 禁用控件
            txtName.Enabled = false;
            txtRole.Enabled = false;
            txtBorrowNum.Enabled = false;
            txtMaxBorrowNum.Enabled = false;
            txtBorrowedNum.Enabled = false;
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // 判断新密码有没有输入
            if (!string.IsNullOrEmpty(txtNewPwd1.Text) || txtNewPwd2.Text != "")
            {
                // 先判断两次新密码是否一致(不一致就不需要连接数据库了)
                if (txtNewPwd1.Text == txtNewPwd2.Text)
                {
                    // 根据用户名和密码查询满足条件的数据行数
                    string sql = $"select count(*) from myuser where username='{userName}' and password='{txtPwd.Text}'";

                    if (db.HumanNum(sql) > 0) // 有满足条件的数据
                    {
                        // 根据用户名更新密码
                        string sql2 = $"update myuser set password='{txtNewPwd1.Text}' where username ='{userName}'";
                        db.OperateData(sql2);
                        MessageBox.Show("密码修改成功");
                        this.Close();
                    }
                    else MessageBox.Show("原始密码错误");
                }
                else MessageBox.Show("两次密码不一致");
            }
            else MessageBox.Show("请输入新密码");
            txtPwd.Text = null;
            txtNewPwd1.Text = null;
            txtNewPwd2.Text = null;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 关闭当前窗体
            this.Close();
        }
    }
}
