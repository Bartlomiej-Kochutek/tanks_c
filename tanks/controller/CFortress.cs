using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    class CFortress
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
            return mModel.PosX;
        }

        public int GetPosY()
        {
            return mModel.PosY;
        }

        public int GetSize()
        {
            return mModel.GetSize();
        }
    }
}
