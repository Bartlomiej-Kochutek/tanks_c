using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tanks.view;

namespace tanks.controller
{
    public interface ICTank
    {
        CHitPoints HitPoints { get; set; }
        VTank View { get; set; }

        void Move(int iDeltaT);
        void UseWeapon(int iDeltaT);
        void MoveMissiles(float iDeltaT);
        void CheckMissilesCollision();

        void RedrawWithMissiles();

        int GetPosX();
        int GetPosY();
        int GetSize();

        void SetMoveDown(bool iMoveDown);
        void SetMoveLeft(bool iMoveLeft);
        void SetMoveRight(bool iMoveRight);
        void SetMoveUp(bool iMoveUp);
        void SetShooting(bool iShooting);
    }
}
