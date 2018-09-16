
using tanks.common;
using tanks.model;
using tanks.view;


namespace tanks.controller
{
    class CFortress : IPositionable
    {
        private CTank mParentTank;

        private MFortress mModel;
        private VFortress mView;



        public CFortress()
        {
            mModel = new MFortress();
            mModel.Controller = this;

            mView = new VFortress();
            mView.Controller = this;
        }



        public void Draw()
        {
            mView.Draw(mParentTank.ParentGameWindow.ChildBoard.Elements);
        }

        public void Prepare()
        {
            mModel.Prepare();
        }




        public CTank ParentTank { get => mParentTank; set => mParentTank = value; }

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
