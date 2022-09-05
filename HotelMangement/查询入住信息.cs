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
    public partial class 查询入住信息 : Form
    {
        public 查询入住信息()
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
            cmd = new SqlCommand("select InID as 入住编号, CustomerID as 顾客编号, CustomerType as 顾客类型, CustomerInDate as 入住时间, CustomerOutDate as 应退房时间, RoomID as 房间编号, Worker as 办理人 from InHistory", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "InHistory");
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
            string str = this.comboBox1.SelectedItem.ToString();
            string sqlstr = "select InID as 入住编号, CustomerID as 顾客编号, CustomerType as 顾客类型, CustomerInDate as 入住时间, CustomerOutDate as 应退房时间, RoomID as 房间编号, Worker as 办理人 from InHistory where " + str + " = '" + t1 + "'";
            conn.Open();
            cmd = new SqlCommand(sqlstr, conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "InHistory");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
