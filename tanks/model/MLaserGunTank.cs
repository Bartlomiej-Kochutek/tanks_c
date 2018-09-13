using System.Collections.Generic;
using tanks.common;
using tanks.controller;

namespace tanks.model
{
    class MLaserGunTank
    {
        private CLaserGunTank mController;

        private int mLaserLastShootingTime;

        private int mPosXOfLaserBeamCollision;
        private int mPosYOfLaserBeamCollision;



        public MLaserGunTank(CLaserGunTank iController)
        {
            mController = iController;
        }



        public void ShootFromLaserGun(int iDeltaT)
        {
            mLaserLastShootingTime = iDeltaT;
        }

        public void CheckLaserBeamCollision(
            float iDeltaT,
            CBoardElement[][] oBoardElements,
            LinkedList<ICTank> oTanks)
        {
            CreateLaserBeamParts(
                oBoardElements,
                oTanks);

            DamageOtherTankIfHit(oTanks);
        }

        public void DrawLaserBeam(CBoardElement[][] oBoardElements)
        {

        }



        private void CreateLaserBeamParts(
            CBoardElement[][] oBoardElements,
            LinkedList<ICTank> oTanks)
        {
            int posXOfLaserBeamPart = mController.CanonPositionX();
            int posYOfLaserBeamPart = mController.CanonPositionY();

            bool createNextLaserBeamPart = true;

            do
            {
                switch (mController.GetDirection())
                {
                    case EDirection.DOWN:
                        posYOfLaserBeamPart++;
                        break;
                    case EDirection.LEFT:
                        posXOfLaserBeamPart--;
                        break;
                    case EDirection.RIGHT:
                        posXOfLaserBeamPart++;
                        break;
                    case EDirection.UP:
                        posYOfLaserBeamPart--;
                        break;
                }

                CMissile cMissile = new CMissile(
                    mController,
                    posXOfLaserBeamPart,
                    posYOfLaserBeamPart,
                    mController.GetDirection());

                if (cMissile.Collision(
                        oBoardElements,
                        oTanks,
                        false))
                {
                    createNextLaserBeamPart = false;
                }
                else
                {
                    mController.LaserBeamParts.AddLast(cMissile);
                }
            } while (createNextLaserBeamPart);

            mPosXOfLaserBeamCollision = posXOfLaserBeamPart;
            mPosYOfLaserBeamCollision = posYOfLaserBeamPart;
        }

        private void DamageOtherTankIfHit(LinkedList<ICTank> oTanks)
        {
            const int LASER_POWER = 50;

            int laserDamage = mLaserLastShootingTime * LASER_POWER;

            Algorithm.CollisionWithOtherTanks(
                    mController,
                    oTanks,
                    mPosXOfLaserBeamCollision,
                    mPosXOfLaserBeamCollision,
                    laserDamage,
                    true);
        }

    }
}
