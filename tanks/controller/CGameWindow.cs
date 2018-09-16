using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using tanks.model;
using tanks.view;


namespace tanks.controller
{
    public class CGameWindow
    {
        private MGameWindow mModel;
        private VGameWindow mView;

        private CGameBoard mChildBoard;
        private LinkedList<ICTank> mChildTanks;
        private LinkedList<CBaseBonus> mChildBonuses;

        private bool mGameStarted;

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



        public CGameWindow()
        {
            mModel = new MGameWindow();
            mModel.Controller = this;

            mView = new VGameWindow();
            mView.SetController(this);

            mChildBoard = new CGameBoard();
            mChildBoard.ParentGameWindow = this;

            mChildTanks = new LinkedList<ICTank>();

            mChildBonuses = new LinkedList<CBaseBonus>();

            mGameStarted = false;
        }



        public void Start(ETankOwner iFirstTankOwner)
        {
            CreateTanks(iFirstTankOwner);

            CreateBonuses();

            mChildBoard.Prepare();

            PrepareTanks();

            mView.PrepareDisplay();

            mGameStarted = true;
        }

        public /*async Task*/void DoNextGameLoopIteration()
        {
            if (!mGameStarted)
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
            if (mModel.AtLeastOneTankDeafeated)
                return;

            int deltaT = mModel.MilisecsDeltaT();

            foreach (ICTank cTank in mChildTanks)
            {
                cTank.Move(deltaT);

                if (cTank.IsUsingWeapon())
                    cTank.UseWeapon(deltaT);

                cTank.CalculateWeaponUsages(deltaT,
                                            mChildBoard.Elements,
                                            mChildTanks);


            }
        }

        private void OnRedraw()
        {
            mChildBoard.Model.ResetElements();
            
            foreach (ICTank cTank in mChildTanks)
            {
                if (cTank.IsDefeated())
                    continue;

                cTank.RedrawWithWeaponUsageEffect(mChildBoard.Elements);
            }

            mChildBoard.Redraw(GetFirstTank(), EPartOfScreen.LEFT);
            mChildBoard.Redraw(GetSecondTank(), EPartOfScreen.RIGHT);
        }

        public void OnKeyPressed(Keys iKeyCode)
        {
            ICTank firstTank = GetFirstTank();
            ICTank secondTank = GetSecondTank();

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
                    secondTank.SetUsingWeapon(true);
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
                    firstTank.SetUsingWeapon(true);
                    break;
            }
        }
        public void OnKeyReleased(Keys iKeyCode)
        {
            ICTank firstTank = GetFirstTank();
            ICTank secondTank = GetSecondTank();

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
                    secondTank.SetUsingWeapon(false);
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
                    firstTank.SetUsingWeapon(false);
                    break;
            }
        }

        public ICTank GetPlayerTank()
        {
            return GetSecondTank();
        }


        private void CreateTanks(ETankOwner iFirstTankOwner)
        {
            mChildTanks.AddLast(new CLaserGunTank(new CTank(60, 25)));

            mChildTanks.AddLast(new CTankProxy(25, 23, mChildTanks.First(), iFirstTankOwner));
        }

        private void CreateBonuses()
        {
            mChildBonuses.AddLast(new CLaserBonus(15, 40));
            mChildBonuses.AddLast(new CLaserBonus(35, 30));
        }

        private void PrepareTanks()
        {
            foreach (ICTank cTank in mChildTanks)
            {
                cTank.ParentGameWindow = this;
                cTank.Prepare();
            }
        }

        private ICTank GetFirstTank()
        {
            LinkedListNode<ICTank> iterator = mChildTanks.First;
            iterator = iterator.Next;
            return iterator.Value;
        }
        private ICTank GetSecondTank()
        {
            LinkedListNode<ICTank> iterator = mChildTanks.First;
            return iterator.Value;
        }




        public MGameWindow Model { get => mModel; set => mModel = value; }

        public VGameWindow View { get => mView; set => mView = value; }

        public CGameBoard ChildBoard { get => mChildBoard; set => mChildBoard = value; }

        public LinkedList<ICTank> ChildTanks { get => mChildTanks; set => mChildTanks = value; }

        public int GetElementSize()
        {
            return mModel.ElementSize;
        }
        public void SetElementSize(int iElementSize)
        {
            mModel.ElementSize = iElementSize;
        }

        public bool IsAtLeastOneTankDeafeated()
        {
            return mModel.AtLeastOneTankDeafeated;
        }
        public void SetAtLeastOneTankDeafeated(bool iAtLeastOneTankDeafeated)
        {
            mModel.AtLeastOneTankDeafeated = iAtLeastOneTankDeafeated;
        }
    }
}
