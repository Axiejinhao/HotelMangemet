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
    public partial class 删除房间 : Form
    {
        public 删除房间()
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
            SqlCommand cmd = new SqlCommand("delete from Room where RoomID ='" + t1 + "'", conn);
            MessageBox.Show("删除成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            conn.Close();

            conn.Open();
            cmd = new SqlCommand("select RoomID as 房间号, RoomType as 房间类型, RoomPrice as 房间价格, RoomState as 入住状态 from Room", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "Room");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void 删除房间_Load(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select RoomID as 房间号, RoomType as 房间类型, RoomPrice as 房间价格, RoomState as 入住状态 from Room", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "Room");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
