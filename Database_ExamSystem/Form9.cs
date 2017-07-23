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
    public partial class Form9 : Form
    {
        public Form9()
        {
            InitializeComponent();
        }

        private void Form9_Load(object sender, EventArgs e)
        {
            String Table = "ANSWERSHEET";
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT ANSWERSHEET.准考证号, 考生姓名, 考试科目, 总分 FROM ANSWERSHEET JOIN EXAMINEE ON ANSWERSHEET.准考证号= EXAMINEE.准考证号";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            String Table = "ANSWERSHEET";
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT ANSWERSHEET.准考证号, 考生姓名, 考试科目, 总分 FROM ANSWERSHEET JOIN EXAMINEE ON ANSWERSHEET.准考证号= EXAMINEE.准考证号 ORDER BY 总分 DESC";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            String Table = "ANSWERSHEET";
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT ANSWERSHEET.准考证号, 考生姓名, 考试科目, 总分 FROM ANSWERSHEET JOIN EXAMINEE ON ANSWERSHEET.准考证号= EXAMINEE.准考证号 ORDER BY 总分 ASC";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void textBox1_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox1.Text == "")
                {
                    MessageBox.Show("你还未输入姓名！", "提示");
                    return;
                }
                else
                {
                    String Table = "ANSWERSHEET";
                    String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                    String sql = "SELECT ANSWERSHEET.准考证号, 考生姓名, 考试科目, 总分 FROM ANSWERSHEET JOIN EXAMINEE ON ANSWERSHEET.准考证号= EXAMINEE.准考证号 WHERE 考生姓名='" + textBox1.Text + "'";
                    SqlConnection con = new SqlConnection(ConStr);
                    con.Open();
                    SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    Adpt.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            String Table = "ANSWERSHEET";
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT ANSWERSHEET.准考证号, 考生姓名, 考试科目, 总分 FROM ANSWERSHEET JOIN EXAMINEE ON ANSWERSHEET.准考证号= EXAMINEE.准考证号 WHERE 考试科目='" + comboBox1.Text + "'";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void pictureBox3_Click(object sender, EventArgs e)
        {
            String Table = "ANSWERSHEET";
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT ANSWERSHEET.准考证号, 考生姓名, 考试科目, 总分 FROM ANSWERSHEET JOIN EXAMINEE ON ANSWERSHEET.准考证号= EXAMINEE.准考证号";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void textBox3_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (textBox2.Text == "" || textBox3.Text == "")
                {
                    MessageBox.Show("你的分数输入不完整！", "提示");
                    return;
                }
                else if (int.Parse(textBox2.Text) >= 0 && int.Parse(textBox2.Text) <= 100 && int.Parse(textBox3.Text) >= 0 && int.Parse(textBox3.Text) <= 100)
                {
                    String Table = "ANSWERSHEET";
                    String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                    String sql = "SELECT ANSWERSHEET.准考证号, 考生姓名, 考试科目, 总分 FROM ANSWERSHEET JOIN EXAMINEE ON ANSWERSHEET.准考证号= EXAMINEE.准考证号 WHERE 总分>=" + textBox2.Text +" AND 总分<=" + textBox3.Text;
                    SqlConnection con = new SqlConnection(ConStr);
                    con.Open();
                    SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    Adpt.Fill(ds);
                    dataGridView1.DataSource = ds.Tables[0];
                    con.Close();
                }
                else
                {
                    MessageBox.Show("你的分数输入有误！", "提示");
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String Table = "ANSWERSHEET";
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT AVG(总分) FROM ANSWERSHEET";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds, Table);
            String point = ds.Tables["ANSWERSHEET"].Rows[0][0].ToString();
            textBox4.Text = point;
            con.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            String Table = "ANSWERSHEET";
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT TOP 1 ANSWERSHEET.准考证号, 考生姓名, 考试科目, 总分 FROM ANSWERSHEET JOIN EXAMINEE ON ANSWERSHEET.准考证号= EXAMINEE.准考证号 ORDER BY 总分 DESC";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            String Table = "ANSWERSHEET";
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT TOP 1 ANSWERSHEET.准考证号, 考生姓名, 考试科目, 总分 FROM ANSWERSHEET JOIN EXAMINEE ON ANSWERSHEET.准考证号= EXAMINEE.准考证号 ORDER BY 总分 ASC";
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }
    }
}
