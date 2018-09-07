using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.controller;


namespace tanks.view
{
    class VBase
    {
        private CBase controller;



        public VBase()
        {
        }


        public void Draw(CBoardElement[][] oElements)
        {
            int thisPosX = controller.GetPosX();
            int thisPosY = controller.GetPosY();
            int thisSize = controller.GetSize();

            for (int xIndex = thisPosX; xIndex <= thisPosX + thisSize; xIndex++)
            {
                if (xIndex == thisPosX + 0.25 * thisSize)
                {
                    xIndex = (int)(thisPosX + 0.75 * thisSize);
                }

                int yIndex = thisPosY;
                if (!CGameBoard.IndicesOutsideWindow(xIndex, yIndex, oElements.Length))
                    oElements[xIndex][yIndex].SetBaseWall(true);

                yIndex = thisPosY + thisSize;
                if (!CGameBoard.IndicesOutsideWindow(xIndex, yIndex, oElements.Length))
                    oElements[xIndex][yIndex].SetBaseWall(true);
            }
            for (int yIndex = thisPosY; yIndex <= thisPosY + thisSize; yIndex++)
            {
                if (yIndex == thisPosY + 0.25 * thisSize)
                {
                    yIndex = (int)(thisPosY + 0.75 * thisSize);
                }

                int xIndex = thisPosX;
                if (!CGameBoard.IndicesOutsideWindow(xIndex, yIndex, oElements.Length))
                    oElements[xIndex][yIndex].SetBaseWall(true);

                xIndex = controller.GetPosX() + thisSize;
                if (!CGameBoard.IndicesOutsideWindow(xIndex, yIndex, oElements.Length))
                    oElements[xIndex][yIndex].SetBaseWall(true);
            }
        }




        public CBase Controller { get => controller; set => controller = value; }
    }
}
