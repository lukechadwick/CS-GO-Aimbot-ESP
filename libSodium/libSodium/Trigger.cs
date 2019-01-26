using System;
using System.Threading;
using System.Windows.Forms;

namespace libSodium
{
    internal class Trigger
    {
        public static void triggerBot(int auto)
        {
            if (Convert.ToBoolean(Native.GetAsyncKeyState(Keys.MButton)) || auto == 1)
            {
                if (vars.localClass.LocalTeam != vars.inCrossClass.InCrossTeam && vars.inCrossClass.InCrossHealth > 0 && vars.inCrossClass.InCrossTeam != 0)
                {
                    Native.mouse_event(0x002, 0, 0);
                    Native.mouse_event(0x004, 0, 0);
                    Random rnd = new Random();
                    Thread.Sleep(rnd.Next(20, 40));
                }
            }

            //Mouse Spammer
            if (Convert.ToBoolean(Native.GetAsyncKeyState(Keys.XButton2)))
            {
                Native.mouse_event(0x002, 0, 0);
                Native.mouse_event(0x004, 0, 0);
                Random rnd = new Random();
                Thread.Sleep(rnd.Next(10, 25));
            }
        }
    }
}