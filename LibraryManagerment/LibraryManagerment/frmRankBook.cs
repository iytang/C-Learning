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
    public partial class frmRankBook : Form
    {
        public frmRankBook()
        {
            InitializeComponent();
        }

        private void frmRankBook_Load(object sender, EventArgs e)
        {
            dtpBeginTime.Value = DateTime.Now.AddYears(-1); // 默认开始时间为当前系统时间一年前
            dtpStopTime.Value = DateTime.Now;
            dtpStopTime.Enabled = false; // 截止时间禁止编辑
            dataGridView1.ClearSelection();
        }
        DBOperate db = new DBOperate();

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 根据Type和时间查询图书借阅次数
            if (cmbType.Text == "不限")
            {
                string sql = $"select bookid as '图书编号',bookname as '图书名称', count(*) as '借阅次数'" +
                    $" from borrow where jysj between '{dtpBeginTime.Value}' and '{dtpStopTime.Value}'" +
                    $" group by bookid,bookname order by '借阅次数' desc";
                db.BindDataGridView(dataGridView1, sql);
                dataGridView1.ClearSelection();
            }
            else
            {
                // borrow表join book表根据type字段进行查询
                string sql = $"select b.bookid as '图书编号',b.bookname as '图书名称', count(*) as '借阅次数'" +
                    $" from borrow b join book bo on b.bookid = bo.bookid" +
                    $" where jysj between '{dtpBeginTime.Value}' and '{dtpStopTime.Value}'" +
                    $" and bo.type = '{cmbType.Text}'" +
                    $" group by b.bookid,b.bookname order by '借阅次数' desc";
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
            // 通过book表的jycs字段查询所有记录
            string sql = $"select bookid as '图书编号', bookname as '图书名称', jycs as '借阅次数'" +
                $" from book order by jycs desc";
            db.BindDataGridView(dataGridView1, sql);
            dataGridView1.ClearSelection();
        }
    }
}
