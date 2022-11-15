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
    public partial class frmBookUpdate : Form
    {
        public frmBookUpdate()
        {
            InitializeComponent();
        }
        public string bookId;
        DBOperate db = new DBOperate();
        private void frmBookEdit_Load(object sender, EventArgs e)
        {
            this.Text = $"修改[{bookId}]的图书信息";
            lblBookId.Text = bookId;
            // 根据图书编号查询相关信息
            string sql = $"select * from book where bookid = '{bookId}'";
            DataSet ds = db.GetTable(sql);
            // 为控件赋值
            txtBookName.Text = ds.Tables[0].Rows[0][1].ToString();
            cmbType.Text = ds.Tables[0].Rows[0][2].ToString();
            txtPress.Text = ds.Tables[0].Rows[0][3].ToString();
            dtpPublishTime.Value = Convert.ToDateTime(ds.Tables[0].Rows[0][4]);
            txtPrice.Text = ds.Tables[0].Rows[0][5].ToString();
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            // 根据图书编号修改图书名称、图书类型、出版社、出版时间、价格信息
            string sql = $"update book set bookname='{txtBookName.Text}',type='{cmbType.Text}'," +
                $"cbs='{txtPress.Text}',cbsj='{dtpPublishTime.Value}'," +
                $"price='{Convert.ToDecimal(txtPrice.Text)}' where bookid='{bookId}'";
            db.OperateData(sql);
            MessageBox.Show("图书信息修改成功");
            this.Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
