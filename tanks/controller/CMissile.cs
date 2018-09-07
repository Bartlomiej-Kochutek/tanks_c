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
            model.Controller = (this);

            model.SetPosX(iPosX);
            model.SetPosY(iPosY);
            model.Direction = iDirection;
        }


        public void Move(float iDeltaPos)
        {
            float deltaPos = iDeltaPos;
            const float MAX_DELTA_POS = 1;
            if (deltaPos > MAX_DELTA_POS)
                deltaPos = MAX_DELTA_POS;

            model.Move(deltaPos);
        }

        public bool Collision()
        {
            return model.Collision();
        }




        public CTank ParentTank { get => parentTank; set => parentTank = value; }

        public int GetPosX()
        {
            return model.GetPosX();
        }
        public void SetPosX(int iPosX)
        {
            model.SetPosX(iPosX);
        }

        public int GetPosY()
        {
            return model.GetPosY();
        }
        public void SetPosY(int iPosY)
        {
            model.SetPosY(iPosY);
        }

        public EDirection GetDirection()
        {
            return model.Direction;
        }
        public void SetDirection(EDirection iDirection)
        {
            model.Direction = iDirection;
        }

        public int GetDamage()
        {
            return model.GetDamage();
        }
        public void SetDamage(int iDamage)
        {
            model.SetDamage(iDamage);
        }
    }
}
