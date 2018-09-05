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


        public void prepare()
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
            Graphics formGraphics = controller.getParentGameWindow().getView().CreateGraphics();
            
            Rectangle windowBounds = controller.getParentGameWindow().getView().Bounds;

            int halfTankSize = iTank.getSize() / 2;

            int tankPosX = iTank.getPosX();
            int amountOfWindowElementsX = (windowBounds.Width / controller.getParentGameWindow().getElementSize()) / 2;
            int elementsFirstXIndex = tankPosX - (amountOfWindowElementsX / 2 - halfTankSize);

            int firstWindowElementX = 0;
            if (iPartOfScreen == EPartOfScreen.RIGHT)
                firstWindowElementX = amountOfWindowElementsX + 1;

            int tankPosY = iTank.getPosY();
            int amountOfWindowElementsY = windowBounds.Height / controller.getParentGameWindow().getElementSize();
            int elementsFirstYIndex = tankPosY - (amountOfWindowElementsY / 2 - halfTankSize);

            CBoardElement[][] boardElements = controller.getElements();

            int boardSize = boardElements.Length;
            int boardElementSize = controller.getParentGameWindow().getElementSize();

            redrawFrameAndBasicMapElements(
                formGraphics,
                iTank,
                boardElementSize,
                boardSize,
                elementsFirstXIndex,
                elementsFirstYIndex,
                firstWindowElementX,
                amountOfWindowElementsX,
                amountOfWindowElementsY);

            redrawTank(
                formGraphics,
                iTank,
                boardElementSize,
                boardSize,
                elementsFirstXIndex,
                elementsFirstYIndex,
                firstWindowElementX,
                amountOfWindowElementsX,
                amountOfWindowElementsY);

            redrawMissiles(
                formGraphics,
                iTank,
                boardElementSize,
                boardSize,
                elementsFirstXIndex,
                elementsFirstYIndex,
                firstWindowElementX,
                amountOfWindowElementsX,
                amountOfWindowElementsY);

            redrawHitPointsBar(
                formGraphics,
                iTank,
                boardElementSize,
                firstWindowElementX,
                amountOfWindowElementsX);

            redrawRightBorder(
                formGraphics,
                boardElementSize,
                firstWindowElementX,
                amountOfWindowElementsX,
                amountOfWindowElementsY);
            
            formGraphics.Dispose();
        }
        private void redrawFrameAndBasicMapElements(
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
                CBoardElement[][] boardElements = controller.getElements();

                int yIndex = iElemenstFirstYIndex - 1;
                for (int currentWindowPartY = iTank.getHitPoints().getBarHeight();
                      currentWindowPartY <= iAmountOfWindowElementsY; currentWindowPartY++)
                {
                    yIndex++;
                    if (CGameBoard.IndicesOutsideWindow(xIndex, yIndex, iBoardSize))
                        solidBrush = new SolidBrush(frameColor);
                    else
                    {
                        if (boardElements[xIndex][yIndex].isTank() ||
                            boardElements[xIndex][yIndex].isMissile())
                            continue;

                        solidBrush = new SolidBrush(boardElements[xIndex][yIndex].getView().getColor());

                        if (boardElements[xIndex][yIndex].isDestroyed())
                            solidBrush = new SolidBrush(destroyedMapColor);

                        if (boardElements[xIndex][yIndex].isBaseWall())
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
        private void redrawTank(
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
            CBoardElement[][] boardElements = controller.getElements();
            SolidBrush solidBrush;

            int xIndex = iElemenstFirstXIndex;
            for (int currentWindowPartX = 0; currentWindowPartX < iAmountOfWindowElementsX; currentWindowPartX++)
            {
                int yIndex = iElemenstFirstYIndex - 1;
                for (int currentWindowPartY = iTank.getHitPoints().getBarHeight();
                      currentWindowPartY <= iAmountOfWindowElementsY; currentWindowPartY++)
                {
                    yIndex++;
                    if (CGameBoard.IndicesOutsideWindow(xIndex, yIndex, iBoardSize))
                        continue;

                    if (boardElements[xIndex][yIndex].isTank())
                    {
                        solidBrush = new SolidBrush(iTank.getView().getTankColor());

                        if (boardElements[xIndex][yIndex].isCanon())
                        {
                            solidBrush = new SolidBrush(iTank.getView().getCanonColor());
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
        private void redrawMissiles(
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
            Color missileColor = iTank.getView().getMissileColor();
            SolidBrush solidBrush = new SolidBrush(missileColor);

            CBoardElement[][] boardElements = controller.getElements();

            int xIndex = iElemenstFirstXIndex;
            for (int currentWindowPartX = 0; currentWindowPartX < iAmountOfWindowElementsX; currentWindowPartX++)
            {
                int yIndex = iElemenstFirstYIndex - 1;
                for (int currentWindowPartY = iTank.getHitPoints().getBarHeight();
                      currentWindowPartY <= iAmountOfWindowElementsY; currentWindowPartY++)
                {
                    yIndex++;
                    if (CGameBoard.IndicesOutsideWindow(xIndex, yIndex, iBoardSize))
                        continue;

                    if (boardElements[xIndex][yIndex].isMissile())
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
        private void redrawHitPointsBar(
            Graphics iFormGraphics,
            CTank iTank,
            int iBoardElementSize,
            int iFirstWindowElementX,
            int iAmountOfWindowElementsX)
        {
            SolidBrush solidBrush;
            double tankHitPointsPercentage = iTank.getHitPoints().getAmountAsPercentage();
            for (int currentWindowPartX = 0; currentWindowPartX < iAmountOfWindowElementsX; currentWindowPartX++)
            {
                double hitPointsBarPart = (double)currentWindowPartX / (double)iAmountOfWindowElementsX;
                bool markHitPointsAsPositive = hitPointsBarPart < tankHitPointsPercentage;

                for (int currentWindowPartY = 0; currentWindowPartY < iTank.getHitPoints().getBarHeight();
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
        private void redrawRightBorder(
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




        public CGameBoard getController()
        {
            return controller;
        }
        public void setController(CGameBoard iController)
        {
            controller = iController;
        }
    }
}
