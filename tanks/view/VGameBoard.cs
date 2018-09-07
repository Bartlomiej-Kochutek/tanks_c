using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using tanks.controller;


namespace tanks.view
{
    public class VGameBoard
    {
        private CGameBoard controller;

        private Color destroyedMapColor;
        private Color frameColor;
        private Color hitPointsPositiveColor;
        private Color hitPointsNegativeColor;
        private Color baseWallColor;



        public VGameBoard()
        {
        }


        public void Prepare()
        {
            destroyedMapColor = Color.FromArgb(255, 255, 255);

            frameColor = Color.FromArgb(0, 0, 0);

            hitPointsPositiveColor = Color.FromArgb(0, 255, 0);

            hitPointsNegativeColor = Color.FromArgb(255, 0, 0);

            baseWallColor = Color.FromArgb(255, 255, 0);
        }

        public void Redraw(
            CTank iTank,
            EPartOfScreen iPartOfScreen)
        {
            Graphics formGraphics = controller.ParentGameWindow.View.CreateGraphics();
            
            Rectangle windowBounds = controller.ParentGameWindow.View.Bounds;

            int halfTankSize = iTank.GetSize() / 2;

            int tankPosX = iTank.GetPosX();
            int amountOfWindowElementsX = (windowBounds.Width / controller.ParentGameWindow.GetElementSize()) / 2;
            int elementsFirstXIndex = tankPosX - (amountOfWindowElementsX / 2 - halfTankSize);

            int firstWindowElementX = 0;
            if (iPartOfScreen == EPartOfScreen.RIGHT)
                firstWindowElementX = amountOfWindowElementsX + 1;

            int tankPosY = iTank.GetPosY();
            int amountOfWindowElementsY = windowBounds.Height / controller.ParentGameWindow.GetElementSize();
            int elementsFirstYIndex = tankPosY - (amountOfWindowElementsY / 2 - halfTankSize);

            CBoardElement[][] boardElements = controller.Elements;

            int boardSize = boardElements.Length;
            int boardElementSize = controller.ParentGameWindow.GetElementSize();

            RedrawFrameAndBasicMapElements(
                formGraphics,
                iTank,
                boardElementSize,
                boardSize,
                elementsFirstXIndex,
                elementsFirstYIndex,
                firstWindowElementX,
                amountOfWindowElementsX,
                amountOfWindowElementsY);

            RedrawTank(
                formGraphics,
                iTank,
                boardElementSize,
                boardSize,
                elementsFirstXIndex,
                elementsFirstYIndex,
                firstWindowElementX,
                amountOfWindowElementsX,
                amountOfWindowElementsY);

            RedrawMissiles(
                formGraphics,
                iTank,
                boardElementSize,
                boardSize,
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
            CTank iTank,
            int iBoardElementSize,
            int iBoardSize,
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
                CBoardElement[][] boardElements = controller.Elements;

                int yIndex = iElemenstFirstYIndex - 1;
                for (int currentWindowPartY = iTank.HitPoints.GetBarHeight();
                      currentWindowPartY <= iAmountOfWindowElementsY; currentWindowPartY++)
                {
                    yIndex++;
                    if (CGameBoard.IndicesOutsideWindow(xIndex, yIndex, iBoardSize))
                        solidBrush = new SolidBrush(frameColor);
                    else
                    {
                        if (boardElements[xIndex][yIndex].IsTank() ||
                            boardElements[xIndex][yIndex].IsMissile())
                            continue;

                        solidBrush = new SolidBrush(boardElements[xIndex][yIndex].View.Color);

                        if (boardElements[xIndex][yIndex].IsDestroyed())
                            solidBrush = new SolidBrush(destroyedMapColor);

                        if (boardElements[xIndex][yIndex].IsBaseWall())
                            solidBrush = new SolidBrush(baseWallColor);
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
            CTank iTank,
            int iBoardElementSize,
            int iBoardSize,
            int iElemenstFirstXIndex,
            int iElemenstFirstYIndex,
            int iFirstWindowElementX,
            int iAmountOfWindowElementsX,
            int iAmountOfWindowElementsY)
        {
            CBoardElement[][] boardElements = controller.Elements;
            SolidBrush solidBrush;

            int xIndex = iElemenstFirstXIndex;
            for (int currentWindowPartX = 0; currentWindowPartX < iAmountOfWindowElementsX; currentWindowPartX++)
            {
                int yIndex = iElemenstFirstYIndex - 1;
                for (int currentWindowPartY = iTank.HitPoints.GetBarHeight();
                      currentWindowPartY <= iAmountOfWindowElementsY; currentWindowPartY++)
                {
                    yIndex++;
                    if (CGameBoard.IndicesOutsideWindow(xIndex, yIndex, iBoardSize))
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
            CTank iTank,
            int iBoardElementSize,
            int iBoardSize,
            int iElemenstFirstXIndex,
            int iElemenstFirstYIndex,
            int iFirstWindowElementX,
            int iAmountOfWindowElementsX,
            int iAmountOfWindowElementsY)
        {
            Color missileColor = iTank.View.MissileColor;
            SolidBrush solidBrush = new SolidBrush(missileColor);

            CBoardElement[][] boardElements = controller.Elements;

            int xIndex = iElemenstFirstXIndex;
            for (int currentWindowPartX = 0; currentWindowPartX < iAmountOfWindowElementsX; currentWindowPartX++)
            {
                int yIndex = iElemenstFirstYIndex - 1;
                for (int currentWindowPartY = iTank.HitPoints.GetBarHeight();
                      currentWindowPartY <= iAmountOfWindowElementsY; currentWindowPartY++)
                {
                    yIndex++;
                    if (CGameBoard.IndicesOutsideWindow(xIndex, yIndex, iBoardSize))
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
            CTank iTank,
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
                        solidBrush = new SolidBrush(hitPointsPositiveColor);
                    else
                        solidBrush = new SolidBrush(hitPointsNegativeColor);
                    
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
            SolidBrush solidBrush = new SolidBrush(frameColor);

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




        public CGameBoard Controller { get => controller; set => controller = value; }
    }
}
