using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.controller;


namespace tanks.model
{
    public class MHitPoints
    {
        private CHitPoints controller;

        private const int DEFAULT_BAR_HEIGHT = 3;
        private int barHeight;

        private const int MAX_HIT_POINTS = 1000;
        private int amount;



        public MHitPoints()
        {
            barHeight = DEFAULT_BAR_HEIGHT;
            amount = MAX_HIT_POINTS;
        }


        public void takeDamagedFromMissile(int iHitPointsDamage)
        {
            amount -= iHitPointsDamage;

            if (amount > 0)
                return;

            controller.getParentTank().getParentGameWindow().setAtLeastOneTankDeafeated(true);
            controller.getParentTank().setDefeated(true);
        }

        public double getAmountAsPercentage()
        {
            return (double)amount / (double)MAX_HIT_POINTS;
        }




        public CHitPoints getController()
        {
            return controller;
        }
        public void setController(CHitPoints iController)
        {
            controller = iController;
        }

        public static int getMaxHitPoints()
        {
            return MAX_HIT_POINTS;
        }

        public int getBarHeight()
        {
            return barHeight;
        }

        public int getAmount()
        {
            return amount;
        }
        public void setAmount(int iAmount)
        {
            amount = iAmount;
        }
    }
}
