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


        public void Prepare()
        {
            maxPos = controller.ParentGameWindow.ChildBoard.GetSize() - size;
        }


        public void Shoot(int iDeltaT)
        {
            if (!shooting)
                return;

            lastShootDelta += iDeltaT;
            if (lastShootDelta < SHOOTING_INTERVAL)
                return;

            lastShootDelta %= SHOOTING_INTERVAL;

            controller.Missiles.AddLast(new CMissile(
                controller,
                CanonPositionX(),
                CanonPositionY(),
                direction));
        }

        public void MoveMissiles(float iDeltaT)
        {
            float deltaPos = iDeltaT / DELTA_T_SCALE;
            const float FASTER_THAN_TANK = (float)1.5;

            foreach (CMissile cMissile in controller.Missiles)
            {
                cMissile.Move(FASTER_THAN_TANK * deltaPos);
            }
        }

        public void CheckMissilesCollision()
        {
            if (controller.ParentGameWindow.IsAtLeastOneTankDeafeated())
            {
                controller.Missiles.Clear();
                return;
            }

            LinkedListNode<CMissile> iterator = controller.Missiles.First;
            while (iterator != null)
            {
                bool collisionOccured = iterator.Value.Collision();
                if (collisionOccured)
                {
                    controller.Missiles.Remove(iterator.Value);
                }
                iterator = iterator.Next;
            }
        }

        public void Move(int iDeltaT)
        {
            float deltaPos = (float)iDeltaT / DELTA_T_SCALE;

            if (mMoveDown)
                MoveDown(deltaPos);

            if (mMoveLeft)
                MoveLeft(deltaPos);

            if (mMoveRight)
                MoveRight(deltaPos);

            if (mMoveUp)
                MoveUp(deltaPos);
        }

        private void MoveDown(float iDeltaPos)
        {
            direction = EDirection.DOWN;

            if (VerticalCollisionWithBaseWall(controller.GetSize()))
                return;

            posY += iDeltaPos;
            CorrectPosY();
        }
        private void MoveLeft(float iDeltaPos)
        {
            direction = EDirection.LEFT;

            if (HorizontalCollisionWithBaseWall(-1))
                return;

            posX -= iDeltaPos;
            CorrectPosX();
        }
        private void MoveRight(float iDeltaPos)
        {
            direction = EDirection.RIGHT;

            if (HorizontalCollisionWithBaseWall(controller.GetSize()))
                return;

            posX += iDeltaPos;
            CorrectPosX();
        }
        private void MoveUp(float iDeltaPos)
        {
            direction = EDirection.UP;

            if (VerticalCollisionWithBaseWall(-1))
                return;

            posY -= iDeltaPos;
            CorrectPosY();
        }

        private bool VerticalCollisionWithBaseWall(int iYDisplacement)
        {
            CBoardElement[][] boardElements = controller.ParentGameWindow.ChildBoard.Elements;

            for (int xDisplacement = 0; xDisplacement < controller.GetSize(); xDisplacement++)
            {
                int xIndex = (int)posX + xDisplacement;
                int yIndex = (int)posY + iYDisplacement;

                if (CGameBoard.IndicesOutsideWindow(xIndex, yIndex, boardElements.Length))
                    continue;

                if (boardElements[xIndex][yIndex].IsBaseWall())
                    return true;
            }
            return false;
        }
        private bool HorizontalCollisionWithBaseWall(int iXDisplacement)
        {
            CBoardElement[][] boardElements = controller.ParentGameWindow.ChildBoard.Elements;

            for (int yDisplacement = 0; yDisplacement < controller.GetSize(); yDisplacement++)
            {
                int xIndex = (int)posX + iXDisplacement;
                int yIndex = (int)posY + yDisplacement;

                if (CGameBoard.IndicesOutsideWindow(xIndex, yIndex, boardElements.Length))
                    continue;

                if (boardElements[xIndex][yIndex].IsBaseWall())
                    return true;
            }
            return false;
        }

        private void CorrectPosY()
        {
            if (posY < 0)
                posY = 0;

            if (posY > maxPos)
                posY = maxPos;
        }
        private void CorrectPosX()
        {
            if (posX < 0)
                posX = 0;

            if (posX > maxPos)
                posX = maxPos;
        }


        private int CanonPositionX()
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
        private int CanonPositionY()
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




        public void SetController(CTank iController)
        {
            controller = iController;
        }
        public CTank GetController()
        {
            return controller;
        }

        public int GetPosX()
        {
            return (int)posX;
        }
        public void SetPosX(int iPosX)
        {
            posX = iPosX;
            if (posX < 0)
                posX = DEFAULT_POS_X;
        }


        public int GetPosY()
        {
            return (int)posY;
        }
        public void SetPosY(int iPosY)
        {
            posY = iPosY;
            if (posY < 0)
                posY = DEFAULT_POS_Y;
        }

        public int GetSize()
        {
            return size;
        }
        public void SetSize(int iSize)
        {
            size = iSize;
            if (size <= 0)
                size = DEFAULT_SIZE;
        }

        public EDirection Direction { get => direction; set => direction = value; }

        public int GetSpeed()
        {
            return speed;
        }
        public void SetSpeed(int iSpeed)
        {
            speed = iSpeed;
            if (speed <= 0)
                speed = DEFAULT_SPEED;
        }


        public bool IsMoveDown()
        {
            return mMoveDown;
        }
        public void SetMoveDown(bool iMoveDown)
        {
            mMoveDown = iMoveDown;
            if (mMoveDown == true)
                mMoveUp = false;
        }

        public bool IsMoveLeft()
        {
            return mMoveLeft;
        }
        public void SetMoveLeft(bool iMoveLeft)
        {
            mMoveLeft = iMoveLeft;
            if (mMoveLeft == true)
                mMoveRight = false;
        }

        public bool IsMoveRight()
        {
            return mMoveRight;
        }
        public void SetMoveRight(bool iMoveRight)
        {
            mMoveRight = iMoveRight;
            if (mMoveRight == true)
                mMoveLeft = false;
        }

        public bool IsMoveUp()
        {
            return mMoveUp;
        }
        public void SetMoveUp(bool iMoveUp)
        {
            mMoveUp = iMoveUp;
            if (mMoveUp == true)
                mMoveDown = false;
        }


        public bool IsShooting()
        {
            return shooting;
        }
        public void SetShooting(bool iShooting)
        {
            shooting = iShooting;
        }

        public bool IsDefeated()
        {
            return defeated;
        }
        public void SetDefeated(bool iDefeated)
        {
            defeated = iDefeated;
        }
    }
}
