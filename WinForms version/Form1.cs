using System;
using System.ComponentModel;
using System.Windows.Forms;
using System.Diagnostics;
using System.Threading;
using System.Runtime.InteropServices;
using System.Management;
using System.Numerics;
using System.Xml;

namespace AfterBurner
{
    public partial class Form1 : Form
    {
        Matrix4x4 Matrix;

        Vector3 wPosenthaimbone = new Vector3();

        int currenttarget;

        int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
        int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;

        int rec0i1x;
        int rec0i1y;

        static int PlayList; //LocalPlayer
        static int crss;
        static int Position;
        static int punccch;

        static int EntList;  //Entity List
        static int Dist; //Entitiy distaance
        static int Dorm; //m_bdormant
        static int team;  //Team Number
        static int Healthy; //Health
        static int bone; //BoneMatrix
        static int spots;  //Team Number
        static int flags; //Health
        static int m_obs; //BoneMatrix
        static int ViewM; //ViewMatrix

        int client; //client.dll

        int obs;
        int rtarget;

        string wintit = "";

        bool perf;

        public Form1()
        {
            InitializeComponent();
        }

        [DllImport("user32.dll")]
        static extern void mouse_event(int dwFlags, int dx, int dy, int dwData = 0, int dwExtraInfo = 0);

        [DllImport("user32.dll")]
        public static extern short GetAsyncKeyState(Keys vKey);

        [DllImport("user32.dll")]
        static extern IntPtr GetForegroundWindow();

        [DllImport("user32.dll")]
        private static extern int GetWindowThreadProcessId(IntPtr handle, out uint processId);

        public static string GetProcessPath()
        {
            try
            { 
            uint pid = 0;
            GetWindowThreadProcessId(GetForegroundWindow(), out pid);
            Process proc = Process.GetProcessById((int)pid);
            return proc.MainModule.ModuleName.ToString();
            }

            catch
            {
                return "none";
            }
        }

        private void backgroundWorker1_DoWork(object sender, DoWorkEventArgs e)
        {

            Olay Music = new Olay(perf);
            Stopwatch Time = Stopwatch.StartNew();

            #region brushesandfonts
            int redBrush = Music.Graphics.CreateBrush(0x7FFF0000);
            int blackBrush = Music.Graphics.CreateBrush(System.Drawing.Color.FromArgb(0, 0, 0, 0));

            int redOpacityBrush = Music.Graphics.CreateBrush(System.Drawing.Color.FromArgb(30, 255, 0, 0));
            int yellowBrush = Music.Graphics.CreateBrush(0x7FFFFF00);
            int blueBrush = Music.Graphics.CreateBrush(0x7F0000FF);
            int blueOpacityBrush = Music.Graphics.CreateBrush(System.Drawing.Color.FromArgb(30, 0, 0, 255));

            int transparent = Music.Graphics.CreateBrush(System.Drawing.Color.FromArgb(1, 255, 0, 0));

            int chair = Music.Graphics.CreateBrush(System.Drawing.Color.FromArgb(200, 255, 0, 0));


            int greenOpacityBrush = Music.Graphics.CreateBrush(System.Drawing.Color.FromArgb(175, 0, 255, 0));

            int font = Music.Graphics.CreateFont("Verdana", 12);

            int fps = 0;
            int displayFPS = 0;
            #endregion

            while (true)
            {
                Music.Graphics.BeginScene();
                Music.Graphics.ClearScene();

                #region displayFPS
                if (Time.ElapsedMilliseconds > 1000)
                {
                    displayFPS = fps;
                    fps = 0;
                    Time.Restart();
                }
                else
                {
                    fps++;
                }

                Music.Graphics.DrawText("FPS: " + displayFPS.ToString(), font, redBrush, 33, 33, false);
                //Music.Graphics.DrawText(wintit, font, redBrush, 200, 200); //Draw current exe name
                #endregion

                #region MemoryWork
                if (client == 0)
                client = Memory.GetBaseAddress(Memory.dec("Y3Nnbw=="), Memory.dec("Y2xpZW50LmRsbA==")); 

                Matrix = Memory.ReadMatrix(client + ViewM);

                //LocalPlayer
                int LocalPlayer = Memory.ReadInteger(client + PlayList, 4);
                int LocalPlayerHealth = Memory.ReadInteger(LocalPlayer + Healthy, 4);
                int LocalTeam = Memory.ReadInteger(LocalPlayer + team, 4);
                int InCross = Memory.ReadInteger(LocalPlayer + crss, 4);
                int obs = Memory.ReadInteger(LocalPlayer + m_obs, 4);

                Vector3 LocalPosition = Memory.ReadVec3(LocalPlayer + Position + (0x4 * 0));

                //Triggerbot Vars
                int InCrossID = Memory.ReadInteger(client + EntList + ((InCross - 1) * Dist), 4);
                int InCrossHealth = Memory.ReadInteger(InCrossID + Healthy, 4); // Enemy in crosshair's 
                int InCrossTeam = Memory.ReadInteger(InCrossID + team, 4); // Enemy in crosshair's team, we need this to compare it to our own player's team)
                int InCrossPosition = Memory.ReadInteger(InCrossID + Position, 4);
                #endregion

                #region triggerbot
                //Triggerbot Code
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.MButton)))
                {                    
                    if (LocalTeam != InCrossTeam && InCrossHealth > 0 && InCrossTeam !=0)
                    {
                        mouse_event(0x002, 0, 0);
                        mouse_event(0x004, 0, 0);
                        Random rnd = new Random();
                        Thread.Sleep(rnd.Next(20, 40));
                    }
                }

                //Mouse Spammer
                if (Convert.ToBoolean(GetAsyncKeyState(Keys.XButton2)))
                {
                        mouse_event(0x002, 0, 0);
                        mouse_event(0x004, 0, 0);
                        Random rnd = new Random();
                        Thread.Sleep(rnd.Next(10, 25));
                }
                #endregion

                #region punchdot

                
                    Vector3 Punch = Memory.ReadVec3(LocalPlayer + punccch);

                    rec0i1x = (int)((ScreenWidth / 2) - (ScreenWidth / 90) * (Punch.Y)) + 1; // These values are used for the aimbot to offset recoil punch , the +1 is to correct it to the center
                    rec0i1y = (int)((ScreenHeight / 2) + (ScreenHeight / 90) * (Punch.X)) + 1; 
                
                    Music.Graphics.DrawPlus(rec0i1x, rec0i1y , 10, 1, chair);
                
                #endregion

                #region aimer

                if (Convert.ToBoolean(GetAsyncKeyState(Keys.LShiftKey)))
                {
                    if (LocalTeam != InCrossTeam) //Check team
                    { 
                        if (InCross !=0)
                            currenttarget = InCross - 1;

                        int Entity = Memory.ReadInteger(client + EntList + (currenttarget * 0x10), 4); 
                        int EntityHealth = Memory.ReadInteger(Entity + Healthy, 4);
                        int spot = Memory.ReadInteger(Entity + spots, 4); //make sure spotted so dont trace through walls
                        int flagz = Memory.ReadInteger(Entity + flags, 4); //dont trace if flag is jumping
                        int bonbase = Memory.ReadInteger(Entity + bone, 4);
                        int dormant = Memory.ReadInteger(Entity + Dorm, 4);

                        Vector3 bon = Memory.ReadBon(bonbase + 0x30 * ((int)UDbon.Value) + 0xC); //Read Bone Coords                  
                        World(bon, out wPosenthaimbone); //get bone screen position

                        if (currenttarget != 0 && EntityHealth > 0 && spot !=0 && flagz != 256 && dormant !=1)
                        {
                            AimP(wPosenthaimbone.X, wPosenthaimbone.Y); //Send co-ords to Aim Function
                        }
                    }
                }
                else
                currenttarget = 0;

                #endregion

                #region FOV Lock

                if (Convert.ToBoolean(GetAsyncKeyState(Keys.XButton1)))
                {
                    int range = (int)udFOV.Value;  //Set the range

                    for (int i = 0; i < 64; i++)
                    {
                        if (rtarget == 0)
                        { 
                        int rEntity = Memory.ReadInteger(client + EntList + (i * 0x10), 4);
                        int rEntityHealth = Memory.ReadInteger(rEntity + Healthy, 4);
                        int rEntityTeam = Memory.ReadInteger(rEntity + team, 4);
                        int spot = Memory.ReadInteger(rEntity + spots, 4);
                        int dormant = Memory.ReadInteger(rEntity + Dorm, 4);
                        int bonbase = Memory.ReadInteger(rEntity + bone, 4);

                        Vector3 mbon = Memory.ReadBon(bonbase + 0x30 * ((int)UDbon.Value) + 0xC); //Read Bone Coords                  
                        World(mbon, out wPosenthaimbone); //get bone screen position

                            //Make sure target is within range circle
                            if (wPosenthaimbone.X > ScreenWidth / 2 - range && wPosenthaimbone.X < ScreenWidth / 2 + range && wPosenthaimbone.Y > ScreenHeight / 2 - range && wPosenthaimbone.Y < ScreenHeight / 2 + range)  
                            { 
                                if (rEntityHealth > 0 && rEntityTeam != LocalTeam && spot != 0 && dormant != 1) //Make sure we have a legit target
                                rtarget = rEntity;
                            }
                        }
                    }

                        int Entity = rtarget;
                        int EntityHealth = Memory.ReadInteger(Entity + Healthy, 4);
                        int abonbase = Memory.ReadInteger(Entity + bone, 4);

                        if (EntityHealth == 0)
                            rtarget = 0; //if target is killed set rtarget to 0 to the loop above runs again
            

                        Vector3 bon = Memory.ReadBon(abonbase + 0x30 * ((int)UDbon.Value) + 0xC); //Read Bone Coords                  
                        World(bon, out wPosenthaimbone); //get bone screen position


                        if (EntityHealth > 0)
                        {
                            AimP(wPosenthaimbone.X, wPosenthaimbone.Y); //Send co-ords to Aim Function
                        }


                    Music.Graphics.DrawCircle(ScreenWidth / 2 + 1, ScreenHeight / 2 + 1, range, 1, redBrush);  //Draw FOV circle 

                    if (LocalTeam != InCrossTeam && InCrossHealth > 0 && InCrossTeam != 0)
                    {
                        mouse_event(0x002, 0, 0);
                        mouse_event(0x004, 0, 0);
                        Random rnd = new Random();
                        Thread.Sleep(rnd.Next(20, 40));
                    }

                }
                else
                rtarget = 0;

                #endregion
                wintit = Memory.dec("Y3Nnbw==") + ".exe";
                #region ESP
                if (wintit == Memory.dec("Y3Nnbw==") + ".exe")
                {

                    for (int i = 0; i < 64; i++)
                    {
                        int Entity = Memory.ReadInteger(client + EntList + (i * 0x10), 4);
                        int EntityHealth = Memory.ReadInteger(Entity + Healthy, 4);
                        int EntityTeam = Memory.ReadInteger(Entity + team, 4);
                        int dormant = Memory.ReadInteger(Entity + Dorm, 4);
                        int bonbase = Memory.ReadInteger(Entity + bone, 4);
                        //int flagz = Memory.ReadInteger(Entity + flags, 4); //dont trace if flag is jumping

                        Vector3 wPos;

                        if (World(GetEntPos(i, 0), out wPos))
                        {
                            if (EntityHealth > 0)
                            {
                                int brush;
                                int brush2;
                                if (EntityTeam == 2)
                                {
                                    brush = redBrush;
                                    brush2 = redOpacityBrush;
                                }
                                else
                                {
                                    brush = blueBrush;
                                    brush2 = blueOpacityBrush;
                                }

                                if (dormant == 1)
                                    brush = yellowBrush;

                                //Get Distance float for ESP
                                float fDistance = GetDistance(GetEntPos(i, 0), LocalPosition);

                                //Get Base Position for ESP Box
                                Vector3 wPosEntFeet;
                                World(GetEntPos(i, 0), out wPosEntFeet);

                                //Get Head Position for ESP Box
                                Vector3 wPosEntHead;
                                World(GetEntPos(i, 1), out wPosEntHead);

                                //Get Bone Position for Target Circle
                                Vector3 bon = Memory.ReadBon(bonbase + 0x30 * ((int)UDbon.Value) + 0xC);
                                World(bon, out wPosenthaimbone);

                                //Calculat box size
                                int HeightNew = (int)(wPosEntHead.Y - wPosEntFeet.Y);
                                int WidthtNew = (int)(HeightNew / 3.5);

                                int GetOBsID = ((obs & 0xFFF) - 1); //Change m_hObserverTarget into playerID
                                int EntOBs = Memory.ReadInteger(client + EntList + (GetOBsID * 0x10), 4); //Change PlayerID into entity

                                //Drawing Code
                                if (LocalPlayer != Entity && Entity != EntOBs) //Don't draw on local player and don't draw on spectated player
                                {

                                    if (chkMin.Checked != true)
                                    {
                                        Music.Graphics.DrawText((fDistance * 0.01905f).ToString("F1"), font, brush, (int)wPos.X - 10, (int)wPos.Y);
                                        //Music.Graphics.DrawText(flagz.ToString(), font, brush, (int)wPos.X - 40, (int)wPos.Y);

                                        Music.Graphics.BorderedRectangle((int)wPos.X - (WidthtNew), (int)wPos.Y, WidthtNew * 5 / 3, HeightNew, 2, 1, brush, blackBrush, brush2);

                                        Music.Graphics.DrawBarH((int)wPos.X - ((int)(WidthtNew * 1.15)), (int)wPosEntHead.Y, WidthtNew / 8, -HeightNew, EntityHealth, 2, transparent, greenOpacityBrush);
                                    }

                                    Music.Graphics.BorderedCircle((int)wPosenthaimbone.X, (int)wPosenthaimbone.Y, 3500 / (int)(fDistance + 1), 1, brush, blackBrush);
                                    Music.Graphics.FillCircle((int)wPosenthaimbone.X, (int)wPosenthaimbone.Y, 3500 / (int)(fDistance + 1), brush2);
                                }
                            }
                        }
                    }
                }
                #endregion

                if (backgroundWorker1.CancellationPending)
                {
                    Music.Graphics.ClearScene();
                    Music.Graphics.EndScene();
                    return;
                }

                Music.Graphics.EndScene();
            }
        }
 
        bool World(Vector3 from, out Vector3 Out) //World to screen
        {
            Out = new Vector3();

            float w = Matrix.M41 * from.X + Matrix.M42 * from.Y + Matrix.M43 * from.Z + Matrix.M44;         
            if (w < 0.01f)
                return false;

            Out.X = (Matrix.M11 * from.X + Matrix.M12 * from.Y + Matrix.M13 * from.Z + Matrix.M14) * 1.0f / w;
            Out.Y = (Matrix.M21 * from.X + Matrix.M22 * from.Y + Matrix.M23 * from.Z + Matrix.M24) * 1.0f / w;

            Out.X = (ScreenWidth / 2) + 0.5f * Out.X * ScreenWidth + 0.5f;
            Out.Y = (ScreenHeight / 2) - 0.5f * Out.Y * ScreenHeight + 0.5f;

            return true;
        }
        
        Vector3 GetEntPos(int entityptr, int head)
        {
            int Entity = Memory.ReadInteger(client + EntList + (entityptr * 0x10), 4);

            Vector3 pos = Memory.ReadVec3(Entity + Position);

            if (head == 1)
                pos.Z = pos.Z + 72f;

            return pos;
        }
        
        public float GetDistance(Vector3 loc, Vector3 ent)
        {
            float dist;
            dist = (float)Math.Sqrt(Math.Pow(loc.X - ent.X, 2) + Math.Pow(loc.Y - ent.Y, 2) + Math.Pow(loc.Z - ent.Z, 2));
            return dist;
        }

        void AimP(float x, float y)
        {
            //X
            float Speed = (float)udSpeed.Value; //Higher number, slower mouse movement
            float CoOrdX;
            float CoOrdY;
            //If you don't want recoil compensation replace recoil with screen res / 2

            if (x > rec0i1x)
            {
                CoOrdX = -(rec0i1x - x) / Speed;
                if (CoOrdX + rec0i1x > rec0i1x * 2) CoOrdX = 0;
            }
            else
            {
                CoOrdX = (x - rec0i1x) / Speed;
                if (CoOrdX + rec0i1x < 0) CoOrdX = 0;
            }

            //Y
            if (y > rec0i1y)
            {
                CoOrdY = -(rec0i1y - y) / Speed;
                if (CoOrdY + rec0i1y > rec0i1y * 2) CoOrdY = 0;
            }
            else
            {
                CoOrdY = (y - rec0i1y) / Speed;
                if (CoOrdY + rec0i1y < 0) CoOrdY = 0;
            }

            mouse_event(0x8000, (int)(CoOrdX), (int)(CoOrdY), 0, 0);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            txtRes.Text = Properties.Settings.Default.Start;
            UDbon.Value = Properties.Settings.Default.Adjust;
            udSpeed.Value = Properties.Settings.Default.Speed;

            read();
        }

        private void btnGo_Click(object sender, EventArgs e)
        {
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.Black;
            this.ClientSize = new System.Drawing.Size(284, 262);
            this.DoubleBuffered = true;
            this.ForeColor = System.Drawing.SystemColors.ControlText;
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Name = "Form1";
            this.Text = "Form1";
            this.TopMost = true;
            this.TransparencyKey = System.Drawing.Color.Black;
            this.Load += new System.EventHandler(this.Form1_Load);
            this.ResumeLayout(false);
            

            if (chkPerf.Checked == true)
                perf = false;
            else
                perf = true;
            Native.SetLayeredWindowAttributes(this.Handle, 0x0000FF00, 0, 1);
            if (!backgroundWorker1.IsBusy)
                backgroundWorker1.RunWorkerAsync();
            
        }

        private void btnStop_Click(object sender, EventArgs e)
        {
            backgroundWorker1.CancelAsync();
            client = 0;
            Memory.pHandle = 0;
        }

        private void btnExit_Click(object sender, EventArgs e)
        {
            Properties.Settings.Default.Start = txtRes.Text;
            Properties.Settings.Default.Adjust = UDbon.Value;
            Properties.Settings.Default.Speed = udSpeed.Value;
            Properties.Settings.Default.Save();

            this.Close();
        }

        private void Form1_MouseDown(object sender, MouseEventArgs e)
        {
            Capture = false;
            Message msg = Message.Create(Handle, 0xA1, (IntPtr)0x02, IntPtr.Zero);
            base.WndProc(ref msg);
        }

        private void btnExtend_Click(object sender, EventArgs e)
        {
            this.Height = 178;
        }

        public static void read()
        {
            XmlTextReader reader = new XmlTextReader("taxes.xml");
            XmlNodeType type;

            while (reader.Read())
            {
                type = reader.NodeType;

                if (type == XmlNodeType.Element)
                {
                    if (reader.Name == "PlayList")
                    {
                        reader.Read();
                        PlayList = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "ViewM")
                    {
                        reader.Read();
                        ViewM = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "Position")
                    {
                        reader.Read();
                        Position = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "TrackInfo")
                    {
                        reader.Read();
                        EntList = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "crss")
                    {
                        reader.Read();
                        crss = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "punccch")
                    {
                        reader.Read();
                        punccch = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "Dist")
                    {
                        reader.Read();
                        Dist = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "Dorm")
                    {
                        reader.Read();
                        Dorm = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "team")
                    {
                        reader.Read();
                        team = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "Healthy")
                    {
                        reader.Read();
                        Healthy = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "bone")
                    {
                        reader.Read();
                        bone = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "spots")
                    {
                        reader.Read();
                        spots = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "flags")
                    {
                        reader.Read();
                        flags = Convert.ToInt32(reader.Value, 16);
                    }

                    if (reader.Name == "m_obs")
                    {
                        reader.Read();
                        m_obs = Convert.ToInt32(reader.Value, 16);
                    }

                }
            }
            reader.Close();
        }

        private void wincheck_Tick(object sender, EventArgs e)
        {
            wintit = GetProcessPath();
        }
    }
}
