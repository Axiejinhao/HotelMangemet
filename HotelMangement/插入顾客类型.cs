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
    public partial class 插入顾客类型 : Form
    {
        public 插入顾客类型()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
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
            if (t1 == "")
            {
                MessageBox.Show("类型名称不能为空!", "警告", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                SqlConnection conn = CONN.Myconn();
                conn.Open();
                SqlCommand cmd = new SqlCommand("select * from CustomerType where TypeName = '" + t1 + "'", conn);
                SqlDataReader sdr = cmd.ExecuteReader();
                if (sdr.Read())
                {
                    this.label5.Text = "类型名称已存在!";
                    this.label5.Visible = true;
                }
                else
                {
                    cmd.Clone();
                    cmd = new SqlCommand("insert into CustomerType values('" + t1 + "','" + t2 + "','" + t3 + "')", conn);
                    sdr.Close();
                    cmd.ExecuteScalar();
                    this.label5.Text = "增加成功!";
                    this.label5.Visible = true;
                }
                this.textBox1.Text = "";
                this.textBox2.Text = "";
                this.textBox3.Text = "";
                conn.Close();
            }
        }
    }
}
