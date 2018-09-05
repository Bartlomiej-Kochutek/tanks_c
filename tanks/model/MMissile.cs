using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.controller;


namespace tanks.model
{
    class MMissile
    {
        private CMissile controller;

        private float posX;
        private float posY;

        private EDirection direction;

        private const int DEFAULT_DAMAGE = 40;
        private int damage;



        public MMissile()
        {
            damage = DEFAULT_DAMAGE;
        }


        public void move(float iDeltaPos)
        {
            switch (direction)
            {
                case EDirection.DOWN:
                    posY += iDeltaPos;
                    break;
                case EDirection.LEFT:
                    posX -= iDeltaPos;
                    break;
                case EDirection.RIGHT:
                    posX += iDeltaPos;
                    break;
                case EDirection.UP:
                    posY -= iDeltaPos;
                    break;
            }
        }

        public bool collision()
        {
            CTank parentTank = controller.getParentTank();

            int boardSize = parentTank.getParentGameWindow().getChildBoard().getSize();

            if (CGameBoard.IndicesOutsideWindow((int)posX, (int)posY, boardSize))
                return true;

            CBoardElement[][] boardElements = parentTank.getParentGameWindow().getChildBoard().getElements();

            int intPosX = (int)posX;
            int intPosY = (int)posY;

            if (collisionWithBoardElements(
                  boardElements,
                  intPosX,
                  intPosY,
                  boardSize))
                return true;

            if (collisionWithOtherTanks(
                  intPosX,
                  intPosY))
                return true;

            return false;
        }

        private bool collisionWithBoardElements(
            CBoardElement[][] oBoardElements,
            int iPosXInt,
            int iPosYInt,
            int iBoardSize)
        { //keep functions sequence order
            if (oBoardElements[iPosXInt][iPosYInt].isBaseWall())
                return true;

            if (oBoardElements[iPosXInt][iPosYInt].isDestroyed())
                return false;

            oBoardElements[iPosXInt][iPosYInt].setDestroyed(true);
            if (direction == EDirection.UP || direction == EDirection.DOWN)
            {
                int neighbourIndex = iPosXInt - 1;
                if (neighbourIndex >= 0)
                    oBoardElements[neighbourIndex][iPosYInt].setDestroyed(true);

                neighbourIndex = iPosXInt + 1;
                if (neighbourIndex < iBoardSize)
                    oBoardElements[neighbourIndex][iPosYInt].setDestroyed(true);
            }
            else
            {
                int neighbourIndex = iPosYInt - 1;
                if (neighbourIndex >= 0)
                    oBoardElements[iPosXInt][neighbourIndex].setDestroyed(true);

                neighbourIndex = iPosYInt + 1;
                if (neighbourIndex < iBoardSize)
                    oBoardElements[iPosXInt][neighbourIndex].setDestroyed(true);
            }
            return true;
        }

        private bool collisionWithOtherTanks(
            int iPosXInt,
            int iPosYInt)
        {
            CTank parentTank = controller.getParentTank();

            LinkedList<CTank> tanks = parentTank.getParentGameWindow().getChildTanks();
            foreach (CTank tank in tanks)
            {
                if (tank == parentTank)
                    continue;

                if (tank.getPosX() > iPosXInt || tank.getPosX() + tank.getSize() <= iPosXInt ||
                    tank.getPosY() > iPosYInt || tank.getPosY() + tank.getSize() <= iPosYInt)
                    continue;

                tank.getHitPoints().takeDamagedFromMissile(damage);

                return true;
            }
            return false;
        }




        public CMissile getController()
        {
            return controller;
        }
        public void setController(CMissile iController)
        {
            controller = iController;
        }

        public int getPosX()
        {
            return (int)posX;
        }
        public void setPosX(int iPosX)
        {
            posX = iPosX;
        }

        public int getPosY()
        {
            return (int)posY;
        }
        public void setPosY(int iPosY)
        {
            posY = iPosY;
        }

        public EDirection getDirection()
        {
            return direction;
        }
        public void setDirection(EDirection iDirection)
        {
            direction = iDirection;
        }

        public int getDamage()
        {
            return damage;
        }
        public void setDamage(int iDamage)
        {
            damage = iDamage;
            if (damage <= 0)
                damage = DEFAULT_DAMAGE;
        }
    }
}
