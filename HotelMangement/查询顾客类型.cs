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
    public partial class 查询顾客类型 : Form
    {
        public 查询顾客类型()
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
