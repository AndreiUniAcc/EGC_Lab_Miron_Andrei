using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;



/// <summary>
/// In constructor m-am jucat cu vsync
/// Draw1 si Draw2 sunt 2 functii cu care pot desena 2 obiecte separate
/// In KeyBoard_KeyDown verific tastele apasate de la tastatura si schimb valorile de bool pt a crea rotatii.
/// In onUpdateFrame am implementat comenzile pt mouse
/// In onRenderFrame am facut sa se miste formele.
/// </summary>

namespace First_OpenTK
{
    class SimpleWindow : GameWindow
    {
        double lastMousePos;
        bool moveLeft = false, moveRight = false, moveUp = false, moveDown = false, mouseClick = false;
        bool pickRandomCubeColors = false;
        KeyboardState lastKeyPress;


        Cube cub;


        // Constructor.
        public SimpleWindow() : base(800, 600, new GraphicsMode(32, 24, 0, 8))
        {
            VSync = VSyncMode.On;
            lastMousePos = 0;
        }


        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.MidnightBlue);
            GL.Enable(EnableCap.DepthTest);
            GL.Hint(HintTarget.PolygonSmoothHint, HintMode.Nicest);

            cub = new Cube(pickRandomCubeColors);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)(Width / (double)Height), 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);

            Matrix4 lookat = Matrix4.LookAt(0, 5, 20, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);

            GL.LoadMatrix(ref lookat);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            MouseState mouse = Mouse.GetState();
            KeyDown += KeyBoard_KeyDown;

            if (mouseClick)
            {
                Console.WriteLine(mouse.X + " " + mouse.Y);
                Console.WriteLine("Pixel Color: " + IntPtr.Size);
                Console.WriteLine(" ");
            }
            if (mouse[MouseButton.Left])
            {
                GL.ClearColor(Color.Orange);
            }
            if (mouse[MouseButton.Right])
            {
                GL.ClearColor(Color.MidnightBlue);
            }
        }


        protected override void OnRenderFrame(FrameEventArgs e)
        {
            base.OnRenderFrame(e);

            GL.Clear(ClearBufferMask.ColorBufferBit | ClearBufferMask.DepthBufferBit);
                
            cub.DrawCube();
            cub.CubeRotation(e, moveLeft, moveRight, moveUp, moveDown);

            SwapBuffers();
        }


        void KeyBoard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            KeyboardState keyboard = Keyboard.GetState();
            MouseState mouse = Mouse.GetState();


            double actualMousePos = mouse.Y;

            // aici fac rotatia obiectului doar in timpul miscarii mouseului
            // idee venita dupa ce m-am uitat la clasa mouseMoveEventArgs si nu am inteles cum 
            // sa o folosesc aici asa ca am implementat o varianta rudimentara.

            if (actualMousePos > lastMousePos)
            {
                moveDown = true;
                moveUp = false;
            }
            else
            if (actualMousePos < lastMousePos)
            {
                moveDown = false;
                moveUp = true;
            }
            else
            {
                moveDown = false;
                moveUp = false;
            }

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

            if (keyboard[Key.Number1] && !keyboard.Equals(lastKeyPress))
            {
                pickRandomCubeColors = true;
            }
            if (keyboard[Key.Number2] && !keyboard.Equals(lastKeyPress))
            {
                pickRandomCubeColors = false;
            }

            if (keyboard[Key.F11] && !keyboard.Equals(lastKeyPress))
            {
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;
            }

            if (keyboard[Key.Right] && !keyboard.Equals(lastKeyPress))
            {
                moveRight = true;
                moveLeft = false;
                moveDown = false;
                moveUp = false;
            }
            if (keyboard[Key.Left] && !keyboard.Equals(lastKeyPress))
            {
                moveLeft = true;
                moveRight = false;
                moveUp = false;
                moveDown = false;
            }

            if (keyboard[Key.L] && !keyboard.Equals(lastKeyPress))
            {
                cub.ToggleVisibility();
            }

            lastMousePos = actualMousePos;
            lastKeyPress = keyboard;
        }


        [STAThread]
        static void Main(string[] args)
        {
            using (SimpleWindow EGC = new SimpleWindow())
            {
                EGC.Run(30.0, 0.0);
            }
        }
    }
}
