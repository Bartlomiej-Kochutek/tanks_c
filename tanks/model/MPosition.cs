using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tanks.common;

namespace tanks.model
{
    public class MPosition : MBasePositionable
    {
        int mPosX;
        int mPosY;



        public override int GetPosX()
        {
            return mPosX;
        }
        public override void SetPosX(int iPosX)
        {
            mPosX = iPosX;
        }

        public override int GetPosY()
        {
            return mPosY;
        }
        public override void SetPosY(int iPosY)
        {
            mPosY = iPosY;
        }
    }
}
