using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;

namespace notepad
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void открытьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //если поле не пустое
            if (richTextBox1.Text != "")
            {
                //пользователя спрашивают, хочет ли он сохранить файл
                if (MessageBox.Show("Хотите сохранить файл?", "Открытие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //если отвечает "да"
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //если открылся showdialog и было нажато ОК
                        string filePath = saveFileDialog1.FileName; //введенное имя файла сохраняется в отдельную переменную
                        string fileContent = richTextBox1.Text; //контент в поле сохраняется в отдельную переменную

                        File.WriteAllText(filePath, fileContent); //сохранение файла
                    }
                }
            }
            //если успешно открылся showdialog и было нажато ок
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath2 = openFileDialog1.FileName;  //введенное имя файла сохраняется в отдельную переменную
                string fileContent2 = File.ReadAllText(filePath2); //текст в файле сохраняется в переменную

                richTextBox1.Text = fileContent2; //текст из файла отображается в поле
            }

        }

        private void создатьToolStripMenuItem_Click(object sender, EventArgs e)
        {
            //если поле не пустое
            if (richTextBox1.Text != "")
            {
                //пользователя спрашивают, хочет ли он сохранить файл
                if (MessageBox.Show("Хотите сохранить файл?", "Открытие", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    //если отвечает "да"
                    if (saveFileDialog1.ShowDialog() == DialogResult.OK)
                    {
                        //если открылся showdialog и было нажато ОК
                        string filePath1 = saveFileDialog1.FileName; //введенное имя файла сохраняется в отдельную переменную
                        string fileContent1 = richTextBox1.Text; //контент в поле сохраняется в отдельную переменную

                        File.WriteAllText(filePath1, fileContent1); //сохранение файла
                    }
                }
                
            }
            richTextBox1.Text = ""; //очищается поле

        }

        private void сохранитьКакToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog1.FileName;
                string fileContent = richTextBox1.Text;

                File.WriteAllText(filePath, fileContent);
            }
        }

        private void выходToolStripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Вы уверены, что хотите выйти?", "Выход", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
            {
                Close();
            }
        }

        private void оПрограммеToolStripMenuItem_Click(object sender, EventArgs e)
        {
            richTextBox1.Text = "Автор программы: Панченкова Екатерина";
        }
    }
}
