using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    class CBase
    {
        private CTank parentTank;

        private MBase model;
        private VBase view;



        public CBase()
        {
            model = new MBase();
            model.Controller = (this);

            view = new VBase();
            view.Controller = (this);
        }


        public void Draw()
        {
            view.Draw(parentTank.ParentGameWindow.ChildBoard.Elements);
        }

        public void Prepare()
        {
            model.Prepare();
        }




        public CTank ParentTank { get => parentTank; set => parentTank = value; }

        public int GetPosX()
        {
            return model.PosX;
        }

        public int GetPosY()
        {
            return model.PosY;
        }

        public int GetSize()
        {
            return model.GetSize();
        }
    }
}
