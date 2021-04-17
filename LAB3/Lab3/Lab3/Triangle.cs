using System;
using System.Collections.Generic;
using System.Text;

namespace Lab3
{
    class Triangle :  Shape
    {
        public Triangle() : base()
        {
        }

        public Triangle(float X, float Y, float Width, float Height) 
        {
            this.X = X;
            this.Y = Y;
            this.Width = Width;
            this.Height = Height;
        }
        public override void Draw()
        {
           
            Console.Write("Drawing triangle");
            for (int i = 0; i < Y + Height; i++)
            {
                if (i < Y)
                {
                    Console.WriteLine();
                    continue;
                }

                    for (int j = 0; j < X; j++)
                    {
                         Console.Write(" ");
                    }
                                   
                    for (float l = 1; l <= Width - (i-Y); l++)
                    {
                        Console.Write(" ");
                    }
                    for (float m = 1; m <= (i - Y); m++)
                    {
                        Console.Write("*");
                    }
                    for (float l = 1; l <=(i - Y)-1; l++)
                    {
                        Console.Write("*");
                    }
                    


                Console.WriteLine();


            }
        }
    }
}
