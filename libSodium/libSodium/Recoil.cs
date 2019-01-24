using System.Numerics;

namespace libSodium
{
    internal class Recoil
    {
        public static void compensation()
        {
            Vector3 Punch = Memory.ReadVec3(vars.localClass.LocalPlayer + Offsets.m_viewPunchAngle);
            vars.recoilX = (int)((vars.ScreenWidth / 2) - (vars.ScreenWidth / 90) * (Punch.Y * Config.sensitivity)); // These values are used for the aimbot to offset recoil punch , the +1 is to correct it to the center
            vars.recoilY = (int)((vars.ScreenHeight / 2) + (vars.ScreenHeight / 90) * (Punch.X * Config.sensitivity));
        }
    }
}