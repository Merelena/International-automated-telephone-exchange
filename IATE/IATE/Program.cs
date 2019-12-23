using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Runtime.Serialization.Formatters.Binary;
using System.Runtime.Serialization;

namespace IATE
{
    static class Program
    {
        internal static int id;
        internal static Identificator iden = new Identificator();
        internal static string exchange = null;
        internal static string exchange2 = null;
        public static BinaryFormatter formatter = new BinaryFormatter();
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            if (System.IO.File.Exists("Identificator.dat"))
            {
                using (FileStream fs = new FileStream("Identificator.dat", FileMode.OpenOrCreate))
                {
                    Identificator deserilizeiden = (Identificator)formatter.Deserialize(fs);
                    iden = deserilizeiden;
                }
            }
            else
            {
                using (FileStream fs = new FileStream("Identificator.dat", FileMode.OpenOrCreate))
                {
                    Program.formatter.Serialize(fs, Program.iden.id);
                }
            }
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }

    }
}
