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
    public partial class Form6 : Form
    {
        string id = Form5.id;
        public Form6()
        {
            InitializeComponent();
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader(id+".txt");
            dateTimePicker1.Value = Convert.ToDateTime(file.ReadLine());
            textBox3.Text = file.ReadLine();
            textBox4.Text = file.ReadLine();
            textBox5.Text = file.ReadLine();
            textBox6.Text = file.ReadLine();
            textBox1.Text = file.ReadLine();
            textBox2.Text = file.ReadLine();
            file.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            StreamWriter changed_file = new StreamWriter(id+".txt");
            changed_file.WriteLine(dateTimePicker1.Value.ToString("D"), 0);
            changed_file.Close();
            StreamWriter kvitation_file = new StreamWriter("Квитанции.txt");
            kvitation_file.Dispose()???
        }
    }
}
