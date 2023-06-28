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

namespace Project
{
    public partial class Glav : Form
    {
        public static SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);
        public Glav()
        {
            InitializeComponent();
        }

        private void Glav_Load(object sender, EventArgs e)
        {
            all_kvitanzia();
        }

        private void all_kvitanzia()
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("select * from Visible_Kvitanzia", con);
            SqlDataAdapter sd = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            sd.Fill(dt);
            KvitanziaGrid.DataSource = dt;
            con.Close();
        }

        private void add_Click(object sender, EventArgs e)
        {
            Add childForm = new Add();
            childForm.Show();
        }

        private void update_Click(object sender, EventArgs e)
        {
            Update childForm = new Update();
            childForm.Show();
        }

        private void delete_Click(object sender, EventArgs e)
        {
            Delete childForm = new Delete();
            childForm.Show();
        }
        private void history_Click(object sender, EventArgs e)
        {
            History childForm = new History();
            childForm.Show();
        }

        private void refresh_Click(object sender, EventArgs e)
        {
            all_kvitanzia();
        }
    }
}
