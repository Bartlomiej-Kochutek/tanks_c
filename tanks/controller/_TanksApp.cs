using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tanks
{
    static class _TanksApp
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);

            controller.CMainMenu mainMenu = new controller.CMainMenu();
            mainMenu.execute();
        }
    }
}
