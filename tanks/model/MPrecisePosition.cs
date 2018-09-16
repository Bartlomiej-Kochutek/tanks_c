using tanks.common;

namespace tanks.model
{
    public class MPrecisePosition : MBasePositionable
    {
        private double mPosX;
        private double mPosY;



        public override int GetPosX()
        {
            return (int)mPosX;
        }
        public override void SetPosX(int iPosX)
        {
            mPosX = iPosX;
        }

        public override int GetPosY()
        {
            return (int)mPosY;
        }
        public override void SetPosY(int iPosY)
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
