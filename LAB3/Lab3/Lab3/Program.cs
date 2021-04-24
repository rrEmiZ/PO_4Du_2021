using System;
using System.Collections.Generic;

namespace Lab3
{
    //zad1

    public class Shape
    {
        public float X { get; set; }
        public float Y { get; set; }
        public float Height { get; set; }
        public float Width { get; set; }

        public virtual void Draw()
        {

        }

    }

    public class Rectangle:Shape
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

    //zad2

    public class Osoba
    {
        public string imie;
        public string nazwisko;
        public string pesel;

        public Osoba(string imie, string nazwisko, string pesel)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.pesel = pesel;
        }

        public void SetFirstName(string x)
        {
            this.imie = x;
        }

        public void SetLastName(string x)
        {
            this.nazwisko = x;
        }

        public void SetPesel(string x)
        {
            this.pesel = x;
        }

        public string GetGender()
        {
            string gender = "";
            if(pesel[9] % 2 == 0)
            {
                gender = "kobieta";
            }
            else
            {
                gender = "mezczyzna";
            }
            return gender;
        }

        public virtual void GetEducationInfo() { }
        public virtual void GetFullName() { }
        public virtual void CanGoAloneToHome() { }


    }

    public class Uczen : Osoba
    {
        public string szkola;
        public bool MozeSamWracacDoDomu;

        public Uczen(string imie, string nazwisko, string pesel, string szkola, bool czymozesamwracac) : base(imie, nazwisko, pesel)
        {
            this.szkola = szkola;
            this.MozeSamWracacDoDomu = czymozesamwracac;
        }

        public void SetSchool(string x)
        {
            this.szkola = x;
        }

        public void ChangeSchool(string x)
        {
            this.szkola = x;
        }

        public void SetCanGoHomeAlone(bool x)
        {
            this.MozeSamWracacDoDomu = x;
        }

        public override void GetEducationInfo()
        {
            Console.WriteLine("Imie:" + this.imie);
            Console.WriteLine("Nazwisko:" + this.nazwisko);
            Console.WriteLine("Pesel:" + this.pesel);
            Console.WriteLine("Szkola:" + this.szkola);
        }

        public override void GetFullName()
        {
            Console.WriteLine(this.imie + " " + this.nazwisko);
        }

        public override void CanGoAloneToHome()
        {
            if(this.MozeSamWracacDoDomu == true)
            {
                Console.WriteLine("Moze sam wracac do domu.");
            }
            else
            {
                Console.WriteLine("Nie moze sam wracac do domu.");
            }
        }

    }

    public class Nauczyciel : Uczen
    {
        public string TytulNaukowy;
        public List<Uczen> PodwladniUczniowie = new List<Uczen>();

        public Nauczyciel(string imie, string nazwisko, string pesel, string szkola, bool czymozesamwracac,string tytul):base(imie,nazwisko,pesel,szkola,czymozesamwracac)
        {
            this.TytulNaukowy = tytul;
        }

        public void DodajUczniow()
        {
            PodwladniUczniowie.Add(new Uczen("Adam", "Kot", "09231367175", "Szkola podstawowa nr 1", true));
            PodwladniUczniowie.Add(new Uczen("Jan", "Kowal", "08291743677", "Szkola podstawowa nr 1", false));
            PodwladniUczniowie.Add(new Uczen("Maria", "Lew", "06322972823", "Szkola podstawowa nr 1", true));
        }

        public void WhichStudentCanGoHomeAlone()
        {
            foreach(var x in PodwladniUczniowie)
            {
                if (x.MozeSamWracacDoDomu == true)
                {
                    x.GetFullName();
                }
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            //zad1

            //List<Shape> shapes = new List<Shape>();

            //shapes.Add(new Rectangle());
            //shapes.Add(new Triangle());
            //shapes.Add(new Circle());

            //foreach(var x in shapes)
            //{
            //    x.Draw();
            //}

            //zad2

            Nauczyciel nauczyciel1 = new Nauczyciel("Jan", "Kowalski", "88031296717", "Liceum nr 2", true, "Inzynier");

            nauczyciel1.DodajUczniow();

            nauczyciel1.WhichStudentCanGoHomeAlone();

        }
    }
}
