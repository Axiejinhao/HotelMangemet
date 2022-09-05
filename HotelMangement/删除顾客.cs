using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelMangement
{
    public partial class 删除顾客 : Form
    {
        public 删除顾客()
        {
            InitializeComponent();
        }

        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            if (t1 == "")
            {
                MessageBox.Show("请选择要更改的图书信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            conn.Open();
            SqlCommand cmd = new SqlCommand("delete from Customer where CustomerID ='" + t1 + "'", conn);
            MessageBox.Show("删除成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            conn.Close();

            conn.Open();
            cmd = new SqlCommand("select CustomerID as 顾客编号, CustomerName as 顾客姓名, CustomerSex as 顾客性别, CustomerIDNumber as 顾客身份证, CustomerType as 顾客类型, CustomerPhone as 顾客联系方式, CustomerCreateDate as 办证时间 from Customer", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "Customer");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void 删除顾客_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select CustomerID as 顾客编号, CustomerName as 顾客姓名, CustomerSex as 顾客性别, CustomerIDNumber as 顾客身份证, CustomerType as 顾客类型, CustomerPhone as 顾客联系方式, CustomerCreateDate as 办证时间 from Customer", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "Customer");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
