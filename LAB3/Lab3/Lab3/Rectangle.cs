using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Rectangle : Shape
    {
        public Rectangle(int x, int y, double height, double width) : base(x, y, height, width)
        { }

        public override void Draw()
        {
            Console.WriteLine("Rectangle");
        }

    }
}
