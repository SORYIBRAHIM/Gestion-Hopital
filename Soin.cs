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
    public partial class Soin : UserControl
    {
        public Soin()
        {
            InitializeComponent();
        }
             public static SqlConnection con = new SqlConnection("Data source= OPTIMUS; Initial Catalog=Gestion_D_hopitals; Integrated Security=true");

        public static SqlCommand cmd = new SqlCommand(" ", con);
        public static SqlDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select * from SOIGNE where id_soin=" + int.Parse(textBox1.Text);
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("CE ID EST EXISTE DéJA ENREGISTRE  .");
            }
            else
            {
                dr.Close();
            cmd.CommandText = "insert into SOIGNE values(" + int.Parse(textBox1.Text) + " ,'" + textBox2.Text + "','" + textBox3.Text + "','" + dateTimePicker1.Value + "','" + int.Parse(comboBox1.Text) + "','" + int.Parse(comboBox2.Text) + "')";
            cmd.ExecuteNonQuery();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); comboBox1.Items.Clear(); comboBox2.Items.Clear(); textBox1.Focus();
            }

            con.Close();
        }

    private void button2_Click(object sender, EventArgs e)
        {
         con.Open();
        cmd.CommandText = "select * from SOIGNE";
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
        cmd.CommandText = " update soigne set nom_Malade =" + int.Parse(textBox2.Text) + "',commentaire'" + textBox3.Text + "',Date_Soigne'" + dateTimePicker1.Value + ",id_medecin" + int.Parse(comboBox1.Text) + ",id_patient" + int.Parse(comboBox2.Text) + " where idsoin = " + int.Parse(textBox1.Text);
            cmd.ExecuteNonQuery();
                 con.Close();
                  textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox1.Focus();
    }

        private void button4_Click(object sender, EventArgs e)
        {
        con.Open();
        cmd.CommandText = " delete from SOIGNE where id_soin =" + int.Parse(textBox1.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        textBox1.Clear(); textBox2.Clear(); comboBox1.Items.Clear(); comboBox2.Items.Clear() ; textBox3.Clear(); textBox1.Focus();
    }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void Soin_Load(object sender, EventArgs e)
        {

            try
            {
                con.Open();
                cmd.CommandText = "select id_medecin from medecin";
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
                cmd.CommandText = "select id_patient from patient";
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

        private void textBox3_TextChanged(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }
    }
}
