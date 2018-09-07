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
        private CGameWindow controller;

        private long lastMeasuredMilisecs;

        private bool atLeastOneTankDeafeated;

        private int elementSize;



        public MGameWindow()
        {
            lastMeasuredMilisecs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            atLeastOneTankDeafeated = false;

            elementSize = 12;
        }


        public int MilisecsDelta()
        {
            long currentMeasuredMilisecs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            int delta = (int)(currentMeasuredMilisecs - lastMeasuredMilisecs);

            lastMeasuredMilisecs = currentMeasuredMilisecs;

            return delta;
        }




        public CGameWindow Controller { get => controller; set => controller = value; }

        public int ElementSize { get => elementSize; set => elementSize = value; }

        public bool AtLeastOneTankDeafeated { get => atLeastOneTankDeafeated; set => atLeastOneTankDeafeated = value; }
    }
}
