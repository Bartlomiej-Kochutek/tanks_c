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
        private CTank parentTank;

        private MHitPoints model;



        public CHitPoints()
        {
            model = new MHitPoints();
            model.Controller = this;
        }


        public void TakeDamagedFromMissile(int iHitPointsDamage)
        {
            model.TakeDamagedFromMissile(iHitPointsDamage);
        }

        public double GetAmountAsPercentage()
        {
            return model.GetAmountAsPercentage();
        }






        public CTank ParentTank { get => parentTank; set => parentTank = value; }

        public MHitPoints GetModel()
        {
            return model;
        }
        public void SetModel(MHitPoints iModel)
        {
            model = iModel;
            model.Controller = this;
        }

        public int GetBarHeight()
        {
            return model.BarHeight;
        }

        public int GetAmount()
        {
            return model.Amount;
        }
        public void SetAmount(int iAmount)
        {
            model.Amount = iAmount;
        }
    }
}
