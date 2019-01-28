using System;
using System.Windows.Forms;

namespace libSodium
{
    internal class shiftAim
    {
        public static void aimLock()
        {
            if (Convert.ToBoolean(Native.GetAsyncKeyState(Keys.LShiftKey)))
            {
                if (vars.localClass.LocalTeam != vars.inCrossClass.InCrossTeam) //Check team
                {
                    //Prevent numbers below 0 or above number of players
                    if (vars.localClass.inCross > 0 && vars.localClass.inCross < Config.numberOfPlayers)
                        vars.shiftAimTarget = vars.localClass.inCross - 1;

                    if (Lists.flags[vars.shiftAimTarget] == 256)
                        Console.WriteLine("heck");

                    if (vars.shiftAimTarget != 0 && Lists.health[vars.shiftAimTarget] > 0 && Lists.spotted[vars.shiftAimTarget] != 0 && Lists.dormant[vars.shiftAimTarget] != 1 && Lists.flags[vars.shiftAimTarget] != 256)
                    {
                        setAim.aimAt(Lists.selectedBoneX[vars.shiftAimTarget], Lists.selectedBoneY[vars.shiftAimTarget]); //Send co-ords to Aim Function
                    }
                }
            }
            else
                vars.shiftAimTarget = 0;
        }
    }
}