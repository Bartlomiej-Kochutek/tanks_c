
using tanks.controller;


namespace tanks.model
{
    public class MGameBoard
    {
        private CGameBoard mController;

        private int mSize;



        public MGameBoard()
        {
            mSize = 300;
        }



        public void ResetElements()
        {
            CBoardElement[][] boardElements = mController.Elements;
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



        public CGameBoard Controller { get => mController; set => mController = value; }

        public int Size { get => mSize; set => mSize = value; }
    }
}
