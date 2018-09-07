using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;
using tanks.controller;

namespace tanks
{
    static class _TanksApp
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            CMainMenu mainMenu = new CMainMenu();
            mainMenu.Execute();
        }
    }
}
