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
        private CGameWindow parentGameWindow;

        protected MTank model;
        private VTank view;

        private LinkedList<CMissile> missiles;
        private CHitPoints hitPoints;

        private CBase mBase;



        public CTank(
            int iPosX,
            int iPosY)
        {
            SetModel(new MTank(iPosX, iPosY));

            view = new VTank();
            view.Controller = this;

            hitPoints = new CHitPoints();
            hitPoints.ParentTank = this;

            mBase = new CBase();
            mBase.ParentTank = this;

            missiles = new LinkedList<CMissile>();
        }


        public void UseWeapon(int iDeltaT)
        {
            model.Shoot(iDeltaT);
        }


        public void Prepare()
        {
            model.Prepare();
            view.Prepare();

            mBase.Prepare();
            mBase.Draw();
        }

        public void RedrawWithMissiles()
        {
            if (model.IsDefeated())
                return;

            view.Redraw(parentGameWindow.ChildBoard.Elements);
            view.RedrawMissiles(parentGameWindow.ChildBoard.Elements);
        }

        public void MoveMissiles(float iDeltaT)
        {
            model.MoveMissiles(iDeltaT);
        }

        public void CheckMissilesCollision()
        {
            model.CheckMissilesCollision();
        }

        public void Move(int iDeltaT)
        {
            model.Move(iDeltaT);
        }




        public void SetModel(MTank iTank)
        {
            model = iTank;
            model.SetController(this);
        }

        public VTank View { get => view; set => view = value; }

        public CGameWindow ParentGameWindow { get => parentGameWindow; set => parentGameWindow = value; }

        public LinkedList<CMissile> Missiles { get => missiles; set => missiles = value; }

        public CHitPoints HitPoints { get => hitPoints; set => hitPoints = value; }

        public int GetPosX()
        {
            return model.GetPosX();
        }
        public void SetPosX(int iPosX)
        {
            model.SetPosX(iPosX);
        }

        public int GetPosY()
        {
            return model.GetPosY();
        }
        public void SetPosY(int iPosY)
        {
            model.SetPosY(iPosY);
        }

        public int GetSize()
        {
            return model.GetSize();
        }
        public void SetSize(int iSize)
        {
            model.SetSize(iSize);
        }

        public EDirection GetDirection()
        {
            return model.Direction;
        }
        public void SetDirection(EDirection iDirection)
        {
            model.Direction = iDirection;
        }

        public int GetSpeed()
        {
            return model.GetSpeed();
        }
        public void SetSpeed(int iSpeed)
        {
            model.SetSpeed(iSpeed);
        }


        public bool IsMoveDown()
        {
            return model.IsMoveDown();
        }
        public void SetMoveDown(bool iMoveDown)
        {
            model.SetMoveDown(iMoveDown);
        }

        public bool IsMoveLeft()
        {
            return model.IsMoveLeft();
        }
        public void SetMoveLeft(bool iMoveLeft)
        {
            model.SetMoveLeft(iMoveLeft);
        }

        public bool IsMoveRight()
        {
            return model.IsMoveRight();
        }
        public void SetMoveRight(bool iMoveRight)
        {
            model.SetMoveRight(iMoveRight);
        }

        public bool IsMoveUp()
        {
            return model.IsMoveUp();
        }
        public void SetMoveUp(bool iMoveUp)
        {
            model.SetMoveUp(iMoveUp);
        }


        public bool IsShooting()
        {
            return model.IsShooting();
        }
        public void SetShooting(bool iShooting)
        {
            model.SetShooting(iShooting);
        }


        public bool IsDefeated()
        {
            return model.IsDefeated();
        }
        public void SetDefeated(bool iDefeated)
        {
            model.SetDefeated(iDefeated);
        }
    }
}
