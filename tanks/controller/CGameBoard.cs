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
            model.setController(this);

            view = new VGameBoard();
            view.setController(this);
        }


        public void Prepare()
        {
            view.prepare();

            int thisSize = model.getSize();

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

        public void redraw(
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




        public controller.CGameWindow getParentGameWindow()
        {
            return parentGameWindow;
        }
        public void setParentGameWindow(CGameWindow iParent)
        {
            parentGameWindow = iParent;
        }

        public MGameBoard getModel()
        {
            return model;
        }
        public void setModel(MGameBoard iModel)
        {
            model = iModel;
        }

        public void setView(VGameBoard iView)
        {
            view = iView;
        }
        public VGameBoard getView()
        {
            return view;
        }

        public CBoardElement[][] getElements()
        {
            return elements;
        }
        public void setElements(CBoardElement[][] iElements)
        {
            elements = iElements;
        }


        public int getSize()
        {
            return model.getSize();
        }
        public void setSize(int iSize)
        {
            model.setSize(iSize);
        }
    }
}
