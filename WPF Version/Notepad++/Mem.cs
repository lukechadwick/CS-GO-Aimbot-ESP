using System;
using System.Diagnostics;
using System.Numerics;
using System.Runtime.InteropServices;
using System.Text;


namespace Notepad__
{
    public class Memory
    {
        /////////////////////
        /////DLL Imports/////
        /////////////////////
        [DllImport("kernel32.dll")]
        private static extern int ReadProcessMemory(int Handle, int Address, byte[] buffer, int Size, int BytesRead = 0);

        [DllImport("kernel32")]
        private static extern int OpenProcess(int AccessType, int InheritHandle, int pID);

        /////////////////////
        //////Variables//////
        /////////////////////
        public static int pHandle;  //Process Handle

        static string ExeName = dec("Y3Nnbw=="); //Use the exename definied in the Trainer form

        /////////////////////
        //Process Functions//
        /////////////////////
        public static int GetProcessHandle() //Find Process
        {
            {
                try
                {
                    if (pHandle == 0)
                    {
                        Process[] pID = Process.GetProcessesByName(ExeName);
                        pHandle = OpenProcess(0x001F0FFF, 0, pID[0].Id);                       
                    }
                    return pHandle;
                }
                catch (Exception ex)
                {
                    return 0;
                }
            }
        }

        public static int GetBaseAddress(string ProcessName, string ModuleName)
        {
            try
            {
                Process[] processes = Process.GetProcessesByName(ProcessName);
                ProcessModuleCollection modules = processes[0].Modules;
                ProcessModule RequestedModuleAddress = null;

                foreach (ProcessModule i in modules)
                {
                    if (i.ModuleName == ModuleName)
                    {
                        RequestedModuleAddress = i;
                    }
                }

                return RequestedModuleAddress.BaseAddress.ToInt32();
            }
            catch
            {
                return 0;
            }
        }

        public static float ReadFloat(int Address) //ReadFloat
        {
            byte[] Buffer = new byte[4];
            ReadProcessMemory(GetProcessHandle(), Address, Buffer, 4);
            return BitConverter.ToSingle(Buffer, 0);
        }

        public static int ReadInteger(int Address, int Length) //ReadInteger
        {
            byte[] Buffer = new byte[Length];
            ReadProcessMemory(GetProcessHandle(), Address, Buffer, Length);
            return BitConverter.ToInt32(Buffer, 0);
        }
        
        public static Vector3 ReadVec3(int pOffset)
        {
            byte[] Buffer = new byte[12]; ;
            ReadProcessMemory(GetProcessHandle(), pOffset, Buffer, 12);

            Vector3 readvec;
            readvec.X = BitConverter.ToSingle(Buffer, 0); // buffer[0] = float 1
            readvec.Y = BitConverter.ToSingle(Buffer, 4); // buffer[4] = float 2
            readvec.Z = BitConverter.ToSingle(Buffer, 8); // buffer[8] = float 3

            return readvec;
        }

        public static Matrix4x4 ReadMatrix(int pOffset)
        {
            byte[] Buffer = new byte[64]; ;
            ReadProcessMemory(GetProcessHandle(), pOffset, Buffer, 64);

            Matrix4x4 genis = new Matrix4x4();
            genis.M11 = BitConverter.ToSingle(Buffer, 0); // buffer[0] = float 1
            genis.M12 = BitConverter.ToSingle(Buffer, 4); // buffer[0] = float 1
            genis.M13 = BitConverter.ToSingle(Buffer, 8); // buffer[0] = float 1
            genis.M14 = BitConverter.ToSingle(Buffer, 12); // buffer[0] = float 1
            genis.M21 = BitConverter.ToSingle(Buffer, 16); // buffer[0] = float 1
            genis.M22 = BitConverter.ToSingle(Buffer, 20); // buffer[0] = float 1
            genis.M23 = BitConverter.ToSingle(Buffer, 24); // buffer[0] = float 1
            genis.M24 = BitConverter.ToSingle(Buffer, 28); // buffer[0] = float 1
            genis.M31 = BitConverter.ToSingle(Buffer, 32); // buffer[0] = float 1
            genis.M32 = BitConverter.ToSingle(Buffer, 36); // buffer[0] = float 1
            genis.M33 = BitConverter.ToSingle(Buffer, 40); // buffer[0] = float 1
            genis.M34 = BitConverter.ToSingle(Buffer, 44); // buffer[0] = float 1
            genis.M41 = BitConverter.ToSingle(Buffer, 48); // buffer[0] = float 1
            genis.M42 = BitConverter.ToSingle(Buffer, 52); // buffer[0] = float 1
            genis.M43 = BitConverter.ToSingle(Buffer, 56); // buffer[0] = float 1
            genis.M44 = BitConverter.ToSingle(Buffer, 60); // buffer[0] = float 1

            return genis;
        }

        public static Vector3 ReadBon(int pOffset)
        {
            byte[] Buffer = new byte[0x24]; ;
            ReadProcessMemory(GetProcessHandle(), pOffset, Buffer, 0x24);

            Vector3 Bon;
            Bon.X = BitConverter.ToSingle(Buffer, 0); // buffer[0] = float 1
            Bon.Y = BitConverter.ToSingle(Buffer, 0x10); // buffer[0] = float 1
            Bon.Z = BitConverter.ToSingle(Buffer, 0x20); // buffer[0] = float 1

            return Bon;
        }

        public static string dec(string dec)
        {
            var data = Convert.FromBase64String(dec);
            var decodedString = Encoding.UTF8.GetString(data); // get string and not bytes, thanks trope
            return decodedString;
        }
    }
}
