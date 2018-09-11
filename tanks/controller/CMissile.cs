﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CMissile
    {
        private CTank mParentTank;

        private MMissile mModel;



        public CMissile(
            CTank iParentTank,
            int iPosX,
            int iPosY,
            EDirection iDirection)
        {
            mParentTank = iParentTank;

            mModel = new MMissile();
            mModel.Controller = this;

            mModel.SetPosX(iPosX);
            mModel.SetPosY(iPosY);
            mModel.Direction = iDirection;
        }


        public void Move(float iDeltaPos)
        {
            float deltaPos = iDeltaPos;
            const float MAX_DELTA_POS = 1;
            if (deltaPos > MAX_DELTA_POS)
                deltaPos = MAX_DELTA_POS;

            mModel.Move(deltaPos);
        }

        public bool Collision()
        {
            return mModel.Collision();
        }




        public CTank ParentTank { get => mParentTank; set => mParentTank = value; }

        public int GetPosX()
        {
            return mModel.GetPosX();
        }
        public void SetPosX(int iPosX)
        {
            mModel.SetPosX(iPosX);
        }

        public int GetPosY()
        {
            return mModel.GetPosY();
        }
        public void SetPosY(int iPosY)
        {
            mModel.SetPosY(iPosY);
        }

        public EDirection GetDirection()
        {
            return mModel.Direction;
        }
        public void SetDirection(EDirection iDirection)
        {
            mModel.Direction = iDirection;
        }

        public int GetDamage()
        {
            return mModel.GetDamage();
        }
        public void SetDamage(int iDamage)
        {
            mModel.SetDamage(iDamage);
        }
    }
}
