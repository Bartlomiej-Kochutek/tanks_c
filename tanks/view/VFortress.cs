﻿
using tanks.common;
using tanks.controller;


namespace tanks.view
{
    class VFortress
    {
        private CFortress mController;



        public VFortress()
        {
        }



        public void Draw(CBoardElement[][] oElements)
        {
            int thisPosX = mController.GetPosX();
            int thisPosY = mController.GetPosY();
            int thisSize = mController.GetSize();

            for (int xIndex = thisPosX; xIndex <= thisPosX + thisSize; xIndex++)
            {
                if (xIndex == thisPosX + 0.25 * thisSize)
                {
                    xIndex = (int)(thisPosX + 0.75 * thisSize);
                }

                int yIndex = thisPosY;
                if (!Algorithm.IndicesOutsideWindow(xIndex, yIndex))
                    oElements[xIndex][yIndex].SetFortressWall(true);

                yIndex = thisPosY + thisSize;
                if (!Algorithm.IndicesOutsideWindow(xIndex, yIndex))
                    oElements[xIndex][yIndex].SetFortressWall(true);
            }
            for (int yIndex = thisPosY; yIndex <= thisPosY + thisSize; yIndex++)
            {
                if (yIndex == thisPosY + 0.25 * thisSize)
                {
                    yIndex = (int)(thisPosY + 0.75 * thisSize);
                }

                int xIndex = thisPosX;
                if (!Algorithm.IndicesOutsideWindow(xIndex, yIndex))
                    oElements[xIndex][yIndex].SetFortressWall(true);

                xIndex = mController.GetPosX() + thisSize;
                if (!Algorithm.IndicesOutsideWindow(xIndex, yIndex))
                    oElements[xIndex][yIndex].SetFortressWall(true);
            }
        }
        


        public CFortress Controller { get => mController; set => mController = value; }
    }
}
