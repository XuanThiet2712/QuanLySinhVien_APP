using QLSV.Data;
using QLSV.Forms.Finance;
using QLSV.Forms.HeThong;
using QLSV.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace QLSV
{
    internal static class Program
    {
        /// <summary>
        /// The main entry point for the application.
        /// </summary>
        [STAThread]
 
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            while (true)
            {

                using (var login = new frmLogin())
                {
                    if (login.ShowDialog() != DialogResult.OK) return;
                }

                var main = new frmMain();
                Application.Run(main);

                if (!main.DangXuat) return;
            }



        }
    }
}
