using System;
using System.Drawing;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CGameBoard
    {
        private CGameWindow mParentGameWindow;

        private MGameBoard mModel;
        private VGameBoard mView;

        private CBoardElement[][] mElements;



        public CGameBoard()
        {
            mModel = new MGameBoard();
            mModel.Controller = this;

            mView = new VGameBoard();
            mView.Controller = this;
        }



        public void Prepare()
        {
            mView.Prepare();

            int thisSize = mModel.Size;

            Random random = new Random();

            mElements = new CBoardElement[thisSize][];
            for (int i = 0; i < thisSize; i++)
            {
                mElements[i] = new CBoardElement[thisSize];
                for (int j = 0; j < thisSize; j++)
                {
                    mElements[i][j] = new CBoardElement(Color.FromArgb(
                        random.Next(70, 200),
                        random.Next(70, 130),
                        random.Next(30, 50)));
                }
            }
        }

        public void Redraw(
            ICTank iTank,
            EPartOfScreen iPartOfScreen)
        {
            mView.Redraw(
                iTank,
                iPartOfScreen);
        }

        public static bool IndicesOutsideWindow(
            int iXIndex,
            int iYIndex,
            int iBoardSize)
        {
            return (iXIndex < 0 || iXIndex >= iBoardSize ||
                    iYIndex < 0 || iYIndex >= iBoardSize);
        }




        public CGameWindow ParentGameWindow { get => mParentGameWindow; set => mParentGameWindow = value; }

        public MGameBoard Model { get => mModel; set => mModel = value; }

        public VGameBoard View { get => mView; set => mView = value; }

        public CBoardElement[][] Elements { get => mElements; set => mElements = value; }

        public int GetSize()
        {
            return mModel.Size;
        }
        public void SetSize(int iSize)
        {
            mModel.Size = iSize;
        }
    }
}
