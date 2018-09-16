using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanks.common
{
    public interface IPositionable
    {
        int GetPosX();
        void SetPosX(int iPosX);

        int GetPosY();
        void SetPosY(int iPosY);

        int GetSize();
        void SetSize(int iSize);
    }
}
