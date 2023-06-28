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
    public partial class Auth : Form
    {
        public static SqlConnection con = new SqlConnection(Properties.Settings.Default.ConString);
        public Auth()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            SqlCommand com = new SqlCommand("SELECT * FROM users WHERE login=@login and password=@password", con);
            con.Open();
            textBox2.UseSystemPasswordChar = true;

            com.Parameters.AddWithValue("@login", textBox1.Text);
            com.Parameters.AddWithValue("@password", textBox2.Text);
            SqlDataReader Dr = com.ExecuteReader();
            if (Dr.HasRows == true)
            {
                Glav main = new Glav();
                main.Show();
                Hide();
            }
            else
            {
                MessageBox.Show("Такого логина или пароля не существует: \n\n1) Проверьте правильность ввода\n\n2) Обратитесь к администартору", "Ошибка авторизации", MessageBoxButtons.OK, MessageBoxIcon.Error);

            }
        }

    }

}