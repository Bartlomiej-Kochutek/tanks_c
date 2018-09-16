using System.Drawing;
using tanks.common;
using tanks.controller;

namespace tanks.view
{
    public class VBaseBonus
    {
        private CBaseBonus mController;



        public VBaseBonus(CBaseBonus iController)
        {
            mController = iController;
        }

        public void Redraw(CBoardElement[][] oBoardElements)
        {
            for (int x = 0; x < mController.GetSize(); x++)
            {
                for (int y = 0; y < mController.GetSize(); y++)
                {
                    if (!Algorithm.IndicesOutsideWindow(x, y))
                        oBoardElements[mController.GetPosX() + x][mController.GetPosY() + y].SetBonus(true);
                }
            }
        }
    }
}
