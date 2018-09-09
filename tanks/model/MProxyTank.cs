using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tanks.controller;

namespace tanks.model
{
    public class MProxyTank : MTank
    {
        ETankOwner owner;
        DateTime absoluteTimeAfterWhichComputerTakesControl;

        const int TAKE_CONTROL_TIMEOUT = 8;


        public MProxyTank(
            int iPosX,
            int iPosY,
            ETankOwner iTankOwner) :
            base(iPosX, iPosY)
        {
            owner = ETankOwner.Player;

            absoluteTimeAfterWhichComputerTakesControl = DateTime.Now;

            TimeSpan relativeTimeAfterWhichComputerTakesControl;

            if (iTankOwner == ETankOwner.Player)
                relativeTimeAfterWhichComputerTakesControl = new TimeSpan(0, 0, TAKE_CONTROL_TIMEOUT);
            else
                relativeTimeAfterWhichComputerTakesControl = new TimeSpan(0, 0, 1);

            absoluteTimeAfterWhichComputerTakesControl += relativeTimeAfterWhichComputerTakesControl;
        }


        public override void Shoot(int iDeltaT)
        {
            if (owner == ETankOwner.Computer)
                shooting = true;

            base.Shoot(iDeltaT);
        }

        public override void Move(int iDeltaT)
        {
            CheckWheterTakeControlByComputer();

            if (owner == ETankOwner.Computer)
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
            owner = ETankOwner.Player;

            shooting = false;

            absoluteTimeAfterWhichComputerTakesControl = DateTime.Now + new TimeSpan(0, 0, TAKE_CONTROL_TIMEOUT);
        }


        private void CheckWheterTakeControlByComputer()
        {
            if (owner == ETankOwner.Computer)
                return;

            if (absoluteTimeAfterWhichComputerTakesControl < DateTime.Now)
                owner = ETankOwner.Computer;
        }

        private void SetDirectionToPlayerPosition()
        {
            CTank playerTank = ((CTankProxy)controller).PlayerTank;

            int playerTankSize = playerTank.GetSize();
            if (posX > playerTank.GetPosX() + playerTankSize)
            {
                base.SetMoveLeft(true);
            }
            else if(posX < playerTank.GetPosX() - playerTankSize)
            {
                base.SetMoveRight(true);
            }

            if (posY > playerTank.GetPosY() + playerTankSize)
            {
                base.SetMoveUp(true);
            }
            else if (posY < playerTank.GetPosY() - playerTankSize)
            {
                base.SetMoveDown(true);
            }
        }
    }
}
