using System;
using System.Collections.Generic;

namespace Lab3
{

    class Program
    {
        static void Main(string[] args)
        {
            Circle circle = new Circle(5, 10, 7.10, 8.2);
            Rectangle rectangle = new Rectangle(5, 10, 7.10, 8.2);
            Triangle triangle = new Triangle(5, 10, 7.10, 8.2);


            List<Shape> shapes = new List<Shape>();

            shapes.Add(circle);
            shapes.Add(rectangle);
            shapes.Add(triangle);

            foreach (Shape element in shapes)
            {
                element.Draw();
            }

            List<Uczen> listaUczniow = new List<Uczen>();
            DateTime date = DateTime.Now;

            Uczen uczen0 = new Uczen("WsIiz", "Paweł", "Januszewski", "97071527419");
            Uczen uczen1 = new Uczen("WsIiz", "Michał", "Kowalski", "11271527419");
            Uczen uczen2 = new Uczen("WsIiz", "Mateusz", "Jeleń", "98152741910");
            Uczen uczen3 = new Uczen("WsIiz", "Jan", "Nibylec", "13271527419");
            Uczen uczen4 = new Uczen("WsIiz", "Jarosław", "Sarna", "95071527419");
            Uczen uczen5 = new Uczen("WsIiz", "Joanna", "Klaus", "99071527429");

            listaUczniow.Add(uczen0);
            listaUczniow.Add(uczen1);
            listaUczniow.Add(uczen2);
            listaUczniow.Add(uczen3);
            listaUczniow.Add(uczen4);
            listaUczniow.Add(uczen5);

            Nauczyciel nauczyciel = new Nauczyciel("Magister", listaUczniow, "WsIiz", "Matylda", "Bernard", "54051957712");
            String school = uczen0.getSchool();

            //Oczekiwany output
            Console.WriteLine(school + " Dnia: " + date.ToString("d"));
            Console.WriteLine("Nauczyciel: " + nauczyciel.TytulNaukowy + " " + nauczyciel.Imie + " " + nauczyciel.Nazwisko);
            Console.WriteLine("Lista studentów: ");

            for(int i=0; i<listaUczniow.Count; i++)
            {
                String reasoning;
                if (listaUczniow[i].canGoAloneToHome())
                {
                    reasoning = "Uczeń ma pozwolenie bądź jest starszy niż 12 lat";
                }
                else
                {
                    reasoning = "Uczeń nie ma pozwolenia bądź nie spełnia wymagań dotyczących wieku";
                }

                //Wypisanie całej listy studentów, jako verdict uznałem informację zapisaną w mozeSamWracacDoDomu 
                //a jako reasoning przyjąłem uzasadnienie dlaczego uczeń może/nie może wyjść sam do domu

                Console.WriteLine(i+1 + ". " + 
                    listaUczniow[i].Imie + " " +  
                    listaUczniow[i].Nazwisko + " - " +
                    listaUczniow[i].getGender() + " - " +
                    listaUczniow[i].canGoAloneToHome().ToString() +  " " + reasoning);  
            }

            Console.WriteLine();
            Console.WriteLine("Lista osób które mogą iść sami do domu: ");
            //Lista osób które mogą iść sami do domu
            nauczyciel.WhichStudentCanGoHomeAlone(date);
        }
    }
}
