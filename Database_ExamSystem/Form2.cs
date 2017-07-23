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
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            String course = "";
            if (txtNumber.Text == "" || !txtNumber.Text.Equals(Question.student))
            { MessageBox.Show("准考证号错误！", "提示"); return; }
            else if (comboBox1.Text == "")
            { MessageBox.Show("你还没有选择考试题目！", "提示"); return; }
            else
            {
                if (comboBox1.Text == "网络科技")
                { Question.q0 = Question.q1; course = "网络科技"; }
                if (comboBox1.Text == "世界地理")
                { Question.q0 = Question.q2; course = "世界地理"; }
                if (comboBox1.Text == "全球历史")
                { Question.q0 = Question.q3; course = "全球历史"; }
                //Question.student = txtNumber.Text;

                String Table_2 = "ANSWERSHEET";
                String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                String sql = "SELECT * FROM " + Table_2;
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                try
                {
                    String str = "INSERT INTO ANSWERSHEET VALUES('" + txtNumber.Text + "','','','','','','','','','','','','')";
                    SqlCommand cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                    DataSet ds = new DataSet();
                    Adpt.Fill(ds, Table_2);
                    //
                    str = "UPDATE " + Table_2 + " SET 考试科目='" + course + "' WHERE 准考证号='" + txtNumber.Text + "'";
                    cmd = new SqlCommand(str, con);
                    cmd.ExecuteNonQuery();
                    Adpt = new SqlDataAdapter(sql, con);
                    ds = new DataSet();
                    Adpt.Fill(ds, Table_2);
                    con.Close();
                    MessageBox.Show("考试即将开始，请点击确定按钮进入考试页面", "提示");
                }
                catch { MessageBox.Show("不存在的!"); }
                
                
            }
            new Form3().Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            new Form4().Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void txtNumber_KeyDown(object sender, KeyEventArgs e)
        {
            String Table = "EXAMINEE";
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT * FROM " + Table;
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            SqlCommand cmd = new SqlCommand();
            cmd.Connection = con;
            cmd.CommandText = "SELECT COUNT(*) FROM EXAMINEE WHERE 准考证号='" + txtNumber.Text + "'";
            Adpt.SelectCommand = cmd;
            Adpt.Fill(ds, Table);
            
            String count = ds.Tables["EXAMINEE"].Rows[0][0].ToString();
            if (e.KeyCode == Keys.Enter)
            {
                if (txtNumber.Text == "")
                {
                    MessageBox.Show("你还未输入准考证号！", "提示");
                    return ;
                }
                else if (count == "0")
                {
                    MessageBox.Show("用户不存在！", "提示");
                }
                else
                {
                    pictureBox1.BackgroundImage = Image.FromFile(@"..\..\..\Resources\login.jpg");
                    MessageBox.Show("登录成功！", "提示");
                    Question.student = txtNumber.Text;
                }
                
            }
        }
    }

    public class Question
    {
        public static String student;
        public static String q1 = "Questions4";
        public static String q2 = "Questions5";
        public static String q3 = "Questions6";
        public static String q0;
    }
}
