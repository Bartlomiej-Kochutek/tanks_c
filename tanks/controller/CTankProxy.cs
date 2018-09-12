using tanks.model;

namespace tanks.controller
{
    public class CTankProxy : CTank
    {


        public CTankProxy(
            int iPosX,
            int iPosY,
            ICTank iPlayerTank,
            ETankOwner iTankOwner)
            :
            base(iPosX, iPosY)
        {
            SetModel(new MProxyTank(iPosX, iPosY, iTankOwner));
        }
        
        
    }
}
