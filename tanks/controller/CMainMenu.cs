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
            view.Controller = this;
        }


        public void Execute()
        {
            view.Display();
        }

        public void OnPlayWithOtherPlayerButtonPushed()
        {
            childGameWindow.Start(ETankOwner.Player);
        }

        public void OnPlayWithComputerButtonPushed()
        {
            childGameWindow.Start(ETankOwner.Computer);
        }

        public void OnExitButtonPushed()
        {
        }




        public CGameWindow ChildGameWindow { get => childGameWindow; set => childGameWindow = value; }

        public VMainMenu View { get => view; set => view = value; }
    }
}
