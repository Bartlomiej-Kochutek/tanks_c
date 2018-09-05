using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Drawing;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CBoardElement
    {
        private MBoardElement model;
        private VBoardElement view;



        public CBoardElement(Color iColor)
        {
            model = new MBoardElement();
            model.Controller = this;

            view = new VBoardElement(iColor);
            view.setController(this);
        }





        public MBoardElement getModel()
        {
            return model;
        }
        public void setModel(MBoardElement iModel)
        {
            model = iModel;
        }

        public VBoardElement getView()
        {
            return view;
        }
        public void setView(VBoardElement iView)
        {
            view = iView;
        }


        public bool isDestroyed()
        {
            return model.IsDestroyed;
        }
        public void setDestroyed(bool iIsDestroyed)
        {
            model.IsDestroyed = iIsDestroyed;
        }

        public bool isTank()
        {
            return model.IsTank;
        }
        public void setTank(bool iIsTank)
        {
            model.IsTank = iIsTank;
        }

        public bool isCanon()
        {
            return model.IsCanon;
        }
        public void setCanon(bool iIsCanon)
        {
            model.IsCanon = iIsCanon;
        }

        public bool isMissile()
        {
            return model.IsMissile;
        }
        public void setMissile(bool iIsMissile)
        {
            model.IsMissile = iIsMissile;
        }

        public bool isBaseWall()
        {
            return model.IsBaseWall;
        }
        public void setBaseWall(bool iIsBaseWall)
        {
            model.IsBaseWall = iIsBaseWall;
        }
    }
}
