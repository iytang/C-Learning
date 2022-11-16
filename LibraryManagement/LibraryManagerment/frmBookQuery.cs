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
    public partial class frmBookQuery : Form
    {
        public frmBookQuery()
        {
            InitializeComponent();
        }
        private void frmBookQuery_Load(object sender, EventArgs e)
        {
            dtpTimeFrom.Value = dtpTimeFrom.MinDate;
            dtpTimeTo.Value = DateTime.Now;
        }
        DBOperate db = new DBOperate();
        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 模糊查询图书信息
            // book表left join borrow表查询
            string sql = $"select bo.bookid as '图书编号',bo.bookname as '图书名称',bo.type as '类型'," +
                    $" bo.cbs as '出版社',bo.cbsj as '出版时间',bo.jycs as '借阅次数',bo.sfjc as '是否借出'," +
                    $" b.username as '借阅人用户名',b.jzsj as '归还时间'" +
                    $" from book bo left join borrow b on bo.bookid = b.bookid" +
                    $" where bo.cbsj between '{dtpTimeFrom.Value}' and '{dtpTimeTo.Value}'";

            if (txtBookName.Text != "") // 如果有填写bookname
            {
                sql += $" and bo.bookname like '%{txtBookName.Text}%'";
            }
            if (txtBookId.Text != "") // 如果有填写bookid
            {
                sql += $" and bo.bookid like '%{txtBookId.Text}%'";
            }
            if (txtPress.Text != "") // 如果有填写cbs
            {
                sql += $" and bo.cbs like '%{txtPress.Text}%'";
            }
            if (cmbBookType.Text != "不限") // type不等于不限
            {
                sql += $" and bo.type = '{cmbBookType.Text}'";
            }

            db.BindDataGridView(dataGridView1, sql);
            dataGridView1.ClearSelection();
        }
    }
}
