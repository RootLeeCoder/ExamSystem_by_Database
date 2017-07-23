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
    public partial class Form7 : Form
    {
        String Table = "Questions";

        public Form7()
        {
            InitializeComponent();
        }

        public void binding()
        {
            try
            {
                textBox1.Text = dataGridView1.SelectedCells[0].Value.ToString();
                textBox2.Text = dataGridView1.SelectedCells[1].Value.ToString();
                textBox3.Text = dataGridView1.SelectedCells[2].Value.ToString();
                textBox4.Text = dataGridView1.SelectedCells[3].Value.ToString();
                textBox5.Text = dataGridView1.SelectedCells[4].Value.ToString();
                textBox6.Text = dataGridView1.SelectedCells[5].Value.ToString();
                comboBox2.Text = dataGridView1.SelectedCells[6].Value.ToString();
            }
            catch (Exception cw)
            {
                MessageBox.Show(cw.Message);
            }
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            //String Table = "Questions";
            if (comboBox1.Text == "网络科技")
            { Table = "Questions4"; }
            if (comboBox1.Text == "世界地理")
            { Table = "Questions5"; }
            if (comboBox1.Text == "全球历史")
            { Table = "Questions6"; }
            
            String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            String sql = "SELECT * FROM " + Table;
            SqlConnection con = new SqlConnection(ConStr);
            con.Open();
            SqlDataAdapter Adpt = new SqlDataAdapter(sql, con);
            DataSet ds = new DataSet();
            Adpt.Fill(ds, Table);
            dataGridView1.DataSource = ds.Tables[0];
            con.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
            //String sql = "SELECT * FROM " + Table;
            //SqlConnection con = new SqlConnection(ConStr);
            //con.Open();
            //SqlDataAdapter myda = new SqlDataAdapter(sql, con);
            //DataSet ds = new DataSet();
            //myda.Fill(ds, Table);
            //SqlCommandBuilder mybuilder = new SqlCommandBuilder(myda);
            //myda.Update(ds, Table);
            //MessageBox.Show("修改成功");
            //con.Close();

        }

        private void Form7_Load(object sender, EventArgs e)
        {

        }

        private void dataGridView1_Click(object sender, EventArgs e)
        {
            binding();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox2.Text == "")
            { MessageBox.Show("请填写完整信息!"); }
            else
            {
                String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                String sql = "SELECT * FROM " + Table;
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                String str = "INSERT INTO " + Table + " VALUES('" + textBox1.Text + "', '" + textBox2.Text + "', '" + textBox3.Text + "', '" + textBox4.Text + "', '" + textBox5.Text + "', '" + textBox6.Text + "', '" + comboBox2.Text + "')";
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox2.Text == "")
            { MessageBox.Show("请填写完整信息!"); }
            else
            {
                String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                String sql = "SELECT * FROM " + Table;
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                String str = "UPDATE " + Table + " SET 题目='" + textBox2.Text + "', A选项='" + textBox3.Text + "', B选项='" + textBox4.Text + "', C选项='" + textBox5.Text + "', D选项='" + textBox6.Text + "', 答案='"+ comboBox2.Text + "'" + " WHERE 题号=" + textBox1.Text.ToString();
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
            if (textBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "" || textBox4.Text == "" || textBox5.Text == "" || textBox6.Text == "" || comboBox2.Text == "")
            { MessageBox.Show("请填写完整信息!"); }
            else
            {
                String ConStr = "server=DESKTOP-E87C9EC; database=TestSystem; Integrated Security=True";
                String sql = "SELECT * FROM " + Table;
                SqlConnection con = new SqlConnection(ConStr);
                con.Open();
                String str = "DELETE FROM " + Table + " WHERE 题号=" + textBox1.Text.ToString() ;
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
