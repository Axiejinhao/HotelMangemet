using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace HotelMangement
{
    public partial class 主界面 : Form
    {
        public String name = "";
        public 主界面()
        {
            InitializeComponent();
        }

        private void 退出系统ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("确定退出系统吗？", "提示", MessageBoxButtons.OKCancel, MessageBoxIcon.Asterisk) == DialogResult.OK)
            {
                Application.Exit();
            }
        }

        private void 插入房间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            插入房间 f1 = new 插入房间();
            f1.ShowDialog();
        }

        private void 删除房间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            删除房间 f2 = new 删除房间();
            f2.ShowDialog();
        }

        private void 更改房间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            更改房间 f3 = new 更改房间();
            f3.ShowDialog();
        }

        private void 查询房间ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            查询房间 f4 = new 查询房间();
            f4.ShowDialog();
        }

        private void 插入员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            插入员工 f5 = new 插入员工();
            f5.ShowDialog();
        }

        private void 删除员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            删除员工 f6 = new 删除员工();
            f6.ShowDialog();

        }

        private void 更改员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            更改员工 f7 = new 更改员工();
            f7.ShowDialog();
        }

        private void 查询员工ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            查询员工 f8 = new 查询员工();
            f8.ShowDialog();
        }

        private void 插入顾客ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            插入顾客 f9 = new 插入顾客();
            f9.ShowDialog();
        }

        private void 删除顾客ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            删除顾客 f10 = new 删除顾客();
            f10.ShowDialog();
        }

        private void 更改顾客ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            更改顾客 f11 = new 更改顾客();
            f11.ShowDialog();
        }

        private void 查询顾客ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            查询顾客 f12 = new 查询顾客();
            f12.ShowDialog();
        }

        private void 入住信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            入住信息 f13 = new 入住信息();
            f13.ShowDialog();
        }

        private void 退房信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            退房信息 f14 = new 退房信息();
            f14.ShowDialog();
        }

        private void 插入顾客类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            插入顾客类型 f15 = new 插入顾客类型();
            f15.ShowDialog();

        }

        private void 删除顾客类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            删除顾客类型 f16 = new 删除顾客类型();
            f16.ShowDialog();

        }

        private void 更改顾客类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            更改顾客类型 f17 = new 更改顾客类型();
            f17.ShowDialog();
        }

        private void 查询顾客类型ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            查询顾客类型 f18 = new 查询顾客类型();
            f18.ShowDialog();
        }

        private void 查询入住信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            查询入住信息 f19 = new 查询入住信息();
            f19.ShowDialog();
        }

        private void 查询退房信息ToolStripMenuItem_Click(object sender, EventArgs e)
        {
            查询退房信息 f20 = new 查询退房信息();
            f20.ShowDialog();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            DateTime dt = DateTime.Now;
            String date = dt.ToLongDateString().ToString();
            String time = dt.ToLongTimeString().ToString();
            label1.Text = "当前时间：" + date + time;
            label2.Text = "欢迎用户：" + name;
        }
    }
}
