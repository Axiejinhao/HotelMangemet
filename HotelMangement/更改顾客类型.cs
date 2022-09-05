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
    public partial class 更改顾客类型 : Form
    {
        public 更改顾客类型()
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
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string t2 = this.textBox2.Text.Trim();
            string t3 = this.textBox3.Text.Trim();
            string sqlstr = "update CustomerType set ";
            if (t1 == "")
            {
                MessageBox.Show("请选择要更改的图书信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            int flag = 0;
            if (t2 != "")
            {
                string s = "Discount = '" + t2 + "'";
                if (flag == 1) sqlstr = sqlstr + ",";
                sqlstr = sqlstr + s;
                flag = 1;
            }
            if (t3 != "")
            {
                string s = " Fine = '" + t3 + "'";
                if (flag == 1) sqlstr = sqlstr + ",";
                sqlstr = sqlstr + s;
                flag = 1;
            }
            sqlstr = sqlstr + " where TypeName = '" + t1 + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            cmd.ExecuteScalar();
            MessageBox.Show("更新成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            cmd.Clone();
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            cmd.Clone();
            conn.Close();

            conn.Open();
            cmd = new SqlCommand("select TypeName as 类型名称, Discount as 折扣, Fine as 罚款 from CustomerType", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "CustomerType");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void 更改顾客类型_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select TypeName as 类型名称, Discount as 折扣, Fine as 罚款 from CustomerType", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "CustomerType");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
