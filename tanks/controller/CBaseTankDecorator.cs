using System.Collections.Generic;
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



        public virtual void Prepare()
        {
            mDecoratedTank.Prepare();
        }

        public virtual CGameWindow ParentGameWindow
            { get => mDecoratedTank.ParentGameWindow; set => mDecoratedTank.ParentGameWindow = value; }
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

        public virtual void RedrawWithWeaponUsageEffect(CBoardElement[][] oBoardElements)
        {
            mDecoratedTank.RedrawWithWeaponUsageEffect(oBoardElements);
        }

        public int CanonPositionX()
        {
            return mDecoratedTank.CanonPositionX();
        }
        public int CanonPositionY()
        {
            return mDecoratedTank.CanonPositionY();
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
        public virtual EDirection GetDirection()
        {
            return mDecoratedTank.GetDirection();
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
