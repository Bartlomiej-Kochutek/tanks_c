using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using tanks.controller;


namespace tanks.model
{
    public class MBoardElement
    {
        private CBoardElement controller;

        private bool isDestroyed;
        private bool isTank;
        private bool isCanon;
        private bool isMissile;
        private bool isBaseWall;



        public MBoardElement()
        {
            isDestroyed = false;
            isTank = false;
            isCanon = false;
            isMissile = false;
            isBaseWall = false;
        }
        



        internal CBoardElement Controller { get => controller; set => controller = value; }

        public bool IsDestroyed { get => this.isDestroyed; set => this.isDestroyed = value; }

        public bool IsTank { get => this.isTank; set => this.isTank = value; }

        public bool IsCanon { get => this.isCanon; set => this.isCanon = value; }

        public bool IsMissile { get => this.isMissile; set => this.isMissile = value; }

        public bool IsBaseWall { get => this.isBaseWall; set => this.isBaseWall = value; }
    }
}
