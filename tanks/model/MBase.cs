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


        public void prepare()
        {
            halfOfSize = size / 2;

            CTank parentTank = controller.getParentTank();

            int halfOfSizeDifference = halfOfSize - parentTank.getSize() / 2;
            posX = parentTank.getPosX() - halfOfSizeDifference;
            posY = parentTank.getPosY() - halfOfSizeDifference;
        }






        public CBase getController()
        {
            return controller;
        }
        public void setController(CBase iController)
        {
            controller = iController;
        }

        public int getPosX()
        {
            return posX;
        }
        public void setPosX(int iPosX)
        {
            posX = iPosX;
        }

        public int getPosY()
        {
            return posY;
        }
        public void setPosY(int iPosY)
        {
            posY = iPosY;
        }

        public int getSize()
        {
            return size;
        }
        public void setSize(int iSize)
        {
            size = iSize;
            halfOfSize = size / 2;
        }

        public int getHalfOfSize()
        {
            return halfOfSize;
        }
    }
}
