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
    public partial class 更改顾客 : Form
    {
        public 更改顾客()
        {
            InitializeComponent();
        }

        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string t2 = this.textBox2.Text.Trim();
            string t3 = this.textBox3.Text.Trim();
            string t4 = this.textBox4.Text.Trim();
            string t5 = this.textBox5.Text.Trim();
            string t6 = this.textBox6.Text.Trim();
            string t7 = this.textBox6.Text.Trim();
            string sqlstr = "update Customer set ";
            if (t1 == "")
            {
                MessageBox.Show("请选择要更改的图书信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            int flag = 0;
            if (t2 != "")
            {
                string s = "CustomerName = '" + t2 + "'";
                if (flag == 1) sqlstr = sqlstr + ",";
                sqlstr = sqlstr + s;
                flag = 1;
            }
            if (t3 != "")
            {
                string s = " CustomerSex = '" + t3 + "'";
                if (flag == 1) sqlstr = sqlstr + ",";
                sqlstr = sqlstr + s;
                flag = 1;
            }
            if (t4 != "")
            {
                string s = " CustomerIDNumber = '" + t4 + "'";
                if (flag == 1) sqlstr = sqlstr + ",";
                sqlstr = sqlstr + s;
                flag = 1;
            }
            if (t5 != "")
            {
                string s = " CustomerType = '" + t5 + "'";
                if (flag == 1) sqlstr = sqlstr + ",";
                sqlstr = sqlstr + s;
                flag = 1;
            }
            if (t6 != "")
            {
                string s = " CustomerPhone = '" + t6 + "'";
                if (flag == 1) sqlstr = sqlstr + ",";
                sqlstr = sqlstr + s;
                flag = 1;
            }
            if (t7 != "")
            {
                string s = " CustomerCreateDate = '" + t7 + "'";
                if (flag == 1) sqlstr = sqlstr + ",";
                sqlstr = sqlstr + s;
                flag = 1;
            }
            sqlstr = sqlstr + " where CustomerID = '" + t1 + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            cmd.ExecuteScalar();
            MessageBox.Show("更新成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            cmd.Clone();
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            this.textBox5.Text = "";
            this.textBox6.Text = "";
            this.textBox7.Text = "";
            cmd.Clone();
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

        private void 更改顾客_Load(object sender, EventArgs e)
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
