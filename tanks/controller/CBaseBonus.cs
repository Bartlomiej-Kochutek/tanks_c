using tanks.common;
using tanks.model;
using tanks.view;

namespace tanks.controller
{
    public class CBaseBonus : IPositionable
    {
        protected MBaseBonus mModel;
        protected VBaseBonus mView;



        protected CBaseBonus(MBaseBonus iModel)
        {
            mModel = iModel;

            mView = new VBaseBonus(this);
        }



        public void Redraw(CBoardElement[][] oBoardElements)
        {
            mView.Redraw(oBoardElements);
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

        public int GetSize()
        {
            return mModel.GetSize();
        }

        public void SetSize(int iSize)
        {
            mModel.SetSize(iSize);
        }
    }
}
