using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Circle : Shape
    {
        public float radius;
        public Circle() : base()
        {
            this.radius = 1;
        }

        public Circle(float X, float Y, float radius)
        {
            this.radius = radius;
            this.X = X;
            this.Y = Y;
        }
        public override void Draw()
        {

            Console.Write("Drawing Circle");
            
        }
    }
}
