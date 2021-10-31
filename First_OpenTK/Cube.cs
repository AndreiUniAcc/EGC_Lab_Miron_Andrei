using System.Drawing;
using OpenTK;
using OpenTK.Graphics.OpenGL;

namespace First_OpenTK
{
    class Cube
    {
        MyPoint A, B, C, D;
        MyPoint E, F, G, H;

        private float angle;
        private const float rotationSpeed = 10.0f;
        private bool isRotating = false;
        //private readonly int OFFSET = 1;

        public bool IsDrawable { get; set; }

        public void Hide()
        {
            IsDrawable = false;
        }

        public void Show()
        {
            IsDrawable = true;
        }

        public void ToggleVisibility()
        {
            if (IsDrawable == true)
                Hide();
            else
                Show();
        }

        // Constructor
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

        // Deseneaza cub daca IsDrawable true.
        public void DrawCube()
        {
            if(IsDrawable == false)
            {
                return;
            }
            GL.Begin(PrimitiveType.Quads);


            /// Fateta sus
            GL.Color3(A.GetColor());
            GL.Vertex3(A.GetX(), A.GetY(), A.GetZ());
            GL.Color3(B.GetColor());
            GL.Vertex3(B.GetX(), B.GetY(), B.GetZ());
            GL.Color3(C.GetColor());
            GL.Vertex3(C.GetX(), C.GetY(), C.GetZ());
            GL.Color3(D.GetColor());
            GL.Vertex3(D.GetX(), D.GetY(), D.GetZ());

            /// Fateta dreapta
            GL.Color3(A.GetColor());
            GL.Vertex3(A.GetX(), A.GetY(), A.GetZ());
            GL.Color3(B.GetColor());
            GL.Vertex3(B.GetX(), B.GetY(), B.GetZ());
            GL.Color3(E.GetColor());
            GL.Vertex3(E.GetX(), E.GetY(), E.GetZ());
            GL.Color3(F.GetColor());
            GL.Vertex3(F.GetX(), F.GetY(), F.GetZ());

            /// Fateta fata
            GL.Color3(B.GetColor());
            GL.Vertex3(B.GetX(), B.GetY(), B.GetZ());
            GL.Color3(C.GetColor());
            GL.Vertex3(C.GetX(), C.GetY(), C.GetZ());
            GL.Color3(F.GetColor());
            GL.Vertex3(F.GetX(), F.GetY(), F.GetZ());
            GL.Color3(G.GetColor());
            GL.Vertex3(G.GetX(), G.GetY(), G.GetZ());

            /// Fateta stanga
            GL.Color3(C.GetColor());
            GL.Vertex3(C.GetX(), C.GetY(), C.GetZ());
            GL.Color3(D.GetColor());
            GL.Vertex3(D.GetX(), D.GetY(), D.GetZ());
            GL.Color3(G.GetColor());
            GL.Vertex3(G.GetX(), G.GetY(), G.GetZ());
            GL.Color3(H.GetColor());
            GL.Vertex3(H.GetX(), H.GetY(), H.GetZ());

            /// Fateta spate 
            GL.Color3(A.GetColor());
            GL.Vertex3(A.GetX(), A.GetY(), A.GetZ());
            GL.Color3(D.GetColor());
            GL.Vertex3(D.GetX(), D.GetY(), D.GetZ());
            GL.Color3(E.GetColor());
            GL.Vertex3(E.GetX(), E.GetY(), E.GetZ());
            GL.Color3(H.GetColor());
            GL.Vertex3(H.GetX(), H.GetY(), H.GetZ());

            /// Fateta jos
            GL.Color3(E.GetColor());
            GL.Vertex3(E.GetX(), E.GetY(), E.GetZ());
            GL.Color3(F.GetColor());
            GL.Vertex3(F.GetX(), F.GetY(), F.GetZ());
            GL.Color3(G.GetColor());
            GL.Vertex3(G.GetX(), G.GetY(), G.GetZ());
            GL.Color3(H.GetColor());
            GL.Vertex3(H.GetX(), H.GetY(), H.GetZ());




            GL.End();
        }


        public void CubeRotation(FrameEventArgs e, bool left, bool right, bool up, bool down)
        {
            angle = 5;
            if (isRotating == true)
                isRotating = false;
            else
                isRotating = true;
            if (IsDrawable == true && isRotating == true)
            {
                angle += rotationSpeed * (float)e.Time;
                if (left is true)
                    GL.Rotate(angle, 0.0f, 1.0f, 0.0f);
                if (right is true)
                    GL.Rotate(angle, 0.0f, -1.0f, 0.0f);
                /*if (up is true)
                    GL.Rotate(angle, 1.0f, 0.0f, 0.0f);
                if (down is true)
                    GL.Rotate(angle, -1.0f, 0.0f, 0.0f);*/

            }
        }


    }
}
