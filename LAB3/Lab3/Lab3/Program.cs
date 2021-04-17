using System;
using System.Collections.Generic;

namespace Lab3
{
    class Program
    {
        
        static void Main(string[] args)
        {
           
            List<Shape> list = new List<Shape>();

            list.Add(new Triangle(5f, 4f, 9f, 10f));
            list.Add(new Rectangle(5f,5f,4f,8f));
            list.Add(new Circle());

            foreach (var item in list)
            {
                item.Draw();
            }
            
            Console.WriteLine();
            Console.WriteLine();
            Nauczyciel Nauczyciel1 = new Nauczyciel();
            Nauczyciel1.SetFirstName("Sławomir");
            Nauczyciel1.SetLastName("Kowalski");
            Nauczyciel1.TytulNaukowy = "Doktor";
            Nauczyciel1.Szkola = "Sp 1 Rzeszów";
            Nauczyciel1.PodwladniUczniowie.Add(new Uczen("Ewa", "Płaczka", "14220364244", "SP 1 Rzeszów"));
            Nauczyciel1.PodwladniUczniowie.Add(new Uczen("Marcin", "Tibijczyk", "10250831112", "SP 1 Rzeszów", true));
            Nauczyciel1.PodwladniUczniowie.Add(new Uczen("Agnieszka", "Niemieszka", "06220329969", "SP 1 Rzeszów", false));
            Nauczyciel1.PodwladniUczniowie.Add(new Uczen("Grzegorz", "Floryda", "07250832137", "SP 1 Rzeszów", true));

            Nauczyciel1.WhichStudentCanGoHomeAlone(DateTime.Now);
        }
    }
}
