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
    public partial class frmReturn : Form
    {
        public frmReturn()
        {
            InitializeComponent();
        }
        DBOperate db = new DBOperate();
        private void frmReturn_Load(object sender, EventArgs e)
        {
            DataGridViewColumn checkCol = new DataGridViewCheckBoxColumn();
            this.dataGridView1.Columns.Add(checkCol); //添加多选框
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 通过借阅人的用户名，图书编号和图书名称模糊查询借阅信息（只显示未归还借阅信息）
            string sql = $"select id as '编号',username as '用户名',name as '姓名',bookid as '图书编号'," +
                $"bookname as '图书名称',jysj as '借阅时间',jzsj as '截止时间',ghsj as '归还时间'," +
                $"sfgh as '是否归还',sfxj as '是否续借' from borrow where sfgh='否'";
            if (txtUserName.Text != "")
            {
                sql += $" and username like '%{txtUserName.Text}%' collate Chinese_PRC_CS_AS";
            }
            if (txtBookId.Text != "")
            {
                sql += $" and bookid like '%{txtBookId.Text}%'";
            }
            if (txtBookName.Text != "")
            {
                sql += $" and bookname like '%{txtBookName.Text}%' collate Chinese_PRC_CS_AS";
            }
            db.BindDataGridView(dataGridView1, sql);
        }

        private void btnReturn_Click(object sender, EventArgs e)
        {
            int count = 0;
            // 获取选中的行数
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                // 如果被选中
                if ((bool)dataGridView1.Rows[i].Cells[0].EditedFormattedValue == true)
                {
                    count += 1;
                }
            }

            if (count > 0) // 判断是否选中一行数据
            {
                // 通过循环还书
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    // 判断是否被选中
                    if ((bool)dataGridView1.Rows[i].Cells[0].EditedFormattedValue == true)
                    {
                        // 更新借阅表中的信息
                        int id = Convert.ToInt32(dataGridView1.Rows[i].Cells[1].Value);
                        string sql = $"update borrow set ghsj='{DateTime.Now}',sfgh='是' where id={id}";
                        db.OperateData(sql);
                        // 更新用户表中的已借阅量字段
                        string userName = dataGridView1.Rows[i].Cells[2].Value.ToString();
                        string sql2 = $"select * from myuser where username = '{userName}'";
                        DataSet ds = db.GetTable(sql2);
                        int borrowedNum = Convert.ToInt32(ds.Tables[0].Rows[0][6]);
                        borrowedNum -= 1; // 已借阅量-1
                        string sql3 = $"update myuser set yjyl={borrowedNum} where username = '{userName}'";
                        db.OperateData(sql3);
                        // 更新图书表中的是否借出字段
                        string bookId = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        string sql4 = $"update book set sfjc='否' where bookid='{bookId}'";
                        db.OperateData(sql4);
                    }
                }
                MessageBox.Show("还书成功");
                btnQuery.PerformClick(); // 更新DataGridView的数据显示
            }
            else MessageBox.Show("请至少选择一行数据");
        }
    }
}
