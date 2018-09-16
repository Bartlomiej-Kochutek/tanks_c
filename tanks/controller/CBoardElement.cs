using System.Drawing;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CBoardElement
    {
        private MBoardElement mModel;
        private VBoardElement mView;



        public CBoardElement(Color iColor)
        {
            mModel = new MBoardElement();
            mModel.Controller = this;

            mView = new VBoardElement(iColor);
            mView.Controller = this;
        }
        


        public MBoardElement Model { get => mModel; set => mModel = value; }

        public VBoardElement View { get => mView; set => mView = value; }

        public bool IsDestroyed()
        {
            return mModel.IsDestroyed;
        }
        public void SetDestroyed(bool iIsDestroyed)
        {
            mModel.IsDestroyed = iIsDestroyed;
        }

        public bool IsTank()
        {
            return mModel.IsTank;
        }
        public void SetTank(bool iIsTank)
        {
            mModel.IsTank = iIsTank;
        }

        public bool IsCanon()
        {
            return mModel.IsCanon;
        }
        public void SetCanon(bool iIsCanon)
        {
            mModel.IsCanon = iIsCanon;
        }

        public bool IsMissile()
        {
            return mModel.IsMissile;
        }
        public void SetMissile(bool iIsMissile)
        {
            mModel.IsMissile = iIsMissile;
        }

        public bool IsFortressWall()
        {
            return mModel.IsFortressWall;
        }
        public void SetFortressWall(bool iIsFortressWall)
        {
            mModel.IsFortressWall = iIsFortressWall;
        }

        public bool IsBonus()
        {
            return mModel.IsBonus;
        }
        public void SetBonus(bool iIsBonus)
        {
            mModel.IsBonus = iIsBonus;
        }
    }
}
