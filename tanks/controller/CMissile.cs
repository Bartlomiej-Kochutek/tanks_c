using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CMissile
    {
        private CTank parentTank;

        private MMissile model;



        public CMissile(
            CTank iParentTank,
            int iPosX,
            int iPosY,
            EDirection iDirection)
        {
            parentTank = iParentTank;

            model = new MMissile();
            model.setController(this);

            model.setPosX(iPosX);
            model.setPosY(iPosY);
            model.setDirection(iDirection);
        }


        public void move(float iDeltaPos)
        {
            float deltaPos = iDeltaPos;
            const float MAX_DELTA_POS = 1;
            if (deltaPos > MAX_DELTA_POS)
                deltaPos = MAX_DELTA_POS;

            model.move(deltaPos);
        }

        public bool collision()
        {
            return model.collision();
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
        public void setPosX(int iPosX)
        {
            model.setPosX(iPosX);
        }

        public int getPosY()
        {
            return model.getPosY();
        }
        public void setPosY(int iPosY)
        {
            model.setPosY(iPosY);
        }

        public EDirection getDirection()
        {
            return model.getDirection();
        }
        public void setDirection(EDirection iDirection)
        {
            model.setDirection(iDirection);
        }

        public int getDamage()
        {
            return model.getDamage();
        }
        public void setDamage(int iDamage)
        {
            model.setDamage(iDamage);
        }
    }
}
