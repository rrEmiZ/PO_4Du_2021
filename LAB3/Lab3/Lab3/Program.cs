using System;
using System.Collections.Generic;
using Lab3;

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

            Console.WriteLine("Rysuje ksztalt");

        }
    }


    public class Rectangle : Shape
    {
        public override void Draw()
        {

            Console.WriteLine("Rysuje prostokat");

        }
    }

    public class Triangle : Shape
    {
        public override void Draw()
        {

            Console.WriteLine("Rysuje Trójkat");
        }
    }

    public class Circle : Shape
    {
        public override void Draw()
        {

            Console.WriteLine("Rysuje Trójkat");
        }
    }



    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> list = new List<Shape>();

            list.Add(new Shape()
            {
                X = 3,
                Y = 4,
                Height = 2,
                Width = 6

            }
            );

            list.Add(new Rectangle()
            {
                X = 2,
                Y = 5,
                Height = 3,
                Width = 3
            }
            );

            list.Add(new Triangle()
            {
                X = 2,
                Y = 5,
                Height = 3,
                Width = 3
            }
            );

            list.Add(new Circle()
            {
                X = 2,
                Y = 5,
                Height = 3,
                Width = 3
            }
            );



            foreach (var item in list)
            {
                item.Draw();
            }


            Console.ReadLine();
        }
    }

}