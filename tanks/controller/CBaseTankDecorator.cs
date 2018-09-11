using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tanks.view;

namespace tanks.controller
{
    class CBaseTankDecorator : ICTank
    {
        ICTank mDecoratedTank;


        CBaseTankDecorator(ICTank iDecoratedTank)
        {
            mDecoratedTank = iDecoratedTank;
        }



        public virtual CHitPoints HitPoints { get => mDecoratedTank.HitPoints; set => mDecoratedTank.HitPoints = value; }
        public virtual VTank View { get => mDecoratedTank.View; set => mDecoratedTank.View = value; }

        public virtual void Move(int iDeltaT)
        {
            mDecoratedTank.Move(iDeltaT);
        }
        public virtual void UseWeapon(int iDeltaT)
        {
            mDecoratedTank.UseWeapon(iDeltaT);
        }
        public virtual void MoveMissiles(float iDeltaT)
        {
            mDecoratedTank.MoveMissiles(iDeltaT);
        }
        public virtual void CheckMissilesCollision()
        {
            mDecoratedTank.CheckMissilesCollision();
        }

        public virtual void RedrawWithMissiles()
        {
            mDecoratedTank.RedrawWithMissiles();
        }

        public virtual int GetPosX()
        {
            return mDecoratedTank.GetPosX();
        }
        public virtual int GetPosY()
        {
            return mDecoratedTank.GetPosY();
        }
        public virtual int GetSize()
        {
            return mDecoratedTank.GetSize();
        }

        public virtual void SetMoveDown(bool iMoveDown)
        {
            mDecoratedTank.SetMoveDown(iMoveDown);
        }
        public virtual void SetMoveLeft(bool iMoveLeft)
        {
            mDecoratedTank.SetMoveLeft(iMoveLeft);
        }
        public virtual void SetMoveRight(bool iMoveRight)
        {
            mDecoratedTank.SetMoveRight(iMoveRight);
        }
        public virtual void SetMoveUp(bool iMoveUp)
        {
            mDecoratedTank.SetMoveUp(iMoveUp);
        }
        public virtual void SetShooting(bool iShooting)
        {
            mDecoratedTank.SetShooting(iShooting);
        }
    }
}
