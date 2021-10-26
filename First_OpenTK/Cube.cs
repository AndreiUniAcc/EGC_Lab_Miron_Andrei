using System.Drawing;
using OpenTK.Graphics.OpenGL;

namespace First_OpenTK
{
    class Cube
    {
        MyPoint A, B, C, D;
        MyPoint E, F, G, H;

        public Cube()
        {
        

                A = new MyPoint(1, 1, -1, Color.Green);
                B = new MyPoint(1, 1, 1, Color.Blue);
                C = new MyPoint(-1, 1, 1, Color.Pink);
                D = new MyPoint(-1, 1, -1, Color.Red);

                E = new MyPoint(1, -1, -1, Color.Green);
                F = new MyPoint(1, -1, 1, Color.Blue);
                G = new MyPoint(-1, -1, 1, Color.Pink);
                H = new MyPoint(-1, -1, -1, Color.Red);
            
        }

        public DrawCube()
        {
            GL.Begin(PrimitiveType.Quads);

            GL.End();
        }


    }
}
