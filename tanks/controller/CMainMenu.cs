using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CMainMenu
    {
        private VMainMenu view;

        private CGameWindow childGameWindow;



        public CMainMenu()
        {
            childGameWindow = new CGameWindow();

            view = new VMainMenu();
            view.setController(this);
        }


        public void execute()
        {
            view.display();
        }

        public void onPlayButtonPushed()
        {
            childGameWindow.start();
        }

        public void onExitButtonPushed()
        {
        }




        public CGameWindow GetChildGameWindow()
        {
            return childGameWindow;
        }
        public void SetChildGameWindow(CGameWindow iChildGameWindow)
        {
            childGameWindow = iChildGameWindow;
        }

        public VMainMenu getView()
        {
            return view;
        }
        public void setView(VMainMenu iView)
        {
            view = iView;
        }
    }
}
