using tanks.common;

namespace tanks.model
{
    class MBaseBonus : IPositionable
    {
        protected MPosition mPosition = new MPosition();



        protected MBaseBonus()
        {

        }



        public int GetPosX()
        {
            return mPosition.GetPosX();
        }
        public void SetPosX(int iPosX)
        {
            mPosition.SetPosX(iPosX);
        }

        public int GetPosY()
        {
            return mPosition.GetPosY();
        }
        public void SetPosY(int iPosY)
        {
            mPosition.SetPosY(iPosY);
        }
    }
}
