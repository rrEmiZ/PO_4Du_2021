using System;
using System.Collections.Generic;

namespace Lab3
{

    class Program
    {
        static void Main(string[] args)
        {
            /*List<Shape> list = new List<Shape>();

            list.Add(new Shape()
            {
                X = 5,
                Y = 3,
                Height = 5,
                Width = 4
            });

            list.Add(new Rectangle()
            {
                X = 4,
                Y = 5,
                Height = 2,
                Width = 6
            });

            list.Add(new Triangle()
            {
                X = 6,
                Y = 4,
                Height = 5,
                Width = 5
            });

            list.Add(new Circle()
            {
                X = 2,
                Y = 5,
                Height = 4,
                Width = 7
            });

            foreach (var item in list)
            {
                item.Draw();
            }*/


            Nauczyciel nauczyciel = new Nauczyciel("Michał", "Kowalski", "ZS18", "75248293492", "mgr");

            nauczyciel.PodwladniUczniowie.Add(new Uczen("Aldona", "Milar","ZS15", "16290723981"));
            nauczyciel.PodwladniUczniowie.Add(new Uczen("Wioletta", "Knos", "ZS16", "15271167787"));
            nauczyciel.PodwladniUczniowie.Add(new Uczen("Gabriela", "Miniuk", "ZS19", "07270613581"));

            nauczyciel.PodwladniUczniowie.Add(new Uczen("Waldek", "Micał", "ZS5", "12210676726"));
            nauczyciel.PodwladniUczniowie.Add(new Uczen("Franek", "Królikowski", "ZS8", "09260839474"));
            nauczyciel.PodwladniUczniowie.Add(new Uczen("Michał", "Kowal", "ZS5", "14301163676"));
            nauczyciel.PodwladniUczniowie.Add(new Uczen("Wojciech", "Adamski", "ZS8", "99060228596"));


            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine(nauczyciel.GetEducationInfo() + " Dnia:" + DateTime.Now);
            
            Console.WriteLine(nauczyciel.TytulNaukowy + " " + nauczyciel.GetFullName());

            Console.WriteLine();
            Console.WriteLine();

            Console.WriteLine("Lista studentów:");

            nauczyciel.WhichStudentCanGoHomeAlone(DateTime.Now);
        }
    }
}