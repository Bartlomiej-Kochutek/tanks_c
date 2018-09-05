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
            model.setController(this);

            view = new VBase();
            view.setController(this);
        }


        public void draw()
        {
            view.draw(parentTank.getParentGameWindow().getChildBoard().getElements());
        }

        public void prepare()
        {
            model.prepare();
        }




        public CTank getParentTank()
        {
            return parentTank;
        }
        public void setParentTank(CTank iParentTank)
        {
            parentTank = iParentTank;
        }

        public int getPosX()
        {
            return model.getPosX();
        }

        public int getPosY()
        {
            return model.getPosY();
        }

        public int getSize()
        {
            return model.getSize();
        }
    }
}
