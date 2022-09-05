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
    public partial class 查询员工 : Form
    {
        public 查询员工()
        {
            InitializeComponent();
        }

        SqlConnection conn = CONN.Myconn();
        SqlCommand cmd;
        SqlDataAdapter sda;
        DataSet ds;

        private void button1_Click(object sender, EventArgs e)
        {
            conn.Open();
            cmd = new SqlCommand("select WorkerID as 员工编号, WorkerName as 员工姓名, WorkerSex as 员工性别, WorkerIDNumber as 员工身份证, WorkerPosition as 员工职称, WorkerPassword as 员工密码 from Worker", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "Worker");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
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
                string str = "select WorkerID as 员工编号, WorkerName as 员工姓名, WorkerSex as 员工性别, WorkerIDNumber as 员工身份证, WorkerPosition as 员工职称, WorkerPassword as 员工密码 from Worker where WorkerID = '" + t1 + "'";
                cmd = new SqlCommand(str, conn);
            }
            else if (this.radioButton2.Checked == true)
            {
                string str = "select WorkerID as 员工编号, WorkerName as 员工姓名, WorkerSex as 员工性别, WorkerIDNumber as 员工身份证, WorkerPosition as 员工职称, WorkerPassword as 员工密码 from Worker where WorkerName like '%" + t1 + "%'";
                cmd = new SqlCommand(str, conn);
            }
            else if (this.radioButton3.Checked == true)
            {
                string str = "select WorkerID as 员工编号, WorkerName as 员工姓名, WorkerSex as 员工性别, WorkerIDNumber as 员工身份证, WorkerPosition as 员工职称, WorkerPassword as 员工密码 from Worker where WorkerPosition like '%" + t1 + "%'";
                cmd = new SqlCommand(str, conn);
            }
            conn.Open();
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "Worker");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }
    }
}
