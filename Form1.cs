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
        public Deixtra Algo;
        public Node[] Nodes = new Node[20];

        public Form1()
        {
            InitializeComponent();
            for (int i = 0; i < 20; i++)
            {
                Nodes[i] = new Node();
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Nodes[Convert.ToInt32(textBox2.Text) - 1].CurrentValue = 0;
            Algo = new Deixtra(Nodes);
            Algo.Run(Convert.ToInt32(textBox2.Text) - 1);
            label1.Text = "Стоимость: " + Convert.ToString(Algo.nodes[Convert.ToInt32(textBox3.Text) - 1].CurrentValue);
            bool flag = true;
            int temp = Convert.ToInt32(textBox3.Text) - 1;
            List<int> ROAD = new List<int>();
            while (flag)
            {
                if (Algo.nodes[Convert.ToInt32(textBox3.Text) - 1].CurrentValue == 999999)
                {
                    label5.Text = "Маршрут не найден!";
                    return;
                }
                if (ROAD.Count > 0)
                    if (Nodes[temp].PrevNode == ROAD.Last())
                        break;
                ROAD.Add(Nodes[temp].PrevNode);
                if (ROAD.Last() == Convert.ToInt32(textBox2.Text) - 1)
                    flag = false;
                temp = ROAD.Last();
            }
            label5.Text = "Маршрут: ";
            for (int i = 0; i < ROAD.Count; i++)
            {
                label5.Text += Convert.ToString(ROAD[ROAD.Count - i - 1] + 1) + " ";
            }
            label5.Text += Convert.ToInt32(textBox3.Text);

        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            OpenFileDialog openFile = new OpenFileDialog();
            if (openFile.ShowDialog() == DialogResult.OK)
            {
                textBox1.Text = openFile.FileName;
                try
                {
                    String[] Mas = File.ReadAllLines(textBox1.Text);
                    string[] TempStrings;
                    for (int i = 0; i < Mas.Length; i++)
                    {
                        TempStrings = Mas[i].Split(';');
                        Nodes[Convert.ToInt32(TempStrings[0]) - 1].Roads.Add(new int[2] { Convert.ToInt32(TempStrings[1]) - 1, Convert.ToInt32(TempStrings[2]) });
                        Nodes[Convert.ToInt32(TempStrings[1]) - 1].Roads.Add(new int[2] { Convert.ToInt32(TempStrings[0]) - 1, Convert.ToInt32(TempStrings[2]) });
                    }
                    label2.Text = "Статус: база загружена";
                }
                catch
                {
                    label2.Text = "Статус: ошибка при чтении файла!";
                }

            }
        }
    }
}
