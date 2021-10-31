using OpenTK.Graphics;
using System.Drawing;

namespace First_OpenTK
{
    class MyPoint
    {
        private int coordX;
        private int coordY;
        private int coordZ;
        private Color pointColor;
        private Color randomColor;

        // Default Constructor
        public MyPoint()
        {
            this.coordX = 0;
            this.coordY = 0;
            this.coordZ = 0;
            this.pointColor = Color.Black;
        }
        
        // Constructor cu tip culoare Color
        public MyPoint(int x, int y, int z, Color pColor)
        {
            this.coordX = x;
            this.coordY = y;
            this.coordZ = z;
            this.pointColor = pColor;
        }

        // No color Constructor
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

        public void SetRandomColor(Color pColor)
        {
            randomColor = pColor;
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

        public Color GetColor() { return this.pointColor; }
        public Color GetRandomColor() { return this.randomColor; }
        public int GetX() { return this.coordX; }
        public int GetY() { return this.coordY; }
        public int GetZ() { return this.coordZ; }

    }
}
