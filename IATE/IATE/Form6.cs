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
        int old_time;
        public Form6()
        {
            InitializeComponent();
            this.MdiParent = Form1.mainParent;
        }

        private void Form6_Load(object sender, EventArgs e)
        {
            StreamReader file = new StreamReader("Квитанции/" + id + ".txt");
            dateTimePicker1.Value = Convert.ToDateTime(file.ReadLine());
            textBox3.Text = file.ReadLine();
            textBox4.Text = file.ReadLine();
            textBox5.Text = file.ReadLine();
            old_time = Convert.ToInt32(textBox5.Text);
            textBox6.Text = file.ReadLine();
            textBox1.Text = file.ReadLine();
            textBox2.Text = file.ReadLine();
            file.Close();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter("Квитанции/" + id + ".txt");
            file.WriteLine(dateTimePicker1.Value.ToString().Replace("0:00:00", "").Replace(" ", ""));
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
            kvitations = kvitations.Replace(Program.exchange2, Convert.ToString(id) + "     " + dateTimePicker1.Value.ToString("D")+ "    " + textBox3.Text);
            StreamWriter writer = new StreamWriter("Квитанции.txt");
            writer.Write(kvitations);
            writer.Close();
            StreamReader city = new StreamReader("Города/" + textBox3.Text + ".txt");
            int time = Convert.ToInt32(city.ReadLine());
            city.Close();
            StreamWriter city2 = new StreamWriter("Города/" + textBox3.Text + ".txt");
            city2.WriteLine(Convert.ToInt32(time) - old_time + Convert.ToInt32(textBox5.Text));
            city2.Close();
            Close();
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            FileInfo fileInf = new FileInfo("Квитанции/" + id + ".txt");
            fileInf.Delete();
            StreamReader reader = new StreamReader("Квитанции.txt");
            string kvitations = reader.ReadToEnd();
            reader.Close();
            kvitations = kvitations.Replace(Program.exchange2, "Квитанция " + id.ToString() + " удалена");
            StreamWriter writer = new StreamWriter("Квитанции.txt");
            writer.Write(kvitations);
            writer.Close();
            StreamReader city = new StreamReader("Города/" + textBox3.Text + ".txt");
            int time = Convert.ToInt32(city.ReadLine());
            city.Close();
            StreamWriter city2 = new StreamWriter("Города/" + textBox3.Text + ".txt");
            city2.WriteLine(Convert.ToInt32(time) - old_time);
            city2.Close();
            Close();
            Form2 newForm = new Form2();
            newForm.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            StreamWriter file = new StreamWriter("Буфер обмена.txt");
            file.WriteLine(dateTimePicker1.Value.ToString().Replace("0:00:00", "").Replace(" ", ""));
            file.WriteLine(textBox3.Text);
            file.WriteLine(textBox4.Text);
            file.WriteLine(textBox5.Text);
            file.WriteLine(textBox6.Text);
            file.WriteLine(textBox1.Text);
            file.WriteLine(textBox2.Text);
            file.Close();
        }
    }
}
