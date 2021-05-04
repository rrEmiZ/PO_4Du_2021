using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace PODuSl01
{
    //Zad5
    class FilePersonRepository : IPersonRepository
    {
        List<Person> lista = new List<Person>();
        public void Add(Person personToAdd)
        {
            
            lista.Add(personToAdd);
            using (var sw = new StreamWriter("person.json"))
            {
                var json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                sw.WriteLine(json);
            }


        }

        public int CountPersonOverYrs(int yearsFromCount)
        {
            List<Person> ListOfALL = GetAll();
            int count = 0;
            for(int i = 0; i < ListOfALL.Count;i++)
            {
                int first = Int32.Parse(ListOfALL[i].Pesel[0].ToString());
                first *= 10;
                int second = Int32.Parse(ListOfALL[i].Pesel[1].ToString());
                int Age;
                if (Int32.Parse(ListOfALL[i].Pesel[2].ToString()) == 2 || Int32.Parse(ListOfALL[i].Pesel[2].ToString()) == 3)
                {
                    Age = 2000 + first + second;
                }
                else
                {
                    Age = 1900 + first + second;
                }
                if(Age >= yearsFromCount)
                {
                    count++;
                }
            }    
            

            return count;
        }

        public List<Person> GetAll()
        {
            List<Person> ListOfAll;
            using (var sr = new StreamReader("person.json"))
            {
                var json = sr.ReadToEnd();
                ListOfAll = JsonConvert.DeserializeObject<List<Person>>(json);
            }
            return ListOfAll;
        }

        public Person GetById(int id)
        {

            List<Person> ListOfALL = GetAll();
            for(int i = 0; i < ListOfALL.Count; i++)
            {
                if (ListOfALL[i].Id == id)
                {
                    return ListOfALL[i];
                }
                
            }
            
            return null;
        }
        
        public void Remove(int id)
        {
            Person example = GetById(id);
            List<Person> bufor = new List<Person>();
            for(int i = 0; i < lista.Count; i++)
            {
                if(lista[i].Id == example.Id)
                {
                    continue;
                }
                else
                {
                    bufor.Add(lista[i]);
                }
            }
            lista.Clear();
            lista = bufor;            
            using (var sw = new StreamWriter("person.json"))
            {
                var json = JsonConvert.SerializeObject(lista, Formatting.Indented);
                sw.WriteLine(json);
            }
        }

        public void RemoveAll()
        {
            
                using (var sw = new StreamWriter("person.json"))
                {
                    sw.WriteLine("");
                }

        }

        public void ConsoleWriteAll()
        {
                 List<Person> ListOfALL = GetAll();

                for (int i = 0; i < ListOfALL.Count; i++)
                {
                    Console.WriteLine($"{ListOfALL[i].Id}. {ListOfALL[i].FirstName} {ListOfALL[i].LastName} {ListOfALL[i].Pesel}");

                }
           
        }


        public void Update(Person personToUpdate)
        {
            Remove(personToUpdate.Id);
            Add(personToUpdate);
        }
    }
}
