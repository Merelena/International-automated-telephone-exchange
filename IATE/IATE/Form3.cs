using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IATE
{
    public partial class Form3 : Form
    {
        int max_time = 0;
        string max_city;
        public Form3()
        {
            InitializeComponent();
            this.MdiParent = Form1.mainParent;
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            string time;
            DirectoryInfo dir = new DirectoryInfo(@"Города/");
            foreach (var item in dir.GetFiles())
            {
                StreamReader file = new StreamReader("Города/" + item.Name);
                time = file.ReadLine();
                listBox1.Items.Add((item.Name + "-      " + time + "     минут").Replace(".txt", "      "));
                file.Close();
                if (Convert.ToInt32(time) > max_time)
                {
                    max_time = Convert.ToInt32(time);
                    max_city = item.Name;
                }
            }
        }

        private void button1_Click(object sender, EventArgs e)
        {
            int temp, time;
            double tariff, result=0;
            string current_date;
            string date = dateTimePicker1.Value.ToString().Replace("0:00:00", "").Replace(" ", "");
            DirectoryInfo dir = new DirectoryInfo(@"Квитанции/");
            foreach (var item in dir.GetFiles())
            {
               StreamReader file = new StreamReader("Квитанции/" + item.Name);
                current_date = file.ReadLine();
                if (current_date == date)
                {
                    file.ReadLine();
                    file.ReadLine();
                    time = Convert.ToInt32(file.ReadLine());
                    tariff = Convert.ToDouble(file.ReadLine());
                    result += time * tariff;
                }
                file.Close();
            }
            label2.Text = result.ToString() + " бел. руб.";
        }

        private void button2_Click(object sender, EventArgs e)
        {
            label4.Text = max_city.Replace(".txt", "");
        }
    }
}
