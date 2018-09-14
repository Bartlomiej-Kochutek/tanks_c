using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tanks.controller;

namespace tanks.common
{
    public abstract class Algorithm
    {
        public static bool IndicesOutsideWindow(
               int iXIndex,
               int iYIndex)
        {
            bool indicesOutsideWindow = (iXIndex < 0 || iXIndex >= Settings.GAME_BOARD_SIZE ||
                                         iYIndex < 0 || iYIndex >= Settings.GAME_BOARD_SIZE);
            return indicesOutsideWindow;
        }

        public static bool CollisionWithOtherTanks(
            ICTank iTank,
            LinkedList<ICTank> oTanks,
            int iPosXInt,
            int iPosYInt,
            int iDamage,
            bool iDoDamage)
        {
            if (IndicesOutsideWindow(iPosXInt, iPosYInt))
                return false;

            foreach (ICTank tank in oTanks)
            {
                if (tank == iTank)
                    continue;

                if (tank.GetPosX() > iPosXInt || tank.GetPosX() + tank.GetSize() <= iPosXInt ||
                    tank.GetPosY() > iPosYInt || tank.GetPosY() + tank.GetSize() <= iPosYInt)
                    continue;

                if (iDoDamage)
                    tank.HitPoints.TakeDamagedFromMissile(iDamage);

                return true;
            }
            return false;
        }

        public static void RedrawMissiles(
            CBoardElement[][] oElements,
            LinkedList<CMissile> iMissiles)
        {
            foreach (CMissile cMissile in iMissiles)
            {
                if (!IndicesOutsideWindow(cMissile.GetPosX(), cMissile.GetPosY()))
                    oElements[cMissile.GetPosX()][cMissile.GetPosY()].SetMissile(true);
            }
        }

    }
}
