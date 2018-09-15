using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tanks.common;

namespace tanks.model
{
    class MPosition : IPositionable
    {
        int mPosX;
        int mPosY;



        public int GetPosX()
        {
            return mPosX;
        }
        public void SetPosX(int iPosX)
        {
            mPosX = iPosX;
        }

        public int GetPosY()
        {
            return mPosY;
        }
        public void SetPosY(int iPosY)
        {
            mPosY = iPosY;
        }
    }
}
