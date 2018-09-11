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


        public void Prepare()
        {
            tankColor = Color.FromArgb(50, 50, 50);

            canonColor = Color.FromArgb(80, 10, 10);

            missileColor = Color.FromArgb(255, 0, 144);
        }

        public void Redraw(CBoardElement[][] oElements)
        {
            int boardSize = oElements.Length;

            int xIndex = controller.GetPosX();
            if (xIndex < 0)
                xIndex = 0;

            int yIndex = controller.GetPosY();
            if (yIndex < 0)
                yIndex = 0;
            int beginY = yIndex;

            int tankPosX = controller.GetPosX();
            int tankEndX = tankPosX + controller.GetSize();
            if (tankEndX > boardSize)
                tankEndX = boardSize;

            int tankPosY = controller.GetPosY();
            int tankEndY = tankPosY + controller.GetSize();
            if (tankEndY > boardSize)
                tankEndY = boardSize;

            while (xIndex < tankEndX)
            {
                yIndex = beginY;
                while (yIndex < tankEndY)
                {
                    oElements[xIndex][yIndex].SetDestroyed(true);
                    oElements[xIndex][yIndex].SetTank(true);

                    if (CanonOnPosition(
                          xIndex,
                          yIndex,
                          tankPosX,
                          tankPosY))
                    {
                        oElements[xIndex][yIndex].SetCanon(true);
                    }
                    yIndex++;
                }
                xIndex++;
            }
        }
        private bool CanonOnPosition(
            int iXIndex,
            int iYIndex,
            int iTankPosX,
            int iTankPosY)
        {
            int halfTankSize = controller.GetSize() / 2;

            switch (controller.GetDirection())
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

        public void RedrawMissiles(CBoardElement[][] iElements)
        {
            int boardSize = controller.ParentGameWindow.ChildBoard.GetSize();

            foreach (CMissile cMissile in controller.Missiles)
            {
                if (!CGameBoard.IndicesOutsideWindow(cMissile.GetPosX(), cMissile.GetPosY(), boardSize))
                    iElements[cMissile.GetPosX()][cMissile.GetPosY()].SetMissile(true);
            }
        }




        public CTank Controller { get => controller; set => controller = value; }

        public Color TankColor { get => tankColor; set => tankColor = value; }

        public Color CanonColor { get => canonColor; set => canonColor = value; }

        public Color MissileColor { get => missileColor; set => missileColor = value; }
    }
}
