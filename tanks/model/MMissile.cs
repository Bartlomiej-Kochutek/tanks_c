﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.controller;


namespace tanks.model
{
    class MMissile
    {
        private CMissile mController;

        private float mPosX;
        private float mPosY;

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

        public bool Collision()
        {
            CTank parentTank = mController.ParentTank;

            int boardSize = parentTank.ParentGameWindow.ChildBoard.GetSize();

            if (CGameBoard.IndicesOutsideWindow((int)mPosX, (int)mPosY, boardSize))
                return true;

            CBoardElement[][] boardElements = parentTank.ParentGameWindow.ChildBoard.Elements;

            int intPosX = (int)mPosX;
            int intPosY = (int)mPosY;

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
            CTank parentTank = mController.ParentTank;

            LinkedList<ICTank> tanks = parentTank.ParentGameWindow.ChildTanks;
            foreach (ICTank tank in tanks)
            {
                if (tank == parentTank)
                    continue;

                if (tank.GetPosX() > iPosXInt || tank.GetPosX() + tank.GetSize() <= iPosXInt ||
                    tank.GetPosY() > iPosYInt || tank.GetPosY() + tank.GetSize() <= iPosYInt)
                    continue;

                tank.HitPoints.TakeDamagedFromMissile(mDamage);

                return true;
            }
            return false;
        }




        public CMissile Controller { get => mController; set => mController = value; }

        public int GetPosX()
        {
            return (int)mPosX;
        }
        public void SetPosX(int iPosX)
        {
            mPosX = iPosX;
        }

        public int GetPosY()
        {
            return (int)mPosY;
        }
        public void SetPosY(int iPosY)
        {
            mPosY = iPosY;
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
