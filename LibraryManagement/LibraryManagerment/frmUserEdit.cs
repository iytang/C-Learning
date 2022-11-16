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
    public partial class frmUserEdit : Form
    {
        public frmUserEdit()
        {
            InitializeComponent();
        }
        public string userName;
        DBOperate db = new DBOperate();

        private void frmUserEdit_Load(object sender, EventArgs e)
        {
            this.Text = $"修改[{userName}]的个人信息";
            lblUserName.Text = userName;
            // 根据用户名查询信息
            string sql = $"select * from myuser where username='{userName}'";
            DataSet ds = db.GetTable(sql);
            // 赋值给控件
            txtUserPwd.Text = ds.Tables[0].Rows[0][1].ToString();
            txtName.Text = ds.Tables[0].Rows[0][2].ToString();
            cmbRole.Text = ds.Tables[0].Rows[0][3].ToString();
            txtBorrowNum.Text = ds.Tables[0].Rows[0][4].ToString();
            txtMaxBorrowNum.Text = ds.Tables[0].Rows[0][5].ToString();
            txtBorrowedNum.Text = ds.Tables[0].Rows[0][6].ToString();
            // 禁用控件
            cmbRole.Enabled = false;
            txtBorrowNum.Enabled = false;
            txtMaxBorrowNum.Enabled = false;
            txtBorrowedNum.Enabled = false;
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 修改用户密码和姓名
            string sql = $"update myuser set password='{txtUserPwd.Text}',name='{txtName.Text}' where " +
                $"username='{userName}'";
            db.OperateData(sql);
            MessageBox.Show("修改用户成功");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // 关闭当前窗体
            this.Close();
        }
    }
}
