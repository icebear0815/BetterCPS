using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;

namespace BetterCPS
{
    static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
        static void Main()
        {
            /*int mask = 0x01;
            mask <<= 4;
            Console.WriteLine(mask);
            mask = 0x01;
            mask = mask << 4;
            Console.WriteLine(mask);*/
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new CPSManager());
        }
    }
}
