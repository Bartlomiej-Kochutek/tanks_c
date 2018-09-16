using System;
using tanks.common;
using tanks.controller;

namespace tanks.model
{
    public class MProxyTank : MTank
    {
        ETankOwner mOwner;
        DateTime mAbsoluteTimeAfterWhichComputerTakesControl;



        public MProxyTank(
            int iPosX,
            int iPosY,
            ETankOwner iTankOwner)
            :
            base(iPosX, iPosY)
        {
            mOwner = ETankOwner.Player;

            mAbsoluteTimeAfterWhichComputerTakesControl = DateTime.Now;

            TimeSpan relativeTimeAfterWhichComputerTakesControl;

            if (iTankOwner == ETankOwner.Player)
                relativeTimeAfterWhichComputerTakesControl = new TimeSpan(0, 0, Settings.PROXY_TANK_TAKE_CONTROL_TIMEOUT_IN_SECONDS);
            else
                relativeTimeAfterWhichComputerTakesControl = new TimeSpan(0, 0, 1);

            mAbsoluteTimeAfterWhichComputerTakesControl += relativeTimeAfterWhichComputerTakesControl;
        }



        public override void ShootFromStandardGun(int iDeltaT)
        {
            if (mOwner == ETankOwner.Computer)
                mIsUsingWeapon = true;

            base.ShootFromStandardGun(iDeltaT);
        }

        public override void Move(int iDeltaT)
        {
            CheckWheterTakeControlByComputer();

            if (mOwner == ETankOwner.Computer)
                SetDirectionToPlayerPosition();

            base.Move(iDeltaT);
        }

        public override void SetMoveDown(bool iMoveDown)
        {
            ResetOwnership();

            base.SetMoveDown(iMoveDown);
        }
        public override void SetMoveLeft(bool iMoveLeft)
        {
            ResetOwnership();

            base.SetMoveLeft(iMoveLeft);
        }
        public override void SetMoveRight(bool iMoveRight)
        {
            ResetOwnership();

            base.SetMoveRight(iMoveRight);
        }
        public override void SetMoveUp(bool iMoveUp)
        {
            ResetOwnership();

            base.SetMoveUp(iMoveUp);
        }


        private void ResetOwnership()
        {
            mOwner = ETankOwner.Player;

            mIsUsingWeapon = false;

            mAbsoluteTimeAfterWhichComputerTakesControl = DateTime.Now + new TimeSpan(0, 0, Settings.PROXY_TANK_TAKE_CONTROL_TIMEOUT_IN_SECONDS);
        }


        private void CheckWheterTakeControlByComputer()
        {
            if (mOwner == ETankOwner.Computer)
                return;

            if (mAbsoluteTimeAfterWhichComputerTakesControl < DateTime.Now)
                mOwner = ETankOwner.Computer;
        }

        private void SetDirectionToPlayerPosition()
        {
            ICTank playerTank = mController.ParentGameWindow.GetPlayerTank();

            int playerTankSize = playerTank.GetSize();
            if (mPosition.GetPosX() > playerTank.GetPosX() + playerTankSize)
            {
                base.SetMoveLeft(true);
            }
            else if(mPosition.GetPosX() < playerTank.GetPosX() - playerTankSize)
            {
                base.SetMoveRight(true);
            }

            if (mPosition.GetPosY() > playerTank.GetPosY() + playerTankSize)
            {
                base.SetMoveUp(true);
            }
            else if (mPosition.GetPosY() < playerTank.GetPosY() - playerTankSize)
            {
                base.SetMoveDown(true);
            }
        }
    }
}
