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
    public partial class 查询房间 : Form
    {
        public 查询房间()
        {
            InitializeComponent();
        }
        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;
        private void 查询房间_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string t2 = this.textBox2.Text.Trim();
            if (this.radioButton1.Checked == true)
            {
                string str = "select RoomID as 房间号, RoomType as 房间类型, RoomPrice as 房间价格, RoomState as 入住状态 from Room where RoomID = '" + t1 + "'";
                cmd = new SqlCommand(str, conn);
            }
            else if (this.radioButton2.Checked == true)
            {
                string str = "select RoomID as 房间号, RoomType as 房间类型, RoomPrice as 房间价格, RoomState as 入住状态 from Room where RoomType = '" + t1 + "'";
                cmd = new SqlCommand(str, conn);
            }
            else if (this.radioButton3.Checked == true)
            {
                string str = "select RoomID as 房间号, RoomType as 房间类型, RoomPrice as 房间价格, RoomState as 入住状态 from Room where RoomPrice between " + t1 + " and " + t2;
                cmd = new SqlCommand(str, conn);
            }
            conn.Open();
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "Room");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button4_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
        }
    }
}
