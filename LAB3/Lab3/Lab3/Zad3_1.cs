using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Shape
    {
        public int X { get; set; }
        public int Y { get; set; }
        public int Width { get; set; }
        public int Height { get; set; }

        public virtual void Draw()
        {
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

    public class Rectangle : Shape
    {
        public override void Draw()
        {
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
            Console.WriteLine("Rectangle\n");
        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {
            int h = 0;
            for (int i = 0; i < Y + Height; i++)
            {
                if (i < Y)
                {
                    Console.WriteLine();
                    continue;
                }
                for (int j = 0; j < X + Width / 2 + h; j++)
                {
                    if (j < X + Width / 2 - h - 1)
                    {
                        Console.Write(" ");
                        continue;
                    }

                    Console.Write("*");
                }

                h++;
                Console.WriteLine();
            }
            Console.WriteLine("Triangle\n");
        }
    }

    public class Circle : Shape
    {
        public int Radius { get; set; }

        public override void Draw()
        {
            for (int y = -Radius; y < Radius; y++)
            {
                int h = (int)Math.Sqrt(Radius * Radius - y * y);
                for (int x = -h; x < h; x++)
                {
                    Console.SetCursorPosition(X + x, Y + y);
                    Console.Write("*");
                }
            }
            Console.Write("*");
            Console.WriteLine("\nCircle\n");
        }
    }

}
