using System;
using tanks.common;
using tanks.controller;

namespace tanks.model
{
    class MLaserBonus : MBaseBonus
    {
        private CLaserBonus mController;

        private TimeSpan mDuration;



        public MLaserBonus()
        {
            mDuration = new TimeSpan(0, 0, Settings.DEFAULT_BONUS_DURATION_IN_SECONDS);
        }



        public void SetController(CLaserBonus iController)
        {
            mController = iController;
        }

        public TimeSpan GetDuration()
        {
            return mDuration;
        }
    }
}
