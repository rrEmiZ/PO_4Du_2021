using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Rectangle : Shape
    {
        public Rectangle() : base()
        {
        }

        public Rectangle(float X, float Y, float Width, float Height)
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }
        public override void Draw()
        {
            Console.Write("Drawing Rectangle");
            for (int i = 0; i < Y + Height; i++)
            {
                if (i < Y)
                {
                    Console.WriteLine();
                    continue;
                }

                for (int j = 0; j < X + Width; j++)
                {
                    if (j < X)
                    {
                        Console.Write(" ");
                        continue;
                    }

                    Console.Write("*");

                }

                Console.WriteLine();
            }
        }
    }
}
