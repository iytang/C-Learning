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
    public partial class frmRankPerson : Form
    {
        public frmRankPerson()
        {
            InitializeComponent();
        }

        private void frmRankPerson_Load(object sender, EventArgs e)
        {
            dtpBeginTime.Value = DateTime.Now.AddYears(-1); // 默认开始时间为当前系统时间一年前
            dtpStopTime.Value = DateTime.Now;
            dtpStopTime.Enabled = false; // 截止时间禁止编辑
            dataGridView1.ClearSelection(); 
        }
        DBOperate db = new DBOperate();
        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 根据Role和时间查询个人借阅次数
            if (cmbRole.Text == "不限")
            {
                string sql = $"select username as '用户名',name as '姓名', count(*) as '借阅次数'" +
                    $" from borrow where jysj between '{dtpBeginTime.Value}' and '{dtpStopTime.Value}'" +
                    $" group by username,name order by '借阅次数' desc";
                db.BindDataGridView(dataGridView1, sql);
                dataGridView1.ClearSelection();
            }
            else
            {
                // borrow表join myuser表根据role字段进行查询
                string sql = $"select b.username as '用户名',b.name as '姓名', count(*) as '借阅次数'" +
                    $" from borrow b join myuser m on b.username = m.username" +
                    $" where jysj between '{dtpBeginTime.Value}' and '{dtpStopTime.Value}'" +
                    $" and m.role = '{cmbRole.Text}'" +
                    $" group by b.username,b.name order by '借阅次数' desc";
                db.BindDataGridView(dataGridView1, sql);
                dataGridView1.ClearSelection();
            }
            if (dataGridView1.Rows.Count == 0)
            {
                MessageBox.Show("没有记录");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            // 通过myuser表的jycs字段查询所有记录
            string sql = $"select username as '用户名', name as '姓名', jycs as '借阅次数'" +
                $" from myuser order by jycs desc";
            db.BindDataGridView(dataGridView1, sql);
            dataGridView1.ClearSelection();
        }
    }
}
