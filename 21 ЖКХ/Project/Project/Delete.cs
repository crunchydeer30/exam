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
    public partial class Delete : Form
    {
        public static SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);
        public Delete()
        {
            InitializeComponent();
        }

        private void Delete_Load(object sender, EventArgs e)
        {
            con.Open();
            SqlCommand cmd = new SqlCommand("SELECT RTRIM(fam) + ' ' + RTRIM(name) as platel FROM [dbo].[Platelshik]", con);
            cmd.CommandType = CommandType.Text;
            SqlDataReader rdr = cmd.ExecuteReader();
            if (rdr.HasRows)
            {
                while (rdr.Read())
                {
                    for (int i = 0; i < rdr.FieldCount; i++)
                    {
                        comboBox1.Items.Add(rdr[i].ToString());
                    }
                }
            }
            rdr.Close();
            SqlCommand cmd2 = new SqlCommand("SELECT rtrim([adres]) FROM [dbo].[Kvartira]", con);
            cmd2.CommandType = CommandType.Text;
            SqlDataReader rdr2 = cmd2.ExecuteReader();
            if (rdr2.HasRows)
            {
                while (rdr2.Read())
                {
                    for (int i = 0; i < rdr2.FieldCount; i++)
                    {
                        comboBox2.Items.Add(rdr2[i].ToString());
                    }
                }
            }
            rdr2.Close();
            con.Close();
        }

        private void vizible_kvitanzia()
        {
            comboBox3.Items.Clear();
            try
            {
                con.Open();
                SqlCommand cmd = new SqlCommand("select rtrim(kvit.id) as id from Kvitanzia kvit inner join Platelshik p on kvit.Platelshik = p.id inner join Kvartira Kvartira on kvit.Kvartira = Kvartira.id where RTRIM(p.fam) + ' ' + RTRIM(p.name) = '" + comboBox1.Text + "' AND RTRIM(Kvartira.adres) = '" + comboBox2.Text + "'", con);
                cmd.CommandType = CommandType.Text;
                SqlDataReader rdr = cmd.ExecuteReader();
                if (rdr.HasRows)
                {
                    while (rdr.Read())
                    {
                        for (int i = 0; i < rdr.FieldCount; i++)
                        {
                            comboBox3.Items.Add(rdr[i].ToString());
                        }
                    }
                }
                rdr.Close();
                con.Close();
            }
            catch
            {
                MessageBox.Show("Квитанции по данному пользователю и квартире нет");
                comboBox1.Text = "";
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            vizible_kvitanzia();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            vizible_kvitanzia();
        }

        private void Delete_kvitanzia_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                string query = "select rtrim(kvit.id) as id from Kvitanzia kvit inner join Platelshik p on kvit.Platelshik = p.id inner join Kvartira Kvartira on kvit.Kvartira = Kvartira.id where RTRIM(p.fam) + ' ' + RTRIM(p.name) = '" + comboBox1.Text + "' AND RTRIM(Kvartira.adres) = '" + comboBox2.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string id_kvit = Convert.ToString(dt.Rows[0][0]);

                con.Open();
                int id = Convert.ToInt32(id_kvit);
                SqlCommand cmd = new SqlCommand("Delete_kvitanzia", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@id", id);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("Квитанция удалена", "Удаление");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка! Нет записей", "Удаление");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Заполните все нужные поля для изменения", "Ошибка");
            }
        }
    }
}
