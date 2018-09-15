using tanks.common;

namespace tanks.model
{
    public class MPrecisePosition : IPositionable
    {
        private double mPosX;
        private double mPosY;



        public int GetPosX()
        {
            return (int)mPosX;
        }
        public void SetPosX(int iPosX)
        {
            mPosX = iPosX;
        }

        public int GetPosY()
        {
            return (int)mPosY;
        }
        public void SetPosY(int iPosY)
        {
            mPosY = iPosY;
        }


        public double GetPrecisePosX()
        {
            return mPosX;
        }
        public void SetPrecisePosX(double iPosX)
        {
            mPosX = iPosX;
        }

        public double GetPrecisePosY()
        {
            return mPosY;
        }
        public void SetPrecisePosY(double iPosY)
        {
            mPosY = iPosY;
        }
    }
}
