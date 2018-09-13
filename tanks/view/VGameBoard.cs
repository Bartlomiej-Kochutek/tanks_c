using System.Drawing;
using tanks.common;
using tanks.controller;


namespace tanks.view
{
    public class VGameBoard
    {
        private CGameBoard mController;

        private Color mDestroyedMapColor;
        private Color mFrameColor;
        private Color mHitPointsPositiveColor;
        private Color mHitPointsNegativeColor;
        private Color mFortressWallColor;



        public VGameBoard()
        {
        }



        public void Prepare()
        {
            mDestroyedMapColor = Color.FromArgb(255, 255, 255);

            mFrameColor = Color.FromArgb(0, 0, 0);

            mHitPointsPositiveColor = Color.FromArgb(0, 255, 0);

            mHitPointsNegativeColor = Color.FromArgb(255, 0, 0);

            mFortressWallColor = Color.FromArgb(255, 255, 0);
        }

        public void Redraw(
            ICTank iTank,
            EPartOfScreen iPartOfScreen)
        {
            Graphics formGraphics = mController.ParentGameWindow.View.CreateGraphics();
            
            Rectangle windowBounds = mController.ParentGameWindow.View.Bounds;

            int halfTankSize = iTank.GetSize() / 2;

            int tankPosX = iTank.GetPosX();
            int amountOfWindowElementsX = (windowBounds.Width / mController.ParentGameWindow.GetElementSize()) / 2;
            int elementsFirstXIndex = tankPosX - (amountOfWindowElementsX / 2 - halfTankSize);

            int firstWindowElementX = 0;
            if (iPartOfScreen == EPartOfScreen.RIGHT)
                firstWindowElementX = amountOfWindowElementsX + 1;

            int tankPosY = iTank.GetPosY();
            int amountOfWindowElementsY = windowBounds.Height / mController.ParentGameWindow.GetElementSize();
            int elementsFirstYIndex = tankPosY - (amountOfWindowElementsY / 2 - halfTankSize);

            CBoardElement[][] boardElements = mController.Elements;
            
            int boardElementSize = mController.ParentGameWindow.GetElementSize();

            RedrawFrameAndBasicMapElements(
                formGraphics,
                iTank,
                boardElementSize,
                elementsFirstXIndex,
                elementsFirstYIndex,
                firstWindowElementX,
                amountOfWindowElementsX,
                amountOfWindowElementsY);

            RedrawTank(
                formGraphics,
                iTank,
                boardElementSize,
                elementsFirstXIndex,
                elementsFirstYIndex,
                firstWindowElementX,
                amountOfWindowElementsX,
                amountOfWindowElementsY);

            RedrawMissiles(
                formGraphics,
                iTank,
                boardElementSize,
                elementsFirstXIndex,
                elementsFirstYIndex,
                firstWindowElementX,
                amountOfWindowElementsX,
                amountOfWindowElementsY);

            RedrawHitPointsBar(
                formGraphics,
                iTank,
                boardElementSize,
                firstWindowElementX,
                amountOfWindowElementsX);

            RedrawRightBorder(
                formGraphics,
                boardElementSize,
                firstWindowElementX,
                amountOfWindowElementsX,
                amountOfWindowElementsY);
            
            formGraphics.Dispose();
        }
        private void RedrawFrameAndBasicMapElements(
            Graphics iFormGraphics,
            ICTank iTank,
            int iBoardElementSize,
            int iElemenstFirstXIndex,
            int iElemenstFirstYIndex,
            int iFirstWindowElementX,
            int iAmountOfWindowElementsX,
            int iAmountOfWindowElementsY)
        {
            SolidBrush solidBrush = new SolidBrush(Color.Red);

            int xIndex = iElemenstFirstXIndex;
            for (int currentWindowPartX = 0; currentWindowPartX < iAmountOfWindowElementsX; currentWindowPartX++)
            {
                CBoardElement[][] boardElements = mController.Elements;

                int yIndex = iElemenstFirstYIndex - 1;
                for (int currentWindowPartY = iTank.HitPoints.GetBarHeight();
                      currentWindowPartY <= iAmountOfWindowElementsY; currentWindowPartY++)
                {
                    yIndex++;
                    if (Algorithm.IndicesOutsideWindow(xIndex, yIndex))
                        solidBrush = new SolidBrush(mFrameColor);
                    else
                    {
                        if (boardElements[xIndex][yIndex].IsTank() ||
                            boardElements[xIndex][yIndex].IsMissile())
                            continue;

                        solidBrush = new SolidBrush(boardElements[xIndex][yIndex].View.Color);

                        if (boardElements[xIndex][yIndex].IsDestroyed())
                            solidBrush = new SolidBrush(mDestroyedMapColor);

                        if (boardElements[xIndex][yIndex].IsFortressWall())
                            solidBrush = new SolidBrush(mFortressWallColor);
                    }
                    iFormGraphics.FillRectangle(
                        solidBrush,
                        new Rectangle(
                            iBoardElementSize * (currentWindowPartX + iFirstWindowElementX),
                            iBoardElementSize * currentWindowPartY,
                            iBoardElementSize,
                            iBoardElementSize));
                }
                xIndex++;
            }
            solidBrush.Dispose();
        }
        private void RedrawTank(
            Graphics iFormGraphics,
            ICTank iTank,
            int iBoardElementSize,
            int iElemenstFirstXIndex,
            int iElemenstFirstYIndex,
            int iFirstWindowElementX,
            int iAmountOfWindowElementsX,
            int iAmountOfWindowElementsY)
        {
            CBoardElement[][] boardElements = mController.Elements;
            SolidBrush solidBrush;

            int xIndex = iElemenstFirstXIndex;
            for (int currentWindowPartX = 0; currentWindowPartX < iAmountOfWindowElementsX; currentWindowPartX++)
            {
                int yIndex = iElemenstFirstYIndex - 1;
                for (int currentWindowPartY = iTank.HitPoints.GetBarHeight();
                      currentWindowPartY <= iAmountOfWindowElementsY; currentWindowPartY++)
                {
                    yIndex++;
                    if (Algorithm.IndicesOutsideWindow(xIndex, yIndex))
                        continue;

                    if (boardElements[xIndex][yIndex].IsTank())
                    {
                        solidBrush = new SolidBrush(iTank.View.TankColor);

                        if (boardElements[xIndex][yIndex].IsCanon())
                        {
                            solidBrush = new SolidBrush(iTank.View.CanonColor);
                        }
                        iFormGraphics.FillRectangle(
                            solidBrush,
                            new Rectangle(
                                iBoardElementSize * (currentWindowPartX + iFirstWindowElementX),
                                iBoardElementSize * currentWindowPartY,
                                iBoardElementSize,
                                iBoardElementSize));
                        solidBrush.Dispose();
                    }
                }
                xIndex++;
            }
        }
        private void RedrawMissiles(
            Graphics iFormGraphics,
            ICTank iTank,
            int iBoardElementSize,
            int iElemenstFirstXIndex,
            int iElemenstFirstYIndex,
            int iFirstWindowElementX,
            int iAmountOfWindowElementsX,
            int iAmountOfWindowElementsY)
        {
            Color missileColor = iTank.View.MissileColor;
            SolidBrush solidBrush = new SolidBrush(missileColor);

            CBoardElement[][] boardElements = mController.Elements;

            int xIndex = iElemenstFirstXIndex;
            for (int currentWindowPartX = 0; currentWindowPartX < iAmountOfWindowElementsX; currentWindowPartX++)
            {
                int yIndex = iElemenstFirstYIndex - 1;
                for (int currentWindowPartY = iTank.HitPoints.GetBarHeight();
                      currentWindowPartY <= iAmountOfWindowElementsY; currentWindowPartY++)
                {
                    yIndex++;
                    if (Algorithm.IndicesOutsideWindow(xIndex, yIndex))
                        continue;

                    if (boardElements[xIndex][yIndex].IsMissile())
                    {
                    iFormGraphics.FillRectangle(
                        solidBrush,
                        new Rectangle(
                            iBoardElementSize * (currentWindowPartX + iFirstWindowElementX),
                            iBoardElementSize * currentWindowPartY,
                            iBoardElementSize,
                            iBoardElementSize));
                    }
                }
                xIndex++;
            }
            solidBrush.Dispose();
        }
        private void RedrawHitPointsBar(
            Graphics iFormGraphics,
            ICTank iTank,
            int iBoardElementSize,
            int iFirstWindowElementX,
            int iAmountOfWindowElementsX)
        {
            SolidBrush solidBrush;
            double tankHitPointsPercentage = iTank.HitPoints.GetAmountAsPercentage();
            for (int currentWindowPartX = 0; currentWindowPartX < iAmountOfWindowElementsX; currentWindowPartX++)
            {
                double hitPointsBarPart = (double)currentWindowPartX / (double)iAmountOfWindowElementsX;
                bool markHitPointsAsPositive = hitPointsBarPart < tankHitPointsPercentage;

                for (int currentWindowPartY = 0; currentWindowPartY < iTank.HitPoints.GetBarHeight();
                      currentWindowPartY++)
                {
                    if (markHitPointsAsPositive)
                        solidBrush = new SolidBrush(mHitPointsPositiveColor);
                    else
                        solidBrush = new SolidBrush(mHitPointsNegativeColor);
                    
                    iFormGraphics.FillRectangle(
                        solidBrush,
                        new Rectangle(
                            iBoardElementSize * (currentWindowPartX + iFirstWindowElementX),
                            iBoardElementSize * currentWindowPartY,
                            iBoardElementSize,
                            iBoardElementSize));
                    solidBrush.Dispose();
                }
            }
        }
        private void RedrawRightBorder(
            Graphics iFormGraphics,
            int iBoardElementSize,
            int iFirstWindowElementX,
            int iAmountOfWindowElementsX,
            int iAmountOfWindowElementsY)
        {
            SolidBrush solidBrush = new SolidBrush(mFrameColor);

            for (int currentWindowPartY = 0; currentWindowPartY <= iAmountOfWindowElementsY; currentWindowPartY++)
            {
                iFormGraphics.FillRectangle(
                    solidBrush,
                    new Rectangle(
                        iBoardElementSize * (iAmountOfWindowElementsX + iFirstWindowElementX),
                        iBoardElementSize * currentWindowPartY,
                        iBoardElementSize,
                        iBoardElementSize));
            }
            solidBrush.Dispose();
        }
        


        public CGameBoard Controller { get => mController; set => mController = value; }
    }
}
