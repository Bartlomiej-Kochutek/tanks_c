using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.controller;


namespace tanks.model
{
    public class MGameBoard
    {
        private CGameBoard controller;

        private int size;



        public MGameBoard()
        {
            size = 70;
        }


        public void ResetElements()
        {
            CBoardElement[][] boardElements = controller.Elements;
            int boardSize = boardElements.Length;
            for (int i = 0; i < boardSize; i++)
            {
                for (int j = 0; j < boardSize; j++)
                {
                    boardElements[i][j].SetTank(false);
                    boardElements[i][j].SetCanon(false);
                    boardElements[i][j].SetMissile(false);
                }
            }
        }




        public CGameBoard Controller { get => controller; set => controller = value; }

        public int Size { get => size; set => size = value; }
    }
}
