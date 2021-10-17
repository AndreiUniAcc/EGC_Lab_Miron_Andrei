using OpenTK;
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
    class FirstWindow: GameWindow
    {
        public FirstWindow() : base(800, 600)
        {
            KeyDown += Keyboard_KeyDown;
        }

        void Keyboard_KeyDown ( object sender, KeyboardKeyEventArgs e)
        {
            if (e.Key == Key.Escape)
                this.Exit();

            if (e.Key == Key.F1)
                if (this.WindowState == WindowState.Fullscreen)
                    this.WindowState = WindowState.Normal;
                else
                    this.WindowState = WindowState.Fullscreen;

            if (e.Key == Key.G)
                GL.ClearColor(Color.DarkSeaGreen);  
        }

        protected override void OnLoad(EventArgs e)
        { 
            GL.ClearColor(Color.MidnightBlue);
        }



    }
    class Program
    {
        static void Main(string[] args)
        {
            using (FirstWindow EGC = new FirstWindow())
            {
                EGC.Run(30.0, 0.0);
            }
        }
    }
}
