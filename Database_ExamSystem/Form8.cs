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
    public partial class Form8 : Form
    {
        int DaDui = 0;
        int rowIndex = 0;
        String[] Keys = new String[10];
        String[] Answers = new String[10];

        public Form8()
        {
            InitializeComponent();
        }

        private void Form8_Load(object sender, EventArgs e)
        {
            pictureBox1.Enabled = false;
            String Table = Question.q0;
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT * FROM " + Table;
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds, Table);

            labelQues.Text = ds.Tables[Table].Rows[rowIndex][1].ToString();
            label1.Text = ds.Tables[Table].Rows[rowIndex][2].ToString();
            label2.Text = ds.Tables[Table].Rows[rowIndex][3].ToString();
            label3.Text = ds.Tables[Table].Rows[rowIndex][4].ToString();
            label4.Text = ds.Tables[Table].Rows[rowIndex][5].ToString();
            label6.Text = ds.Tables[Table].Rows[rowIndex][6].ToString();
            con.Close();


            for (int i = 0; i < 10; i++)
            {
                Keys[i] = ds.Tables[Table].Rows[i][6].ToString();
            }

            Table = "ANSWERSHEET";
            ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            sql = "SELECT * FROM " + Table;
            con.Open();
            SqlDataAdapter Adpt_2 = new SqlDataAdapter("SELECT * FROM " + Table + " WHERE 准考证号 = '" + Question.student + "'", con);
            Adpt_2.Fill(ds, Table);
            for (int i = 0; i < 10; i++)
            {
                Answers[i] = ds.Tables[Table].Rows[0][i + 2].ToString();
            }
            label8.Text = ds.Tables[Table].Rows[0][rowIndex + 2].ToString();

            for (int i = 0; i < 10; i++)
            {
                if (Keys[i].Equals(Answers[i]))
                {
                    DaDui++;
                }
            }
            label12.Text = (10 * DaDui).ToString();

            //
            SqlCommand cmd = new SqlCommand();
            Adpt_2 = new SqlDataAdapter("UPDATE ANSWERSHEET SET 总分=" + label12.Text + " WHERE 准考证号 = '" + Question.student + "'", con);
            //cmd.CommandText = "UPDATE SET 总分=" + label12.Text + " WHERE 准考证号 = '" + Question.student + "'";
            Adpt_2.Fill(ds, Table);
            con.Close();


        }


        

        private void pictureBox1_Click(object sender, EventArgs e)
        {
            if (rowIndex == 0)
            {
                pictureBox1.Enabled = false;
            }
            else
            {
                rowIndex--;
                if (rowIndex == 0)
                { pictureBox1.Enabled = false; }
                if (rowIndex == 8)
                { pictureBox2.Enabled = true; }

                String Table = Question.q0;
                String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                String sql = "SELECT * FROM " + Table;
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                Adpt.Fill(ds, Table);

                labelQues.Text = ds.Tables[Table].Rows[rowIndex][1].ToString();
                label1.Text = ds.Tables[Table].Rows[rowIndex][2].ToString();
                label2.Text = ds.Tables[Table].Rows[rowIndex][3].ToString();
                label3.Text = ds.Tables[Table].Rows[rowIndex][4].ToString();
                label4.Text = ds.Tables[Table].Rows[rowIndex][5].ToString();
                label6.Text = ds.Tables[Table].Rows[rowIndex][6].ToString();
                con.Close();

                Table = "ANSWERSHEET";
                ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                sql = "SELECT * FROM " + Table;
                con.Open();
                SqlDataAdapter Adpt_2 = new SqlDataAdapter("SELECT * FROM " + Table + " WHERE 准考证号 = '" + Question.student + "'", con);
                Adpt_2.Fill(ds, Table);
                label8.Text = ds.Tables[Table].Rows[0][rowIndex + 2].ToString();

            }
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            if (rowIndex == 9)
            {
                pictureBox2.Enabled = false;
            }
            else
            {
                rowIndex++;
                if (rowIndex == 1)
                { pictureBox1.Enabled = true; }
                if (rowIndex == 9)
                { pictureBox2.Enabled = false; }

                String Table = Question.q0;
                String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                String sql = "SELECT * FROM " + Table;
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                Adpt.Fill(ds, Table);

                labelQues.Text = ds.Tables[Table].Rows[rowIndex][1].ToString();
                label1.Text = ds.Tables[Table].Rows[rowIndex][2].ToString();
                label2.Text = ds.Tables[Table].Rows[rowIndex][3].ToString();
                label3.Text = ds.Tables[Table].Rows[rowIndex][4].ToString();
                label4.Text = ds.Tables[Table].Rows[rowIndex][5].ToString();
                label6.Text = ds.Tables[Table].Rows[rowIndex][6].ToString();
                con.Close();

                Table = "ANSWERSHEET";
                ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                sql = "SELECT * FROM " + Table;
                con.Open();
                SqlDataAdapter Adpt_2 = new SqlDataAdapter("SELECT * FROM " + Table + " WHERE 准考证号 = '" + Question.student + "'", con);
                Adpt_2.Fill(ds, Table);
                label8.Text = ds.Tables[Table].Rows[0][rowIndex + 2].ToString();
            }
        }
    }
}
