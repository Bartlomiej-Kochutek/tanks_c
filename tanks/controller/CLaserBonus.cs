using System;
using tanks.model;

namespace tanks.controller
{
    class CLaserBonus : CBaseBonus
    {
        new private MLaserBonus mModel;



        public CLaserBonus(): base(new MLaserBonus())
        {
            mModel = (MLaserBonus)base.mModel;
            mModel.SetController(this);
        }
        public CLaserBonus(
            int iPosX,
            int iPosY)
            :
            this()
        {
            mModel.SetPosX(iPosX);
            mModel.SetPosY(iPosY);
        }

        public TimeSpan GetDuration()
        {
            return mModel.GetDuration();
        }
    }
}
