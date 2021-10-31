using System;
using System.Drawing;
using OpenTK;
using OpenTK.Graphics;
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
        private Color[] randomColorsList = new Color[8];
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
                IsDrawable = true;
                A = new MyPoint(1, 1, -1, Color.Green);
                B = new MyPoint(1, 1, 1, Color.Blue);
                C = new MyPoint(-1, 1, 1, Color.Black);
                D = new MyPoint(-1, 1, -1, Color.Red);

                E = new MyPoint(1, -1, -1, Color.Green);
                F = new MyPoint(1, -1, 1, Color.Blue);
                G = new MyPoint(-1, -1, 1, Color.Black);
                H = new MyPoint(-1, -1, -1, Color.Red);
        }

        // Deseneaza cub daca IsDrawable true.
        public void DrawCube(bool randomColors)
        {
            // Stop drawing if cube not visible
            if(IsDrawable == false)
            {
                return;
            }


            // Draw with random colors or predefined
            if (randomColors == true)
            {
                GL.Begin(PrimitiveType.Quads);

                /// Fateta sus
                GL.Color3(randomColorsList[0]);
                GL.Vertex3(A.GetX(), A.GetY(), A.GetZ());
                GL.Color3(randomColorsList[1]);
                GL.Vertex3(B.GetX(), B.GetY(), B.GetZ());
                GL.Color3(randomColorsList[2]);
                GL.Vertex3(C.GetX(), C.GetY(), C.GetZ());
                GL.Color3(randomColorsList[3]);
                GL.Vertex3(D.GetX(), D.GetY(), D.GetZ());


                /// Fateta dreapta
                GL.Color3(randomColorsList[0]);
                GL.Vertex3(A.GetX(), A.GetY(), A.GetZ());
                GL.Color3(randomColorsList[1]);
                GL.Vertex3(B.GetX(), B.GetY(), B.GetZ());
                GL.Color3(randomColorsList[4]);
                GL.Vertex3(E.GetX(), E.GetY(), E.GetZ());
                GL.Color3(randomColorsList[5]);
                GL.Vertex3(F.GetX(), F.GetY(), F.GetZ());

                /// Fateta fata
                GL.Color3(randomColorsList[1]);
                GL.Vertex3(B.GetX(), B.GetY(), B.GetZ());
                GL.Color3(randomColorsList[2]);
                GL.Vertex3(C.GetX(), C.GetY(), C.GetZ());
                GL.Color3(randomColorsList[5]);
                GL.Vertex3(F.GetX(), F.GetY(), F.GetZ());
                GL.Color3(randomColorsList[6]);
                GL.Vertex3(G.GetX(), G.GetY(), G.GetZ());

                /// Fateta stanga
                GL.Color3(randomColorsList[2]);
                GL.Vertex3(C.GetX(), C.GetY(), C.GetZ());
                GL.Color3(randomColorsList[3]);
                GL.Vertex3(D.GetX(), D.GetY(), D.GetZ());
                GL.Color3(randomColorsList[6]);
                GL.Vertex3(G.GetX(), G.GetY(), G.GetZ());
                GL.Color3(randomColorsList[7]);
                GL.Vertex3(H.GetX(), H.GetY(), H.GetZ());

                /// Fateta spate 
                GL.Color3(randomColorsList[0]);
                GL.Vertex3(A.GetX(), A.GetY(), A.GetZ());
                GL.Color3(randomColorsList[3]);
                GL.Vertex3(D.GetX(), D.GetY(), D.GetZ());
                GL.Color3(randomColorsList[4]);
                GL.Vertex3(E.GetX(), E.GetY(), E.GetZ());
                GL.Color3(randomColorsList[7]);
                GL.Vertex3(H.GetX(), H.GetY(), H.GetZ());

                /// Fateta jos
                GL.Color3(randomColorsList[4]);
                GL.Vertex3(E.GetX(), E.GetY(), E.GetZ());
                GL.Color3(randomColorsList[5]);
                GL.Vertex3(F.GetX(), F.GetY(), F.GetZ());
                GL.Color3(randomColorsList[6]);
                GL.Vertex3(G.GetX(), G.GetY(), G.GetZ());
                GL.Color3(randomColorsList[7]);
                GL.Vertex3(H.GetX(), H.GetY(), H.GetZ());

                GL.End();

            }
            else
            {
            GL.Begin(PrimitiveType.Quads);

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
        }


        // Generates a random set of colors for the cube.
        public void SetRandomColorList()
        {
            var rand = new Random();
            for (int i = 0; i < 8; i++)
            {
                randomColorsList[i] = new Color();
                randomColorsList[i] = Color.FromArgb(255, rand.Next(0, 255), rand.Next(0, 255), rand.Next(0, 255));
            }
            A.SetRandomColor(randomColorsList[0]);
            B.SetRandomColor(randomColorsList[1]);
            C.SetRandomColor(randomColorsList[2]);
            D.SetRandomColor(randomColorsList[3]);
            E.SetRandomColor(randomColorsList[4]);
            F.SetRandomColor(randomColorsList[5]);
            G.SetRandomColor(randomColorsList[6]);
            H.SetRandomColor(randomColorsList[7]);

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
