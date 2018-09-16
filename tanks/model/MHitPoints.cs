
using tanks.common;
using tanks.controller;


namespace tanks.model
{
    public class MHitPoints
    {
        private CHitPoints mController;

        private int mBarHeight;

        private int mAmount;



        public MHitPoints()
        {
            mBarHeight = Settings.DEFAULT_HIT_POINTS_BAR_HEIGHT;
            mAmount = Settings.MAX_HIT_POINTS;
        }



        public void TakeDamagedFromMissile(int iHitPointsDamage)
        {
            mAmount -= iHitPointsDamage;

            if (mAmount > 0)
                return;

            mController.ParentTank.ParentGameWindow.SetAtLeastOneTankDeafeated(true);
            mController.ParentTank.SetDefeated(true);
        }

        public double GetAmountAsPercentage()
        {
            return (double)mAmount / (double)Settings.MAX_HIT_POINTS;
        }



        public CHitPoints Controller { get => mController; set => mController = value; }

        public int BarHeight => mBarHeight;

        public int Amount { get => mAmount; set => mAmount = value; }
    }
}
