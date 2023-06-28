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
    public partial class Add : Form
    {
        public static SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);
        public Add()
        {
            InitializeComponent();
        }

        private void Add_kvitanzia_Click(object sender, EventArgs e)
        {
            con.Open();
            string fam = textBox1.Text;
            string name = textBox2.Text;

            SqlCommand cmd = new SqlCommand("Insert_Platelshik", con);
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.AddWithValue("@fm", fam);
            cmd.Parameters.AddWithValue("@nm", name);

            if (cmd.ExecuteNonQuery() != 0)
            {
            }
            else
            {
                MessageBox.Show("Ошибка! Нет записей", "Изменение");
            }

            string query = "select rtrim(id) as id from Platelshik where RTRIM(fam) = '" + fam + "' AND RTRIM(name) = '" + name + "'";
            SqlDataAdapter da = new SqlDataAdapter(query, con);
            DataTable dt = new DataTable();
            da.Fill(dt);

            int id_platel = Convert.ToInt32(dt.Rows[0][0]);
            string adr = textBox3.Text;
            float plosh = Convert.ToInt32(textBox4.Text);
            int kol = Convert.ToInt32(textBox5.Text);
            SqlCommand cmd2 = new SqlCommand("Insert_Kvartira", con);
            cmd2.CommandType = CommandType.StoredProcedure;
            cmd2.Parameters.AddWithValue("@plat", id_platel);
            cmd2.Parameters.AddWithValue("@plosh", plosh);
            cmd2.Parameters.AddWithValue("@kolvo", kol);
            cmd2.Parameters.AddWithValue("@adres", adr);

            if (cmd2.ExecuteNonQuery() != 0)
            {
            }
            else
            {
                MessageBox.Show("Ошибка! Нет записей", "Изменение");
            }

            string query2 = "select rtrim(id) as id from Kvartira where RTRIM(adres) = '" + adr + "' AND kolvo_prozhiv = '" + kol + "' AND ploshad = '" + plosh + "'";
            SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
            DataTable dt2 = new DataTable();
            da2.Fill(dt2);
            int id_kvar = Convert.ToInt32(dt2.Rows[0][0]);

            string data_pokaz = Convert.ToString(dateTimePicker1.Text);
            string data_nachis = Convert.ToString(dateTimePicker2.Text);
            string data_srok = Convert.ToString(dateTimePicker3.Text);
            float sum = Convert.ToInt32(textBox6.Text);
            float p = Convert.ToInt32(textBox7.Text);

            SqlCommand cmd3 = new SqlCommand("Insert_Kvitanzia", con);
            cmd3.CommandType = CommandType.StoredProcedure;
            cmd3.Parameters.AddWithValue("@plat", id_platel);
            cmd3.Parameters.AddWithValue("@kvar", id_kvar);
            cmd3.Parameters.Add(new SqlParameter("@data_pred", SqlDbType.Date));
            cmd3.Parameters["@data_pred"].Value = data_pokaz;
            cmd3.Parameters.Add(new SqlParameter("@data_posl", SqlDbType.Date));
            cmd3.Parameters["@data_posl"].Value = data_nachis;
            cmd3.Parameters.Add(new SqlParameter("@srok", SqlDbType.Date));
            cmd3.Parameters["@srok"].Value = data_srok;
            cmd3.Parameters.AddWithValue("@summa", sum);
            cmd3.Parameters.AddWithValue("@peni", p);

            if (cmd3.ExecuteNonQuery() != 0)
            {
                MessageBox.Show("Квитанция добавлена", "Добавление");
                this.Close();
            }
            else
            {
                MessageBox.Show("Ошибка! Нет записей", "Добавдение");
            }
            con.Close();
        }

        private void Add_Load(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
