﻿using System.Collections.Generic;
using tanks.common;
using tanks.controller;


namespace tanks.model
{
    public class MTank : IPositionable
    {
        protected CTank mController;

        protected MPrecisePosition mPosition = new MPrecisePosition();

        private int mMaxPos;

        private EDirection mDirection;

        protected bool mMoveDown;
        protected bool mMoveLeft;
        protected bool mMoveRight;
        protected bool mMoveUp;

        protected bool mIsUsingWeapon;
        private int mLastShootDelta;

        private bool mDefeated;



        public MTank(
            int iPosX,
            int iPosY)
        {
            mPosition.SetSize(Settings.DEFAULT_TANK_SIZE);

            mPosition.SetPosX(iPosX);
            mPosition.SetPosY(iPosY);

            mDirection = EDirection.UP;

            mMoveDown = false;
            mMoveLeft = false;
            mMoveRight = false;
            mMoveUp = false;

            mIsUsingWeapon = false;

            mLastShootDelta = 0;

            mDefeated = false;
        }



        public void Prepare()
        {
            mMaxPos = mController.ParentGameWindow.ChildBoard.GetSize() - mPosition.GetSize();
        }


        public virtual void ShootFromStandardGun(int iDeltaT)
        {
            mLastShootDelta += iDeltaT;
            if (mLastShootDelta < Settings.MISSILES_SHOOTING_INTERVAL)
                return;

            mLastShootDelta %= Settings.MISSILES_SHOOTING_INTERVAL;

            mController.Missiles.AddLast(new CMissile(
                mController,
                CanonPositionX(),
                CanonPositionY(),
                mDirection));
        }

        public void MoveMissiles(float iDeltaT)
        {
            float deltaPos = iDeltaT / Settings.TANK_DELTA_T_SCALE;

            foreach (CMissile cMissile in mController.Missiles)
            {
                cMissile.Move(Settings.MISSILES_FASTER_THAN_TANK * deltaPos);
            }
        }

        public void CheckMissilesCollision(
            CBoardElement[][] oBoardElements,
            LinkedList<ICTank> oTanks)
        {
            LinkedListNode<CMissile> iterator = mController.Missiles.First;
            while (iterator != null)
            {
                bool collisionOccured = iterator.Value.Collision(oBoardElements,
                                                                 oTanks);
                if (collisionOccured)
                {
                    mController.Missiles.Remove(iterator.Value);
                }
                iterator = iterator.Next;
            }
        }

        public int GetIndexOfPickedBonus(LinkedList<CBaseBonus> oBonuses)
        {
            int index = 0;
            foreach (CBaseBonus bonus in oBonuses)
            {
                bool collisionOccured = mPosition.CollisionWithOtherPositinables(bonus);
                if (collisionOccured)
                {
                    return index;
                }
                index++;
            }
            return -1; // non bonus picked
        }

        public virtual void Move(int iDeltaT)
        {
            float deltaPos = (float)iDeltaT / Settings.TANK_DELTA_T_SCALE;
            //System.Diagnostics.Debug.WriteLine(deltaPos);

            if (mMoveDown)
                MoveDown(deltaPos);

            if (mMoveLeft)
                MoveLeft(deltaPos);

            if (mMoveRight)
                MoveRight(deltaPos);

            if (mMoveUp)
                MoveUp(deltaPos);
        }

        private void MoveDown(float iDeltaPos)
        {
            mDirection = EDirection.DOWN;

            if (VerticalCollisionWithFortressWall(mController.GetSize()))
                return;

            mPosition.SetPrecisePosY(mPosition.GetPrecisePosY() + iDeltaPos);
            CorrectPosY();
        }
        private void MoveLeft(float iDeltaPos)
        {
            mDirection = EDirection.LEFT;

            if (HorizontalCollisionWithFortressWall(-1))
                return;

            mPosition.SetPrecisePosX(mPosition.GetPrecisePosX() - iDeltaPos);
            CorrectPosX();
        }
        private void MoveRight(float iDeltaPos)
        {
            mDirection = EDirection.RIGHT;

            if (HorizontalCollisionWithFortressWall(mController.GetSize()))
                return;

            mPosition.SetPrecisePosX(mPosition.GetPrecisePosX() + iDeltaPos);
            CorrectPosX();
        }
        private void MoveUp(float iDeltaPos)
        {
            mDirection = EDirection.UP;

            if (VerticalCollisionWithFortressWall(-1))
                return;

            mPosition.SetPrecisePosY(mPosition.GetPrecisePosY() - iDeltaPos);
            CorrectPosY();
        }

        private bool VerticalCollisionWithFortressWall(int iYDisplacement)
        {
            CBoardElement[][] boardElements = mController.ParentGameWindow.ChildBoard.Elements;

            for (int xDisplacement = 0; xDisplacement < mController.GetSize(); xDisplacement++)
            {
                int xIndex = mPosition.GetPosX() + xDisplacement;
                int yIndex = mPosition.GetPosY() + iYDisplacement;

                if (Algorithm.IndicesOutsideWindow(xIndex, yIndex))
                    continue;

                if (boardElements[xIndex][yIndex].IsFortressWall())
                    return true;
            }
            return false;
        }
        private bool HorizontalCollisionWithFortressWall(int iXDisplacement)
        {
            CBoardElement[][] boardElements = mController.ParentGameWindow.ChildBoard.Elements;

            for (int yDisplacement = 0; yDisplacement < mController.GetSize(); yDisplacement++)
            {
                int xIndex = mPosition.GetPosX() + iXDisplacement;
                int yIndex = mPosition.GetPosY() + yDisplacement;

                if (Algorithm.IndicesOutsideWindow(xIndex, yIndex))
                    continue;

                if (boardElements[xIndex][yIndex].IsFortressWall())
                    return true;
            }
            return false;
        }

        private void CorrectPosX()
        {
            if (mPosition.GetPosX() < 0)
                mPosition.SetPosX(0);

            if (mPosition.GetPosX() > mMaxPos)
                mPosition.SetPosX(mMaxPos);
        }
        private void CorrectPosY()
        {
            if (mPosition.GetPosY() < 0)
                mPosition.SetPosY(0);

            if (mPosition.GetPosY() > mMaxPos)
                mPosition.SetPosY(mMaxPos);
        }


        public int CanonPositionX()
        {
            switch (mDirection)
            {
                case EDirection.DOWN:
                    return mPosition.GetPosX() + mPosition.GetSize() / 2;
                case EDirection.LEFT:
                    return mPosition.GetPosX();
                case EDirection.RIGHT:
                    return mPosition.GetPosX() + mPosition.GetSize() - 1;
                case EDirection.UP:
                    return mPosition.GetPosX() + mPosition.GetSize() / 2;
                default:
                    return 0;
            }
        }
        public int CanonPositionY()
        {
            switch (mDirection)
            {
                case EDirection.DOWN:
                    return mPosition.GetPosY() + mPosition.GetSize() - 1;
                case EDirection.LEFT:
                    return mPosition.GetPosY() + mPosition.GetSize() / 2;
                case EDirection.RIGHT:
                    return mPosition.GetPosY() + mPosition.GetSize() / 2;
                case EDirection.UP:
                    return mPosition.GetPosY();
                default:
                    return 0;
            }
        }
        


        public void SetController(CTank iController)
        {
            mController = iController;
        }
        public CTank GetController()
        {
            return mController;
        }

        public int GetPosX()
        {
            return mPosition.GetPosX();
        }
        public void SetPosX(int iPosX)
        {
            mPosition.SetPosX(iPosX);

            CorrectPosX();
        }


        public int GetPosY()
        {
            return mPosition.GetPosY();
        }
        public void SetPosY(int iPosY)
        {
            mPosition.SetPosY(iPosY);

            CorrectPosY();
        }

        public int GetSize()
        {
            return mPosition.GetSize();
        }
        public void SetSize(int iSize)
        {
            mPosition.SetSize(iSize);
            if (iSize <= 0)
                mPosition.SetSize(Settings.DEFAULT_TANK_SIZE);
        }

        public EDirection Direction { get => mDirection; set => mDirection = value; }


        public bool IsMoveDown()
        {
            return mMoveDown;
        }
        public virtual void SetMoveDown(bool iMoveDown)
        {
            mMoveDown = iMoveDown;
            if (mMoveDown == true)
                mMoveUp = false;
        }

        public bool IsMoveLeft()
        {
            return mMoveLeft;
        }
        public virtual void SetMoveLeft(bool iMoveLeft)
        {
            mMoveLeft = iMoveLeft;
            if (mMoveLeft == true)
                mMoveRight = false;
        }

        public bool IsMoveRight()
        {
            return mMoveRight;
        }
        public virtual void SetMoveRight(bool iMoveRight)
        {
            mMoveRight = iMoveRight;
            if (mMoveRight == true)
                mMoveLeft = false;
        }

        public bool IsMoveUp()
        {
            return mMoveUp;
        }
        public virtual void SetMoveUp(bool iMoveUp)
        {
            mMoveUp = iMoveUp;
            if (mMoveUp == true)
                mMoveDown = false;
        }


        public bool IsUsingWeapon()
        {
            return mIsUsingWeapon;
        }
        public void SetUsingWeapon(bool iUsingWeapon)
        {
            mIsUsingWeapon = iUsingWeapon;
        }

        public bool IsDefeated()
        {
            return mDefeated;
        }
        public void SetDefeated(bool iDefeated)
        {
            mDefeated = iDefeated;
        }
    }
}
