using tanks.common;
using tanks.model;

namespace tanks.controller
{
    class CBaseBonus : IPositionable
    {
        protected MBaseBonus mModel;



        protected CBaseBonus(MBaseBonus iModel)
        {
            mModel = iModel;
        }



        public int GetPosX()
        {
            return mModel.GetPosX();
        }
        public void SetPosX(int iPosX)
        {
            mModel.SetPosX(iPosX);
        }

        public int GetPosY()
        {
            return mModel.GetPosY();
        }
        public void SetPosY(int iPosY)
        {
            mModel.SetPosY(iPosY);
        }
    }
}
