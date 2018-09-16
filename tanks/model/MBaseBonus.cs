using tanks.common;

namespace tanks.model
{
    public class MBaseBonus : IPositionable
    {
        protected MPosition mPosition = new MPosition();



        protected MBaseBonus()
        {
            mPosition.SetSize(Settings.DEFAULT_BONUS_SIZE);
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

        public int GetSize()
        {
            return mPosition.GetSize();
        }

        public void SetSize(int iSize)
        {
            mPosition.SetSize(iSize);
        }
    }
}
