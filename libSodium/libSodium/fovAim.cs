using System;
using System.Numerics;
using System.Threading;
using System.Windows.Forms;

namespace libSodium
{
    internal class fovAim
    {
        public static void Aimlock()
        {
            if (Convert.ToBoolean(Native.GetAsyncKeyState(Keys.XButton1)))
            {
                int range = Config.FOV;
                vars.drawFOV = 1;

                for (int i = 0; i < Config.numberOfPlayers; i++)
                {
                    if (vars.fovTarget == 0)
                    {
                        //Make sure target is within range circle
                        if (Lists.selectedBoneX[i] > vars.ScreenWidth / 2 - range && Lists.selectedBoneX[i] < vars.ScreenWidth / 2 + range && Lists.selectedBoneY[i] > vars.ScreenHeight / 2 - range && Lists.selectedBoneY[i] < vars.ScreenHeight / 2 + range)
                        {
                            if (Lists.health[i] > 0 && Lists.team[i] != vars.localClass.LocalTeam && Lists.spotted[i] != 0 && Lists.dormant[i] != 1 && Lists.observer[i] != 1) //Make sure we have a legit target
                            {
                                //if (Lists.entity[i] != vars.localClass.LocalPlayer)
                                vars.fovTarget = i;
                            }
                        }
                    }
                }

                if (Lists.health[vars.fovTarget] == 0)
                    vars.fovTarget = 0; //if target is killed set rtarget to 0 to the loop above runs again

                if (vars.fovTarget != 0 && Lists.flags[vars.fovTarget] != 256)
                {
                    setAim.aimAt(Lists.selectedBoneX[vars.fovTarget], Lists.selectedBoneY[vars.fovTarget]); //Send co-ords to Aim Function
                }

                Trigger.triggerBot(1);
            }
            else
            {
                vars.fovTarget = 0;
                vars.drawFOV = 0;
            }
        }
    }
}