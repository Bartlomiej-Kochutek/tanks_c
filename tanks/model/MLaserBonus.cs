using tanks.controller;

namespace tanks.model
{
    class MLaserBonus : MBaseBonus
    {
        private CLaserBonus mController;

        //private ;



        public MLaserBonus()
        {
        }



        public void SetController(CLaserBonus iController)
        {
            mController = iController;
        }
    }
}
