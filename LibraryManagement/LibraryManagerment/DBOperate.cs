using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LibraryManagement
{
    public class DBOperate
    {
        public SqlConnection con;
        public DBOperate()
        {
            string str = "Server=192.168.31.249;Database=Demo;UID=sa;Pwd=zxcv";
            this.con = new SqlConnection(str);
        }
        // 用于对数据库执行SQL语句
        public int OperateData(string sql)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int j = cmd.ExecuteNonQuery();
            con.Close();
            return j; // 返回影响的行数
        }
        // 用于查询表中数据的行数select count(*)
        public int HumanNum(string sql)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand(sql, con);
            int j = Convert.ToInt32(cmd.ExecuteScalar());
            con.Close();
            return j; // 返回查询结果的行数：0代表不存在，>0表示存在
        }
        // 用于根据指定的SQL查询语句返回对应的DataSet对象
        public DataSet GetTable(string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            return ds; // 返回数据集
        }
        // 用于将SQL语句查询的结果绑定到DataGridView插件
        public void BindDataGridView(DataGridView dataGridView,string sql)
        {
            SqlDataAdapter da = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            da.Fill(ds);
            dataGridView.DataSource = ds.Tables[0]; // 绑定DataGridView
        }
    }
}
