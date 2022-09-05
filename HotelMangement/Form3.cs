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
    public partial class Form3 : Form
    {
        public Form3()
        {
            InitializeComponent();
        }
        public Form1 f1;
        public string sql;
        private void button1_Click(object sender, EventArgs e)
        {
            string userid = textBox1.Text.Trim();
            string userpwd = textBox2.Text.Trim();
            string userpwd2 = textBox3.Text.Trim();
            SqlConnection conn = new SqlConnection(f1.ConStr);
            try
            {
                if (userpwd == userpwd2)
                {
                    conn.Open();
                    if (conn.State == ConnectionState.Open)
                    {
                        if (f1.rd1) { sql = f1.sqlstr3 + "'" + userid + "'" + "," + "'" + userpwd + "')"; }
                        else { sql = f1.sqlstr4 + "'" + userid + "'" + "," + "'" + userpwd + "')"; }

                        SqlDataAdapter data = new SqlDataAdapter(sql, conn);
                        DataSet dt = new DataSet();
                        data.Fill(dt);
                        MessageBox.Show("注册成功！","注册提示");
                        conn.Close();
                    }
                    else
                    {
                        MessageBox.Show("连接数据库失败", "连接提示");
                    }
                }
                else
                {
                    MessageBox.Show("请输入相同的密码！", "注册提示");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "连接提示");
            }
        }

        private void Form3_Load(object sender, EventArgs e)
        {

        }
    }
}
