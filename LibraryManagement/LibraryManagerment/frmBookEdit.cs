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
    public partial class frmBookEdit : Form
    {
        public frmBookEdit()
        {
            InitializeComponent();
        }
        private void frmBookEdit_Load(object sender, EventArgs e)
        {
            dtpTimeFrom.Value = dtpTimeFrom.MinDate;
            dtpTimeTo.Value = DateTime.Now;
        }
        DBOperate db = new DBOperate();

        private void btnQuery_Click(object sender, EventArgs e)
        {
            // 模糊查询图书信息
            string sql = $"select bookid as '图书编号',bookname as '图书名称',type as '类型',cbs as '出版社'," +
                    $" cbsj as '出版时间',price as '价格', jycs as '借阅次数',sfjc as '是否借出'" +
                    $" from book" +
                    $" where cbsj between '{dtpTimeFrom.Value}' and '{dtpTimeTo.Value}'";
            
            if (txtBookName.Text != "") // 如果有填写bookname
            {
                sql += $" and bookname like '%{txtBookName.Text}%'";
            }
            if (txtBookId.Text != "") // 如果有填写bookid
            {
                sql += $" and bookid like '%{txtBookId.Text}%'";
            }
            if (txtPress.Text != "") // 如果有填写cbs
            {
                sql += $" and cbs like '%{txtPress.Text}%'";
            }
            if (cmbBookType.Text != "不限") // type不等于不限
            {
                sql += $" and type = '{cmbBookType.Text}'";
            }

            db.BindDataGridView(dataGridView1, sql);
            dataGridView1.ClearSelection();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            // 判断是否选中一行数据
            if (dataGridView1.SelectedCells.Count > 0)
            {
                if (MessageBox.Show("确定删除？","删除提示",MessageBoxButtons.YesNo,MessageBoxIcon.Warning)
                    ==DialogResult.Yes)
                {
                    // 根据图书编号删除图书信息
                    string sql = $"delete from book where bookid = '{dataGridView1.SelectedCells[0].Value.ToString()}'";
                    db.OperateData(sql);
                    btnQuery.PerformClick(); // 调用查询按钮
                    MessageBox.Show("图书删除成功");
                }
            }
            else MessageBox.Show("请选择一行数据");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 判断是否选中一项数据
            if (dataGridView1.SelectedCells.Count > 0)
            {
                // 跳转到图书信息修改窗体
                frmBookUpdate form = new frmBookUpdate();
                form.bookId = dataGridView1.SelectedCells[0].Value.ToString();
                form.Show();
            }
            else MessageBox.Show("请选择一行数据");
        }
    }
}
