﻿using System;
using System.Collections.Generic;

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
        public override void Draw() {

            Console.WriteLine("Rectangle");
        }

    }

    public class Triangle : Shape
    {
        public override void Draw()
        {

            Console.WriteLine("Triangle");
        }

    }

    public class Circle : Shape
    {
        public override void Draw()
        {

            Console.WriteLine("Triangle");
        }

    }

    class Program
    {
        static void Main(string[] args)
        {
           
        }
    }
}
