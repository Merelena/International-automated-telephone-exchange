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
        string id = Program.exchange;
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

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter(id + ".txt");
            file.WriteLine(dateTimePicker1.Value.ToString("D"));
            file.WriteLine(textBox3.Text);
            file.WriteLine(textBox4.Text);
            file.WriteLine(textBox5.Text);
            file.WriteLine(textBox6.Text);
            file.WriteLine(textBox1.Text);
            file.WriteLine(textBox2.Text);
            file.Close();
            StreamReader reader = new StreamReader("Квитанции.txt");
            string kvitations = reader.ReadToEnd();
            reader.Close();
            kvitations = kvitations.Replace(Program.exchange2, Convert.ToString(Program.id) + "     " + dateTimePicker1.Value.ToString("D") + "    " + textBox3.Text);
            StreamWriter writer = new StreamWriter("Квитанции.txt");
            writer.Write(kvitations);
            writer.Close();
            Close();
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo fileInf = new FileInfo(id + ".txt");
            fileInf.Delete();
            StreamReader reader = new StreamReader("Квитанции.txt");
            string kvitations = reader.ReadToEnd();
            reader.Close();
            kvitations = kvitations.Replace(Program.exchange2, null);
            StreamWriter writer = new StreamWriter("Квитанции.txt");
            writer.Write(kvitations);
            writer.Close();
            Close();
            Form2 newForm = new Form2();
            newForm.Show();
        }
    }
}
