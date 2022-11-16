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
    public partial class frmBookAdd : Form
    {
        public frmBookAdd()
        {
            InitializeComponent();
        }
        DBOperate db = new DBOperate();
        private void btnAdd_Click(object sender, EventArgs e)
        {
            // 先根据图书编号判断书籍是否已经存在
            string sql = $"select count(*) from book where bookid='{txtBookId.Text}'";
            if (db.HumanNum(sql) == 0) // 数据库中没有记录
            {
                // 插入图书信息
                string sql2 = $"insert into book values('{txtBookId.Text}','{txtBookName.Text}','{cmbBookType.Text}'" +
                    $",'{txtPress.Text}','{dateTimePicker1.Value}'," +
                    $"'{Convert.ToDecimal(txtPrice.Text)}','0','否')";
                db.OperateData(sql2);
                MessageBox.Show("添加图书成功");
            }
            else MessageBox.Show("图书编号重复");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
