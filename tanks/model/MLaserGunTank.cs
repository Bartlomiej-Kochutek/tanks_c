using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        public void CheckLaserBeamCollision()
        {

        }
    }
}
