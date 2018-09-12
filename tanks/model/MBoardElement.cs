
using tanks.controller;


namespace tanks.model
{
    public class MBoardElement
    {
        private CBoardElement mController;

        private bool mIsDestroyed;
        private bool mIsTank;
        private bool mIsCanon;
        private bool mIsMissile;
        private bool mIsFortressWall;



        public MBoardElement()
        {
            mIsDestroyed = false;
            mIsTank = false;
            mIsCanon = false;
            mIsMissile = false;
            mIsFortressWall = false;
        }
        


        public CBoardElement Controller { get => mController; set => mController = value; }

        public bool IsDestroyed { get => this.mIsDestroyed; set => this.mIsDestroyed = value; }

        public bool IsTank { get => this.mIsTank; set => this.mIsTank = value; }

        public bool IsCanon { get => this.mIsCanon; set => this.mIsCanon = value; }

        public bool IsMissile { get => this.mIsMissile; set => this.mIsMissile = value; }

        public bool IsFortressWall { get => this.mIsFortressWall; set => this.mIsFortressWall = value; }
    }
}
