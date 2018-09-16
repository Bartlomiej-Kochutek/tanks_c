using System.Collections.Generic;
using tanks.common;
using tanks.model;


namespace tanks.controller
{
    public class CMissile : IPositionable
    {
        private ICTank mParentTank;

        private MMissile mModel;



        public CMissile(
            ICTank iParentTank,
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
            mModel.Move(iDeltaPos);
        }

        public bool Collision(
            CBoardElement[][] oBoardElements,
            LinkedList<ICTank> oTanks,
            bool iDoDamage = true)
        {
            return mModel.Collision(oBoardElements,
                                    oTanks,
                                    iDoDamage);
        }
        


        public ICTank ParentTank { get => mParentTank; set => mParentTank = value; }

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
