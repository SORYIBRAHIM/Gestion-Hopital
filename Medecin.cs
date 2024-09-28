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
    public partial class Medecin : UserControl
    {
        public Medecin()
        {
            InitializeComponent();
        }

        public static SqlConnection con = new SqlConnection("Data source= OPTIMUS; Initial Catalog=Gestion_D_hopitals; Integrated Security=true");

        public static SqlCommand cmd = new SqlCommand(" ", con);
        public static SqlDataReader dr;
        private void Medecin_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.CommandText = "select id_specialite from specialite";
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {
                    comboBox1.Items.Add(drd[0].ToString());
                }
                con.Close();
            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
            try
            {
                con.Open();
                cmd.CommandText = "select id_service from service";
                SqlDataReader drd = cmd.ExecuteReader();
                while (drd.Read())
                {
                    comboBox2.Items.Add(drd[0].ToString());
                }
                con.Close();
            }

            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select * from MEDECIN where id_medecin=" + int.Parse(textBox1.Text);

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show(" CE ID EST EXISTE DéJA ENREGISTRE  .");
            }
            else
            {
                dr.Close();
                cmd.CommandText = "insert into MEDECIN values(" + int.Parse(textBox1.Text) + " ,'" + textBox2.Text + "','" + dateTimePicker1.Value + "' ,'" + textBox3.Text + "','" + comboBox1.Text + "','" + comboBox2.Text + "' )";
                cmd.ExecuteNonQuery();
                con.Close();

                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); comboBox1.Items.Clear(); comboBox2.Items.Clear(); textBox1.Focus();
            }
        }


        private void button2_Click(object sender, EventArgs e)
        {

            con.Open();
            cmd.CommandText = "select * from medecin";
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
                    dateTimePicker1.Text = dr[2].ToString();
                    textBox3.Text = dr[3].ToString();
                    comboBox1.Text = dr[4].ToString();
                    comboBox2.Text = dr[5].ToString();



                }
            }
            if (test == 0) MessageBox.Show("id inexixtant");
            con.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            con.Open();
            cmd.CommandText = "UPDATE medecin SET Nom_medecin = '" + textBox2.Text + "', sexe_Medecin = '" + textBox3.Text + "', id_specialite = '" + comboBox1.Text + "', id_service = '" + comboBox2.Text + "', Date_naissance = '" + dateTimePicker1.Value + "' WHERE id_medecin = " + int.Parse(textBox1.Text);

            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); comboBox1.Items.Clear(); comboBox2.Items.Clear(); textBox1.Focus();
        }
        private void button4_Click(object sender, EventArgs e)
        {
            con.Open();

            cmd.CommandText = " delete from medecin where id_medecin =" + int.Parse(textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();

            textBox1.Clear(); textBox2.Clear();textBox3.Clear() ; comboBox1.Items.Clear(); comboBox2.Items.Clear(); textBox1.Focus();
        }
    }
}

