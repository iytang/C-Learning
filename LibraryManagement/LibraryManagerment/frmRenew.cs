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
    public partial class frmRenew : Form
    {
        public frmRenew()
        {
            InitializeComponent();
        }
        public string userName;
        DBOperate db = new DBOperate();
        private void frmRenew_Load(object sender, EventArgs e)
        {
            this.Text = $"用户[{userName}]的续借信息";
            DataGridViewColumn checkCol = new DataGridViewCheckBoxColumn();
            this.dataGridView1.Columns.Add(checkCol); // 添加多选框
        }
        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 根据图书编号和图书名称查询本人的借阅信息
            string sql = $"select id as '编号',username as '用户名',name as '姓名',bookid as '图书编号'," +
                $"bookname as '图书名称',jysj as '借阅时间',jzsj as '截止时间',ghsj as '归还时间'," +
                $"sfgh as '是否归还',sfxj as '是否续借' from borrow where username='{userName}'";
            if (txtBookId.Text != "")
            {
                sql += $" and bookid='{txtBookId.Text}'";
            }
            if (txtBookName.Text != "")
            {
                sql += $" and bookname like '%{txtBookName.Text}%'";
            }
            db.BindDataGridView(dataGridView1, sql);
        }

        private void btnRenew_Click(object sender, EventArgs e)
        {
            // 获取被选中的行数
            int count = 0;
            for (int i = 0; i < dataGridView1.Rows.Count; i++)
            {
                if ((bool)dataGridView1.Rows[i].Cells[0].EditedFormattedValue == true)
                {
                    count++;
                }
            }
            // 续借
            if (count > 0) // 判断是否选中一行数据
            {
                bool someIsRenewed = false;
                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    if ((bool)dataGridView1.Rows[i].Cells[0].EditedFormattedValue == true) // 被选中
                    {
                        string bookName = dataGridView1.Rows[i].Cells[5].Value.ToString();
                        string bookId = dataGridView1.Rows[i].Cells[4].Value.ToString();
                        // 判断是否已归还
                        string isReturned = dataGridView1.Rows[i].Cells[9].Value.ToString();
                        if (isReturned == "否")
                        {
                            // 判断是否续借过
                            string isRenewed = dataGridView1.Rows[i].Cells[10].Value.ToString();
                            DateTime lastReturnTime = Convert.ToDateTime(dataGridView1.Rows[i].Cells[7].Value);
                            if (isRenewed == "否")
                            {
                                // 更新借阅表中的截止时间和是否续借字段
                                lastReturnTime = lastReturnTime.AddMonths(1); // 截止时间增加一个月
                                string sql = $"update borrow set jzsj='{lastReturnTime}',sfxj='是' where bookid='{bookId}'";
                                db.OperateData(sql);
                            }
                            else
                            {
                                someIsRenewed = true;
                                MessageBox.Show($"《{bookName}》已续借过一次，无法继续续借");
                                btnQuery.PerformClick();
                                return;
                            }
                        }
                        else
                        {
                            someIsRenewed= true;
                            MessageBox.Show($"《{bookName}》已经归还，无法续借");
                            btnQuery.PerformClick();
                            return;
                        }
                    }
                }
                if (!someIsRenewed)
                {
                    btnQuery.PerformClick(); // 更新DataGridView中的显示数据
                    MessageBox.Show("续借成功");
                }
            }
            else MessageBox.Show("请至少选择一行数据");
        }
    }
}
