using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.controller;


namespace tanks.model
{
    class MFortress
    {
        private CFortress mController;

        private int mPosX;
        private int mPosY;

        private const int DEFAULT_SIZE = 16;
        private int mSize;
        private int mHalfOfSize;



        public MFortress()
        {
            mSize = DEFAULT_SIZE;
        }


        public void Prepare()
        {
            mHalfOfSize = mSize / 2;

            CTank parentTank = mController.ParentTank;

            int halfOfSizeDifference = mHalfOfSize - parentTank.GetSize() / 2;
            mPosX = parentTank.GetPosX() - halfOfSizeDifference;
            mPosY = parentTank.GetPosY() - halfOfSizeDifference;
        }






        public CFortress Controller { get => mController; set => mController = value; }

        public int PosX { get => mPosX; set => mPosX = value; }

        public int PosY { get => mPosY; set => mPosY = value; }
        public int PosY1 { get => mPosY; set => mPosY = value; }

        public int GetSize()
        {
            return mSize;
        }
        public void SetSize(int iSize)
        {
            mSize = iSize;
            mHalfOfSize = mSize / 2;
        }

        public int GetHalfOfSize()
        {
            return mHalfOfSize;
        }
    }
}
