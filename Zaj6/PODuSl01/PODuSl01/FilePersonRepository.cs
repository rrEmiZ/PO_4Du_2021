using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace PODuSl01
{
    class FilePersonRepository : IPersonRepository
    {
        List<Person> peopleList = new List<Person>();
        public void Add(Person personToAdd)
        {
            peopleList.Add(personToAdd);
            using (var sw = new StreamWriter("people.json"))
            {
                var json = JsonConvert.SerializeObject(peopleList, Formatting.Indented);

                sw.Write(json);
            }
        }

        public int CountPersonOverYrs(int yearsFromCount)
        {
            int counter = 0;
            foreach (var person in GetAll())
            {
                int month = Int32.Parse(person.Pesel.Substring(2, 2));
                int baseYear;
                if (month > 80)
                    baseYear = 1800;
                else if (month > 20)
                    baseYear = 2000;
                else
                    baseYear = 1900;
                if (baseYear + Int32.Parse(person.Pesel.Substring(0, 2)) >= yearsFromCount)
                    counter++;
            }
            return counter;
        }

        public List<Person> GetAll()
        {
            return peopleList;
        }

        public Person GetById(int id)
        {
            var person1 = new Person();
           foreach(var person in peopleList)
            {
                if (person.Id == id)
                {
                 person1= person;
                }
            }
            return person1;
        }

        public void Remove(int id)
        {
            peopleList.Remove(GetById(id));
            using (var sw = new StreamWriter("people.json"))
            {
                var json = JsonConvert.SerializeObject(peopleList, Formatting.Indented);

                sw.Write(json); 
            }
        }

        public void Update(Person personToUpdate)
        {
            Remove(personToUpdate.Id);
            Add(personToUpdate);
        }
    }
}
