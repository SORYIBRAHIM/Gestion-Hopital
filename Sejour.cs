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
    public partial class Sejour : UserControl
    {
        public Sejour()
        {
            InitializeComponent();
        }
             public static SqlConnection con = new SqlConnection("Data source= OPTIMUS; Initial Catalog=Gestion_D_hopitals; Integrated Security=true");

        public static SqlCommand cmd = new SqlCommand(" ", con);
        public static SqlDataReader dr;

        private void button1_Click(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select * from sejourne where id_Sejour=" + textBox1.Text;

            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show(" CE ID EST EXISTE DéJA ENREGISTRE  .");
            }
            else
            {
                dr.Close();
                cmd.CommandText = "insert into SEJOURNE values(" + int.Parse(textBox1.Text) + ",'" + dateTimePicker1.Value + "','" + dateTimePicker2.Value + "'," + int.Parse(comboBox1.Text) + "," + int.Parse(comboBox2.Text) + " )";
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Clear(); comboBox1.Items.Clear(); comboBox2.Items.Clear(); textBox1.Focus();
            }
            
        }

         private void button2_Click(object sender, EventArgs e)
        {
        con.Open();
        cmd.CommandText = "select * from SEJOURNE";
        SqlDataReader dr;
        dr = cmd.ExecuteReader();
        int test = 0;
        while (dr.Read())
        {
            if (dr[0].ToString().Equals(textBox1.Text))
            {
                test = 1;
                textBox1.Text = dr[0].ToString();
                dateTimePicker1.Text = dr[1].ToString();
                dateTimePicker1.Text = dr[2].ToString();
                comboBox1.Text = dr[3].ToString();
                comboBox2.Text = dr[4].ToString();
            }
        }
        if (test == 0) MessageBox.Show("id  inexixtant");
        con.Close();
    }

        private void button3_Click(object sender, EventArgs e)
        {
        con.Open();
        cmd.CommandText = " update sejour set date_entre ='" + dateTimePicker1.Value + "' , date_sortie ='" + dateTimePicker2.Value + "' , id_service ='" + comboBox1.Text + "' , id_patient ='" +
                comboBox2.Text + "' where id_SEJOURNE = " + int.Parse(textBox1.Text);
        cmd.ExecuteNonQuery();
        con.Close();
        textBox1.Clear(); comboBox1.Items.Clear(); comboBox2.Items.Clear(); textBox1.Focus();
    }

        private void button4_Click(object sender, EventArgs e)
        {
        con.Open();

        cmd.CommandText = " delete from sejour where id_SEJOURNE =" + int.Parse(textBox1.Text);
        cmd.ExecuteNonQuery();
        con.Close();

        textBox1.Clear(); comboBox1.Items.Clear(); comboBox2.Items.Clear(); textBox1.Focus();
    }

        private void Sejour_Load(object sender, EventArgs e)
        {
            try
            {
                con.Open();
                cmd.CommandText = "select id_service from SERVICE";
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
    }
}
