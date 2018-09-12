using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tanks.view;

namespace tanks.controller
{
    abstract class CBaseTankDecorator : ICTank
    {
        protected ICTank mDecoratedTank;



        public CBaseTankDecorator(ICTank iDecoratedTank)
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
        public virtual void CalculateWeaponUsages(
            float iDeltaT,
            CBoardElement[][] oBoardElements,
            LinkedList<ICTank> oTanks)
        {
            mDecoratedTank.CalculateWeaponUsages(iDeltaT,
                                                 oBoardElements,
                                                 oTanks);
        }

        public virtual void RedrawWithWeaponUsageEffect(CBoardElement[][] iBoardElements)
        {
            mDecoratedTank.RedrawWithWeaponUsageEffect(iBoardElements);
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

        public virtual bool IsUsingWeapon()
        {
            return mDecoratedTank.IsUsingWeapon();
        }
        public virtual void SetUsingWeapon(bool iShooting)
        {
            mDecoratedTank.SetUsingWeapon(iShooting);
        }

        public virtual bool IsDefeated()
        {
            return mDecoratedTank.IsDefeated();
        }
    }
}
