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
    public partial class frmUserQuery : Form
    {
        public frmUserQuery()
        {
            InitializeComponent();
        }
        DBOperate db = new DBOperate();
        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 根据用户名模糊查询用户的所用信息
            string sql = $"select username as '用户名',password as '密码',name as '姓名',role as " +
                $"'角色',jycs as '借阅次数',zdjyl as '最大借阅量',yjyl as '已借阅量' from myuser where " +
                $"username like '%{txtUserName.Text}%'";
            // 如果角色为不限，查询所有角色信息，否则查询指定角色的信息
            if (cmbRole.Text != "不限")
            {
                sql += $" and role = '{cmbRole.Text}'";
            }
            db.BindDataGridView(dataGridView1, sql);
            dataGridView1.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0) // 判断是否选中了一行数据
            {
                if (DialogResult.Yes == MessageBox.Show("请确认删除","删除提示",MessageBoxButtons.YesNo,MessageBoxIcon.Warning))
                {
                    // 通过用户名删除用户信息
                    string sql = $"delete from myuser where username = '{dataGridView1.SelectedCells[0].Value.ToString()}'";
                    db.OperateData(sql);
                    // 重新绑定DataGridView,显示删除后的用户数据
                    btnQuery.PerformClick(); // 调用btnQuery的Click事件
                    MessageBox.Show("用户删除成功");
                }
            }
            else MessageBox.Show("请选中一行数据");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // 跳转到【用户信息修改窗体】
                frmUserEdit form = new frmUserEdit();
                // 将选中的用户名赋值给【用户信息修改窗体】的全局变量
                form.userName = dataGridView1.SelectedCells[0].Value.ToString();
                form.Show();
            }
            else MessageBox.Show("请选中一行数据");
        }
    }
}
