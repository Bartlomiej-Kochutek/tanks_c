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


        public void TakeDamagedFromMissile(int iHitPointsDamage)
        {
            amount -= iHitPointsDamage;

            if (amount > 0)
                return;

            controller.ParentTank.ParentGameWindow.SetAtLeastOneTankDeafeated(true);
            controller.ParentTank.SetDefeated(true);
        }

        public double GetAmountAsPercentage()
        {
            return (double)amount / (double)MAX_HIT_POINTS;
        }




        public CHitPoints Controller { get => controller; set => controller = value; }

        public static int MaxHitPoints => MAX_HIT_POINTS;

        public int BarHeight => barHeight;

        public int Amount { get => amount; set => amount = value; }
    }
}
