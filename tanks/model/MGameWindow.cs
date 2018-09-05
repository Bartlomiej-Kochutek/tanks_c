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


        public int milisecsDelta()
        {
            long currentMeasuredMilisecs = DateTimeOffset.Now.ToUnixTimeMilliseconds();
            int delta = (int)(currentMeasuredMilisecs - lastMeasuredMilisecs);

            lastMeasuredMilisecs = currentMeasuredMilisecs;

            return delta;
        }




        public CGameWindow getController()
        {
            return controller;
        }
        public void setController(CGameWindow iController)
        {
            controller = iController;
        }

        public int getElementSize()
        {
            return elementSize;
        }
        public void setElementSize(int iElementSize)
        {
            elementSize = iElementSize;
        }

        public bool isAtLeastOneTankDeafeated()
        {
            return atLeastOneTankDeafeated;
        }
        public void setAtLeastOneTankDeafeated(bool iAtLeastOneTankDeafeated)
        {
            atLeastOneTankDeafeated = iAtLeastOneTankDeafeated;
        }
    }
}
