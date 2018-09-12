using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CTank : ICTank
    {
        private CGameWindow mParentGameWindow;

        protected MTank mModel;
        private VTank mView;

        private LinkedList<CMissile> mMissiles;
        private CHitPoints mHitPoints;

        private CFortress mFortress;



        public CTank(
            int iPosX,
            int iPosY)
        {
            SetModel(new MTank(iPosX, iPosY));

            mView = new VTank();
            mView.Controller = this;

            mHitPoints = new CHitPoints();
            mHitPoints.ParentTank = this;

            mFortress = new CFortress();
            mFortress.ParentTank = this;

            mMissiles = new LinkedList<CMissile>();
        }


        public void Prepare()
        {
            mModel.Prepare();
            mView.Prepare();

            mFortress.Prepare();
            mFortress.Draw();
        }


        public void Move(int iDeltaT)
        {
            mModel.Move(iDeltaT);
        }

        public void UseWeapon(int iDeltaT)
        {
            mModel.ShootFromStandardGun(iDeltaT);
        }

        public void CalculateWeaponUsages(
            float iDeltaT,
            CBoardElement[][] oBoardElements,
            LinkedList<ICTank> oTanks)
        {
            mModel.MoveMissiles(iDeltaT);
            mModel.CheckMissilesCollision(oBoardElements,
                                          oTanks);
        }


        public void RedrawWithWeaponUsageEffect(CBoardElement[][] iBoardElements)
        {
            mView.Redraw(iBoardElements);
            mView.RedrawMissiles(iBoardElements);
        }



        public void SetModel(MTank iTank)
        {
            mModel = iTank;
            mModel.SetController(this);
        }

        public VTank View { get => mView; set => mView = value; }

        public CGameWindow ParentGameWindow { get => mParentGameWindow; set => mParentGameWindow = value; }

        public LinkedList<CMissile> Missiles { get => mMissiles; set => mMissiles = value; }

        public CHitPoints HitPoints { get => mHitPoints; set => mHitPoints = value; }

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

        public int GetSize()
        {
            return mModel.GetSize();
        }
        public void SetSize(int iSize)
        {
            mModel.SetSize(iSize);
        }

        public EDirection GetDirection()
        {
            return mModel.Direction;
        }
        public void SetDirection(EDirection iDirection)
        {
            mModel.Direction = iDirection;
        }

        public int GetSpeed()
        {
            return mModel.GetSpeed();
        }
        public void SetSpeed(int iSpeed)
        {
            mModel.SetSpeed(iSpeed);
        }


        public bool IsMoveDown()
        {
            return mModel.IsMoveDown();
        }
        public void SetMoveDown(bool iMoveDown)
        {
            mModel.SetMoveDown(iMoveDown);
        }

        public bool IsMoveLeft()
        {
            return mModel.IsMoveLeft();
        }
        public void SetMoveLeft(bool iMoveLeft)
        {
            mModel.SetMoveLeft(iMoveLeft);
        }

        public bool IsMoveRight()
        {
            return mModel.IsMoveRight();
        }
        public void SetMoveRight(bool iMoveRight)
        {
            mModel.SetMoveRight(iMoveRight);
        }

        public bool IsMoveUp()
        {
            return mModel.IsMoveUp();
        }
        public void SetMoveUp(bool iMoveUp)
        {
            mModel.SetMoveUp(iMoveUp);
        }


        public bool IsUsingWeapon()
        {
            return mModel.IsUsingWeapon();
        }
        public void SetUsingWeapon(bool iUsingWeapon)
        {
            mModel.SetUsingWeapon(iUsingWeapon);
        }


        public bool IsDefeated()
        {
            return mModel.IsDefeated();
        }
        public void SetDefeated(bool iDefeated)
        {
            mModel.SetDefeated(iDefeated);
        }
    }
}
