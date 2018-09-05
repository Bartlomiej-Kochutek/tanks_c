using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.controller;


namespace tanks.model
{
    class MTank
    {
        private CTank controller;

        private const int DELTA_T_SCALE = 100;
        private const int SHOOTING_INTERVAL = 100;

        private const int DEFAULT_POS_X = 0;
        private const int DEFAULT_POS_Y = 0;
        private float posX;
        private float posY;

        private int maxPos;

        private const int DEFAULT_SPEED = 1;
        private int speed;

        private const int DEFAULT_SIZE = 5;
        private int size;

        private EDirection direction;

        private bool mMoveDown;
        private bool mMoveLeft;
        private bool mMoveRight;
        private bool mMoveUp;

        private bool shooting;
        private int lastShootDelta;

        private bool defeated;



        public MTank()
        {
            size = DEFAULT_SIZE;

            posX = DEFAULT_POS_X;
            posY = DEFAULT_POS_Y;
            speed = DEFAULT_SPEED;

            direction = EDirection.UP;

            mMoveDown = false;
            mMoveLeft = false;
            mMoveRight = false;
            mMoveUp = false;

            shooting = false;

            lastShootDelta = 0;

            defeated = false;
        }


        public void prepare()
        {
            maxPos = controller.getParentGameWindow().getChildBoard().getSize() - size;
        }


        public void shoot(int iDeltaT)
        {
            if (!shooting)
                return;

            lastShootDelta += iDeltaT;
            if (lastShootDelta < SHOOTING_INTERVAL)
                return;

            lastShootDelta %= SHOOTING_INTERVAL;

            controller.getMissiles().AddLast(new CMissile(
                controller,
                canonPositionX(),
                canonPositionY(),
                direction));
        }

        public void moveMissiles(float iDeltaT)
        {
            float deltaPos = iDeltaT / DELTA_T_SCALE;
            const float FASTER_THAN_TANK = (float)1.5;

            foreach (CMissile cMissile in controller.getMissiles())
            {
                cMissile.move(FASTER_THAN_TANK * deltaPos);
            }
        }

        public void checkMissilesCollision()
        {
            if (controller.getParentGameWindow().isAtLeastOneTankDeafeated())
            {
                controller.getMissiles().Clear();
                return;
            }

            LinkedListNode<CMissile> iterator = controller.getMissiles().First;
            while (iterator != null)
            {
                bool collisionOccured = iterator.Value.collision();
                if (collisionOccured)
                {
                    controller.getMissiles().Remove(iterator.Value);
                }
                iterator = iterator.Next;
            }
        }

        public void move(int iDeltaT)
        {
            float deltaPos = (float)iDeltaT / DELTA_T_SCALE;

            if (mMoveDown)
                moveDown(deltaPos);

            if (mMoveLeft)
                moveLeft(deltaPos);

            if (mMoveRight)
                moveRight(deltaPos);

            if (mMoveUp)
                moveUp(deltaPos);
        }

        private void moveDown(float iDeltaPos)
        {
            direction = EDirection.DOWN;

            if (verticalCollisionWithBaseWall(controller.getSize()))
                return;

            posY += iDeltaPos;
            correctPosY();
        }
        private void moveLeft(float iDeltaPos)
        {
            direction = EDirection.LEFT;

            if (horizontalCollisionWithBaseWall(-1))
                return;

            posX -= iDeltaPos;
            correctPosX();
        }
        private void moveRight(float iDeltaPos)
        {
            direction = EDirection.RIGHT;

            if (horizontalCollisionWithBaseWall(controller.getSize()))
                return;

            posX += iDeltaPos;
            correctPosX();
        }
        private void moveUp(float iDeltaPos)
        {
            direction = EDirection.UP;

            if (verticalCollisionWithBaseWall(-1))
                return;

            posY -= iDeltaPos;
            correctPosY();
        }

        private bool verticalCollisionWithBaseWall(int iYDisplacement)
        {
            CBoardElement[][] boardElements = controller.getParentGameWindow().getChildBoard().getElements();

            for (int xDisplacement = 0; xDisplacement < controller.getSize(); xDisplacement++)
            {
                int xIndex = (int)posX + xDisplacement;
                int yIndex = (int)posY + iYDisplacement;

                if (CGameBoard.IndicesOutsideWindow(xIndex, yIndex, boardElements.Length))
                    continue;

                if (boardElements[xIndex][yIndex].isBaseWall())
                    return true;
            }
            return false;
        }
        private bool horizontalCollisionWithBaseWall(int iXDisplacement)
        {
            CBoardElement[][] boardElements = controller.getParentGameWindow().getChildBoard().getElements();

            for (int yDisplacement = 0; yDisplacement < controller.getSize(); yDisplacement++)
            {
                int xIndex = (int)posX + iXDisplacement;
                int yIndex = (int)posY + yDisplacement;

                if (CGameBoard.IndicesOutsideWindow(xIndex, yIndex, boardElements.Length))
                    continue;

                if (boardElements[xIndex][yIndex].isBaseWall())
                    return true;
            }
            return false;
        }

        private void correctPosY()
        {
            if (posY < 0)
                posY = 0;

            if (posY > maxPos)
                posY = maxPos;
        }
        private void correctPosX()
        {
            if (posX < 0)
                posX = 0;

            if (posX > maxPos)
                posX = maxPos;
        }


        private int canonPositionX()
        {
            switch (direction)
            {
                case EDirection.DOWN:
                    return (int)posX + size / 2;
                case EDirection.LEFT:
                    return (int)posX;
                case EDirection.RIGHT:
                    return (int)posX + size;
                case EDirection.UP:
                    return (int)posX + size / 2;
                default:
                    return 0;
            }
        }
        private int canonPositionY()
        {
            switch (direction)
            {
                case EDirection.DOWN:
                    return (int)posY + size;
                case EDirection.LEFT:
                    return (int)posY + size / 2;
                case EDirection.RIGHT:
                    return (int)posY + size / 2;
                case EDirection.UP:
                    return (int)posY;
                default:
                    return 0;
            }
        }




        public void setController(CTank iController)
        {
            controller = iController;
        }
        public CTank getController()
        {
            return controller;
        }

        public int getPosX()
        {
            return (int)posX;
        }
        public void setPosX(int iPosX)
        {
            posX = iPosX;
            if (posX < 0)
                posX = DEFAULT_POS_X;
        }


        public int getPosY()
        {
            return (int)posY;
        }
        public void setPosY(int iPosY)
        {
            posY = iPosY;
            if (posY < 0)
                posY = DEFAULT_POS_Y;
        }

        public int getSize()
        {
            return size;
        }
        public void setSize(int iSize)
        {
            size = iSize;
            if (size <= 0)
                size = DEFAULT_SIZE;
        }

        public EDirection getDirection()
        {
            return direction;
        }
        public void setDirection(EDirection iDirection)
        {
            direction = iDirection;
        }

        public int getSpeed()
        {
            return speed;
        }
        public void setSpeed(int iSpeed)
        {
            speed = iSpeed;
            if (speed <= 0)
                speed = DEFAULT_SPEED;
        }


        public bool isMoveDown()
        {
            return mMoveDown;
        }
        public void setMoveDown(bool iMoveDown)
        {
            mMoveDown = iMoveDown;
            if (mMoveDown == true)
                mMoveUp = false;
        }

        public bool isMoveLeft()
        {
            return mMoveLeft;
        }
        public void setMoveLeft(bool iMoveLeft)
        {
            mMoveLeft = iMoveLeft;
            if (mMoveLeft == true)
                mMoveRight = false;
        }

        public bool isMoveRight()
        {
            return mMoveRight;
        }
        public void setMoveRight(bool iMoveRight)
        {
            mMoveRight = iMoveRight;
            if (mMoveRight == true)
                mMoveLeft = false;
        }

        public bool isMoveUp()
        {
            return mMoveUp;
        }
        public void setMoveUp(bool iMoveUp)
        {
            mMoveUp = iMoveUp;
            if (mMoveUp == true)
                mMoveDown = false;
        }


        public bool isShooting()
        {
            return shooting;
        }
        public void setShooting(bool iShooting)
        {
            shooting = iShooting;
        }

        public bool isDefeated()
        {
            return defeated;
        }
        public void setDefeated(bool iDefeated)
        {
            defeated = iDefeated;
        }
    }
}
