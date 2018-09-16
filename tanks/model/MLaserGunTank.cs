using System;
using System.Collections.Generic;
using tanks.common;
using tanks.controller;

namespace tanks.model
{
    class MLaserGunTank
    {
        private CLaserGunTank mController;

        private int mLaserLastShootingTime;

        private MPosition mPosOfLaserBeamCollision;
        private DateTime mDecorationEndTime;



        public MLaserGunTank(
            CLaserGunTank iController,
            TimeSpan iDecorationDuration)
        {
            mController = iController;

            mPosOfLaserBeamCollision = new MPosition();

            mDecorationEndTime = DateTime.Now + iDecorationDuration;
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
            mController.LaserBeamParts.Clear();

            if (mController.IsUsingWeapon())
                CreateLaserBeamParts(
                    oBoardElements,
                    oTanks);

            DamageOtherTankIfHit(oTanks);
        }

        public void DrawLaserBeam(CBoardElement[][] oBoardElements)
        {
            Algorithm.RedrawMissiles(
                oBoardElements,
                mController.LaserBeamParts);
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

            mPosOfLaserBeamCollision.SetPosX(posXOfLaserBeamPart);
            mPosOfLaserBeamCollision.SetPosY(posYOfLaserBeamPart);
        }

        private void DamageOtherTankIfHit(LinkedList<ICTank> oTanks)
        {
            if (!mController.IsUsingWeapon())
                return;

            int laserDamage = (int)(mLaserLastShootingTime * Settings.LASER_POWER);

            Algorithm.CollisionWithOtherTanks(
                    mController,
                    oTanks,
                    mPosOfLaserBeamCollision.GetPosX(),
                    mPosOfLaserBeamCollision.GetPosY(),
                    laserDamage,
                    true);
        }

        public DateTime GetDecorationEndTime()
        {
            return mDecorationEndTime;
        }

    }
}
