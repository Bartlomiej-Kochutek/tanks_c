using System.Collections.Generic;
using tanks.view;

namespace tanks.controller
{
    public interface ICTank
    {
        void Prepare();

        void Move(int iDeltaT);
        void UseWeapon(int iDeltaT);
        void CalculateWeaponUsages(
            float iDeltaT,
            CBoardElement[][] oBoardElements,
            LinkedList<ICTank> oTanks);

        void RedrawWithWeaponUsageEffect(CBoardElement[][] oBoardElements);



        CGameWindow ParentGameWindow { get ; set; }
        CHitPoints HitPoints { get; set; }
        VTank View { get; set; }

        int CanonPositionX();
        int CanonPositionY();

        int GetPosX();
        int GetPosY();
        int GetSize();
        EDirection GetDirection();

        void SetMoveDown(bool iMoveDown);
        void SetMoveLeft(bool iMoveLeft);
        void SetMoveRight(bool iMoveRight);
        void SetMoveUp(bool iMoveUp);

        bool IsUsingWeapon();
        void SetUsingWeapon(bool iUsingWeapon);

        bool IsDefeated();
    }
}
