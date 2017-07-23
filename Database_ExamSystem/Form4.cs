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
    public partial class Form4 : Form
    {
        public Form4()
        {
            InitializeComponent();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (textBox4.Text == "" || textBox1.Text == "" || comboBox1.Text == "" || textBox2.Text == "" || textBox3.Text == "")
            { MessageBox.Show("你还有未填写的信息!", "提示"); return; }
            else
            {
                
                try
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
                    con.Close();
                    MessageBox.Show("注册成功", "提示");
                    this.Close();
                }
                catch { MessageBox.Show("重复的准考证号", "错误"); }
            }
        }
    }
}
