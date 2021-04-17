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

    public class Rectangle: Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Rectangle");
        }
    }
    
    public class Triangle: Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Triangle");
        }
    }    
    
    public class Circle: Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle");
        }
    }

    public class Osoba
    {
        public const string MALE    = "mężczyzna"; 
        public const string FEMALE  = "kobieta";

        string Imie, Nazwisko, Pesel;

        public void SetFirstName(string imie)
        {
            this.Imie = imie;
        }

        public void SetLastName(string nazwisko)
        {
            this.Nazwisko = nazwisko;
        }

        public void SetPesel(string pesel)
        {
            this.Pesel = pesel;
        }

        public int GetAge()
        {
            return new DateTime().Year - this.GetYearOfBirth();
        }

        public string GetGender()
        {
            return Int32.Parse(this.Pesel[9].ToString()) % 2 == 0 
                ? Osoba.FEMALE 
                : Osoba.MALE;
        }

        public virtual void GetEducationInfo() { }
        public virtual void GetFullName() { }
        public virtual void CanGoAloneToHome() { }

        protected int GetYearOfBirth()
        {
            int month = Int32.Parse(this.Pesel.Substring(2, 2));
            int baseYear;

            if (month > 80)
                baseYear = 1800;
            else if (month > 20)
                baseYear = 2000;
            else 
                baseYear = 1900;

            return baseYear + Int32.Parse(this.Pesel.Substring(0, 2));
        }
    }

    public class Uczen: Osoba
    {
        string Szkola { get; set; }
        bool MozeSamWracacDoDomu { get; set; }

        public void SetSchool(string szkola)
        {
            Szkola = szkola;
        }

        public void ChangeSchool(string szkola)
        {
            Szkola = szkola;
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
            });

            list.Add(new Rectangle()
            {
                X = 3,
                Y = 4,
                Height = 2,
                Width = 6
            });

            list.Add(new Triangle()
            {
                X = 3,
                Y = 4,
                Height = 2,
                Width = 6
            });

            list.Add(new Circle()
            {
                X = 3,
                Y = 4,
                Height = 2,
                Width = 6
            });

            //list.Add(new Rectangle());


            foreach (var item in list)
            {
                item.Draw();
            }
        }
    }
}
