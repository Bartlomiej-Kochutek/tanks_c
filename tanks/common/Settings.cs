using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace tanks.common
{
    public abstract class Settings
    {
        public const int GAME_BOARD_SIZE = 160;

        public const int DEFAULT_BONUS_SIZE = 4;

        public const int DEFAULT_FORTRESS_SIZE = 16;

        public const int DEFAULT_TANK_SIZE = 5;

        public const int DEFAULT_HIT_POINTS_BAR_HEIGHT = 3;


        public const int MAX_HIT_POINTS = 1000;


        public const int DEFAULT_MISSILE_DAMAGE = 40;

        public const double LASER_POWER = 0.08;


        public const int PROXY_TANK_TAKE_CONTROL_TIMEOUT = 20;


        public const int TANK_DELTA_T_SCALE = 200;

        public const int MISSILES_SHOOTING_INTERVAL = 100;

        public const float MISSILES_FASTER_THAN_TANK = (float)1.5;
    }
}
