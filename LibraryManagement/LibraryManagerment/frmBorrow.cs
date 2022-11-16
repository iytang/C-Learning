using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public partial class frmBorrow : Form
    {
        public frmBorrow()
        {
            InitializeComponent();
        }
        DBOperate db = new DBOperate();
        private void btnBorrow_Click(object sender, EventArgs e)
        {
            if (txtBookId.Text != "" && txtUserName.Text != "")
            {
                // 判断用户名是否在myuser表中及图书编号是否在book表中
                string strSql = $"select count(*) from myuser where username='{txtUserName.Text}'collate Chinese_PRC_CS_AS";
                string strsql2 = $"select count(*) from book where bookid = '{txtBookId.Text}'collate Chinese_PRC_CS_AS";
                int count1 = db.HumanNum(strSql);
                int count2 = db.HumanNum(strsql2);

                if (count1 > 0 && count2 > 0) // 数据库中存在这个用户名和书籍
                {
                    // 根据用户名查询用户信息
                    string sql = $"select * from myuser where username='{txtUserName.Text}' collate Chinese_PRC_CS_AS";
                    DataSet ds = db.GetTable(sql);
                    string name = ds.Tables[0].Rows[0][2].ToString(); // 姓名字段
                    int borrowNum = Convert.ToInt32(ds.Tables[0].Rows[0][4]); // 借阅次数字段
                    int borrowMaxNum = Convert.ToInt32(ds.Tables[0].Rows[0][5]); // 最大借阅量字段
                    int borrowedNum = Convert.ToInt32(ds.Tables[0].Rows[0][6]); // 已借阅量字段

                    // 根据图书编号查询图书信息
                    string sql2 = $"select * from book where bookid='{txtBookId.Text}'";
                    DataSet ds2 = db.GetTable(sql2);
                    string bookName = ds2.Tables[0].Rows[0][1].ToString(); // 图书名称字段
                    int bookBorrowNum = Convert.ToInt32(ds2.Tables[0].Rows[0][6]); // 图书借阅次数字段
                    string bookIsBorrowed = ds2.Tables[0].Rows[0][7].ToString(); // 是否被借阅字段
                    // 取系统当前时间并在这个基础上加两个月就是截止时间（借书时间为两个月）
                    DateTime time = DateTime.Now.AddMonths(2); // 截止时间字段

                    // 判断已借阅量和最大借阅量的大小关系
                    if (borrowedNum < borrowMaxNum)
                    {
                        if (bookIsBorrowed == "否") // 图书未被借出
                        {
                            // 在借阅表borrow中添加记录，(归还时间“null”,是否归还“否”,是否续借“否”)
                            // 插入数据又不写列名时，自增列不写也是可以的
                            string sql3 = $"insert into borrow values('{txtUserName.Text}','{name}','{txtBookId.Text}'," +
                                $"'{bookName}','{DateTime.Now}','{time}',null,'否','否')";
                            db.OperateData(sql3);

                            // 更新用户表的借阅次数和已借阅量
                            borrowNum += 1;
                            borrowedNum += 1;
                            string sql4 = $"update myuser set jycs={borrowNum},yjyl={borrowedNum} where username = '{txtUserName.Text}'";
                            db.OperateData(sql4);

                            // 更新图书表的图书借阅次数和是否借出
                            bookBorrowNum += 1;
                            bookIsBorrowed = "是";
                            string sql5 = $"update book set jycs={bookBorrowNum},sfjc='{bookIsBorrowed}' where bookid='{txtBookId.Text}'";
                            db.OperateData(sql5);

                            MessageBox.Show("借书成功");
                        }
                        else MessageBox.Show("这本书已被借出");
                    }
                    else MessageBox.Show("已借阅图书量达到最大，请先还书");
                }
                else if (count1 > 0 && count2 == 0)
                {
                    MessageBox.Show("图书编号输入错误");
                }
                else if (count1 == 0 && count2 > 0)
                {
                    MessageBox.Show("用户名输入错误");
                }
                else MessageBox.Show("用户名和图书编号输入错误");
                btnQuery.PerformClick();
            }
            else MessageBox.Show("请输入图书名称和用户名");
        }

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 查询所有借阅信息
            string sql = $"select id as '编号',username as '用户名',name as '姓名',bookid as '图书编号'," +
                $"bookname as '图书名称',jysj as '借阅时间',jzsj as '截止时间',ghsj as '归还时间'," +
                $"sfgh as '是否归还',sfxj as '是否续借' from borrow order by jysj desc";
            db.BindDataGridView(dataGridView1, sql);
        }
    }
}