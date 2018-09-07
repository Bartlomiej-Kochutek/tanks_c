using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.controller;


namespace tanks.model
{
    class MBase
    {
        private CBase controller;

        private int posX;
        private int posY;

        private const int DEFAULT_SIZE = 16;
        private int size;
        private int halfOfSize;



        public MBase()
        {
            size = DEFAULT_SIZE;
        }


        public void Prepare()
        {
            halfOfSize = size / 2;

            CTank parentTank = controller.ParentTank;

            int halfOfSizeDifference = halfOfSize - parentTank.GetSize() / 2;
            posX = parentTank.GetPosX() - halfOfSizeDifference;
            posY = parentTank.GetPosY() - halfOfSizeDifference;
        }






        public CBase Controller { get => controller; set => controller = value; }

        public int PosX { get => posX; set => posX = value; }

        public int PosY { get => posY; set => posY = value; }
        public int PosY1 { get => posY; set => posY = value; }

        public int GetSize()
        {
            return size;
        }
        public void SetSize(int iSize)
        {
            size = iSize;
            halfOfSize = size / 2;
        }

        public int GetHalfOfSize()
        {
            return halfOfSize;
        }
    }
}
