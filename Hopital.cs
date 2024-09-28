using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Gestion_Hopital
{
    public partial class Hopital : UserControl
    {
        public Hopital()
        {
            InitializeComponent();
        }

        public static SqlConnection con = new SqlConnection("Data source= OPTIMUS; Initial Catalog=Gestion_D_hopitals; Integrated Security=true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public static SqlDataReader dr;

      

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
             cmd.CommandText = "select * from HOPITAL where id_hopital=" + int.Parse(textBox1.Text);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("CE ID EST EXISTE DéJA ENREGISTRE  .");
            }
            else
            {
                cmd.CommandText = "insert into hopital values(" + int.Parse(textBox1.Text) + " ,'" + textBox2.Text + "','" + textBox3.Text + "','" + textBox4.Text + "' )";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox1.Focus();
            }
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = " update hopital set nom_hopital ='" + textBox2.Text + "' , adresse ='" +
            textBox3.Text + "',ville ='" + textBox4.Text + "' where id_hopital = " + int.Parse(textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox1.Focus();
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select * from hopital";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int test = 0;
            while (dr.Read())
            {
                if (dr[0].ToString().Equals(textBox1.Text))
                {
                    test = 1;
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                    textBox3.Text = dr[2].ToString();
                    textBox4.Text = dr[3].ToString();
                }
            }
            if (test == 0) MessageBox.Show("id  inexixtant");
            con.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {

            con.Open();
            cmd.CommandText = " delete from hopital where id_hopital =" + int.Parse(textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox4.Clear(); textBox1.Focus();
        }

        private void Hopital_Load(object sender, EventArgs e)
        {

        }
    }
}
