using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CGameBoard
    {
        private CGameWindow parentGameWindow;

        private MGameBoard model;
        private VGameBoard view;

        private CBoardElement[][] elements;



        public CGameBoard()
        {
            model = new MGameBoard();
            model.Controller = (this);

            view = new VGameBoard();
            view.Controller = (this);
        }


        public void Prepare()
        {
            view.Prepare();

            int thisSize = model.Size;

            Random random = new Random();

            elements = new CBoardElement[thisSize][];
            for (int i = 0; i < thisSize; i++)
            {
                elements[i] = new CBoardElement[thisSize];
                for (int j = 0; j < thisSize; j++)
                {
                    elements[i][j] = new CBoardElement(Color.FromArgb(
                        random.Next(70, 200),
                        random.Next(70, 130),
                        random.Next(30, 50)));
                }
            }
        }

        public void Redraw(
            CTank iTank,
            EPartOfScreen iPartOfScreen)
        {
            view.Redraw(
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




        public CGameWindow ParentGameWindow { get => parentGameWindow; set => parentGameWindow = value; }

        public MGameBoard Model { get => model; set => model = value; }

        public VGameBoard View { get => view; set => view = value; }

        public CBoardElement[][] Elements { get => elements; set => elements = value; }

        public int GetSize()
        {
            return model.Size;
        }
        public void SetSize(int iSize)
        {
            model.Size = iSize;
        }
    }
}
