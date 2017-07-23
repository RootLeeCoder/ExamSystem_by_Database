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
    public partial class Form6 : Form
    {
        public Form6()
        {
            InitializeComponent();
        }

        public void binding()
        {
            try
            {
                textBox4.Text = dataGridView1.SelectedCells[0].Value.ToString();
                textBox1.Text = dataGridView1.SelectedCells[1].Value.ToString();
                comboBox1.Text = dataGridView1.SelectedCells[2].Value.ToString();
                textBox2.Text = dataGridView1.SelectedCells[3].Value.ToString();
                textBox3.Text = dataGridView1.SelectedCells[4].Value.ToString();
            }
            catch (Exception cw)
            {
                //MessageBox.Show(cw.Message);
            }
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            String Table = "EXAMINEE";
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT * FROM " + Table;
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            binding();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "")
            { MessageBox.Show("请填写完整信息!"); }
            else
            {
                String Table = "EXAMINEE";
                String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                String sql = "SELECT * FROM " + Table;
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                String str = "INSERT INTO " + Table + " VALUES('" + textBox4.Text + "', '" + textBox1.Text + "', '" + comboBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "')";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                Adpt.Fill(ds, Table);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
                MessageBox.Show("添加成功");
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "")
            { MessageBox.Show("请填写完整信息!"); }
            else
            {
                String Table = "EXAMINEE";
                String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                String sql = "SELECT * FROM " + Table;
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                String str = "UPDATE " + Table + " SET 考生姓名='" + textBox1.Text + "', 考生性别='" + comboBox1.Text + "', 出生地='" + textBox2.Text + "', 学校名称='" + textBox3.Text + "'" + "WHERE 准考证号='" + textBox4.Text.ToString() + "'";
                //String str = "UPDATE " + Table + " SET 学校名称='南信123大'" + "WHERE 准考证号='" + textBox4.Text.ToString() + "'";
                //String str = "UPDATE " + Table + " SET 学校名称='南信123大'" + "WHERE 准考证号='1'";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                Adpt.Fill(ds, Table);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
                MessageBox.Show("修改成功");
            }
        }

        private void button3_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || comboBox1.Text == "")
            { MessageBox.Show("请填写完整信息!"); }
            else
            {
                String Table = "EXAMINEE";
                String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                String sql = "SELECT * FROM " + Table;
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                String str = "DELETE FROM " + Table + " WHERE 准考证号='" + textBox4.Text.ToString() + "'";
                SqlCommand cmd = new SqlCommand(str, con);
                cmd.ExecuteNonQuery();
                SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
                DataSet ds = new DataSet();
                Adpt.Fill(ds, Table);
                dataGridView1.DataSource = ds.Tables[0];
                con.Close();
                MessageBox.Show("删除成功");
            }
        }
    }
}
