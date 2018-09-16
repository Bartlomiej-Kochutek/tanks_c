
using tanks.common;
using tanks.controller;


namespace tanks.model
{
    class MFortress : IPositionable
    {
        private CFortress mController;

        protected MPosition mPosition = new MPosition();
        
        private int mHalfOfSize;



        public MFortress()
        {
            mPosition.SetSize(Settings.DEFAULT_FORTRESS_SIZE);
        }



        public void Prepare()
        {
            mHalfOfSize = mPosition.GetSize() / 2;

            CTank parentTank = mController.ParentTank;

            int halfOfSizeDifference = mHalfOfSize - parentTank.GetSize() / 2;
            mPosition.SetPosX(parentTank.GetPosX() - halfOfSizeDifference);
            mPosition.SetPosY(parentTank.GetPosY() - halfOfSizeDifference);
        }



        public CFortress Controller { get => mController; set => mController = value; }

        public int GetSize()
        {
            return mPosition.GetSize();
        }
        public void SetSize(int iSize)
        {
            mPosition.SetSize(iSize);
            mHalfOfSize = mPosition.GetSize() / 2;
        }

        public int GetHalfOfSize()
        {
            return mHalfOfSize;
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
