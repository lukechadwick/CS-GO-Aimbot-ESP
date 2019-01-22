using System;
using System.Numerics;

namespace libSodium
{
    public class Maths
    {
        public static Vector3 worldToScreen(Vector3 bone) //World to screen
        {
            Vector3 Out = new Vector3();

            float w = vars.Matrix.M41 * bone.X + vars.Matrix.M42 * bone.Y + vars.Matrix.M43 * bone.Z + vars.Matrix.M44;
            if (w < 0.01f)
                return Out;

            Out.X = (vars.Matrix.M11 * bone.X + vars.Matrix.M12 * bone.Y + vars.Matrix.M13 * bone.Z + vars.Matrix.M14) * 1.0f / w;
            Out.Y = (vars.Matrix.M21 * bone.X + vars.Matrix.M22 * bone.Y + vars.Matrix.M23 * bone.Z + vars.Matrix.M24) * 1.0f / w;

            Out.X = (vars.ScreenWidth / 2) + 0.5f * Out.X * vars.ScreenWidth + 0.5f;
            Out.Y = (vars.ScreenHeight / 2) - 0.5f * Out.Y * vars.ScreenHeight + 0.5f;

            return Out;
        }

        public static float GetDistance(Vector3 loc, Vector3 ent)
        {
            float dist;
            dist = (float)Math.Sqrt(Math.Pow(loc.X - ent.X, 2) + Math.Pow(loc.Y - ent.Y, 2) + Math.Pow(loc.Z - ent.Z, 2));
            return dist;
        }

        public static Vector3 GetEntPos(int entityptr, int head)
        {
            int Entity = Memory.ReadInteger(vars.client + Offsets.dwEntityList + (entityptr * 0x10), 4);

            Vector3 pos = Memory.ReadVec3(Entity + Offsets.m_vecOrigin);

            if (head == 1)
                pos.Z = pos.Z + 72f;

            return pos;
        }
    }
}