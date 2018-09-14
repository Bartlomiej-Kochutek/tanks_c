using System.Drawing;
using tanks.common;
using tanks.controller;


namespace tanks.view
{
    public class VTank
    {
        private CTank mController;

        private Color mTankColor;
        private Color mCanonColor;
        private Color mMissileColor;



        public VTank()
        {
        }



        public void Prepare()
        {
            mTankColor = Color.FromArgb(50, 50, 50);

            mCanonColor = Color.FromArgb(80, 10, 10);

            mMissileColor = Color.FromArgb(255, 0, 144);
        }

        public void Redraw(CBoardElement[][] oElements)
        {
            int boardSize = oElements.Length;

            int xIndex = mController.GetPosX();
            if (xIndex < 0)
                xIndex = 0;

            int yIndex = mController.GetPosY();
            if (yIndex < 0)
                yIndex = 0;
            int beginY = yIndex;

            int tankPosX = mController.GetPosX();
            int tankEndX = tankPosX + mController.GetSize();
            if (tankEndX > boardSize)
                tankEndX = boardSize;

            int tankPosY = mController.GetPosY();
            int tankEndY = tankPosY + mController.GetSize();
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
            int halfTankSize = mController.GetSize() / 2;

            switch (mController.GetDirection())
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

        

        public CTank Controller { get => mController; set => mController = value; }

        public Color TankColor { get => mTankColor; set => mTankColor = value; }

        public Color CanonColor { get => mCanonColor; set => mCanonColor = value; }

        public Color MissileColor { get => mMissileColor; set => mMissileColor = value; }
    }
}
