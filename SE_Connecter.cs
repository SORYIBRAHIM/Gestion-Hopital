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
    public partial class SE_Connecter : UserControl
    {
        public SE_Connecter()
        {
            InitializeComponent();
        }

        public static SqlConnection con = new SqlConnection("Data source= OPTIMUS; Initial Catalog=Gestion_D_hopitals; Integrated Security=true");
        public static SqlCommand cmd = new SqlCommand(" ", con);
        public static SqlDataReader dr;
        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void SE_Connecter_Load(object sender, EventArgs e)
        {

        }
    }
}
