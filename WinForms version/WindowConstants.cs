using System;

namespace AfterBurner
{
    internal class WindowConstants
    {


        public const string DESKTOP_CLASS = "#32769";

        public const uint WINDOW_STYLE_DX = 0x8000000     //WS_DISABLED
                                            | 0x10000000    //WS_VISIBLE
                                            | 0x80000000;   //WS_POPUP

        public const uint WINDOW_EX_STYLE_DX = 0x8000000     //WS_EX_NOACTIVATE
                                            | 0x80000       //WS_EX_LAYERED
                                            | 0x80          //WS_EX_TOOLWINDOW -> Not in taskbar
                                            | 0x8            //WS_EX_TOPMOST
                                            | 0x20;         //WS_EX_TRANSPARENT


        public const uint SW_SHOW = 5;
        public const uint SW_HIDE = 0;
    }
}
