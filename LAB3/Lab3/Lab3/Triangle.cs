using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Triangle : Shape
    {
        public Triangle(int x, int y, double height, double width) : base(x, y, height, width)
        { }

        public override void Draw()
        {
            Console.WriteLine("Triangle");
        }

    }
}
