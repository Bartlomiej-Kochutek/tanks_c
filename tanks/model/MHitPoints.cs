
using tanks.controller;


namespace tanks.model
{
    public class MHitPoints
    {
        private CHitPoints mController;

        private const int DEFAULT_BAR_HEIGHT = 3;
        private int mBarHeight;

        private const int MAX_HIT_POINTS = 1000;
        private int mAmount;



        public MHitPoints()
        {
            mBarHeight = DEFAULT_BAR_HEIGHT;
            mAmount = MAX_HIT_POINTS;
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
            return (double)mAmount / (double)MAX_HIT_POINTS;
        }



        public CHitPoints Controller { get => mController; set => mController = value; }

        public static int MaxHitPoints => MAX_HIT_POINTS;

        public int BarHeight => mBarHeight;

        public int Amount { get => mAmount; set => mAmount = value; }
    }
}
