using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using tanks.model;

namespace tanks.controller
{
    public class CTankProxy : CTank
    {
        CTank playerTank;


        public CTankProxy(
            int iPosX,
            int iPosY,
            CTank iPlayerTank,
            ETankOwner iTankOwner) :
            base(iPosX, iPosY)
        {
            SetModel(new MProxyTank(iPosX, iPosY, iTankOwner));

            playerTank = iPlayerTank;
        }





        public CTank PlayerTank { get => playerTank; set => playerTank = value; }
    }
}
