using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CHitPoints
    {
        private CTank mParentTank;

        private MHitPoints mModel;



        public CHitPoints()
        {
            mModel = new MHitPoints();
            mModel.Controller = this;
        }


        public void TakeDamagedFromMissile(int iHitPointsDamage)
        {
            mModel.TakeDamagedFromMissile(iHitPointsDamage);
        }

        public double GetAmountAsPercentage()
        {
            return mModel.GetAmountAsPercentage();
        }






        public CTank ParentTank { get => mParentTank; set => mParentTank = value; }

        public MHitPoints GetModel()
        {
            return mModel;
        }
        public void SetModel(MHitPoints iModel)
        {
            mModel = iModel;
            mModel.Controller = this;
        }

        public int GetBarHeight()
        {
            return mModel.BarHeight;
        }

        public int GetAmount()
        {
            return mModel.Amount;
        }
        public void SetAmount(int iAmount)
        {
            mModel.Amount = iAmount;
        }
    }
}
