using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace IATE
{
    static class Program
    {
        internal static int id;

        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            StreamReader iden = new StreamReader("Identificator.txt");
            id = Convert.ToInt32(iden.ReadLine());
            iden.Close();
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }        
    }
}
