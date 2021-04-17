using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    public class Shape
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Width { get; set; }
        public float Height { get; set; }
        
        public Shape()
        {
            this.X = 0;
            this.Y = 0;
            this.Width = 0;
            this.Height = 0;
        }
        public virtual void Draw()
        {
            Console.Write("Drwaing shape");
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
/*public class Shape
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

}*/
