using System.Collections.Generic;
using tanks.common;
using tanks.controller;


namespace tanks.model
{
    class MMissile
    {
        private CMissile mController;

        private float mPosX;
        private float mPosY;

        private float mPreviousPosX;
        private float mPreviousPosY;

        private EDirection direction;

        private const int DEFAULT_DAMAGE = 40;
        private int mDamage;



        public MMissile()
        {
            mDamage = DEFAULT_DAMAGE;
        }



        public void Move(float iDeltaPos)
        {
            switch (direction)
            {
                case EDirection.DOWN:
                    mPosY += iDeltaPos;
                    break;
                case EDirection.LEFT:
                    mPosX -= iDeltaPos;
                    break;
                case EDirection.RIGHT:
                    mPosX += iDeltaPos;
                    break;
                case EDirection.UP:
                    mPosY -= iDeltaPos;
                    break;
            }
        }

        public bool Collision(
            CBoardElement[][] oBoardElements,
            LinkedList<ICTank> oTanks,
            bool iDoDamage)
        {
            int intPosX = (int)mPosX;
            int intPosY = (int)mPosY;

            if (CollisionWithBoardElements(
                    oBoardElements,
                    intPosX,
                    intPosY))
                return true;

            if (Algorithm.CollisionWithOtherTanks(
                    mController.ParentTank,
                    oTanks,
                    intPosX,
                    intPosY,
                    mDamage,
                    iDoDamage))
                return true;

            return false;
        }

        private bool CollisionWithBoardElements(
            CBoardElement[][] oBoardElements,
            int iPosXInt,
            int iPosYInt)
        { //keep functions sequence order
            if (CGameBoard.IndicesOutsideWindow(iPosXInt, iPosYInt))
                return true;

            if (oBoardElements[iPosXInt][iPosYInt].IsFortressWall())
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
                if (neighbourIndex < oBoardElements.Length)
                    oBoardElements[neighbourIndex][iPosYInt].SetDestroyed(true);
            }
            else
            {
                int neighbourIndex = iPosYInt - 1;
                if (neighbourIndex >= 0)
                    oBoardElements[iPosXInt][neighbourIndex].SetDestroyed(true);

                neighbourIndex = iPosYInt + 1;
                if (neighbourIndex < oBoardElements.Length)
                    oBoardElements[iPosXInt][neighbourIndex].SetDestroyed(true);
            }
            return true;
        }
        


        public CMissile Controller { get => mController; set => mController = value; }

        public int GetPosX()
        {
            return (int)mPosX;
        }
        public void SetPosX(int iPosX)
        {
            mPosX = mPreviousPosX = iPosX;
        }

        public int GetPosY()
        {
            return (int)mPosY;
        }
        public void SetPosY(int iPosY)
        {
            mPosY = mPreviousPosY = iPosY;
        }

        public EDirection Direction { get => direction; set => direction = value; }

        public int GetDamage()
        {
            return mDamage;
        }
        public void SetDamage(int iDamage)
        {
            mDamage = iDamage;
            if (mDamage <= 0)
                mDamage = DEFAULT_DAMAGE;
        }
    }
}
