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
    public partial class Specialités : UserControl
    {
        public Specialités()
        {
            InitializeComponent();
        }
              public static SqlConnection con = new SqlConnection("Data source= OPTIMUS; Initial Catalog=Gestion_D_hopitals; Integrated Security=true");

        public static SqlCommand cmd = new SqlCommand(" ", con);
        public static SqlDataReader dr;

        private void Specialités_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
              cmd.CommandText = "select * from SPECIALITE where id_specialite=" + textBox1.Text;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("CE ID EST EXISTE DéJA ENREGISTRE  .");
            }
            else
            {
                dr.Close();
                cmd.CommandText = "insert into SPECIALITE values(" + int.Parse(textBox1.Text) + " ,'" + textBox2.Text + "' )";
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Clear(); textBox2.Clear(); textBox1.Focus();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select * from SPECIALITE";
            SqlDataReader dr;
            dr = cmd.ExecuteReader();
            int test = 0;
            while (dr.Read())
            {
                if (dr[0].ToString().Equals(textBox1.Text))
                {   test = 1;
                    textBox1.Text = dr[0].ToString();
                    textBox2.Text = dr[1].ToString();
                }
            }
            if (test == 0) MessageBox.Show("id  inexixtant");
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = " update specialite set libelle ='" + textBox2.Text + "' where id_specialite = " + int.Parse(textBox1.Text);
            cmd.ExecuteNonQuery();
            textBox1.Clear(); textBox2.Clear(); textBox1.Focus();
            con.Close();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = " delete from SPECIALITE where id_SPECIALITE =" + int.Parse(textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Clear(); textBox2.Clear(); textBox1.Focus();
        }
    }
}
