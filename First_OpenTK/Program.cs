﻿using OpenTK;
using OpenTK.Graphics.OpenGL;
using OpenTK.Input;
using System;
using System.Drawing;

/// <summary>
/// AM IMPLEMENTAT ACTIUNE LA MISCAREA SI ACTIONAREA MOUSE-ULUI IN ON UPDATE FRAME
/// ACTIONAREA CULORILOR PRIN SAGETILE DE LA TASTATURA IN METODA CHEMATA IN CONSTRUCTOR.
/// </summary>


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

        protected override void OnLoad(EventArgs e)
        {
            GL.ClearColor(Color.MidnightBlue);
        }

        protected override void OnResize(EventArgs e)
        {
            GL.Viewport(0, 0, Width, Height);

            GL.MatrixMode(MatrixMode.Projection);
            GL.LoadIdentity();
            GL.Ortho(-1.0, 1.0, -1.0, 1.0, 0.0, 4.0);
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
            GL.Clear(ClearBufferMask.ColorBufferBit);

            GL.Begin(PrimitiveType.Quads);

            GL.Color3(Color.Blue);
            GL.Vertex2(-1.0f, -1.0f);

            GL.Color3(Color.Green);
            GL.Vertex2(1.0f, -1.0f);

            GL.Color3(Color.Red);
            GL.Vertex2(0f, 1.0f);


            GL.Color3(Color.White);
            GL.Vertex2(-0.8f, 0.4f);


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
