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

    public class Rectangle : Shape
    {
        public override void Draw()
        {
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
            Console.WriteLine("Circle");
        }
    }

    public class Osoba
    {
        public string Imie, Nazwisko, Pesel;
        public const string MALE = "mężczyzna";
        public const string FEMALE = "kobieta";

       
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

        
        public string GetGender()
        {
            return Int32.Parse(this.Pesel[9].ToString()) % 2 == 0
                ? Osoba.FEMALE
                : Osoba.MALE;
        }
        public int GetAge(DateTime dateToCheck)
        {
            return dateToCheck.Year - this.GetYearOfBirth();
        }
        public virtual string GetEducationInfo() { return "Szkoła ukończona"; }
        public virtual string GetFullName() { return Imie; }
        public virtual bool CanGoAloneToHome(DateTime dateToCheck) { return true; }

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

    public class Uczen : Osoba
    {
        string Szkola { get; set; }
        bool MozeSamWracacDoDomu { get; set; }
        public Uczen(string imie, string nazwisko, string szkola, string pesel)
        {
            Imie = imie;
            Nazwisko = nazwisko;
            Szkola = szkola;
            Pesel = pesel;
        }
        public void SetSchool(string szkola)
        {
            Szkola = szkola;
        }

        public void ChangeSchool(string szkola)
        {
            Szkola = szkola;
        }
        public void SetCanGoHomeAlone(bool permission)
        {
            MozeSamWracacDoDomu = permission;
        }

        public override string GetEducationInfo()
        {
            return Szkola;
        }

        public override string GetFullName()
        {
            return Imie + " " + Nazwisko;
        }

        public override bool CanGoAloneToHome(DateTime dateToCheck)
        {
            return MozeSamWracacDoDomu || this.GetAge(dateToCheck) >= 12;
        }
    }

    public class Nauczyciel : Uczen
    {
        public string TytulNaukowy { get; set; }
        public List<Uczen> PodwladniUczniowie;

        public Nauczyciel(string imie, string nazwisko, string szkola, string pesel, string tytul)
            : base(imie, nazwisko, szkola, pesel)
        {
            TytulNaukowy = tytul;
            PodwladniUczniowie = new List<Uczen>();
        }

        public void WhichStudendCanGoHomeAlone(DateTime dateToCheck)
        {
            foreach (Uczen u in PodwladniUczniowie)
            {
                if (u.CanGoAloneToHome(dateToCheck))
                {
                    Console.WriteLine(u.GetFullName()+"\t\t - "+ u.GetGender()+"\t\t - może samemu wracać do domu");
                }
                else
                {
                    Console.WriteLine(u.GetFullName() + "\t\t - " + u.GetGender()+"\t\t - nie może samemu wracać do domu");
                }
            }
        }
    }


    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> list = new List<Shape>();

            Rectangle a = new Rectangle()
            {
                X = 2,
                Y = 4,
                Height = 4,
                Width = 4
            };

            Triangle b = new Triangle()
            {
                X = 2,
                Y = 6,
                Height = 2,
                Width = 6
            };

            Circle c = new Circle()
            {
                X = 2,
                Y = 5,
                Height = 6,
                Width = 6
            };
            list.Add(a);
            list.Add(b);
            list.Add(c);

            foreach (var item in list)
            {
                item.Draw();
            }
            Nauczyciel nauczyciel = new Nauczyciel("Adam", "Zgórski", "Szkoła", "85100719933", "mgr");
            nauczyciel.PodwladniUczniowie.Add(new Uczen("Filip", "Baran", "Szkoła", "97032281352"));
            nauczyciel.PodwladniUczniowie.Add(new Uczen("Ola", "Kwaśny", "Szkoła", "10290185741"));
            nauczyciel.PodwladniUczniowie.Add(new Uczen("Anna", "Czech", "Szkoła", "11250181221"));
            nauczyciel.PodwladniUczniowie.Add(new Uczen("Kamil", "Ślimak", "Szkoła", "99020189752"));

            Console.WriteLine(nauczyciel.GetEducationInfo() + " Dnia: " + DateTime.Now);
            Console.WriteLine("Nauczyciel: " + nauczyciel.TytulNaukowy + " " + nauczyciel.GetFullName());
            Console.WriteLine("Lista studentów: ");
            nauczyciel.WhichStudendCanGoHomeAlone(DateTime.Now);
        }
    }
}