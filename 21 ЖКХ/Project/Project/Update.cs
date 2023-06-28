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
    public partial class Update : Form
    {
        public static SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);
        public Update()
        {
            InitializeComponent();
        }

        private void Update_Load(object sender, EventArgs e)
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

        private void Zapolnenie()
        {
            try
            {
                string query1 = "select rtrim(kvit.id) as id from Kvitanzia kvit inner join Platelshik p on kvit.Platelshik = p.id inner join Kvartira Kvartira on kvit.Kvartira = Kvartira.id where RTRIM(p.fam) + ' ' + RTRIM(p.name) = '" + comboBox1.Text + "' AND RTRIM(Kvartira.adres) = '" + comboBox2.Text + "'";
                SqlDataAdapter da1 = new SqlDataAdapter(query1, con);
                DataTable dt1 = new DataTable();
                da1.Fill(dt1);
                string id_kvit = Convert.ToString(dt1.Rows[0][0]);

                if (comboBox1.Text != "" && comboBox2.Text != "")
                {

                    string query2 = "select data_pred from Kvitanzia where id ='" + id_kvit + "'";
                    SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                    DataTable dt2 = new DataTable();
                    da2.Fill(dt2);
                    string data_pred = Convert.ToString(dt2.Rows[0][0]);

                    string query3 = "select data_posl from Kvitanzia where id ='" + id_kvit + "'";
                    SqlDataAdapter da3 = new SqlDataAdapter(query3, con);
                    DataTable dt3 = new DataTable();
                    da3.Fill(dt3);
                    string data_posl = Convert.ToString(dt3.Rows[0][0]);

                    string query4 = "select srok from Kvitanzia where id ='" + id_kvit + "'";
                    SqlDataAdapter da4 = new SqlDataAdapter(query4, con);
                    DataTable dt4 = new DataTable();
                    da4.Fill(dt4);
                    string srok = Convert.ToString(dt4.Rows[0][0]);

                    string query5 = "select summa from Kvitanzia where id ='" + id_kvit + "'";
                    SqlDataAdapter da5 = new SqlDataAdapter(query5, con);
                    DataTable dt5 = new DataTable();
                    da5.Fill(dt5);
                    string summa = Convert.ToString(dt5.Rows[0][0]);

                    string query6 = "select peni from Kvitanzia where id ='" + id_kvit + "'";
                    SqlDataAdapter da6 = new SqlDataAdapter(query6, con);
                    DataTable dt6 = new DataTable();
                    da6.Fill(dt6);
                    string peni = Convert.ToString(dt6.Rows[0][0]);

                    try
                    {
                        dateTimePicker1.Text = data_pred;
                        dateTimePicker2.Text = data_posl;
                        dateTimePicker3.Text = srok;
                        textBox1.Text = summa;
                        textBox2.Text = peni;
                    }
                    catch
                    {
                        dateTimePicker1.Text = data_pred;
                        dateTimePicker2.Text = data_posl;
                        dateTimePicker3.Text = srok;
                        textBox1.Text = summa;
                        textBox2.Text = peni;
                        MessageBox.Show("Данные не отобразились");
                    }
                }
            }
            catch
            {
                MessageBox.Show("Квитанции по данному пользователю и квартире нет");
                DateTime curDate = DateTime.Now;
                dateTimePicker1.Text = Convert.ToString(curDate);
                dateTimePicker2.Text = Convert.ToString(curDate);
                dateTimePicker3.Text = Convert.ToString(curDate);
                textBox1.Text = "0";
                textBox2.Text = "0";
            }
        }
        private void Update_kvitanzia_Click(object sender, EventArgs e)
        {
            if (comboBox1.Text != "" && comboBox2.Text != "")
            {
                string query = "select rtrim(id) as id from Platelshik where RTRIM(fam) + ' ' + RTRIM(name) = '" + comboBox1.Text + "'";
                SqlDataAdapter da = new SqlDataAdapter(query, con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                string id_platel = Convert.ToString(dt.Rows[0][0]);

                string query2 = "select rtrim(id) as id from Kvartira where RTRIM(adres) = '" + comboBox2.Text + "'";
                SqlDataAdapter da2 = new SqlDataAdapter(query2, con);
                DataTable dt2 = new DataTable();
                da.Fill(dt2);
                string id_kvar = Convert.ToString(dt2.Rows[0][0]);

                con.Open();
                string plat = id_platel;
                string kvar = id_kvar;
                string data_pokaz = Convert.ToString(dateTimePicker1.Text);
                string data_nachis = Convert.ToString(dateTimePicker2.Text);
                string data_srok = Convert.ToString(dateTimePicker3.Text);
                float sum = Convert.ToInt32(textBox1.Text);
                float p = Convert.ToInt32(textBox2.Text);

                SqlCommand cmd = new SqlCommand("Update_kvitanzia", con);
                cmd.CommandType = CommandType.StoredProcedure;
                cmd.Parameters.AddWithValue("@p", plat);
                cmd.Parameters.AddWithValue("@kv", kvar);
                cmd.Parameters.Add(new SqlParameter("@pred_pokaz", SqlDbType.Date));
                cmd.Parameters["@pred_pokaz"].Value = data_pokaz;
                cmd.Parameters.Add(new SqlParameter("@posl_nachisl", SqlDbType.Date));
                cmd.Parameters["@posl_nachisl"].Value = data_nachis;
                cmd.Parameters.Add(new SqlParameter("@sr", SqlDbType.Date));
                cmd.Parameters["@sr"].Value = data_srok;
                cmd.Parameters.AddWithValue("@s", sum);
                cmd.Parameters.AddWithValue("@pen", p);
                if (cmd.ExecuteNonQuery() != 0)
                {
                    MessageBox.Show("Квитанция изменена", "Изменение");
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Ошибка! Нет записей", "Изменение");
                }
                con.Close();
            }
            else
            {
                MessageBox.Show("Заполните все нужные поля для изменения", "Ошибка");
            }
        }

        private void comboBox2_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zapolnenie();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            Zapolnenie();
        }

        private void groupBox2_Enter(object sender, EventArgs e)
        {

        }

        private void groupBox1_Enter(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker3_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker2_ValueChanged(object sender, EventArgs e)
        {

        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {

        }

        private void label7_Click(object sender, EventArgs e)
        {

        }

        private void label6_Click(object sender, EventArgs e)
        {

        }

        private void label5_Click(object sender, EventArgs e)
        {

        }

        private void label4_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {

        }
    }
}
