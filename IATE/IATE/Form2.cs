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

        private void button2_Click(object sender, EventArgs e)
        {
            Form5 newForm = new Form5();
            newForm.Show();
        }

        private void Form2_Load(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader("Квитанции.txt");
            while (! file.EndOfStream)
            {
                listBox1.Items.Add(file.ReadLine());
            }
            file.Close();
        }
    }
}
