using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IATE
{
    public partial class Form5 : Form
    {
        internal static string id;

        public Form5()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            id = textBox1.Text;
            Form6 newForm = new Form6();
            newForm.Text = id;
            newForm.Show();
            Close();
        }
    }
}
