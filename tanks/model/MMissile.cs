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


        public void Move(float iDeltaPos)
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

        public bool Collision()
        {
            CTank parentTank = controller.ParentTank;

            int boardSize = parentTank.ParentGameWindow.ChildBoard.GetSize();

            if (CGameBoard.IndicesOutsideWindow((int)posX, (int)posY, boardSize))
                return true;

            CBoardElement[][] boardElements = parentTank.ParentGameWindow.ChildBoard.Elements;

            int intPosX = (int)posX;
            int intPosY = (int)posY;

            if (CollisionWithBoardElements(
                  boardElements,
                  intPosX,
                  intPosY,
                  boardSize))
                return true;

            if (CollisionWithOtherTanks(
                  intPosX,
                  intPosY))
                return true;

            return false;
        }

        private bool CollisionWithBoardElements(
            CBoardElement[][] oBoardElements,
            int iPosXInt,
            int iPosYInt,
            int iBoardSize)
        { //keep functions sequence order
            if (oBoardElements[iPosXInt][iPosYInt].IsBaseWall())
                return true;

            if (oBoardElements[iPosXInt][iPosYInt].IsDestroyed())
                return false;

            oBoardElements[iPosXInt][iPosYInt].SetDestroyed(true);
            if (direction == EDirection.UP || direction == EDirection.DOWN)
            {
                int neighbourIndex = iPosXInt - 1;
                if (neighbourIndex >= 0)
                    oBoardElements[neighbourIndex][iPosYInt].SetDestroyed(true);

                neighbourIndex = iPosXInt + 1;
                if (neighbourIndex < iBoardSize)
                    oBoardElements[neighbourIndex][iPosYInt].SetDestroyed(true);
            }
            else
            {
                int neighbourIndex = iPosYInt - 1;
                if (neighbourIndex >= 0)
                    oBoardElements[iPosXInt][neighbourIndex].SetDestroyed(true);

                neighbourIndex = iPosYInt + 1;
                if (neighbourIndex < iBoardSize)
                    oBoardElements[iPosXInt][neighbourIndex].SetDestroyed(true);
            }
            return true;
        }

        private bool CollisionWithOtherTanks(
            int iPosXInt,
            int iPosYInt)
        {
            CTank parentTank = controller.ParentTank;

            LinkedList<CTank> tanks = parentTank.ParentGameWindow.ChildTanks;
            foreach (CTank tank in tanks)
            {
                if (tank == parentTank)
                    continue;

                if (tank.GetPosX() > iPosXInt || tank.GetPosX() + tank.GetSize() <= iPosXInt ||
                    tank.GetPosY() > iPosYInt || tank.GetPosY() + tank.GetSize() <= iPosYInt)
                    continue;

                tank.HitPoints.TakeDamagedFromMissile(damage);

                return true;
            }
            return false;
        }




        public CMissile Controller { get => controller; set => controller = value; }

        public int GetPosX()
        {
            return (int)posX;
        }
        public void SetPosX(int iPosX)
        {
            posX = iPosX;
        }

        public int GetPosY()
        {
            return (int)posY;
        }
        public void SetPosY(int iPosY)
        {
            posY = iPosY;
        }

        public EDirection Direction { get => direction; set => direction = value; }

        public int GetDamage()
        {
            return damage;
        }
        public void SetDamage(int iDamage)
        {
            damage = iDamage;
            if (damage <= 0)
                damage = DEFAULT_DAMAGE;
        }
    }
}
