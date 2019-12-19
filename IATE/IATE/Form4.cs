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
            this.MdiParent = Form1.mainParent;
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
            string address = "Квитанции/" + Convert.ToString(Program.id) + ".txt";
            StreamWriter file = new StreamWriter(address);
            file.WriteLine(date.ToString().Replace("0:00:00", "").Replace(" ", ""));
            file.WriteLine(city);
            file.WriteLine(code);
            file.WriteLine(time);
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
            int old_time;
            if (System.IO.File.Exists("Города/" + city + ".txt"))
            {
                StreamReader reader = new StreamReader("Города/" + city + ".txt");
                old_time = Convert.ToInt32(reader.ReadLine());
                reader.Close();
                StreamWriter writer = new StreamWriter("Города/" + city + ".txt");
                writer.WriteLine(time+old_time);
                writer.Close();
            }
            else
            {
                System.IO.File.WriteAllText("Города/" + city + ".txt", time.ToString());
            }
        }

    }
}
