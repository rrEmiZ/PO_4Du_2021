using System;
using System.Collections.Generic;

namespace Zadanie2
{
    class Program
    {
        static void Main(string[] args)
        {
            Zadanie1.Zadanie();//o co chodzi z x i y?
            Zadanie2.Zadanie();//jak mam tu zrobić polimorfizm jak nie ma nigdzie nic napisane żeby go zrobić? nie trzeba
        }
    }
    class Zadanie1
    {
        public static void Zadanie()
        {
            List<Shape> lista = new List<Shape>();
            Shape ob;
            ob = new Shape();
            lista.Add(ob);
            ob = new Rectangle(5, 8);
            lista.Add(ob);
            ob = new Triangle(5, 6);
            lista.Add(ob);
            ob = new Circle(12, 4);
            lista.Add(ob);

            foreach (var item in lista)
            {
                item.Draw();
            }
        }
    }

    class Shape
    {
        public int X, Y, Height, Width;//po co te x oraz y?

        public Shape() { X = 0; Y = 0; Height = 0; Width = 0; }
        public Shape(int Height, int Width)
        {
            this.Height = Height;
            this.Width = Width;
        }
        public virtual void Draw()
        {
            Console.WriteLine(new string('*', Height * Width));
        }
    }

    class Rectangle : Shape
    {
        public Rectangle(int Height, int Width) : base(Height, Width) { }
        public override void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                Console.WriteLine(new string('*', Width));
            }
            Console.WriteLine("narysowalem rectangle z podanych rozmarow");
        }
    }

    class Triangle : Shape
    {
        public Triangle(int Height, int Width) : base(Height, Width) { }
        public override void Draw()
        {
            for (int i = 0; i < Height; i++)
            {
                Console.WriteLine(new string('*', Width-(Width-i)));
            }
            Console.WriteLine("narysowalem triangle z podanych rozmarow");
        }
    }

    class Circle : Shape
    {
        public Circle(int Height, int Width) : base(Height, Width) { }
        public override void Draw()
        {
            Console.WriteLine("im drawing circle :>");
        }
    }

    /// <summary>
    /// ////////////////////////////////////tam niżej to 2 część
    /// </summary>
    class Zadanie2
    {
        public static void Zadanie()
        {
            String name, surname, id;
            int age, sex;
            var ob1 = new Nauczyciel("NauczMaciek", "NauczPelc", "14884202137", 22, 19, "profesor");
            ob1.SaySomethingImGivingUp();
            for (int i = 0; i < 5; i++)
            {
                //age = Convert.ToInt32(Console.ReadLine());
                //sex = Convert.ToInt32(Console.ReadLine());
                //name = Console.ReadLine();
                //surname = Console.ReadLine();
                //id = Console.ReadLine();
                age = 12 + i;
                sex = 12 + i;
                name = $"Maciek+{i}";
                surname = $"Pelc+{i}";
                id = $"{i+i*i}";
                var ob = new Uczen(name,surname,id,age,sex);
                ob1.AddStud(ob);
            }
            ob1.SaySomethingImGivingUp();
        }
    }

    public class Osoba
    {
        public String firstName, lastName, pesel;
        public int age, gender;

        public Osoba(
            String firstName,
            String lastName,
            String pesel,
            int age,
            int gender
            )
        {
            this.firstName = firstName;
            this.lastName = lastName;
            this.pesel = pesel;
            this.age = age;
            this.gender = gender;
        }
        public void SetFirstName(String firstName) { this.firstName = firstName;}//idk po co te sety, jak ja potrzebuje getów raczej
        public void SetLastName(String lastName) { this.lastName = lastName;}
        public void SetPesel(String pesel) { this.pesel = pesel;}
        public void SetAge(int age) { this.age = age;}
        public void SetGender(int gender) { this.gender = gender;}
        public void GetEducationInfo() { }
        public void GetFullName() { }
        public void CanGoAloneToHome() { }

    }
    class Uczen : Osoba
    {
        public Uczen(String firstName, String lastName, String pesel, int age, int gender) 
            : base(firstName, lastName, pesel, age, gender) { }
        String school;
        bool permit;
        public void CanGoAloneTome() 
        {
            if (base.age < 12 || permit) 
            {
                Console.WriteLine("nie moze wyjsc :c");
            }
            else
            {
                Console.WriteLine("moze wyjsc!");
            }
        }
    }
    class Nauczyciel:Uczen
    {
        public Nauczyciel(String firstName, String lastName, String pesel, int age, int gender, String academicDegree) 
            : base(firstName, lastName, pesel, age, gender) { this.academicDegree = academicDegree; }
        String academicDegree, subordinate;
        List<Uczen> collection = new List<Uczen>();//kolekcja tych podwładnych uczniów
        public void AddStud(Uczen stud)
        {
            collection.Add(stud);
        }
        public bool WhichStudentCanGoHomeAlone(int dateToCheck)
        {
            if (dateToCheck>15)
            {
                return true;
            }
            return false;
        }

        public void SaySomethingImGivingUp()
        {
            if (collection.Count == 0)
            {
                DateTime dat1 = DateTime.Now;
                Console.WriteLine("Wsliz Dnia: " + dat1.ToString(System.Globalization.CultureInfo.InvariantCulture));
                Console.WriteLine($"Nauczyciel: {academicDegree} {firstName} {lastName}");
            }else
            {
                for (int i = 0; i < collection.Count; i++)
                {
                    String sex;
                    String canGo;
                    if (collection[i].gender % 2 == 0)
                        sex = "chlopiec";
                    else
                        sex = "dziewczynka";
                    if (WhichStudentCanGoHomeAlone(collection[i].age) == true)
                        canGo = "moze isc do domu, ma ponad 15 lat";
                    else
                        canGo = "nie moze isc do domu, nie ma jeszcze 15 lat";
                    var wyjscie = WhichStudentCanGoHomeAlone(collection[i].age);

                    Console.WriteLine(i+1 + $" {collection[i].firstName}" + " " + $"{collection[i].lastName}" + " " +
                        $"{sex}" + $"{canGo}");
                } 
            }
        }
    }
}
