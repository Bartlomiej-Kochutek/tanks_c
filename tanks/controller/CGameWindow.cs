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
            model.Controller = this;

            view = new VGameWindow();
            view.SetController(this);

            childBoard = new CGameBoard();
            childBoard.ParentGameWindow = this;

            childTanks = new LinkedList<CTank>();

            gameStarted = false;
        }


        public void Start(ETankOwner iFirstTankOwner)
        {
            CreateTanks(iFirstTankOwner);

            childBoard.Prepare();

            PrepareTanks();

            view.PrepareDisplay();

            gameStarted = true;
        }

        public /*async Task*/void DoNextGameLoopIteration()
        {
            if (!gameStarted)
                return;

            UpdateWithDeltaT();
            OnRedraw();

            /*Thread.Sleep(10);
            try
            {
                await Task.Delay(10);
            }
            catch (TaskCanceledException)
            {
            }*/
        }

        private void UpdateWithDeltaT()
        {
            int deltaT = model.MilisecsDelta();

            foreach (CTank cTank in childTanks)
            {
                cTank.Move(deltaT);
                cTank.Shoot(deltaT);
                cTank.MoveMissiles(deltaT);
                cTank.CheckMissilesCollision();
            }
        }

        private void OnRedraw()
        {
            childBoard.Model.ResetElements();

            foreach (CTank cTank in childTanks)
            {
                cTank.RedrawWithMissiles();
            }

            childBoard.Redraw(GetFirstTank(), EPartOfScreen.LEFT);
            childBoard.Redraw(GetSecondTank(), EPartOfScreen.RIGHT);
        }

        public void OnKeyPressed(Keys iKeyCode)
        {
            CTank firstTank = GetFirstTank();
            CTank secondTank = GetSecondTank();

            switch (iKeyCode)
            {
                case SECOND_TANK_MOVE_DOWN:
                    secondTank.SetMoveDown(true);
                    break;
                case SECOND_TANK_MOVE_LEFT:
                    secondTank.SetMoveLeft(true);
                    break;
                case SECOND_TANK_MOVE_RIGHT:
                    secondTank.SetMoveRight(true);
                    break;
                case SECOND_TANK_MOVE_UP:
                    secondTank.SetMoveUp(true);
                    break;
                case SECOND_TANK_SHOOT:
                    secondTank.SetShooting(true);
                    break;

                case FIRST_TANK_MOVE_DOWN:
                    firstTank.SetMoveDown(true);
                    break;
                case FIRST_TANK_MOVE_LEFT:
                    firstTank.SetMoveLeft(true);
                    break;
                case FIRST_TANK_MOVE_RIGHT:
                    firstTank.SetMoveRight(true);
                    break;
                case FIRST_TANK_MOVE_UP:
                    firstTank.SetMoveUp(true);
                    break;
                case FIRST_TANK_SHOOT:
                    firstTank.SetShooting(true);
                    break;
            }
        }
        public void OnKeyReleased(Keys iKeyCode)
        {
            CTank firstTank = GetFirstTank();
            CTank secondTank = GetSecondTank();

            switch (iKeyCode)
            {
                case SECOND_TANK_MOVE_DOWN:
                    secondTank.SetMoveDown(false);
                    break;
                case SECOND_TANK_MOVE_LEFT:
                    secondTank.SetMoveLeft(false);
                    break;
                case SECOND_TANK_MOVE_RIGHT:
                    secondTank.SetMoveRight(false);
                    break;
                case SECOND_TANK_MOVE_UP:
                    secondTank.SetMoveUp(false);
                    break;
                case SECOND_TANK_SHOOT:
                    secondTank.SetShooting(false);
                    break;

                case FIRST_TANK_MOVE_DOWN:
                    firstTank.SetMoveDown(false);
                    break;
                case FIRST_TANK_MOVE_LEFT:
                    firstTank.SetMoveLeft(false);
                    break;
                case FIRST_TANK_MOVE_RIGHT:
                    firstTank.SetMoveRight(false);
                    break;
                case FIRST_TANK_MOVE_UP:
                    firstTank.SetMoveUp(false);
                    break;
                case FIRST_TANK_SHOOT:
                    firstTank.SetShooting(false);
                    break;
            }
        }


        private void CreateTanks(ETankOwner iFirstTankOwner)
        {
            childTanks.AddLast(new CTank(60, 25));

            childTanks.AddLast(new CTankProxy(25, 23, childTanks.First(), iFirstTankOwner));
        }

        private void PrepareTanks()
        {
            foreach (CTank cTank in childTanks)
            {
                cTank.ParentGameWindow = this;
                cTank.Prepare();
            }
        }

        private CTank GetFirstTank()
        {
            LinkedListNode<CTank> iterator = childTanks.First;
            iterator = iterator.Next;
            return iterator.Value;
        }
        private CTank GetSecondTank()
        {
            LinkedListNode<CTank> iterator = childTanks.First;
            return iterator.Value;
        }




        public MGameWindow Model { get => model; set => model = value; }

        public VGameWindow View { get => view; set => view = value; }

        public CGameBoard ChildBoard { get => childBoard; set => childBoard = value; }

        public LinkedList<CTank> ChildTanks { get => childTanks; set => childTanks = value; }

        public int GetElementSize()
        {
            return model.ElementSize;
        }
        public void SetElementSize(int iElementSize)
        {
            model.ElementSize = iElementSize;
        }

        public bool IsAtLeastOneTankDeafeated()
        {
            return model.AtLeastOneTankDeafeated;
        }
        public void SetAtLeastOneTankDeafeated(bool iAtLeastOneTankDeafeated)
        {
            model.AtLeastOneTankDeafeated = iAtLeastOneTankDeafeated;
        }
    }
}
