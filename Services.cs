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
    public partial class Services : UserControl
    {
        public Services()
        {
            InitializeComponent();
        }

        public static SqlConnection con = new SqlConnection("Data source= OPTIMUS; Initial Catalog=Gestion_D_hopitals; Integrated Security=true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public static SqlDataReader dr;
        
        private void button1_Click_1(object sender, EventArgs e)
        {
            con.Open();
             cmd.CommandText = "select * from SERVICE where id_service=" + int.Parse(textBox1.Text);
   
            dr = cmd.ExecuteReader();
            if (dr.HasRows)
            {
                MessageBox.Show("CE ID EST EXISTE DéJA ENREGISTRE  .");
            }
            else
            {
                dr.Close();
                string sql = "insert into service values(" + int.Parse(textBox1.Text) + ",'" + textBox2.Text + "'," + int.Parse(textBox3.Text) + "," + int.Parse(comboBox1.Text) + ")";
                cmd.CommandText = sql;
                cmd.ExecuteNonQuery();
                con.Close();
                textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox1.Focus();
            }
        }

        private void button2_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select *  from service";
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
                    comboBox1.Text = dr[3].ToString();
                }
            }
            if (test == 0) MessageBox.Show("id inexixtant");
            con.Close();
        }

        private void button3_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = " update service set nom_service ='" + textBox2.Text + "', id_hopital='" + comboBox1.Text + "' , nonbre_Lits ='" +
                    int.Parse(textBox3.Text) + "' where id_service = " + int.Parse(textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox1.Focus();
        }

        private void button4_Click_1(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = " delete from service where id_service =" + int.Parse(textBox1.Text);
            cmd.ExecuteNonQuery();
            con.Close();
            textBox1.Clear(); textBox2.Clear(); textBox3.Clear(); textBox1.Focus();
        }

        private void Services_Load(object sender, EventArgs e)
        {
            con.Open();
            cmd.CommandText = "select id_service from  service";
            dr = cmd.ExecuteReader();
            while (dr.Read())
            {
                comboBox1.Items.Add(dr[0].ToString());
            }
            con.Close();
            dr.Close();
        }

    }
}

