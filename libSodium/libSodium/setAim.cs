using System.Windows.Forms;

namespace libSodium
{
    internal class setAim
    {
        public static void aimAt(float x, float y)
        {
            //X
            float Speed = Config.aimSpeed; //Higher number, slower mouse movement
            float CoOrdX;
            float CoOrdY;
            //If you don't want recoil compensation replace recoil with screen res / 2

            if (x > vars.recoilX)
            {
                CoOrdX = -(vars.recoilX - x) / Speed;
                if (CoOrdX + vars.recoilX > vars.recoilX * 2) CoOrdX = 0;
            }
            else
            {
                CoOrdX = (x - vars.recoilX) / Speed;
                if (CoOrdX + vars.recoilX < 0) CoOrdX = 0;
            }

            //Y
            if (y > vars.recoilY)
            {
                CoOrdY = -(vars.recoilY - y) / Speed;
                if (CoOrdY + vars.recoilY > vars.recoilY * 2) CoOrdY = 0;
            }
            else
            {
                CoOrdY = (y - vars.recoilY) / Speed;
                if (CoOrdY + vars.recoilY < 0) CoOrdY = 0;
            }

            Native.mouse_event(0x0001, (int)(CoOrdX), (int)(CoOrdY), 0, 0);
        }
    }
}