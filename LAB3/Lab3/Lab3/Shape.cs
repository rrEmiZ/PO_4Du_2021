using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Shape
    {
        private int x;
        private int y;
        private double height;
        private double width;

        public Shape(int x, int y, double height, double width)
        {
            this.x = x;
            this.y = y;
            this.height = height;
            this.width = width;
        }

        public virtual void Draw()
        {
        }
    }
}
