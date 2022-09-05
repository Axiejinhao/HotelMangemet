using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace HotelMangement
{
    public partial class Form1 : Form
    {
        public string ConStr = "server=.\\SQLEXPRESS; database = HotelManagementLibrary; Integrated Security = SSPI";            
        public string sqlstr1="select * from Worker";
        public string sqlstr2 = "select * from Manager";
        public string sqlstr3 = "insert into Worker(WorkerID,WorkerPassword) values(";
        public string sqlstr4 = "insert into Manager(ManagerID,ManagerPassword) values(";
        public bool rd1; 
        public Form1()
        {
            InitializeComponent();
        }



        private void button2_Click(object sender, EventArgs e)
        {
            try
            {
                SqlConnection conn = new SqlConnection(ConStr);
                conn.Open();
                if (conn.State == ConnectionState.Open)
                {
                    主界面 f = new 主界面();
                    if (radioButton1.Checked) 
                    {
                        rd1 = true;
                        string sql1 = "select * from Worker where WorkerID=" + "'" + textBox1.Text.Trim() + "'" + "and WorkerPassword=" + "'" + textBox2.Text.Trim() + "'";
                        SqlCommand com = new SqlCommand(sql1, conn);
                        SqlDataReader sread = com.ExecuteReader();
                        try
                        {
                            if (sread.Read())
                            {
                                f.员工信息ToolStripMenuItem.Enabled = false;
                                f.name = textBox1.Text.Trim();
                                f.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("请输入正确的用户名和密码");
                            }
                        }
                        catch (Exception msg)
                        {
                            throw new Exception(msg.ToString()); 
                        }
                        finally
                        {
                            conn.Close();
                            conn.Dispose(); 
                            sread.Dispose(); 
                        }
                    }                 
                    else 
                    {
                        rd1 = false;
                        string sql2 = "select * from Manager where ManagerID=" + "'" + textBox1.Text.Trim() + "'" + "and ManagerPassword=" + "'" + textBox2.Text.Trim() + "'";
                        SqlCommand com = new SqlCommand(sql2, conn);
                        SqlDataReader sread = com.ExecuteReader();
                        try
                        {
                            if (sread.Read())
                            {
                                f.name = textBox1.Text.Trim();
                                f.ShowDialog();
                                this.Close();
                            }
                            else
                            {
                                MessageBox.Show("请输入正确的用户名和密码","登录提示");
                            }
                        }
                        catch (Exception msg)
                        {
                            throw new Exception(msg.ToString());
                        }
                        finally
                        {
                            conn.Close();
                            conn.Dispose();
                            sread.Dispose();
                        }
                    }

                }
                else
                {
                    MessageBox.Show("连接数据库失败", "连接提示");
                }

            }
            catch (Exception ex)
            {
                MessageBox.Show("Error:" + ex.Message, "连接提示");
            }


        } 
    

        private void button1_Click(object sender, EventArgs e)
        {
            if (radioButton1.Checked) { rd1 = true; }
            else { rd1 = false; }
            Form3 f3 = new Form3();
            f3.f1 = this;
            f3.ShowDialog();

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }
    }
}
