using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

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

        const float rotationSpeed = 100.0f;
        float angle;
        bool showCube = false, moveLeft = false, moveRight = false;
        bool moveUp = false, moveDown = false;

        // Constructor.
        public SimpleWindow() : base(800, 600)
        {
            VSync = VSyncMode.On;
        }

        void KeyBoard_KeyDown(object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
            {
                this.Exit();
            }

            if (e.Key == Key.F11)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;

            if (e.Key == Key.Right)
            {
                moveRight = true;
                moveLeft = false;
                moveDown = false;
                moveUp = false;
            }
            if (e.Key == Key.Left)
            {
                moveLeft = true;
                moveRight = false;
                moveUp = false;
                moveDown = false;
            }

            if(e.Key == Key.E)
                if (showCube == true)
                {
                    showCube = false;
                }
                else
                {
                    showCube = true;
                }
        }

        protected override void OnLoad(EventArgs e)
        {
            base.OnLoad(e);
            GL.ClearColor(Color.MidnightBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)(Width / (double)Height), 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            base.OnUpdateFrame(e);

            KeyDown += KeyBoard_KeyDown;
            MouseState mouse = Mouse.GetState();

            if (mouse.IsAnyButtonDown)
                Console.WriteLine(mouse.X + " " + mouse.Y);
            if (mouse.Y > 0) 
            {
                moveUp = true;
                moveDown = false;
            }
            else
            {
                moveUp = false;
                moveDown = true;

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
            GL.Clear(ClearBufferMask.ColorBufferBit);

            Matrix4 lookat = Matrix4.LookAt(0, 5, 10, 
                                            0, 0, 0,
                                            0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);


            

            if (showCube == true)
            {
                angle += rotationSpeed * (float)e.Time;
                if(moveLeft is true)
                    GL.Rotate(angle, 0.0f, 1.0f, 0.0f);
                if (moveRight is true)
                    GL.Rotate(angle, 0.0f, -1.0f, 0.0f);
                //if (moveUp is true)
                //    GL.Rotate(angle, 1.0f, 0.0f, 0.0f);
                //if (moveDown is true)
                //    GL.Rotate(angle, -1.0f, 0.0f, 0.0f);
               // Draw2();
                Draw();
               
            }

            this.SwapBuffers();
        }


        private void Draw()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Silver);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);

            GL.Color3(Color.Honeydew);
            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);

            GL.Color3(Color.Moccasin);

            GL.Vertex3(-1.0f, -1.0f, -1.0f);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);

            GL.Color3(Color.IndianRed);
            GL.Vertex3(-1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);

            GL.Color3(Color.PaleVioletRed);
            GL.Vertex3(-1.0f, 1.0f, -1.0f);
            GL.Vertex3(-1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);

            GL.Color3(Color.ForestGreen);
            GL.Vertex3(1.0f, -1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, -1.0f);
            GL.Vertex3(1.0f, 1.0f, 1.0f);
            GL.Vertex3(1.0f, -1.0f, 1.0f);

            GL.End();
        }

        private void Draw2()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Silver);
            GL.Vertex3(-2.0f, -0.0f, -2.0f);
            GL.Vertex3(-2.0f, 4.0f, -2.0f);
            GL.Vertex3(2.0f, 4.0f, -2.0f);
            GL.Vertex3(2.0f, -0.0f, -2.0f);

            GL.Color3(Color.Honeydew);
            GL.Vertex3(-2.0f, -0.0f, -2.0f);
            GL.Vertex3(2.0f, -0.0f, -2.0f);
            GL.Vertex3(2.0f, -0.0f, 2.0f);
            GL.Vertex3(-2.0f, -0.0f, 2.0f);


            GL.Color3(Color.Moccasin);
            GL.Vertex3(-2.0f, -0.0f, -2.0f);
            GL.Vertex3(-2.0f, -0.0f, 2.0f);
            GL.Vertex3(-2.0f, 4.0f, 2.0f);
            GL.Vertex3(-2.0f, 4.0f, -2.0f);

            GL.Color3(Color.IndianRed);
            GL.Vertex3(-2.0f, -0.0f, 2.0f);
            GL.Vertex3(2.0f, -0.0f, 2.0f);
            GL.Vertex3(2.0f, 4.0f, 2.0f);
            GL.Vertex3(-2.0f, 4.0f, 2.0f);

            GL.Color3(Color.PaleVioletRed);
            GL.Vertex3(-2.0f, 4.0f, -2.0f);
            GL.Vertex3(-2.0f, 4.0f, 2.0f);
            GL.Vertex3(2.0f, 4.0f, 2.0f);
            GL.Vertex3(2.0f, 4.0f, -2.0f);

            GL.Color3(Color.ForestGreen);
            GL.Vertex3(2.0f, -0.0f, -2.0f);
            GL.Vertex3(2.0f, 4.0f, -2.0f);
            GL.Vertex3(2.0f, 4.0f, 2.0f);
            GL.Vertex3(2.0f, -0.0f, 2.0f);

            GL.End();
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
