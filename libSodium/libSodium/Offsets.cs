using System.Xml;
using System;

namespace libSodium
{
    public class Offsets
    {
        public static int entityLoopDistance = 0x10; //Entitiy distance

        public static int dwLocalPlayer; //LocalPlayer
        public static int dwEntityList;  //Entity List
        public static int dwViewMatrix; //ViewMatrix

        public static int m_iCrosshairId;
        public static int m_vecOrigin;
        public static int m_viewPunchAngle; //Aim punch

        public static int m_bDormant; //Dormant
        public static int m_iTeamNum;  //Team Number
        public static int m_iHealth; //Health
        public static int m_dwBoneMatrix; //BoneMatrix
        public static int m_bSpottedByMask;  //Spotted
        public static int m_fFlags; //Flags
        public static int m_observerT; //Observer Targert

        public static void ReadXML()
        {
            XmlTextReader reader = new XmlTextReader("vars.xml");
            XmlNodeType type;

            while (reader.Read())
            {
                type = reader.NodeType;

                if (type == XmlNodeType.Element)
                {
                    if (reader.Name == "dwLocalPlayer")
                    {
                        reader.Read();
                        dwLocalPlayer = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "dwViewMatrix")
                    {
                        reader.Read();
                        dwViewMatrix = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "m_vecOrigin")
                    {
                        reader.Read();
                        m_vecOrigin = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "dwEntityList")
                    {
                        reader.Read();
                        dwEntityList = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "m_iCrosshairId")
                    {
                        reader.Read();
                        m_iCrosshairId = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "m_viewPunchAngle")
                    {
                        reader.Read();
                        m_viewPunchAngle = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "entityLoopDistance")
                    {
                        reader.Read();
                        entityLoopDistance = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "m_bDormant")
                    {
                        reader.Read();
                        m_bDormant = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "m_iTeamNum")
                    {
                        reader.Read();
                        m_iTeamNum = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "m_iHealth")
                    {
                        reader.Read();
                        m_iHealth = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "m_dwBoneMatrix")
                    {
                        reader.Read();
                        m_dwBoneMatrix = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "m_bSpottedByMask")
                    {
                        reader.Read();
                        m_bSpottedByMask = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "m_fFlags")
                    {
                        reader.Read();
                        m_fFlags = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "m_observerT")
                    {
                        reader.Read();
                        m_observerT = Convert.ToInt32(reader.Value, 16);
                    }
                }
            }
            reader.Close();
        }
    }
}