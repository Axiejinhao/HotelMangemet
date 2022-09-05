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
    public partial class 更改房间 : Form
    {
        public 更改房间()
        {
            InitializeComponent();
        }

        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;

        private void 更改房间_Load(object sender, EventArgs e)
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

        private void button3_Click(object sender, EventArgs e)
        {
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string t1 = this.textBox1.Text.Trim();
            string t2 = this.textBox2.Text.Trim();
            string t3 = this.textBox3.Text.Trim();
            string t4 = this.textBox4.Text.Trim();
            string sqlstr = "update Room set ";
            if (t1 == "")
            {
                MessageBox.Show("请选择要更改的图书信息", "提示", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
                return;
            }
            int flag = 0;
            if(t2 != "")
            {
                string s = " RoomType = '" + t2 + "'";
                if (flag == 1) sqlstr = sqlstr + ",";
                sqlstr = sqlstr + s;
                flag = 1;
            }
            if (t3 != "")
            {
                string s = " RoomPrice = '" + t3 + "'";
                if (flag == 1) sqlstr = sqlstr + ",";
                sqlstr = sqlstr + s;
                flag = 1;
            }
            if (t4 != "")
            {
                string s = " RoomState = '" + t4 + "'";
                if (flag == 1) sqlstr = sqlstr + ",";
                sqlstr = sqlstr + s;
                flag = 1;
            }
            sqlstr = sqlstr + " where RoomID = '" + t1 + "'";
            conn.Open();
            SqlCommand cmd = new SqlCommand(sqlstr, conn);
            cmd.ExecuteScalar();
            MessageBox.Show("更新成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            cmd.Clone();
            this.textBox1.Text = "";
            this.textBox2.Text = "";
            this.textBox3.Text = "";
            this.textBox4.Text = "";
            cmd.Clone();
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

        private void button1_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
