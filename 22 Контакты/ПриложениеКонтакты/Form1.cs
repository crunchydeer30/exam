using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ПриложениеКонтакты
{
    public partial class Form1 : Form
    {
        public List<Contact> contacts = new List<Contact>();
        public List<String> newContacts = new List<String>();
        string path = "C:/Users/Владислава/Desktop/Учеба/МодульныйЭкзамен/ПриложениеКонтакты/contacts.txt";
        public class Contact
        {
            public string name;
            public string telephone;

            public Contact(string nname, string ntelephone)
            {
                name = nname;
                telephone = ntelephone;
            }
        }

        public Form1()
        {
            InitializeComponent();
        }


        public void addContactBut_Click(object sender, EventArgs e)
        {
            dataGridView1.Rows.Add(name.Text, telephone.Text);
        }

        public void Form1_Load(object sender, EventArgs e)
        {

            StreamReader file = new StreamReader(path);
            List<string> rows = file.ReadLine().Split(' ').ToList();
            file.Close();
            string nme = "";
            string tlphone = "";
            int a = 0;
            foreach (string row in rows)
            {
                if (a % 2 == 0)
                {
                    nme = row;
                } else
                {
                    tlphone = row;
                    contacts.Add(new Contact(nme, tlphone));
                }
                a++;
            }

            dataGridView1.Columns.Add("Column1", "Имя");
            dataGridView1.Columns.Add("Column2", "Телефон");

            foreach (var i in contacts)
            {
                dataGridView1.Rows.Add(i.name, i.telephone);
            }
        }

        public void saveBtnClick(object sender, EventArgs e)
        {
            newContacts.Clear();
            for (int v = 0; v < dataGridView1.Rows.Count - 1; v++)
            {
                newContacts.Add(dataGridView1[0,v].Value.ToString());
                newContacts.Add(dataGridView1[1, v].Value.ToString());
            }
            string writingText = "";
            //
            foreach (string str in newContacts)
            {
                writingText += str + " ";
            }
            //

            // полная перезапись файла 
            using (StreamWriter writer = new StreamWriter(path))
            {
                writer.WriteLine(writingText);
            }
        }
    }
}
