using System;
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

            //list.Add(new Rectangle());


            foreach (var item in list)
            {
                item.Draw();
            }


            Console.ReadLine();
        }
    }
}
