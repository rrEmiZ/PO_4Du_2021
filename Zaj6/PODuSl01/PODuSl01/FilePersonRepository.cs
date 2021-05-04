using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace PODuSl01
{
    class FilePersonRepository : IPersonRepository
    {
        List<Person> list;
        public List<Person> GetAll()
        {
            using (var sr = new StreamReader("People.json"))
            {
                var json = sr.ReadToEnd();

                list = JsonConvert.DeserializeObject<List<Person>>(json);
            }
            return list;
        }
        public Person GetById(int id)
        {
            return list.Find(person => person.Id == id);
        }
        public void Add(Person personToAdd)
        {
            list.Add(personToAdd);
            using var File = new StreamWriter("People.json");
            var json = JsonConvert.SerializeObject(personToAdd);
            File.WriteLine(json);
        }
        public void Remove(int id)
        {
            list.Remove(GetById(id));
            using (var File = new StreamWriter("People.json"))
            {
                var json = JsonConvert.SerializeObject(list);

                File.Write(json);
            }
        }
        public void Update(Person personToUpdate)
        {
            Person obj = list.FirstOrDefault(person => person.FirstName == personToUpdate.FirstName);
            if (obj != null)
            {
                obj.FirstName = personToUpdate.FirstName;
                obj.LastName = personToUpdate.LastName;
                obj.Id = obj.Id;
                obj.Pesel = personToUpdate.Pesel;
            }
            using (var File = new StreamWriter("People.json"))
            {
                var json = JsonConvert.SerializeObject(list);

                File.Write(json);
            }
        }

        public int CountPersonOverYrs(int yearsFromCount)
        {
            int PeopleCount = 0;
            foreach(Person person in list)
            {
                int BaseYear = 1900;

                if (Int32.Parse(person.Pesel[2].ToString()) == 2 || Int32.Parse(person.Pesel[2].ToString()) == 3)
                {
                    BaseYear = 2000;
                }
                int YearOfBirth = Int32.Parse(person.Pesel[0].ToString() + person.Pesel[1].ToString());
                int Year = YearOfBirth + BaseYear;

                if(Year == yearsFromCount)
                {
                    PeopleCount++;
                }
            }
            return PeopleCount;
        }
    }
}
