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

        private bool mAtLeastOneTankDeafeated;

        private int mElementSize;



        public MGameWindow()
        {
            mLastMeasuredMilisecs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            mAtLeastOneTankDeafeated = false;

            mElementSize = 12;
        }


        public int MilisecsDelta()
        {
            long currentMeasuredMilisecs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            int delta = (int)(currentMeasuredMilisecs - mLastMeasuredMilisecs);

            mLastMeasuredMilisecs = currentMeasuredMilisecs;

            return delta;
        }




        public CGameWindow Controller { get => mController; set => mController = value; }

        public int ElementSize { get => mElementSize; set => mElementSize = value; }

        public bool AtLeastOneTankDeafeated { get => mAtLeastOneTankDeafeated; set => mAtLeastOneTankDeafeated = value; }
    }
}
