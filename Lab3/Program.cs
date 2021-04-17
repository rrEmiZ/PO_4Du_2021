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
    public class Reactangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Reactangle");
        }
    }
    public class Triangle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Triangle");
        }
    }
    class Circle : Shape
    {
        public override void Draw()
        {
            Console.WriteLine("Circle");
        }
    }

    //zad2
    public abstract class Osoba
    {
        public string imie, nazwisko, pesel;

        public Osoba(string imie, string nazwisko, string pesel)
        {
            this.imie = imie;
            this.nazwisko = nazwisko;
            this.pesel = pesel;
        }
        public void SetFirstName(string imie)
        {
            this.imie = imie;
        }
        public void SetLastName(string nazwisko)
        {
            this.nazwisko = nazwisko;
        }
        public void SetPesel(string pesel)
        {
            this.pesel = pesel;
        }

        public void GetGender()
        {
            if (pesel[9] % 2 == 0)
            {
                Console.Write("Kobieta\n");
            }
            else
            {
                Console.Write("Mężczyzna\n");
            }
        }

        public virtual void GetEducationInfo() { }
        public virtual void GetFullName() { }
        public void CanGoAloneToHome()
        {
           
        }
    }

    public class Uczen : Osoba
    {
        protected string szkola;
        protected bool mozeSamWracacDoDomu;
        protected DateTime dataUrodznia;

        public Uczen(string imie, string nazwisko, string pesel, string szkola, bool zgoda) : base(imie, nazwisko, pesel)
        {
            this.szkola = szkola;
            this.mozeSamWracacDoDomu = zgoda;
        }
        public void SetSchool(string szkola)
        {
            this.szkola = szkola;
        }
        public void ChangeSchool(string szkola)
        {
            this.szkola = szkola; //?
        }
        public override void GetEducationInfo()
        {
            Console.WriteLine("Imie:{0}\nNazwisko:{1}\nPesel:{2}\n", imie, nazwisko, pesel);
            Console.Write("Płeć:"); GetGender();
            string inf = (mozeSamWracacDoDomu == true) ? "Tak" : "Nie";
            Console.WriteLine("Szkoła:{0}\nZgoda na wyjście samemu:{1}\n", szkola, inf);
        }
        public override void GetFullName()
        {
            Console.WriteLine(imie + " " + nazwisko);
        }
        
        public void SetCanGoHomeAlone()
        {
            if (pesel.Length == 11)
            {
                int day = Convert.ToInt32(Convert.ToString(pesel[4]) + Convert.ToString(pesel[5]));
                int month = Convert.ToInt32(Convert.ToString(pesel[2]) + Convert.ToString(pesel[3]));
                int year0 = Convert.ToInt32(Convert.ToString(pesel[0]) + Convert.ToString(pesel[1]));

                int year1 = 0;
                if (month == 21 || month == 22 || month == 23 || month == 24 || month == 25 || month == 26 || month == 27 || month == 28 || month == 29 || month == 30 || month == 31 || month == 32)
                {
                    year1 = 20;
                    //zmiana miesiecy styczeń 21 -> 1
                    if (month == 21) { month = 1; } else if (month == 22) { month = 2; } else if (month == 23) { month = 3; } else if (month == 24) { month = 4; } else if (month == 25) { month = 5; } else if (month == 26) { month = 6; } else if (month == 27) { month = 7; } else if (month == 28) { month = 8; } else if (month == 29) { month = 9; } else if (month == 30) { month = 10; } else if (month == 31) { month = 11; } else if (month == 32) { month = 12; }
                    if (year0 % 10 == year0) { year1 = 200; } //przypadek --> 2001-2009 
                }
                else if (month == 01 || month == 02 || month == 03 || month == 04 || month == 05 || month == 06 || month == 07 || month == 08 || month == 09 || month == 10 || month == 11 || month == 12)
                {
                    year1 = 19;
                    if (year0 % 10 == year0) { year1 = 190; } //przypadek --> 1901-1909 
                }
                else if (month == 81 || month == 82 || month == 83 || month == 84 || month == 85 || month == 86 || month == 87 || month == 88 || month == 89 || month == 90 || month == 91 || month == 92)
                {
                    year1 = 18;
                    if (month == 81) { month = 1; } else if (month == 82) { month = 2; } else if (month == 83) { month = 3; } else if (month == 84) { month = 4; } else if (month == 85) { month = 5; } else if (month == 86) { month = 6; } else if (month == 87) { month = 7; } else if (month == 88) { month = 8; } else if (month == 89) { month = 9; } else if (month == 90) { month = 10; } else if (month == 91) { month = 11; } else if (month == 92) { month = 12; }
                    if (year0 % 10 == year0) { year1 = 180; }
                }
                int year = Convert.ToInt32(Convert.ToString(year1) + Convert.ToString(year0));

                DateTime data = new DateTime(year, month, day);
                DateTime today = DateTime.Today;

                TimeSpan diff = today - data;
                int days = diff.Days;

                //Console.WriteLine("year: {0}, month: {1}, day:{2} \nData urodzenia: {3},\nToday: {4}\n Różnica dni: {5}", year, month, day, data, today, days);

                if (days >= 6575) // 6575 = 18 lat
                {
                    Console.WriteLine("Możesz iść sam");
                }
                else
                {
                    if (days >= 4383 && mozeSamWracacDoDomu == true) // 4383 = 12 lat
                    {
                        Console.WriteLine("Możesz iść sam, bo masz zgodę.");
                    }
                    else
                    {
                        Console.WriteLine("NIE masz 18 lat ani zgody rodzica na wyjście, nie możesz iść sam.");
                    }

                }
            }
            else
            {
                Console.WriteLine("Błędy pesel");
            }
        }
       
    }
    public class Nauczyciel : Uczen
    {
        private string _TytulNaukowy { get; set; }
        protected List<Uczen> listaUczniow = new List<Uczen> { };

        public Nauczyciel(string imie, string nazwisko, string pesel, string szkola, bool zgoda, string tytulNaukowy) : base(imie, nazwisko, pesel, szkola, zgoda)
        {
            _TytulNaukowy = tytulNaukowy;
        }

        public void ListOfPupils()
        {
            listaUczniow.Add(new Uczen("Asia", "Makinki", "03241712868", "Szkoła podstawowa nr.3", true ));
            listaUczniow.Add(new Uczen("Tomek", "Lew", "08301034519", "Szkoła podstawowa nr.3", true));
            listaUczniow.Add(new Uczen("Marek", "Preis", "11241051254", "Szkoła podstawowa nr.3", false));
            listaUczniow.Add(new Uczen("Magda", "Smołucha", "10270529767", "Szkoła podstawowa nr.3", false));
            listaUczniow.Add(new Uczen("Lucian", "Olewniczak", "08231036511", "Szkoła podstawowa nr.3", true)); 
        }

        public void WhichStudentCanGoHomeAlone()
        {
            Console.Write("Lista uczniów:\n");
            foreach (var i in listaUczniow)
            {
                Console.Write("\n"); 
                i.GetFullName(); 
                i.SetCanGoHomeAlone(); 
            }
        }
    }

    class Program
    {
        static void Main(string[] args)
        {
            /* Zad 1
            List<Shape> s1 = new List<Shape> { };

            s1.Add(new Reactangle());
            s1.Add(new Triangle());
            s1.Add(new Circle());

            foreach( var item in s1)
            {
                item.Draw();
            }*/

            /*Zad2
            Uczen o = new Uczen("Asia", "Makinki", "03241712868", "Szkoła podstawowa nr.3", true);
            o.GetEducationInfo();
            o.GetFullName();
            o.SetCanGoHomeAlone();*/
            
            Nauczyciel n = new Nauczyciel("Asia", "Makinki", "99241712868", "Szkoła podstawowa nr.3", true,"Magister inżynier...");
            n.ListOfPupils();
            n.WhichStudentCanGoHomeAlone();
        }
    }
}
