using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.controller;


namespace tanks.model
{
    public class MGameWindow
    {
        private CGameWindow mController;

        private long mLastMeasuredMilisecs;

        private int mPreviouseDeltaT;

        private bool mAtLeastOneTankDeafeated;

        private int mElementSize;



        public MGameWindow()
        {
            mLastMeasuredMilisecs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            mPreviouseDeltaT = 0;

            mAtLeastOneTankDeafeated = false;

            mElementSize = 12;
        }


        public int MilisecsDeltaT()
        {
            long currentMeasuredMilisecs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            int currentDeltaT = (int)(currentMeasuredMilisecs - mLastMeasuredMilisecs);

            mLastMeasuredMilisecs = currentMeasuredMilisecs;

            int deltaTsMean = (currentDeltaT + mPreviouseDeltaT) / 2;

            mPreviouseDeltaT = currentDeltaT;

            return deltaTsMean;
        }




        public CGameWindow Controller { get => mController; set => mController = value; }

        public int ElementSize { get => mElementSize; set => mElementSize = value; }

        public bool AtLeastOneTankDeafeated { get => mAtLeastOneTankDeafeated; set => mAtLeastOneTankDeafeated = value; }
    }
}
