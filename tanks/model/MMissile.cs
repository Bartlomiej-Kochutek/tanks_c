using System.Collections.Generic;
using tanks.common;
using tanks.controller;


namespace tanks.model
{
    class MMissile : IPositionable
    {
        private CMissile mController;

        protected MPrecisePosition mPosition = new MPrecisePosition();
        
        protected MPrecisePosition mPreviousPosition = new MPrecisePosition();

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
                    mPosition.SetPrecisePosY(mPosition.GetPrecisePosY() + iDeltaPos);
                    break;
                case EDirection.LEFT:
                    mPosition.SetPrecisePosX(mPosition.GetPrecisePosX() - iDeltaPos);
                    break;
                case EDirection.RIGHT:
                    mPosition.SetPrecisePosX(mPosition.GetPrecisePosX() + iDeltaPos);
                    break;
                case EDirection.UP:
                    mPosition.SetPrecisePosY(mPosition.GetPrecisePosY() - iDeltaPos);
                    break;
            }
        }

        public bool Collision(
            CBoardElement[][] oBoardElements,
            LinkedList<ICTank> oTanks,
            bool iDoDamage)
        {
            int intPosX = mPosition.GetPosX();
            int intPosY = mPosition.GetPosY();

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
            if (Algorithm.IndicesOutsideWindow(iPosXInt, iPosYInt))
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
            return mPosition.GetPosX();
        }
        public void SetPosX(int iPosX)
        {
            mPosition.SetPosX(iPosX);
            mPreviousPosition.SetPosX(iPosX);
        }

        public int GetPosY()
        {
            return mPosition.GetPosY();
        }
        public void SetPosY(int iPosY)
        {
            mPosition.SetPosY(iPosY);
            mPreviousPosition.SetPosY(iPosY);
        }

        public int GetSize()
        {
            return mPosition.GetSize();
        }
        public void SetSize(int iSize)
        {
            mPosition.SetSize(iSize);
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
