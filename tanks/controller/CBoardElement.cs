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
            view.Controller = this;
        }





        public MBoardElement Model { get => model; set => model = value; }

        public VBoardElement View { get => view; set => view = value; }

        public bool IsDestroyed()
        {
            return model.IsDestroyed;
        }
        public void SetDestroyed(bool iIsDestroyed)
        {
            model.IsDestroyed = iIsDestroyed;
        }

        public bool IsTank()
        {
            return model.IsTank;
        }
        public void SetTank(bool iIsTank)
        {
            model.IsTank = iIsTank;
        }

        public bool IsCanon()
        {
            return model.IsCanon;
        }
        public void SetCanon(bool iIsCanon)
        {
            model.IsCanon = iIsCanon;
        }

        public bool IsMissile()
        {
            return model.IsMissile;
        }
        public void SetMissile(bool iIsMissile)
        {
            model.IsMissile = iIsMissile;
        }

        public bool IsBaseWall()
        {
            return model.IsBaseWall;
        }
        public void SetBaseWall(bool iIsBaseWall)
        {
            model.IsBaseWall = iIsBaseWall;
        }
    }
}
