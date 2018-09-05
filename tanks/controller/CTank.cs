using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CTank
    {
        private CGameWindow parentGameWindow;

        private MTank model;
        private VTank view;

        private LinkedList<CMissile> missiles;
        private CHitPoints hitPoints;

        private CBase mBase;



        public CTank()
        {
            model = new MTank();
            model.setController(this);

            view = new VTank();
            view.setController(this);

            hitPoints = new CHitPoints();
            hitPoints.setParentTank(this);

            mBase = new CBase();
            mBase.setParentTank(this);

            missiles = new LinkedList<CMissile>();
        }


        public void prepare()
        {
            model.prepare();
            view.prepare();

            mBase.prepare();
            mBase.draw();
        }

        public void redrawWithMissiles()
        {
            if (model.isDefeated())
                return;

            view.redraw(parentGameWindow.getChildBoard().getElements());
            view.redrawMissiles(parentGameWindow.getChildBoard().getElements());
        }


        public void shoot(int iDeltaT)
        {
            model.shoot(iDeltaT);
        }

        public void moveMissiles(float iDeltaT)
        {
            model.moveMissiles(iDeltaT);
        }

        public void checkMissilesCollision()
        {
            model.checkMissilesCollision();
        }

        public void move(int iDeltaT)
        {
            model.move(iDeltaT);
        }




        public VTank getView()
        {
            return view;
        }
        public void setView(VTank iView)
        {
            view = iView;
        }

        public controller.CGameWindow getParentGameWindow()
        {
            return parentGameWindow;
        }
        public void setParentGameWindow(CGameWindow iParent)
        {
            parentGameWindow = iParent;
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

        public int getSize()
        {
            return model.getSize();
        }
        public void setSize(int iSize)
        {
            model.setSize(iSize);
        }

        public EDirection getDirection()
        {
            return model.getDirection();
        }
        public void setDirection(EDirection iDirection)
        {
            model.setDirection(iDirection);
        }

        public int getSpeed()
        {
            return model.getSpeed();
        }
        public void setSpeed(int iSpeed)
        {
            model.setSpeed(iSpeed);
        }


        public bool isMoveDown()
        {
            return model.isMoveDown();
        }
        public void setMoveDown(bool iMoveDown)
        {
            model.setMoveDown(iMoveDown);
        }

        public bool isMoveLeft()
        {
            return model.isMoveLeft();
        }
        public void setMoveLeft(bool iMoveLeft)
        {
            model.setMoveLeft(iMoveLeft);
        }

        public bool isMoveRight()
        {
            return model.isMoveRight();
        }
        public void setMoveRight(bool iMoveRight)
        {
            model.setMoveRight(iMoveRight);
        }

        public bool isMoveUp()
        {
            return model.isMoveUp();
        }
        public void setMoveUp(bool iMoveUp)
        {
            model.setMoveUp(iMoveUp);
        }


        public bool isShooting()
        {
            return model.isShooting();
        }
        public void setShooting(bool iShooting)
        {
            model.setShooting(iShooting);
        }


        public LinkedList<CMissile> getMissiles()
        {
            return missiles;
        }
        public void setMissiles(LinkedList<CMissile> iMissiles)
        {
            missiles = iMissiles;
        }

        public CHitPoints getHitPoints()
        {
            return hitPoints;
        }
        public void setHitPoints(CHitPoints iHitPoints)
        {
            hitPoints = iHitPoints;
        }

        public bool isDefeated()
        {
            return model.isDefeated();
        }
        public void setDefeated(bool iDefeated)
        {
            model.setDefeated(iDefeated);
        }
    }
}
