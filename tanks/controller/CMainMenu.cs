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
        private VMainMenu mView;

        private CGameWindow mChildGameWindow;



        public CMainMenu()
        {
            mChildGameWindow = new CGameWindow();

            mView = new VMainMenu();
            mView.Controller = this;
        }


        public void Execute()
        {
            mView.Display();
        }

        public void OnPlayWithOtherPlayerButtonPushed()
        {
            mChildGameWindow.Start(ETankOwner.Player);
        }

        public void OnPlayWithComputerButtonPushed()
        {
            mChildGameWindow.Start(ETankOwner.Computer);
        }

        public void OnExitButtonPushed()
        {
        }




        public CGameWindow ChildGameWindow { get => mChildGameWindow; set => mChildGameWindow = value; }

        public VMainMenu View { get => mView; set => mView = value; }
    }
}
