using tanks.model;

namespace tanks.controller
{
    class CLaserBonus : CBaseBonus
    {
        new private MLaserBonus mModel;



        public CLaserBonus(): base(new MLaserBonus())
        {
            mModel = (MLaserBonus)base.mModel;
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
    }
}
