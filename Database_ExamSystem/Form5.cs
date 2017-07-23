using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Database_ExamSystem
{
    public partial class Form5 : Form
    {
        public Form5()
        {
            InitializeComponent();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "admin")
                {
                    label3.Text = "当前状态：已登录";
                    label3.ForeColor = Color.LightGreen;
                    MessageBox.Show("登录成功！", "提示");
                }
                else
                {
                    MessageBox.Show("密码错误!");
                    return;
                }
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (label3.Text == "当前状态：已登录")
            { new Form6().Show(); }
            else
            {
                MessageBox.Show("您还未登录!");
                return;
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (label3.Text == "当前状态：已登录")
            { new Form7().Show(); }
            else
            {
                MessageBox.Show("您还未登录!");
                return;
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            if (label3.Text == "当前状态：已登录")
            { new Form9().Show(); }
            else
            {
                MessageBox.Show("您还未登录!");
                return;
            }
        }
    }
}
