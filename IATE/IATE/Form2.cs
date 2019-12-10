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

namespace IATE
{
    public partial class Form2 : Form
    {
        public Form2()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form4 newForm = new Form4();
            newForm.Show();
            Close();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader("Квитанции.txt");
            while (!file.EndOfStream)
            {
                listBox1.Items.Add(file.ReadLine());
            }
            file.Close();
        }

        private void listBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
            string expression = "";
            for (int i = 0; i < 6; i++)
            {
                expression += listBox1.SelectedItem.ToString()[i];
            }
            Program.exchange = Convert.ToInt32(expression).ToString();
            Program.exchange2 = listBox1.SelectedItem.ToString();
            string id = expression;
            Form6 newForm = new Form6();
            newForm.Text = id;
            newForm.Show();
            Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }
    }
}
