using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tanks.model;

namespace tanks.controller
{
    class CLaserGunTank : CBaseTankDecorator
    {
        private MLaserGunTank mModel;



        public CLaserGunTank(ICTank iDecoratedTank)
            :
            base(iDecoratedTank)
        {
            mModel = new MLaserGunTank();
        }


        public override void UseWeapon(int iDeltaT)
        {
            mModel.ShootFromLaserGun(iDeltaT);
        }

        public override void CalculateWeaponUsages(
            float iDeltaT,
            CBoardElement[][] oBoardElements,
            LinkedList<ICTank> oTanks)
        {
            base.CalculateWeaponUsages(iDeltaT,
                                       oBoardElements,
                                       oTanks);

            mModel.CheckLaserBeamCollision();
        }

        public override void RedrawWithWeaponUsageEffect(CBoardElement[][] iBoardElements)
        {
            base.RedrawWithWeaponUsageEffect(iBoardElements);
        }
    }
}
