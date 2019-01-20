using System;

using GameOverlay.Graphics;
using GameOverlay.Graphics.Primitives;
using GameOverlay.Utilities;
using GameOverlay.Windows;

namespace libSodium
{
    public class Draw
    {
        private OverlayWindow _window;
        public D2DDevice _device;
        private FrameTimer _frameTimer;

        private bool _initializeGraphicObjects;

        private D2DSolidColorBrush _blackBrush;
        private D2DSolidColorBrush _redBrush;
        private D2DSolidColorBrush _greenBrush;
        private D2DSolidColorBrush _blueBrush;
        private D2DSolidColorBrush _yellowBrush;
        private D2DSolidColorBrush _emptyBrush;

        private D2DLinearGradientBrush _gradient;

        public Draw()
        {
            SetupInstance();
        }

        ~Draw()
        {
            //DestroyInstance();
        }

        private void SetupInstance()
        {
            _window = new OverlayWindow(new OverlayOptions()
            {
                BypassTopmost = false,
                Height = 1080,
                Width = 1920,
                WindowTitle = "libSodium",
                X = 0,
                Y = 0
            });

            _device = new D2DDevice(new DeviceOptions()
            {
                AntiAliasing = true,
                Hwnd = _window.WindowHandle,
                MeasureFps = true,
                MultiThreaded = true,
                VSync = true
            });

            _frameTimer = new FrameTimer(_device, 0);

            _window.OnWindowBoundsChanged += _window_OnWindowBoundsChanged;

            _initializeGraphicObjects = true;

            _frameTimer.OnFrameStarting += _frameTimer_OnFrameStarting;
            _frameTimer.OnFrame += _frameTimer_OnFrame;

            _frameTimer.Start();
        }

        public void DestroyInstance()
        {
            _frameTimer.Stop();

            //Begin and clear scene to stop last draw sticking on screen
            _device.BeginScene();
            _device.ClearScene();

            _frameTimer.Dispose();
            _device.Dispose();
            _window.Dispose();

            _window = null;
            _device = null;
            _frameTimer = null;
        }

        private void _window_OnWindowBoundsChanged(int x, int y, int width, int height)
        {
            if (_device == null) return;
            if (!_device.IsInitialized) return;

            _device.Resize(width, height);
        }

        private void _frameTimer_OnFrameStarting(FrameTimer timer, D2DDevice device)
        {
            if (!_initializeGraphicObjects) return;

            if (!device.IsInitialized) return;
            if (device.IsDrawing) return;

            // colors automatically normalize values to fit. you can use 1.0f but also 255.0f.
            _blackBrush = device.CreateSolidColorBrush(0x0, 0x0, 0x0, 0xFF);
            _redBrush = device.CreateSolidColorBrush(0xFF, 0x0, 0x0, 0xFF);
            _greenBrush = device.CreateSolidColorBrush(0x0, 0xFF, 0x0, 0xFF);
            _blueBrush = device.CreateSolidColorBrush(0x0, 0x0, 0xFF, 0xFF);
            _yellowBrush = device.CreateSolidColorBrush(0xFF, 0xFF, 0x0, 0xFF);
            _gradient = new D2DLinearGradientBrush(device, new D2DColor(0, 0, 80), new D2DColor(0x88, 0, 125), new D2DColor(0, 0, 225));

            _initializeGraphicObjects = false;
        }

        private void _frameTimer_OnFrame(FrameTimer timer, D2DDevice device)
        {
            // the render loop will call device.BeginScene() and device.EndScene() for us
            if (!device.IsDrawing)
            {
                _initializeGraphicObjects = true;
                return;
            }
            device.ClearScene();

            if (Config.focused)
            {
                if (vars.drawFOV == 1)
                    device.DrawCircle(vars.ScreenWidth / 2 + 1, vars.ScreenHeight / 2 + 1, Config.FOV, 1, _blueBrush);  //Draw FOV circle

                //Crosshair aimPunch
                Point centralPoint = new Point(vars.recoilX + 1, vars.recoilY + 1);
                device.DrawCrosshair(CrosshairStyle.Plus, centralPoint, 7, 1f, _greenBrush);

                for (int i = 0; i < Config.numberOfPlayers; i++)
                {
                    if (Lists.team[i] == 2)
                        _emptyBrush = _redBrush;
                    else
                        _emptyBrush = _greenBrush; ;

                    if (Lists.dormant[i] == 1)
                    {
                        _emptyBrush = _yellowBrush;
                    }

                    if (Lists.health[i] > 0 && vars.localClass.LocalPlayer != Lists.entityID[i] && Lists.entityID[i] != Lists.observer[i] && Lists.selectedBoneX[i] != 0)
                        device.OutlineCircle(Lists.selectedBoneX[i], Lists.selectedBoneY[i], Lists.distance[i] + 0.1f, 2.0f, _emptyBrush, _blackBrush);
                }
            }
        }
    }
}