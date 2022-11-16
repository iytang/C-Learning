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
    public partial class frmUserAdd : Form
    {
        public frmUserAdd()
        {
            InitializeComponent();
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 查询用户名是否存在
            DBOperate db = new DBOperate();
            string sql = $"select count(*) from myuser where username = '{txtUserName.Text}'";
            if (db.HumanNum(sql) == 0) // 不存在用户
            {
                int max = 100; //最大借阅量默认为100
                if (cmbRole.Text == "教师") max = 20;
                else if (cmbRole.Text == "学生") max = 10;
                // 插入SQL语句，将借阅次数和已借阅量赋值为0，max赋值给最大借阅量
                string sql2 = $"insert into myuser values('{txtUserName.Text}','{txtUserPwd.Text}'," +
                    $"'{txtName.Text}','{cmbRole.Text}','0','{max}','0')";
                db.OperateData(sql2);
                MessageBox.Show("用户添加成功");
            }
            else MessageBox.Show("用户名重复，请重新输入");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 关闭当前窗体
            this.Close();
        }
    }
}
