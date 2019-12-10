using System;
using System.IO;
using System.Windows.Forms;

namespace IATE
{
    public partial class Form4 : Form
    {
        DateTime date;
        string city;
        string code;
        int time;
        float tariff;
        string caller;
        string subscriber;
        public Form4()
        {
            InitializeComponent();
        }

        private void textBox3_TextChanged(object sender, EventArgs e)
        {
            city = textBox3.Text;
        }

        private void dateTimePicker1_ValueChanged(object sender, EventArgs e)
        {
            date = dateTimePicker1.Value;
        }

        private void textBox4_TextChanged(object sender, EventArgs e)
        {
            code = textBox4.Text;
        }

        private void textBox5_TextChanged(object sender, EventArgs e)
        {
            time = Convert.ToInt32(textBox5.Text);
        }

        private void textBox6_TextChanged(object sender, EventArgs e)
        {
            tariff = Convert.ToSingle(textBox6.Text);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            caller = textBox1.Text;
        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {
            subscriber = textBox2.Text;
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Program.id += 1;
            string address = Convert.ToString(Program.id) + ".txt";
            StreamWriter file = new StreamWriter(address);
            file.WriteLine(date);
            file.WriteLine(city);
            file.WriteLine(code);
            file.WriteLine(tariff);
            file.WriteLine(caller);
            file.WriteLine(subscriber);
            file.Close();
            StreamWriter iden = new StreamWriter("Identificator.txt");
            iden.Write(Program.id);
            iden.Close();
            Program.exchange = Convert.ToString(Program.id) + "     " + date.ToString("D") +"    " + city;
            StreamWriter file2 = new StreamWriter("Квитанции.txt", true);
            file2.WriteLine(Program.exchange);
            file2.Close();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Close();
            Form2 newForm = new Form2();
            newForm.Show();
        }
    }
}
