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
    public partial class Patient : UserControl
    {
        public Patient()
        {
            InitializeComponent();
        }

             public static SqlConnection con = new SqlConnection("Data source= OPTIMUS; Initial Catalog=Gestion_D_hopitals; Integrated Security=true");
             public static SqlCommand cmd = new SqlCommand(" ", con);
             public static SqlDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
                 cmd.CommandText = "select * from patient where id_patient=" + textBox1.Text;
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show(" CE ID EST EXISTE DéJA ENREGISTRE  .");
            }
            else
            {
                dr.Close();
                cmd.CommandText = "insert into patient values(" + int.Parse(textBox1.Text) + " ,'" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value + "','" + textBox4.Text + "','" + textBox5.Text + "' )";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox5.Clear(); textBox1.Focus();
            }
        }

                private void button2_Click(object sender, EventArgs e)
                {
                con.Open();
                cmd.CommandText = "select * from patient";
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
                        dateTimePicker1.Text = dr[3].ToString();
                        textBox4.Text = dr[4].ToString();
                        textBox5.Text = dr[5].ToString();
                    }
                }
                if (test == 0) MessageBox.Show("id_ inexixtant");
                con.Close();
            }

                private void button3_Click(object sender, EventArgs e)
                {
                    con.Open();

                    cmd.CommandText = " update patient set Nom_Patient ='" + textBox2.Text + "' , prenom ='" + textBox3.Text + "' , date_naissance ='" + dateTimePicker1.Value + "' , Sexe_Patient ='" + textBox4.Text + "' , Adresse ='" + textBox5.Text + "'  where id_patient = " + int.Parse(textBox1.Text);
                    cmd.ExecuteNonQuery();
                    con.Close();
                    textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox5.Clear(); textBox1.Focus();
                }

                private void button4_Click(object sender, EventArgs e)
                {
                con.Open();
                cmd.CommandText = " delete from patient where id_patient =" + int.Parse(textBox1.Text);
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox5.Clear(); textBox1.Focus();
            }

                private void Patient_Load(object sender, EventArgs e)
                {

                }
            }
}
