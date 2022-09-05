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
    public partial class 查询顾客 : Form
    {
        public 查询顾客()
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
            conn.Open();
            cmd = new SqlCommand("select CustomerID as 顾客编号, CustomerName as 顾客姓名, CustomerSex as 顾客性别, CustomerIDNumber as 顾客身份证, CustomerType as 顾客类型, CustomerPhone as 顾客联系方式, CustomerCreateDate as 办证时间 from Customer", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "Customer");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            if (this.radioButton1.Checked == true)
            {
                string str = "select CustomerID as 顾客编号, CustomerName as 顾客姓名, CustomerSex as 顾客性别, CustomerIDNumber as 顾客身份证, CustomerType as 顾客类型, CustomerPhone as 顾客联系方式, CustomerCreateDate as 办证时间 from Customer where CustomerID = '" + t1 + "'";
                cmd = new SqlCommand(str, conn);
            }
            else if (this.radioButton2.Checked == true)
            {
                string str = "select CustomerID as 顾客编号, CustomerName as 顾客姓名, CustomerSex as 顾客性别, CustomerIDNumber as 顾客身份证, CustomerType as 顾客类型, CustomerPhone as 顾客联系方式, CustomerCreateDate as 办证时间 from Customer where CustomerName like '%" + t1 + "%'";
                cmd = new SqlCommand(str, conn);
            }
            else if (this.radioButton3.Checked == true)
            {
                string str = "select CustomerID as 顾客编号, CustomerName as 顾客姓名, CustomerSex as 顾客性别, CustomerIDNumber as 顾客身份证, CustomerType as 顾客类型, CustomerPhone as 顾客联系方式, CustomerCreateDate as 办证时间 from Customer where CustomerCreateDate > '" + t1 + "'";
                cmd = new SqlCommand(str, conn);
            }
            conn.Open();
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "Customer");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
