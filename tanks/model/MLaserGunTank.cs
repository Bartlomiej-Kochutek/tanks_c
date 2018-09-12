using System.Collections.Generic;
using tanks.controller;

namespace tanks.model
{
    class MLaserGunTank
    {
        int mLastLaserShootingTime;



        public MLaserGunTank()
        {
        }



        public void ShootFromLaserGun(int iDeltaT)
        {
            mLastLaserShootingTime = iDeltaT;
        }

        public void CheckLaserBeamCollision(
            float iDeltaT,
            CBoardElement[][] oBoardElements,
            LinkedList<ICTank> oTanks)
        {
        }
    }
}
