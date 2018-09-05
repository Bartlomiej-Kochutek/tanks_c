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
            model.setController(this);
        }


        public void takeDamagedFromMissile(int iHitPointsDamage)
        {
            model.takeDamagedFromMissile(iHitPointsDamage);
        }

        public double getAmountAsPercentage()
        {
            return model.getAmountAsPercentage();
        }






        public CTank getParentTank()
        {
            return parentTank;
        }
        public void setParentTank(CTank iParentTank)
        {
            parentTank = iParentTank;
        }

        public MHitPoints getModel()
        {
            return model;
        }
        public void setModel(MHitPoints iModel)
        {
            model = iModel;
            model.setController(this);
        }

        public int getBarHeight()
        {
            return model.getBarHeight();
        }

        public int getAmount()
        {
            return model.getAmount();
        }
        public void setAmount(int iAmount)
        {
            model.setAmount(iAmount);
        }
    }
}
