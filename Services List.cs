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
    public partial class Services_List : UserControl
    {
        public Services_List()
        {
            InitializeComponent();
        }

            public static SqlConnection con = new SqlConnection("Data source= OPTIMUS; Initial Catalog=Gestion_D_hopitals; Integrated Security=true");

        public static SqlCommand cmd = new SqlCommand(" ", con);
        public static SqlDataReader dr;

        private void Services_List_Load(object sender, EventArgs e)
        {
      
            try
            {
                dataGridView2.Rows.Clear();
                cmd.CommandText = " select * from SERVICE ";
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                dr.Close();
                con.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            try
            {
                dataGridView2.Rows.Clear();
                cmd.CommandText = "select * from service";
                con.Open();
                dr = cmd.ExecuteReader();
                while (dr.Read())
                {
                    dataGridView2.Rows.Add(dr[0].ToString(), dr[1].ToString(), dr[2].ToString());
                }
                dr.Close();
                con.Close();

            }
            catch (Exception err)
            {
                MessageBox.Show(err.Message);
            }
        }
    }
}
