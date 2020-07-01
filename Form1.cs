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

namespace Transport_Company
{
    
    public partial class Form1 : Form
    {
        public int[,] Price = new int[20, 20];
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() ==  DialogResult.OK)
            {
                textBox1.Text = openFile.FileName;
                try
                {
                    String[] Mas = File.ReadAllLines(textBox1.Text);
                    string[] TempStrings;

                    for (int i = 0; i < Mas.Length; i++)
                    {
                        TempStrings = Mas[i].Split(';');
                        Price[Convert.ToInt32(TempStrings[0])-1, Convert.ToInt32(TempStrings[1])-1] = Convert.ToInt32(TempStrings[2]);
                    }
                    label2.Text = "Статус: база загружена";
                }
                catch {
                   label2.Text = "Статус: ошибка при чтении файла!";
                }

            } 
        }
    }
}
