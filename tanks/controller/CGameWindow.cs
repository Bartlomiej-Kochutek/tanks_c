using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CGameWindow
    {
        private MGameWindow model;
        private VGameWindow view;

        private CGameBoard childBoard;
        private LinkedList<CTank> childTanks;

        private const Keys FIRST_TANK_MOVE_DOWN = Keys.S;
        private const Keys FIRST_TANK_MOVE_LEFT = Keys.A;
        private const Keys FIRST_TANK_MOVE_RIGHT = Keys.D;
        private const Keys FIRST_TANK_MOVE_UP = Keys.W;
        private const Keys FIRST_TANK_SHOOT = Keys.ControlKey;

        private const Keys SECOND_TANK_MOVE_DOWN = Keys.Down;
        private const Keys SECOND_TANK_MOVE_LEFT = Keys.Left;
        private const Keys SECOND_TANK_MOVE_RIGHT = Keys.Right;
        private const Keys SECOND_TANK_MOVE_UP = Keys.Up;
        private const Keys SECOND_TANK_SHOOT = Keys.Oemcomma;

        private bool gameStarted;



        public CGameWindow()
        {
            model = new MGameWindow();
            model.setController(this);

            view = new VGameWindow();
            view.setController(this);

            childBoard = new CGameBoard();
            childBoard.setParentGameWindow(this);

            childTanks = new LinkedList<CTank>();
            childTanks.AddLast(new CTank());
            childTanks.AddLast(new CTank());

            gameStarted = false;
        }


        public void start()
        {
            childBoard.Prepare();

            foreach (CTank cTank in childTanks)
            {
                cTank.setParentGameWindow(this);
                cTank.prepare();
            }

            view.prepareDisplay();

            gameStarted = true;
        }

        public void DoNextGameLoopIteration()
        {
            if (!gameStarted)
                return;

            UpdateWithDeltaT();
            OnRedraw();
        }

        private void UpdateWithDeltaT()
        {
            int deltaT = model.milisecsDelta();

            foreach (CTank cTank in childTanks)
            {
                cTank.move(deltaT);
                cTank.shoot(deltaT);
                cTank.moveMissiles(deltaT);
                cTank.checkMissilesCollision();
            }
        }

        private void OnRedraw()
        {
            childBoard.getModel().resetElements();

            foreach (CTank cTank in childTanks)
            {
                cTank.redrawWithMissiles();
            }

            LinkedListNode<CTank> iterator = childTanks.First;
            CTank firstTank = iterator.Value;
            iterator = iterator.Next;
            CTank secondTank = iterator.Value;

            childBoard.redraw(firstTank, EPartOfScreen.LEFT);
            childBoard.redraw(secondTank, EPartOfScreen.RIGHT);
        }

        public void onKeyPressed(Keys iKeyCode)
        {
            LinkedListNode<CTank> iterator = childTanks.First;
            CTank firstTank = iterator.Value;
            iterator = iterator.Next;
            CTank secondTank = iterator.Value;

            switch (iKeyCode)
            {
                case SECOND_TANK_MOVE_DOWN:
                    secondTank.setMoveDown(true);
                    break;
                case SECOND_TANK_MOVE_LEFT:
                    secondTank.setMoveLeft(true);
                    break;
                case SECOND_TANK_MOVE_RIGHT:
                    secondTank.setMoveRight(true);
                    break;
                case SECOND_TANK_MOVE_UP:
                    secondTank.setMoveUp(true);
                    break;
                case SECOND_TANK_SHOOT:
                    secondTank.setShooting(true);
                    break;

                case FIRST_TANK_MOVE_DOWN:
                    firstTank.setMoveDown(true);
                    break;
                case FIRST_TANK_MOVE_LEFT:
                    firstTank.setMoveLeft(true);
                    break;
                case FIRST_TANK_MOVE_RIGHT:
                    firstTank.setMoveRight(true);
                    break;
                case FIRST_TANK_MOVE_UP:
                    firstTank.setMoveUp(true);
                    break;
                case FIRST_TANK_SHOOT:
                    firstTank.setShooting(true);
                    break;
            }
        }
        public void onKeyReleased(Keys iKeyCode)
        {
            LinkedListNode<CTank> iterator = childTanks.First;
            CTank firstTank = iterator.Value;
            iterator = iterator.Next;
            CTank secondTank = iterator.Value;

            switch (iKeyCode)
            {
                case SECOND_TANK_MOVE_DOWN:
                    secondTank.setMoveDown(false);
                    break;
                case SECOND_TANK_MOVE_LEFT:
                    secondTank.setMoveLeft(false);
                    break;
                case SECOND_TANK_MOVE_RIGHT:
                    secondTank.setMoveRight(false);
                    break;
                case SECOND_TANK_MOVE_UP:
                    secondTank.setMoveUp(false);
                    break;
                case SECOND_TANK_SHOOT:
                    secondTank.setShooting(false);
                    break;

                case FIRST_TANK_MOVE_DOWN:
                    firstTank.setMoveDown(false);
                    break;
                case FIRST_TANK_MOVE_LEFT:
                    firstTank.setMoveLeft(false);
                    break;
                case FIRST_TANK_MOVE_RIGHT:
                    firstTank.setMoveRight(false);
                    break;
                case FIRST_TANK_MOVE_UP:
                    firstTank.setMoveUp(false);
                    break;
                case FIRST_TANK_SHOOT:
                    firstTank.setShooting(false);
                    break;
            }
        }




        public MGameWindow getModel()
        {
            return model;
        }
        public void setModel(MGameWindow iModel)
        {
            model = iModel;
        }

        public VGameWindow getView()
        {
            return view;
        }
        public void setView(VGameWindow iView)
        {
            view = iView;
        }

        public CGameBoard getChildBoard()
        {
            return childBoard;
        }
        public void setChildBoard(CGameBoard iChildBoard)
        {
            childBoard = iChildBoard;
        }


        public LinkedList<CTank> getChildTanks()
        {
            return childTanks;
        }
        public void setChildTanks(LinkedList<CTank> iChildTanks)
        {
            childTanks = iChildTanks;
        }


        public int getElementSize()
        {
            return model.getElementSize();
        }
        public void setElementSize(int iElementSize)
        {
            model.setElementSize(iElementSize);
        }

        public bool isAtLeastOneTankDeafeated()
        {
            return model.isAtLeastOneTankDeafeated();
        }
        public void setAtLeastOneTankDeafeated(bool iAtLeastOneTankDeafeated)
        {
            model.setAtLeastOneTankDeafeated(iAtLeastOneTankDeafeated);
        }
    }
}
