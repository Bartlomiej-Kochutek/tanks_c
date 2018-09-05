using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using tanks.controller;


namespace tanks.view
{
    public class VTank
    {
        private CTank controller;

        private Color tankColor;
        private Color canonColor;
        private Color missileColor;



        public VTank()
        {
        }


        public void prepare()
        {
            tankColor = Color.FromArgb(50, 50, 50);

            canonColor = Color.FromArgb(80, 10, 10);

            missileColor = Color.FromArgb(255, 0, 144);
        }

        public void redraw(CBoardElement[][] oElements)
        {
            int boardSize = oElements.Length;

            int xIndex = controller.getPosX();
            if (xIndex < 0)
                xIndex = 0;

            int yIndex = controller.getPosY();
            if (yIndex < 0)
                yIndex = 0;
            int beginY = yIndex;

            int tankPosX = controller.getPosX();
            int tankEndX = tankPosX + controller.getSize();
            if (tankEndX > boardSize)
                tankEndX = boardSize;

            int tankPosY = controller.getPosY();
            int tankEndY = tankPosY + controller.getSize();
            if (tankEndY > boardSize)
                tankEndY = boardSize;

            while (xIndex < tankEndX)
            {
                yIndex = beginY;
                while (yIndex < tankEndY)
                {
                    oElements[xIndex][yIndex].setDestroyed(true);
                    oElements[xIndex][yIndex].setTank(true);

                    if (canonOnPosition(
                          xIndex,
                          yIndex,
                          tankPosX,
                          tankPosY))
                    {
                        oElements[xIndex][yIndex].setCanon(true);
                    }
                    yIndex++;
                }
                xIndex++;
            }
        }
        private bool canonOnPosition(
            int iXIndex,
            int iYIndex,
            int iTankPosX,
            int iTankPosY)
        {
            int halfTankSize = controller.getSize() / 2;

            switch (controller.getDirection())
            {
                case EDirection.DOWN:
                    if (iXIndex == iTankPosX + halfTankSize &&
                        iYIndex >= iTankPosY + halfTankSize)
                        return true;
                    break;
                case EDirection.LEFT:
                    if (iXIndex <= iTankPosX + halfTankSize &&
                        iYIndex == iTankPosY + halfTankSize)
                        return true;
                    break;
                case EDirection.RIGHT:
                    if (iXIndex >= iTankPosX + halfTankSize &&
                        iYIndex == iTankPosY + halfTankSize)
                        return true;
                    break;
                case EDirection.UP:
                    if (iXIndex == iTankPosX + halfTankSize &&
                        iYIndex <= iTankPosY + halfTankSize)
                        return true;
                    break;
            }
            return false;
        }

        public void redrawMissiles(CBoardElement[][] iElements)
        {
            foreach (CMissile cMissile in controller.getMissiles())
            {
                iElements[cMissile.getPosX()][cMissile.getPosY()].setMissile(true);
            }
        }




        public CTank getController()
        {
            return controller;
        }
        public void setController(CTank iController)
        {
            controller = iController;
        }

        public Color getTankColor()
        {
            return tankColor;
        }
        public void setTankColor(Color iTankColor)
        {
            tankColor = iTankColor;
        }

        public Color getCanonColor()
        {
            return canonColor;
        }
        public void setCanonColor(Color iCanonColor)
        {
            canonColor = iCanonColor;
        }

        public Color getMissileColor()
        {
            return missileColor;
        }
        public void setMissileColor(Color iMissileColor)
        {
            missileColor = iMissileColor;
        }
    }
}
