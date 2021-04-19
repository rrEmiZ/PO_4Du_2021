using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        static void Main(string[] args)
        {
            List<Shape> list = new List<Shape>();

            list.Add(new Shape()
            {
                X = 15,
                Y = 10,
                Height = 2,
                 Width = 6
            }
            );

            list.Add(new Rectangle() {

                X = 15,
                Y = 30,
                Height = 10,
                Width = 10
            });

            list.Add(new Triangle()
            {
                X = 15,
                Y = 50,
                Height = 10,
                Width = 10

            });

            list.Add(new Circle()
            {
                X = 15,
                Y = 70,
                Radius = 10
            });

            foreach (var item in list)
            {
                item.Draw();
            }

            Uczen u1 = new Uczen();
            u1.SetFirstName("Adrian");
            u1.SetLastName("Kowalski");
            u1.SetPesel("96032322119");
            u1.SetCanGoHomeAlone(true);
            u1.SetSchool("szkola1");

            Uczen u2 = new Uczen();
            u2.SetFirstName("Krystian");
            u2.SetLastName("Kowalski");
            u2.SetPesel("03301917194");
            u2.SetSchool("szkola1");

            Uczen u3 = new Uczen();
            u3.SetFirstName("Natalia");
            u3.SetLastName("Kowalska");
            u3.SetPesel("13221415928");
            u1.SetCanGoHomeAlone(false);
            u3.SetSchool("szkola1");

            Nauczyciel n1 = new Nauczyciel()
            {
                TytulNaukowy = "dr-hab",
                PodwladniUczniowie = new List<Uczen>()
            };
            n1.SetFirstName("Lucyna");
            n1.SetLastName("Kowalska");
            n1.SetSchool("szkola1");
            n1.PodwladniUczniowie.Add(u1);
            n1.PodwladniUczniowie.Add(u2);
            n1.PodwladniUczniowie.Add(u3);

            n1.WhichStudentCanGoHomeAlone(DateTime.Today);

            Console.ReadLine();
        }
    }
}
