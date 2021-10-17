using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

namespace First_OpenTK
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

        void Mouse_KeyDown(object sender, MouseButtonEventArgs e)
        {
            if (e.IsPressed is true)
                GL.ClearColor(Color.DarkOliveGreen);

        }

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Texture);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
        }

        protected override void OnUpdateFrame(FrameEventArgs e)
        {
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Begin(PrimitiveType.Triangles);

            GL.Color3(Color.Blue);
            GL.Vertex2(-1.0f, -1.0f);

            GL.Color3(Color.Green);
            GL.Vertex2(1.0f, -1.0f);

            GL.Color3(Color.Red);
            GL.Vertex2(0f, 1.0f);

            GL.End();

            this.SwapBuffers();
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
