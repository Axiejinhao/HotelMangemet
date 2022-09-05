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
    public partial class 删除员工 : Form
    {
        public 删除员工()
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
            SqlCommand cmd = new SqlCommand("delete from Worker where WorkerID ='" + t1 + "'", conn);
            MessageBox.Show("删除成功!", "成功", MessageBoxButtons.OK, MessageBoxIcon.Asterisk);
            conn.Close();

            conn.Open();
            cmd = new SqlCommand("select WorkerID as 员工编号, WorkerName as 员工姓名, WorkerSex as 员工性别, WorkerIDNumber as 员工身份证, WorkerPosition as 员工职称, WorkerPassword as 员工密码 from Worker", conn);
            sda = new SqlDataAdapter();
            sda.SelectCommand = cmd;
            ds = new DataSet();
            sda.Fill(ds, "Worker");
            this.dataGridView1.DataSource = ds.Tables[0];
            conn.Close();
        }

        private void 删除员工_Load(object sender, EventArgs e)
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
    }
}
