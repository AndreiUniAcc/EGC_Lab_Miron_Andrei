using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

/// <summary>
/// AM IMPLEMENTAT ACTIUNE LA MISCAREA SI ACTIONAREA MOUSE-ULUI IN ON UPDATE FRAME
/// ACTIONAREA CULORILOR PRIN SAGETILE DE LA TASTATURA IN METODA CHEMATA IN CONSTRUCTOR.
/// </summary>


namespace First_OpenTK2
{
    class SimpleWindow : GameWindow
    {
        // Constructor.
        public SimpleWindow() : base(800, 600)
        {
            KeyDown += KeyBoard_KeyDown;
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
                GL.ClearColor(Color.DarkOliveGreen);
            }
            if (e.Key == Key.Left)
            {
                GL.ClearColor(Color.MidnightBlue);
            }
        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            Matrix4 perspective = Matrix4.CreatePerspectiveFieldOfView(MathHelper.PiOver4, (float)(Width/(double)Height), 1, 64);
            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadMatrix(ref perspective);
            GL.Ortho(10, 10, 10, 10, 1, 64);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {

            MouseState mouse = Mouse.GetState();
            if (mouse.IsAnyButtonDown)
                Console.WriteLine(mouse.X + " " + mouse.Y);

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

            Matrix4 lookat = Matrix4.LookAt(15, 50, 15, 0, 0, 0, 0, 1, 0);
            GL.MatrixMode(MatrixMode.Modelview);
            GL.LoadMatrix(ref lookat);


            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Blue);
            GL.Vertex2(-3.0f, -3.0f);

            GL.Color3(Color.Green);
            GL.Vertex2(3.0f, -3.0f);

            GL.Color3(Color.Red);
            GL.Vertex2(0f, 6.0f);


            GL.Color3(Color.White);
            GL.Vertex2(-2.8f, 2.4f);


            GL.End();

            this.SwapBuffers();
        }


        private void DrawCube()
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
