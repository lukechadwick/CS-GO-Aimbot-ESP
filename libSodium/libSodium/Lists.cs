using System.Collections.Generic;
using System.Numerics;

namespace libSodium
{
    internal class Lists
    {
        public static void Populate(int num)
        {
            //Populate lists
            for (int i = 0; i < num; i++)
            {
                //baseX.Add(0);
                //baseY.Add(0);
                entityID.Add(0);
                spotted.Add(0);
                boneMatrix.Add(0);
                flags.Add(0);
                selectedBoneX.Add(0);
                selectedBoneY.Add(0);
                team.Add(0);
                distance.Add(0);
                dormant.Add(0);
                health.Add(0);
                observer.Add(0);
            }
        }

        //public static List<float> baseX = new List<float>(); //hold entity X-coords
        //public static List<float> baseY = new List<float>(); //hold entity Y-coords

        public static List<int> entityID = new List<int>(); //hold entity X-coords
        public static List<int> spotted = new List<int>(); //hold entity X-coords
        public static List<int> boneMatrix = new List<int>(); //hold entity X-coords
        public static List<int> flags = new List<int>(); //hold entity X-coords
        public static List<int> team = new List<int>(); //hold entity distance
        public static List<int> dormant = new List<int>(); //hold entity distance
        public static List<int> health = new List<int>(); //hold entity distance
        public static List<int> observer = new List<int>(); //hold entity distance
        public static List<float> selectedBoneX = new List<float>(); //hold entity X-coords
        public static List<float> selectedBoneY = new List<float>(); //hold entity Y-coords
        public static List<float> distance = new List<float>(); //hold entity distance
    }
}