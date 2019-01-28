using System;
using System.Windows.Forms;
using System.Threading;
using System.Numerics;

namespace libSodium
{
    public partial class naCL : Form
    {
        public naCL()
        {
            InitializeComponent();
        }

        private void naCL_Load(object sender, EventArgs e)
        {
            //On-Load code
            Offsets.ReadXML();
            Lists.Populate(Config.numberOfPlayers);
        }

        private Draw overlay;

        private void reader_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (Config.active)
            {
                while (Config.focused)
                {
                    if (vars.client == 0)
                        vars.client = Memory.GetBaseAddress(Memory.dec("Y3Nnbw=="), Memory.dec("Y2xpZW50X3Bhbm9yYW1hLmRsbA==")); //'Y3Nnbw==' == 'csgo', 'Y2xpZW50X3Bhbm9yYW1hLmRsbA==' == 'client_panorama.dll'

                    //View Matrix
                    vars.Matrix = Memory.ReadMatrix(vars.client + Offsets.dwViewMatrix);

                    //LocalPlayer
                    vars.localClass.LocalPlayer = Memory.ReadInteger(vars.client + Offsets.dwLocalPlayer, 4);
                    vars.localClass.LocalPlayerHealth = Memory.ReadInteger(vars.localClass.LocalPlayer + Offsets.m_iHealth, 4);
                    vars.localClass.LocalTeam = Memory.ReadInteger(vars.localClass.LocalPlayer + Offsets.m_iTeamNum, 4);
                    vars.localClass.inCross = Memory.ReadInteger(vars.localClass.LocalPlayer + Offsets.m_iCrosshairId, 4);
                    vars.localClass.observerTarget = Memory.ReadInteger(vars.localClass.LocalPlayer + Offsets.m_observerT, 4);

                    //Local player position
                    vars.localClass.LocalPosition = Memory.ReadVec3(vars.localClass.LocalPlayer + Offsets.m_vecOrigin + (0x4 * 0));

                    //Triggerbot Vars
                    vars.inCrossClass.InCrossID = Memory.ReadInteger(vars.client + Offsets.dwEntityList + ((vars.localClass.inCross - 1) * Offsets.entityLoopDistance), 4);
                    vars.inCrossClass.InCrossHealth = Memory.ReadInteger(vars.inCrossClass.InCrossID + Offsets.m_iHealth, 4); // Enemy in crosshair's
                    vars.inCrossClass.InCrossTeam = Memory.ReadInteger(vars.inCrossClass.InCrossID + Offsets.m_iTeamNum, 4); // Enemy in crosshair's team, we need this to compare it to our own player's team)
                    vars.inCrossClass.InCrossPosition = Memory.ReadInteger(vars.inCrossClass.InCrossID + Offsets.m_vecOrigin, 4);

                    //Triggerbot Code
                    Recoil.compensation();

                    Thread.Sleep((int)udThreadPerformance.Value);
                }
                Thread.Sleep((int)udThreadPerformance.Value);
            }
        }

        private void configUpdater_Tick(object sender, EventArgs e)
        {
            Config.FOV = (int)udFOV.Value;
            Config.boneSelector = (int)udBoneSelector.Value;
            Config.threadPerformance = (int)udThreadPerformance.Value;
            Config.aimSpeed = (int)udAimSpeed.Value;
            Config.sensitivity = (float)udMouseSensitivity.Value;

            Config.windowTitle = Memory.GetProcessPath();

            if (Config.windowTitle == Memory.dec("Q291bnRlci1TdHJpa2U6IEdsb2JhbCBPZmZlbnNpdmU=")) //if Counter-Strike: Global Offensive
            {
                Config.focused = true;
            }
            else
            {
                Config.focused = false;
            }
        }

        private void draw_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            overlay = new Draw();
        }

        private void entityLoop_DoWork(object sender, System.ComponentModel.DoWorkEventArgs e)
        {
            while (Config.active)
            {
                while (Config.focused)
                {
                    for (int i = 0; i < Config.numberOfPlayers; i++)
                    {
                        Lists.entityID[i] = Memory.ReadInteger(vars.client + Offsets.dwEntityList + (i * 0x10), 4);
                        Lists.team[i] = Memory.ReadInteger(Lists.entityID[i] + Offsets.m_iTeamNum, 4);
                        Lists.health[i] = Memory.ReadInteger(Lists.entityID[i] + Offsets.m_iHealth, 4);
                        Lists.spotted[i] = Memory.ReadInteger(Lists.entityID[i] + Offsets.m_bSpottedByMask, 4);
                        Lists.boneMatrix[i] = Memory.ReadInteger(Lists.entityID[i] + Offsets.m_dwBoneMatrix, 4);
                        Lists.flags[i] = Memory.ReadInteger(Lists.entityID[i] + Offsets.m_fFlags, 4);

                        if (true)
                        {
                            //Get Entity Position
                            Vector3 wPos = Maths.worldToScreen(Maths.GetEntPos(i, 0));

                            //Get Distance float for ESP
                            float fDistance = Maths.GetDistance(Maths.GetEntPos(i, 0), vars.localClass.LocalPosition);

                            //Get Base Position for ESP Box
                            //Vector3 wPosEntFeet = Maths.worldToScreen(Maths.GetEntPos(i, 0));

                            //Get Head Position for ESP Box
                            Vector3 wPosEntHead = Maths.worldToScreen(Maths.GetEntPos(i, 1));

                            //Get Bone Position for Target Circle
                            Vector3 bone = Memory.readBonePosition(Lists.boneMatrix[i] + 0x30 * Config.boneSelector + 0xC);
                            Vector3 targetBonePosition = Maths.worldToScreen(bone);

                            int GetOBsID = ((vars.localClass.observerTarget & 0xFFF) - 1); //Change m_hObserverTarget into playerID
                            int EntOBs = Memory.ReadInteger(vars.client + Offsets.dwEntityList + (GetOBsID * 0x10), 4); //Change PlayerID into entity

                            //Fill lists with player/entity info
                            if (Lists.entityID[i] == EntOBs)
                                Lists.observer[i] = 1;
                            else
                                Lists.observer[i] = 0;

                            Lists.dormant[i] = Memory.ReadInteger(Lists.entityID[i] + Offsets.m_bDormant, 4);
                            //Lists.baseX[i] = wPosEntFeet.X;
                            //Lists.baseY[i] = wPosEntFeet.Y;

                            Lists.selectedBoneX[i] = targetBonePosition.X;
                            Lists.selectedBoneY[i] = targetBonePosition.Y;

                            if (fDistance > 0)
                                Lists.distance[i] = 7000 / (fDistance);
                        }
                    }
                    Thread.Sleep(Config.threadPerformance);
                }
                Thread.Sleep(Config.threadPerformance);
            }
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            Config.active = true;
            if (!reader.IsBusy)
                reader.RunWorkerAsync();
            if (!entityLoop.IsBusy)
                entityLoop.RunWorkerAsync();
            if (!draw.IsBusy)
                draw.RunWorkerAsync();
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            Config.active = false;
            overlay.DestroyInstance();
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void textBox1_MouseDown(object sender, MouseEventArgs e)
        {
            if (e.Button == MouseButtons.Left)
            {
                Native.ReleaseCapture();
                Native.SendMessage(Handle, 0xA1, 0x2, 0);
            }
        }

        private void keyCheck_Tick(object sender, EventArgs e)
        {
            Trigger.triggerBot(0);
            shiftAim.aimLock();
            fovAim.Aimlock();
        }
    }
}