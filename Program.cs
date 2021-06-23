using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;

namespace Lab13
{
    public class Student
    {
        public int Id{get; set;}
        public string NrAlbumu{get; set;}
        public string Imie{get; set;}
        public string Nazwisko{get; set;}
        public string Grupa{get; set;}
        public void Hello()
        {
            Console.WriteLine("lol "+Imie);
        }
    }

    
    class Program
    {
        static void PierwszaCzesc()
        {
            ////bez refleksji
            Student student = new Student();
            student.Imie = "Testowe";
            student.Hello();


            var type = Type.GetType("Lab13.Student");
            object obj = Activator.CreateInstance(type);

            //var props = type.GetProperties();

            //PropertyInfo prop = props.FirstOrDefault(x=>x.Name=="Imie");
            PropertyInfo prop = type.GetProperty("Imie");

            prop.SetValue(obj, "Testowe");//ustawiam wartość do stringa Imie -> "Testowe"

            Console.WriteLine(prop.GetValue(obj));

            MethodInfo methodInfo = type.GetMethod("Hello");
            methodInfo.Invoke(obj, null);


            //foreach (var prop in props) 
            //{
            //    Console.WriteLine(prop.Name);
            //}


            ////z użyciem refleksji
            //var type = Type.GetType("namespace.Foo"); //string powinien zawierać
            //namespace naszej klasy
            //var foo = Activator.CreateInstance(type); //inicjalizacja obiektu 
            //określonego typu
            //MethodInfo inf = type.GetMethod("hello");
            //inf.Invoke(foo); // jako drugi parametr metoda Invoke przyjmuje tablicę
            //Object[] są to parametry metody hello
        }
        static void DrugaCzesc()
        {
            //dynamic d = 13;
            //Console.WriteLine(d.GetType());
            ////Typ zmiennej d to: System.Int32
            //d = "Napis";
            ////Teraz typ zmiennej d to: Systems.String
            //d--; //BŁĄD zmienna jest aktualnie typu String
            //Console.ReadLine();

            //dynamic p = new Student();
            //Console.WriteLine(p.GetType());
            //p.Hello();
            var type = Type.GetType("Lab13.Student");
            object obj = Activator.CreateInstance(type);

            //var fields = type.GetFields();

            //PropertyInfo[] props = type.GetProperties();

            MethodInfo metodInfo = type.GetMethod("Hello");
            metodInfo.Invoke(obj, null);
            dynamic d = new Student();
            Console.WriteLine(d.GetType());
            d.Hello();

        }
        static void Main(string[] args)
        {
            //zadanie 2
            List<Student> studs = new List<Student>();
            for (int i = 0; i < 10; i++)
            {
                studs.Add(new Student()
                {
                    Id = i,
                    NrAlbumu = "NrAlbumu: " + i.ToString(),
                    Imie = "Imie: " + i.ToString(),
                    Nazwisko = "Nazwisko: " + i.ToString(),
                    Grupa = "Grupa: " + i.ToString(),
                });
            }
            foreach (var stud in studs)
            {
                stud.PrintProbs();
            }
            foreach (var stud in studs)
            {
                stud.PrintProbs();
            }
            //zadanie 1, albo na odwrót
            var type = Type.GetType("Lab13.Student");
            var props = type.GetProperties();
            foreach (var prop in props)
            {
                Console.WriteLine(prop.Name);
            }
            Console.ReadLine();
        }
    }
}
