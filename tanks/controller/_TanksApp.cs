using System;
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
