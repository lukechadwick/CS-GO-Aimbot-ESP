using System.Windows.Forms;
using System.Numerics;

namespace libSodium
{
    public class vars
    {
        public static localPlayer localClass = new localPlayer();
        public static inCross inCrossClass = new inCross();

        public class localPlayer
        {
            public int LocalPlayer;
            public int LocalPlayerHealth;
            public int LocalTeam;
            public int inCross;
            public int observerTarget;
            public Vector3 LocalPosition;
        }

        public class inCross
        {
            public int InCrossID;
            public int InCrossHealth;
            public int InCrossTeam;
            public int InCrossPosition;
        }

        public static Matrix4x4 Matrix;
        public static int client; //client.dll

        public static int recoilX;
        public static int recoilY;

        public static int shiftAimTarget;
        public static int fovTarget;

        public static int drawFOV;

        public static int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
        public static int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;
    }
}