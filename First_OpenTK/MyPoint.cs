﻿using System.Drawing;

namespace First_OpenTK
{
    class MyPoint
    {
        private int coordX;
        private int coordY;
        private int coordZ;
        private Color pointColor;


        public MyPoint()
        {
            this.coordX = 0;
            this.coordY = 0;
            this.coordZ = 0;
            this.pointColor = Color.Black;
        }
        public MyPoint(int x, int y, int z, Color pColor)
        {
            this.coordX = x;
            this.coordY = y;
            this.coordZ = z;
            this.pointColor = pColor;
        }
        public MyPoint(int x, int y, int z)
        {
            this.coordX = x;
            this.coordY = y;
            this.coordZ = z;
            this.pointColor = Color.Black;
        }

        public void SetColor(Color pColor)
        {
            pointColor = pColor;
        }

        public void SetX(int x)
        {
            coordX = x;
        }

        public void SetY(int y)
        {
            coordX = y;
        }

        public void SetZ(int z)
        {
            coordX = z;
        }

    }
}
