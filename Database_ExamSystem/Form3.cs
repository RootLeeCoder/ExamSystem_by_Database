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

namespace Database_ExamSystem
{
    public partial class Form3 : Form
    {
        String Table = Question.q0;
        int rowIndex = 0;
        int YiZuo = 0;

        public Form3()
        {
            InitializeComponent();
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboBox1.Text = "简体中文";

            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT * FROM " + Table;
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds, Table);

            rowIndex = 0;
            labelQues.Text = ds.Tables[Table].Rows[rowIndex][1].ToString();
            radioButton1.Text = ds.Tables[Table].Rows[rowIndex][2].ToString();
            radioButton2.Text = ds.Tables[Table].Rows[rowIndex][3].ToString();
            radioButton3.Text = ds.Tables[Table].Rows[rowIndex][4].ToString();
            radioButton4.Text = ds.Tables[Table].Rows[rowIndex][5].ToString();

            labelFen.Text = "0";
            labelMiao.Text = "0";
            labelFenLast.Text = "10";
            labelMiaoLast.Text = "0";
            timer1.Enabled = true;

        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            int min = Int32.Parse(labelFen.Text);
            int sec = Int32.Parse(labelMiao.Text);
            sec++;
            if (sec == 60)
            {
                min++;
                labelFen.Text = min.ToString();
                labelMiao.Text = "0";
                if (min == 10)
                {
                    timer1.Enabled = false;
                    groupBox3.Enabled = false;
                    button1.Enabled = false;
                    pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\0.png");
                    MessageBox.Show("考试时间到！请停止答题", "提示");
                    return;
                }
            }
            sec = sec % 60;
            labelMiao.Text = sec.ToString();
            labelFenLast.Text = (9 - min).ToString();
            labelMiaoLast.Text = (60 - sec).ToString();

            if (min == 0)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\100.png"); }
            if (min == 1)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\90.png"); }
            if (min == 2)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\80.png"); }
            if (min == 3)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\70.png"); }
            if (min == 4)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\60.png"); }
            if (min == 5)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\50.png"); }
            if (min == 6)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\40.png"); }
            if (min == 7)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\30.png"); }
            if (min == 8)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\20.png"); }
            if (min == 9)
            { pictureBox3.Image = Image.FromFile(@"..\..\..\Resources\10.png"); }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (timer1.Enabled == true)
            {
                timer1.Enabled = false; button2.Text = "开始计时";
                groupBox3.Enabled = false;
                button1.Enabled = false;
            }
            else
            {
                timer1.Enabled = true; button2.Text = "暂停计时";
                button1.Enabled = true;
                if (button1.Text.ToString().Equals("提交本题"))
                {
                    groupBox3.Enabled = true;
                }
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://en.wikipedia.org/wiki/Bitcoin");
        }

        private void linkLabel2_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            System.Diagnostics.Process.Start("https://www.bitcoin.com/");
        }

        private void linkLabel3_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            MessageBox.Show("项目名：在线考试系统客户端\n作者：李根\n学号：20151308062", "关于作者");
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Answer = "";

            if (radioButton1.Checked)
            {
                Answer = "A";
            }
            else if (radioButton2.Checked)
            {
                Answer = "B";
            }
            else if (radioButton3.Checked)
            {
                Answer = "C";
            }
            else if (radioButton4.Checked)
            {
                Answer = "D";
            }
            else
            {
                MessageBox.Show("你还没有选择！");
                return;
            }
            YiZuo++;
            labelYiZuo.Text = (YiZuo).ToString();
            labelShengYu.Text = (10 - YiZuo).ToString();

            //Table = "ANSWERSHEET";
            String Table_2 = "ANSWERSHEET";
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT * FROM " + Table_2;
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            String str = "UPDATE " + Table_2 + " SET 第" + YiZuo.ToString() + "题='" + Answer + "' WHERE 准考证号='" + Question.student + "'";
            //MessageBox.Show("Here");
            SqlCommand cmd = new SqlCommand(str, con);
            cmd.ExecuteNonQuery();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds, Table_2);
            con.Close();
            
            rowIndex++;
            if (rowIndex == 10)
            {
                timer1.Enabled = false;
                MessageBox.Show("考试结束，请点击确定按钮查看答题情况", "提示");
                new Form8().Show();
                Close();
            }
            else
            {
                Table = Question.q0;
                ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                sql = "SELECT * FROM " + Table;
                con.Open();
                SqlDataAdapter Adpt_2 = new SqlDataAdapter("SELECT * FROM " + Table, con);
                Adpt_2.Fill(ds, Table);
                
                labelQues.Text = ds.Tables[Table].Rows[rowIndex][1].ToString();
                radioButton1.Text = ds.Tables[Table].Rows[rowIndex][2].ToString();
                radioButton2.Text = ds.Tables[Table].Rows[rowIndex][3].ToString();
                radioButton3.Text = ds.Tables[Table].Rows[rowIndex][4].ToString();
                radioButton4.Text = ds.Tables[Table].Rows[rowIndex][5].ToString();
                con.Close();
            }
        }
    }
}
