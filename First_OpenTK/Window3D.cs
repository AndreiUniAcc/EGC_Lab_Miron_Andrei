using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_OpenTK
{
    class Window3D : GameWindow
    {

        private bool mouseClick = false;
        private bool activateCameraMovement = false, activateObjectMovement = false, activateZoom = false, closeZoom = false, farZoom = false;
        private bool pickRandomCubeColors = false;

        private CameraMovement cam;

        private KeyboardState lastKeyPress;
        private MouseState lastClick;


        private MassiveObject mo;
        private Cube cub;
        private Axes axe;
        private FallingObj fb;


        // Constructor.
        public Window3D() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            Program.Menu();
            VSync = VSyncMode.On;
            cam = new CameraMovement();
            fb = new FallingObj();
            cub = new Cube();
            axe = new Axes();
            mo = new MassiveObject(Color.Green);
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.DarkSlateGray);
            GL.Enable(EnableCap.DepthTest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);
      
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)(Width / (double)Height), 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
         
            cam.SetCamera();

        }

    protected override void OnUpdateFrame(FrameEventArgs e)
    {
            base.OnUpdateFrame(e);
 
            MouseState mouse = Mouse.GetState();
            KeyboardState keyboard = Keyboard.GetState();

            KeyDown += KeyBoard_KeyDown;

            if (mouse[MouseButton.Left] && !lastClick[MouseButton.Left])
                if(!fb.isVisible() || fb.onGround())
                { 
                    fb = new FallingObj();
                    fb.VisibilityToggle();
                }
            fb.Falling();

            if (mouse[MouseButton.Right])
            {
                GL.ClearColor(Color.MidnightBlue);
            }



            #region Camera Movement
            if (keyboard[Key.Left] && activateCameraMovement)
            cam.MoveLeft();
        if (keyboard[Key.Right] && activateCameraMovement)
            cam.MoveRight();
        if (keyboard[Key.Up] && activateCameraMovement)
            cam.MoveUp();
        if (keyboard[Key.Down] && activateCameraMovement)
            cam.MoveDown();
            #endregion

            #region Zoom

            if (keyboard[Key.Up] && activateZoom)
            cam.MoveForward();
        if (keyboard[Key.Down] &&  activateZoom)
            cam.MoveBackward();
        if (keyboard[Key.Q] && activateZoom && !farZoom && !lastKeyPress[Key.Q])
        {
            cam.SetCameraFar();
            farZoom = true;
        }
        else 
        {
            Vector3 eye = new Vector3(10, 10, 30);
            cam.SetCamera();
            farZoom = false; 
        }
        if (keyboard[Key.A] && activateZoom && !closeZoom && !lastKeyPress[Key.A])
        {
            cam.SetCameraClose();
            closeZoom = true;
        }
        else
        {
                Vector3 eye = new Vector3(10, 10, 30);
                cam.SetCamera();
            closeZoom = false;
        }
            #endregion



            if (keyboard[Key.O] && !keyboard.Equals(lastKeyPress))
                mo.ToggleVisibility();


            lastClick = mouse;
            lastKeyPress = keyboard;
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);

            cub.DrawCube(pickRandomCubeColors);
            axe.Draw();
            
            fb.Draw();
            mo.Draw();
            SwapBuffers();
        }


        void KeyBoard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();


            if (mouse[MouseButton.Left])
            {
                if (mouseClick)
                    mouseClick = false;
                else
                    mouseClick = true;
            }
            if (keyboard[Key.Escape] && !keyboard.Equals(lastKeyPress))
            {
                this.Exit();
            }

            if (keyboard[Key.F11] && !keyboard.Equals(lastKeyPress))
            {
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
            }


            #region Movement activation type.Zoom, Camera, objRotation, objTranslation.

            if (keyboard[Key.M] && !keyboard.Equals(lastKeyPress))
            {
                Program.Menu();
                Console.WriteLine("Object movement is activated.");
                activateObjectMovement = true;
                activateZoom = activateCameraMovement = false;
            }
            if (keyboard[Key.C] && !keyboard.Equals(lastKeyPress))
            {
                Program.Menu();
                Console.WriteLine("Camera control Activated.");
                activateCameraMovement = true;
                activateZoom = activateObjectMovement = false;
            }
            if (keyboard[Key.Z] && !keyboard.Equals(lastKeyPress))
            {
                Program.Menu();
                Console.WriteLine("Zoom Activated.");
                activateZoom = true;
                activateObjectMovement = activateCameraMovement = false;
            }
            #endregion


            #region Cube's Colors/draw control


            if (keyboard[Key.Number1] && !keyboard.Equals(lastKeyPress))
            {
                pickRandomCubeColors = true;
            }
            if (keyboard[Key.Number2] && !keyboard.Equals(lastKeyPress))
            {
                pickRandomCubeColors = false;
            }
            if (keyboard[Key.Number3])
            {
                cub.SetRandomColorList();
            }
            if (keyboard[Key.L] && !keyboard.Equals(lastKeyPress))
            {
                cub.ToggleVisibility();
            }
            #endregion

            lastKeyPress = keyboard;

        }
    }
}
