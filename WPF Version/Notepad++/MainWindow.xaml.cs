using System;
using System.Collections.Generic;
using System.Windows.Threading;
using System.Threading;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Media;
using System.Windows.Shapes;
using System.Windows.Interop;
using System.Numerics;
using System.Windows.Controls;
using System.Windows.Forms;


namespace Notepad__
{
    public partial class MainWindow : Window
    {
        int currenttarget;

        int ScreenHeight = Screen.PrimaryScreen.Bounds.Height;
        int ScreenWidth = Screen.PrimaryScreen.Bounds.Width;

        int memoryperf = 4;

        Form1 frm = new Form1();

        int fovcirc = 500;
        float aimspeed = 2;
        int aimbone = 8;

        public static int render = 0;

        #region lists
        List<float> xLlist = new List<float>(); //hold entity X-coords
        List<float> yLlist = new List<float>(); //hold entity Y-coords
        List<float> xLlistAim = new List<float>(); //hold entity X-coords
        List<float> yLlistAim = new List<float>(); //hold entity Y-coords
        List<float> dist = new List<float>(); //hold entity distance
        List<int> team = new List<int>(); //hold entity distance
        List<int> dorm = new List<int>(); //hold entity distance
        List<int> health = new List<int>(); //hold entity distance
        List<int> BoxX = new List<int>(); //hold entity distance
        List<int> BoxY = new List<int>(); //hold entity distance
        List<int> BoxW = new List<int>(); //hold entity distance
        List<int> BoxH = new List<int>(); //hold entity distance
        List<int> loc = new List<int>(); //hold entity distance
        List<int> obz = new List<int>(); //hold entity distance
        #endregion

        Matrix4x4 Matrix;

        Vector3 wPos;
        Vector3 wPosenthaimbone = new Vector3();

        int rec0i1x;
        int rec0i1y;


        #region brushes

        SolidColorBrush TransparentRed = new SolidColorBrush(Color.FromArgb(30, 255, 0, 0));
        SolidColorBrush TransparentGreen = new SolidColorBrush(Color.FromArgb(30, 0, 255, 0));
        SolidColorBrush TransparentBlue = new SolidColorBrush(Color.FromArgb(30, 0, 0, 255));
        SolidColorBrush TransparentYellow = new SolidColorBrush(Color.FromArgb(30, 255, 255, 0));

        Color bRed = (Color.FromRgb(255, 0, 0));
        Color bGreen = (Color.FromRgb(0, 255, 0));
        Color bBlue = (Color.FromRgb(0, 0, 255));
        Color bYellow = (Color.FromRgb(255, 255, 0));

        Color bEmpty = (Color.FromRgb(0, 0, 0));
        SolidColorBrush EmptyBrush = new SolidColorBrush(Color.FromArgb(0, 0, 0, 0));
        #   endregion

        int rtarget;

        int client; //client.dll

        public MainWindow()
        {
            InitializeComponent();

            System.Diagnostics.Process myProcess = System.Diagnostics.Process.GetCurrentProcess();
            myProcess.PriorityClass = System.Diagnostics.ProcessPriorityClass.RealTime;

            DispatcherTimer dtDrawTime = new DispatcherTimer();

            dtDrawTime.Interval = new TimeSpan(0, 0, 1); //in Hour, Minutes, Second.
            dtDrawTime.Tick += DrawTimer_Tick;
            
            dtDrawTime.Start();
            ;
        }

        protected override void OnSourceInitialized(EventArgs e)
        {
            // Set the WS_EX_TRANSPARENT style on the window so we can click through it.
            var hwnd = new WindowInteropHelper(this).Handle;
            Native.SetWindowTransparent(hwnd);
            base.OnSourceInitialized(e);

         //   Form1 frm = new Form1();
            frm.Show();


            //Populate lists
            for (int i = 0; i < 64; i++)
            {
                xLlist.Add(0);
                yLlist.Add(0);
                xLlistAim.Add(0);
                yLlistAim.Add(0);
                team.Add(0);
                dist.Add(0);
                dorm.Add(0);
                health.Add(0);
                BoxX.Add(0);
                BoxY.Add(0);
                BoxW.Add(0);
                BoxH.Add(0);
                loc.Add(0);
                obz.Add(0);
            }

            GetNews();

            CompositionTarget.Rendering += CompositionTarget_Rendering;
        }


        private void DrawTimer_Tick(object sender, EventArgs e)
        {
            fovcirc = (int)frm.udFOV.Value;
            aimspeed = (int)frm.udSpeed.Value;
            aimbone = (int)frm.UDbon.Value;
            //Thread.Sleep(200);
        }

        Vector3 GetEntPos(int entityptr, int head)
        {
            int Entity = Memory.ReadInteger(client + Offsets.EntityList + (entityptr * 0x10), 4);

            Vector3 pos = Memory.ReadVec3(Entity + Offsets.Position);

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


        public void begin()
        {
            render = 1;
        }

        public void end()
        {
            render = 0;
        }

        void AimP(float x, float y)
        {
            //X
            float Speed = aimspeed; //Higher number, slower mouse movement
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

            Native.mouse_event(0x0001, (int)(CoOrdX), (int)(CoOrdY), 0, 0);
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

        private void GetNews()
        {
            Task.Factory.StartNew(() =>
            {
                while (true)
                {

                    #region MemoryWork
                    if (client == 0)
                        client = Memory.GetBaseAddress(Memory.dec("Y3Nnbw=="), Memory.dec("Y2xpZW50LmRsbA=="));

                    Matrix = Memory.ReadMatrix(client + Offsets.ViewMatrix);



                    //LocalPlayer
                    int LocalPlayer = Memory.ReadInteger(client + Offsets.LocalPlayer, 4);
                    int LocalTeam = Memory.ReadInteger(LocalPlayer + Offsets.Team, 4);
                    int InCross = Memory.ReadInteger(LocalPlayer + Offsets.CrossID, 4);
                    int obs = Memory.ReadInteger(LocalPlayer + Offsets.m_observerT, 4);

                    Vector3 LocalPosition = Memory.ReadVec3(LocalPlayer + Offsets.Position + (0x4 * 0));
                    

                    #endregion

                    #region punchdot
                    Vector3 Punch = Memory.ReadVec3(LocalPlayer + Offsets.AimPunch);

                    rec0i1x = (int)((ScreenWidth / 2) - (ScreenWidth / 90) * (Punch.Y)) + 1; // These values are used for the aimbot to offset recoil punch , the +1 is to correct it to the center
                    rec0i1y = (int)((ScreenHeight / 2) + (ScreenHeight / 90) * (Punch.X)) + 1;
                    #endregion

                    #region triggerbot
                    //Triggerbot Code
                    if (Convert.ToBoolean(Native.GetAsyncKeyState(Keys.MButton)))
                    {
                        int InCrossID = Memory.ReadInteger(client + Offsets.EntityList + ((InCross - 1) * Offsets.Dist), 4);
                        int InCrossHealth = Memory.ReadInteger(InCrossID + Offsets.Health, 4); // Enemy in crosshair's 
                        int InCrossTeam = Memory.ReadInteger(InCrossID + Offsets.Team, 4); // Enemy in crosshair's team, we need this to compare it to our own player's team)
                        int InCrossPosition = Memory.ReadInteger(InCrossID + Offsets.Position, 4);

                        if (LocalTeam != InCrossTeam && InCrossHealth > 0 && InCrossTeam != 0)
                        {
                            Native.mouse_event(0x002, 0, 0);
                            Native.mouse_event(0x004, 0, 0);
                            Random rnd = new Random();
                            Thread.Sleep(rnd.Next(10, 30));
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
                    #endregion

                    #region aimer

                    if (Convert.ToBoolean(Native.GetAsyncKeyState(Keys.LShiftKey)))
                    {
                        int InCrossID = Memory.ReadInteger(client + Offsets.EntityList + ((InCross - 1) * Offsets.Dist), 4);
                        int InCrossTeam = Memory.ReadInteger(InCrossID + Offsets.Team, 4); // Enemy in crosshair's team, we need this to compare it to our own player's team)

                        if (LocalTeam != InCrossTeam) //Check team
                        {
                            if (InCross != 0)
                                currenttarget = InCross - 1;

                            int Entity = Memory.ReadInteger(client + Offsets.EntityList + (currenttarget * 0x10), 4);
                            int EntityHealth = Memory.ReadInteger(Entity + Offsets.Health, 4);
                            int spot = Memory.ReadInteger(Entity + Offsets.spots, 4); //make sure spotted so dont trace through walls
                            int flagz = Memory.ReadInteger(Entity + Offsets.flags, 4); //dont trace if flag is jumping
                            int bonbase = Memory.ReadInteger(Entity + Offsets.bone, 4);
                            int dormant = Memory.ReadInteger(Entity + Offsets.Dorm, 4);

                            Vector3 bon = Memory.ReadBon(bonbase + 0x30 * ((int)aimbone) + 0xC); //Read Bone Coords                  
                            World(bon, out wPosenthaimbone); //get bone screen position

                            if (currenttarget != 0 && EntityHealth > 0 && spot != 0 && flagz != 256 && dormant != 1)
                            {
                                AimP(wPosenthaimbone.X, wPosenthaimbone.Y); //Send co-ords to Aim Function
                            }
                        }
                    }
                    else
                        currenttarget = 0;

                    #endregion

                    #region FOV Lock

                    if (Convert.ToBoolean(Native.GetAsyncKeyState(Keys.XButton1)))
                    {
                        int range = (int)fovcirc / 2;  //Set the range

                        for (int i = 0; i < 64; i++)
                        {
                            if (rtarget == 0)
                            {
                                int rEntity = Memory.ReadInteger(client + Offsets.EntityList + (i * 0x10), 4);
                                int rEntityHealth = Memory.ReadInteger(rEntity + Offsets.Health, 4);
                                int rEntityTeam = Memory.ReadInteger(rEntity + Offsets.Team, 4);
                                int spot = Memory.ReadInteger(rEntity + Offsets.spots, 4);
                                int dormant = Memory.ReadInteger(rEntity + Offsets.Dorm, 4);
                                int bonbase = Memory.ReadInteger(rEntity + Offsets.bone, 4);

                                Vector3 mbon = Memory.ReadBon(bonbase + 0x30 * ((int)aimbone) + 0xC); //Read Bone Coords                  
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
                        int EntityHealth = Memory.ReadInteger(Entity + Offsets.Health, 4);
                        int abonbase = Memory.ReadInteger(Entity + Offsets.bone, 4);

                        if (EntityHealth == 0)
                            rtarget = 0; //if target is killed set rtarget to 0 to the loop above runs again


                        Vector3 bon = Memory.ReadBon(abonbase + 0x30 * ((int)aimbone) + 0xC); //Read Bone Coords                  
                        World(bon, out wPosenthaimbone); //get bone screen position


                        if (EntityHealth > 0)
                        {
                            AimP(wPosenthaimbone.X, wPosenthaimbone.Y); //Send co-ords to Aim Function
                        }


                        int InCrossID = Memory.ReadInteger(client + Offsets.EntityList + ((InCross - 1) * Offsets.Dist), 4);
                        int InCrossHealth = Memory.ReadInteger(InCrossID + Offsets.Health, 4); // Enemy in crosshair's 
                        int InCrossTeam = Memory.ReadInteger(InCrossID + Offsets.Team, 4); // Enemy in crosshair's team, we need this to compare it to our own player's team)
                        //int InCrossPosition = Memory.ReadInteger(InCrossID + Offsets.Position, 4);

                        if (LocalTeam != InCrossTeam && InCrossHealth > 0 && InCrossTeam != 0)
                        {
                            Native.mouse_event(0x002, 0, 0);
                            Native.mouse_event(0x004, 0, 0);
                            Random rnd = new Random();
                            Thread.Sleep(rnd.Next(10, 30));
                        }

                    }
                    else
                        rtarget = 0;



                    #endregion

                    #region ReadInfo

                    for (int i = 0; i < 64; i++)
                    {
                        int Entity = Memory.ReadInteger(client + Offsets.EntityList + (i * 0x10), 4);

                        team[i] = Memory.ReadInteger(Entity + Offsets.Team, 4);

                        health[i] = Memory.ReadInteger(Entity + Offsets.Health, 4);

                        int bonbase = Memory.ReadInteger(Entity + Offsets.bone, 4);

                        if (health[i] > 0)
                        {
                            //Get Entity Position
                            World(GetEntPos(i, 0), out wPos);

                            //Get Distance float for ESP
                            float fDistance = GetDistance(GetEntPos(i, 0), LocalPosition);

                            //Get Base Position for ESP Box
                            Vector3 wPosEntFeet;
                            World(GetEntPos(i, 0), out wPosEntFeet);

                            //Get Head Position for ESP Box
                            Vector3 wPosEntHead;
                            World(GetEntPos(i, 1), out wPosEntHead);

                            //Get Bone Position for Target Circle
                            Vector3 bon = Memory.ReadBon(bonbase + 0x30 * ((int)aimbone) + 0xC);
                            World(bon, out wPosenthaimbone);

                            //Calculate box size
                            int HeightNew = (int)(wPosEntHead.Y - wPosEntFeet.Y);
                            int WidthtNew = (int)(HeightNew / 3);

                            //Make sure values aren't or below 0
                            if (HeightNew < 0)
                                HeightNew = HeightNew * -1;

                            if (WidthtNew < 0)
                                WidthtNew = WidthtNew * -1;

                            if (fDistance < 1)
                                fDistance = fDistance + 1;

                            int GetOBsID = ((obs & 0xFFF) - 1); //Change m_hObserverTarget into playerID
                            int EntOBs = Memory.ReadInteger(client + Offsets.EntityList + (GetOBsID * 0x10), 4); //Change PlayerID into entity

                            //Fill lists with player/entity info
                            if (LocalPlayer == Entity)
                            {
                                loc[i] = 1;
                            }
                            else
                            {
                                loc[i] = 0;
                            }

                            if (Entity == EntOBs)
                            {
                                obz[i] = 1;
                            }
                            else
                            {
                                obz[i] = 0;
                            }

                            dorm[i] = Memory.ReadInteger(Entity + Offsets.Dorm, 4);
                            xLlist[i] = wPosEntFeet.X;
                            yLlist[i] = wPosEntFeet.Y;

                            xLlistAim[i] = wPosenthaimbone.X;
                            yLlistAim[i] = wPosenthaimbone.Y;

                            dist[i] = 7000 / (int)(fDistance);

                            BoxX[i] = (int)wPos.X - (WidthtNew);
                            BoxY[i] = (int)wPos.Y - HeightNew;

                            BoxW[i] = WidthtNew * 5 / 3;
                            BoxH[i] = (int)(HeightNew);
                        }
                    }
                    #endregion

                    Thread.Sleep(memoryperf);
                }
            });

        }



        private bool[] playerBoxesUsed = new bool[64];
        private Border[] playerBoxes = new Border[64];
        private TextBlock[] playerText = new TextBlock[64];
        private Ellipse[] playerellipse = new Ellipse[64];
        private Line cross = new Line();
        private Line cross2 = new Line();
        private Ellipse fov2 = new Ellipse();

        // Required to calculate FPS.
        private TimeSpan lastFps = TimeSpan.Zero;
        private int fps;

        // Required to limit FPS.
        private bool enableFPSLimiting = true; // Set to true to enable.
        private int fpsCapValue = 60;
        private TimeSpan lastFpsValue = TimeSpan.Zero;

        void CompositionTarget_Rendering(object sender, EventArgs e)
        {
            if (render == 1)
            {
                CanvasX.Visibility = Visibility.Visible;
                // Cast the EventArgs to a RenderingEventArgs because of a bad decleration by Microsoft.
                var args = (RenderingEventArgs)e;

                // Check if FPS limiting is enabled and skip the render if required.
                if (enableFPSLimiting)
                {
                    var capTime = TimeSpan.FromSeconds(1.0 / fpsCapValue);
                    if (args.RenderingTime.Subtract(lastFpsValue) < capTime)
                        return;
                    lastFpsValue += capTime;
                }

                // Increase the FPS counter.
                fps++;

                // Check that 1 second has elapsed and update the FPS (using the argument's rendering
                // time is more accurate than other methods).
                if (args.RenderingTime.Subtract(lastFps).TotalMilliseconds >= 1000)
                {
                    fpsTextBlock.Text = "FPS: " + fps;
                    lastFps = args.RenderingTime;

                    // Yes, I set this to -1 because the FPS seems to always be 1 frame off when
                    // comparing it with Perforator in the WPF Performance Suite.
                    fps = -1;
                }

                for (int i = 0; i < playerBoxesUsed.Length; i++)
                    playerBoxesUsed[i] = false;

                // Go through each player that we need to draw.
                for (int i = 0; i < 64; i++)
                {
                    // Check if this is a new player, if so, create a new Border and TextBlock object which
                    // wil form our rectangles and player names.


                    if (team[i] == 2)
                        EmptyBrush = TransparentRed;
                    else
                        EmptyBrush = TransparentGreen;

                    if (team[i] == 2)
                        bEmpty = bRed;
                    else
                        bEmpty = bGreen;

                    if (dorm[i] == 1)
                    {
                        EmptyBrush = TransparentYellow;
                        bEmpty = bYellow;
                    }


                    if (playerBoxes[i] == null)
                    {
                        playerBoxes[i] = new Border { BorderThickness = new Thickness(1), CornerRadius = new CornerRadius(15) };
                        playerText[i] = new TextBlock { FontSize = 12, Foreground = new SolidColorBrush(Color.FromArgb(0x7F, 0xFF, 0xFF, 0xFF)) };
                        playerellipse[i] = new Ellipse { };
                        cross = new Line { };
                        cross2 = new Line { };
                        fov2 = new Ellipse { };

                        cross.Visibility = Visibility.Hidden;
                        cross2.Visibility = Visibility.Hidden;

                        //if (Form1.chkPerf.Checked == true)
                       // CanvasX.Children.Add(playerBoxes[i]);
                  //      CanvasX.Children.Add(playerText[i]);
                        CanvasX.Children.Add(playerellipse[i]);
                        CanvasX.Children.Add(cross);
                        CanvasX.Children.Add(cross2);
                        CanvasX.Children.Add(fov2);
                    }
                    else if (!playerBoxesUsed[i])
                    {
                        // If the box was previously marked as not to draw, make it visible.
                        playerBoxes[i].Visibility = Visibility.Visible;
                        playerText[i].Visibility = Visibility.Visible;
                        playerellipse[i].Visibility = Visibility.Visible;
                        cross.Visibility = Visibility.Visible;
                        cross2.Visibility = Visibility.Visible;
                    }

                    //FOV Circle
                    if (Convert.ToBoolean(Native.GetAsyncKeyState(Keys.XButton1)))
                    {

                        fov2.Visibility = Visibility.Visible;
                    }
                    else
                    {
                        fov2.Visibility = Visibility.Hidden;
                    }

                    // Mark this box as drawn.
                    playerBoxesUsed[i] = true;

                    // Set the properties of the border, eg. color, thickness, width and height.
                    playerBoxes[i].BorderBrush = new SolidColorBrush(Color.FromRgb(0, 0, 0));
                    playerBoxes[i].Background = EmptyBrush;
                    playerellipse[i].Fill = EmptyBrush;

                    if (team[i] == 2)
                        playerellipse[i].Stroke = new SolidColorBrush(Color.FromRgb(255, 0, 0));
                    else
                        playerellipse[i].Stroke = new SolidColorBrush(Color.FromRgb(0, 255, 0));

                    if (dorm[i] == 1)
                    {
                        playerellipse[i].Stroke = new SolidColorBrush(Color.FromRgb(255, 255, 0));
                    }



                    //Set Properties of FOV Circle
                    fov2.Fill = new SolidColorBrush(Color.FromArgb(50, 0, 0, 255));
                    fov2.Width = fovcirc;
                    fov2.Height = fovcirc;

                    Canvas.SetLeft(fov2, (ScreenWidth / 2) - (fovcirc / 2));
                    Canvas.SetTop(fov2, (ScreenHeight / 2) - (fovcirc / 2));


                    // Set the properties of the text.
                    //playerText[i].Text = i.ToString();

                    //Set Properties of CrossHair
                    cross.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                    cross.X1 = rec0i1x - 4;
                    cross.X2 = rec0i1x + 16;
                    cross.Y1 = rec0i1y + 6;
                    cross.Y2 = rec0i1y + 6;

                    cross2.Stroke = new SolidColorBrush(Color.FromArgb(255, 0, 255, 0));
                    cross2.X1 = rec0i1x + 6;
                    cross2.X2 = rec0i1x + 6;
                    cross2.Y1 = rec0i1y - 4;
                    cross2.Y2 = rec0i1y + 16;

                    // Set the X and Y location of the box.
                    if (health[i] > 0)
                    {
                        playerBoxes[i].Width = BoxW[i];
                        playerBoxes[i].Height = BoxH[i];

                        //circle
                        playerellipse[i].Width = dist[i];
                        playerellipse[i].Height = dist[i];

                        //Set Box
                        Canvas.SetLeft(playerBoxes[i], xLlist[i] - (BoxW[i] / 2)); //+ (dist[i])
                        Canvas.SetTop(playerBoxes[i], yLlist[i] - BoxH[i]);

                        // Set the X and Y location of the ellipse.
                        Canvas.SetLeft(playerellipse[i], xLlistAim[i] - (dist[i] / 2) + 6);
                        Canvas.SetTop(playerellipse[i], yLlistAim[i] - (dist[i] / 2) + 6);

                        // Set the X and Y location of the player's name.
                        Canvas.SetLeft(playerText[i], xLlistAim[i] + dist[i] / 2 - playerText[i].ActualWidth / 2);
                        Canvas.SetTop(playerText[i], yLlistAim[i] - dist[i]);
                    }
                    else
                    {
                        playerBoxes[i].Width = 0;
                        playerBoxes[i].Height = 0;

                        //circle
                        playerellipse[i].Width = 0;
                        playerellipse[i].Height = 0;

                        //Set Box
                        Canvas.SetLeft(playerBoxes[i], 0);
                        Canvas.SetTop(playerBoxes[i], 0);

                        // Set the X and Y location of the ellipse.
                        Canvas.SetLeft(playerellipse[i], 0);
                        Canvas.SetTop(playerellipse[i], 0);

                        // Set the X and Y location of the player's name.
                        Canvas.SetLeft(playerText[i], 0);
                        Canvas.SetTop(playerText[i], 0);
                    }
                }

           
            // Go through each box and hide any boxes we don't need.
            for (int i = 0; i < playerBoxesUsed.Length; i++)
                {
                    if (!playerBoxesUsed[i] && playerBoxes[i] != null)
                    {
                        playerBoxes[i].Visibility = Visibility.Hidden;
                        playerText[i].Visibility = Visibility.Hidden;
                        playerellipse[i].Visibility = Visibility.Hidden;
                    }


                    if (loc[i] == 1 || obz[i] == 1 )
                    {
                        playerBoxes[i].Visibility = Visibility.Hidden;
                        playerText[i].Visibility = Visibility.Hidden;
                        playerellipse[i].Visibility = Visibility.Hidden;
                    }
                }
            }
            else
            { CanvasX.Visibility = Visibility.Hidden; }
        }   
    }
}
