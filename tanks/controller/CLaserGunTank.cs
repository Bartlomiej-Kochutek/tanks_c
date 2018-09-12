using System.Collections.Generic;
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

            mModel.CheckLaserBeamCollision(iDeltaT,
                                           oBoardElements,
                                           oTanks);
        }

        public override void RedrawWithWeaponUsageEffect(CBoardElement[][] oBoardElements)
        {
            base.RedrawWithWeaponUsageEffect(oBoardElements);
        }
    }
}
