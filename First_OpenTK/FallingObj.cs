using OpenTK;
using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_OpenTK
{
    class FallingObj
    {
        private bool visibility = false;
        private Color colour;
        private List<Vector3> coordinates;
        private Randomizer rand;


        /// <summary>
        /// Ctor.
        /// </summary>
        public FallingObj()
        {
            //visibility = true;
            rand = new Randomizer();
            coordinates = new List<Vector3>();

            int size_offset = rand.RandomInt(5);
            int position_offset = rand.RandomInt(3,8);
            int height_offset = rand.RandomInt(10,20);

            colour = rand.RandomColor();


            coordinates.Add(new Vector3(0 * size_offset + position_offset, 0 * size_offset + height_offset, 1 * size_offset + position_offset));
            coordinates.Add(new Vector3(0 * size_offset + position_offset, 0 * size_offset + height_offset, 0 * size_offset + position_offset));
            coordinates.Add(new Vector3(1 * size_offset + position_offset, 0 * size_offset + height_offset, 1 * size_offset + position_offset));
            coordinates.Add(new Vector3(1 * size_offset + position_offset, 0 * size_offset + height_offset, 0 * size_offset + position_offset));

            coordinates.Add(new Vector3(1 * size_offset + position_offset, 1 * size_offset + height_offset, 1 * size_offset + position_offset));
            coordinates.Add(new Vector3(1 * size_offset + position_offset, 1 * size_offset + height_offset, 0 * size_offset + position_offset));
            coordinates.Add(new Vector3(0 * size_offset + position_offset, 1 * size_offset + height_offset, 1 * size_offset + position_offset));
            coordinates.Add(new Vector3(0 * size_offset + position_offset, 1 * size_offset + height_offset, 0 * size_offset + position_offset));
            coordinates.Add(new Vector3(0 * size_offset + position_offset, 0 * size_offset + height_offset, 1 * size_offset + position_offset));
            coordinates.Add(new Vector3(0 * size_offset + position_offset, 0 * size_offset + height_offset, 0 * size_offset + position_offset));

            coordinates.Add(new Vector3(1 * size_offset + position_offset, 0 * size_offset + height_offset, 1 * size_offset + position_offset));
            coordinates.Add(new Vector3(0 * size_offset + position_offset, 0 * size_offset + height_offset, 1 * size_offset + position_offset));
            coordinates.Add(new Vector3(1 * size_offset + position_offset, 1 * size_offset + height_offset, 1 * size_offset + position_offset));
            coordinates.Add(new Vector3(0 * size_offset + position_offset, 1 * size_offset + height_offset, 1 * size_offset + position_offset));

            coordinates.Add(new Vector3(1 * size_offset + position_offset, 0 * size_offset + height_offset, 0 * size_offset + position_offset));
            coordinates.Add(new Vector3(0 * size_offset + position_offset, 0 * size_offset + height_offset, 0 * size_offset + position_offset));
            coordinates.Add(new Vector3(1 * size_offset + position_offset, 1 * size_offset + height_offset, 0 * size_offset + position_offset));
            coordinates.Add(new Vector3(0 * size_offset + position_offset, 1 * size_offset + height_offset, 0 * size_offset + position_offset));




        }

        public void Draw()
        {
            if (visibility)
            { 
                GL.Begin(PrimitiveType.QuadStrip);
                GL.Color3(colour);

                foreach (Vector3 v in coordinates)
                {
                    GL.Vertex3(v);
                }

                GL.End();
            }

        }

        public void VisibilityToggle()
        {
            visibility = !visibility;
        }

        public bool isVisible()
        {
            return visibility;
        }

        public void Falling()
        {

            if (visibility && !onGround())
                for (int i = 0; i < coordinates.Count; i++)
                    coordinates[i] = new Vector3(coordinates[i].X, coordinates[i].Y - 0.5f, coordinates[i].Z);
             
        }

        public bool onGround()
        {
            foreach (Vector3 v in coordinates)
                if (v.Y <= 0)
                    return true;

            return false;
        }
    }
}
