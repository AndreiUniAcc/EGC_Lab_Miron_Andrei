using OpenTK.Graphics.OpenGL;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace First_OpenTK
{
    class Floor
    {
        private readonly Color colorisation;
        private readonly Color fColorisation;

        private bool visibility;
        private bool floorVisibility;

        // CONST
        private readonly Color GRIDCOLOR = Color.WhiteSmoke;
        private readonly Color floorColor = Color.SandyBrown;
        private const int GRIDSTEP = 10;
        private const int UNITS = 50;
        private const int POINT_OFFSET = GRIDSTEP * UNITS;
        private const int MICRO_OFFSET = 1; // usefeul because otherwise the axes will be "drown" in overlapping grid lines...

        public Floor()
        {
            colorisation = GRIDCOLOR;
            fColorisation = floorColor;
            visibility = true;
        }

        public void Show()
        {
            visibility = true;
        }

        public void Hide()
        {
            visibility = false;
        }

        public void ShowF()
        {
            floorVisibility = true;
        }

        public void HideF()
        {
            floorVisibility = false;
        }

        public void ToggleVisibility()
        {
            visibility = !visibility;
        }

        public void ToggleFloor()
        {
            floorVisibility = !floorVisibility;
        }

        public void DrawGrid()
        {
            if (visibility)
            {
                GL.Begin(PrimitiveType.Lines);
                GL.Color3(colorisation);
                for (int i = -1 * GRIDSTEP * UNITS; i <= GRIDSTEP * UNITS; i += GRIDSTEP)
                {
                    // XZ plan drawing: parallel with Oz
                    GL.Vertex3(i + MICRO_OFFSET, 0, POINT_OFFSET);
                    GL.Vertex3(i + MICRO_OFFSET, 0, -1 * POINT_OFFSET);

                    // XZ plan drawing: parallel with Ox
                    GL.Vertex3(POINT_OFFSET, 0, i + MICRO_OFFSET);
                    GL.Vertex3(-1 * POINT_OFFSET, 0, i + MICRO_OFFSET);
                }
                GL.End();
            }
        }
            public void DrawFloor()
            {
                if (floorVisibility)
                {
                GL.Begin(PrimitiveType.Quads);
                GL.Vertex3(-10, 0, 10);
                }
            }
        
    }
}

