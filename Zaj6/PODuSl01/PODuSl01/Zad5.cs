using System;
using System.Collections.Generic;
using System.Text;
using System.IO;
using Newtonsoft.Json;

namespace PODuSl01
{
    public class FilePersonRepository : IPersonRepository
    {
        List<Person> people;

        public FilePersonRepository()
        {
            ReadData();
        }

        public List<Person> GetAll()
        {
            return people;
        }
        public Person GetById(int id)
        {
            return people.Find(p => p.Id == id);
        }
        public void Add(Person personToAdd)
        {
            if(!people.Exists(p => p.Id == personToAdd.Id))
            {
                people.Add(personToAdd);
                SaveData();
            }
        }
        public void Update(Person personToUpdate)
        {
            var person = GetById(personToUpdate.Id);
            if (person == null) return;
            if (person.FirstName != personToUpdate.FirstName || person.LastName != personToUpdate.LastName || person.Pesel != personToUpdate.Pesel)
            {
                person.FirstName = personToUpdate.FirstName;
                person.LastName = personToUpdate.LastName;
                person.Pesel = personToUpdate.Pesel;
                SaveData();
            }
        }
        public void Remove(int id)
        {
            people.Remove(GetById(id));
            SaveData();
        }

        public int CountPersonOverYrs(int yearsFromCount)
        {
            int peopleCount = 0;
            foreach(var person in people)
            {
                var month = person.Pesel.Substring(2, 2);
                string year;
                if (int.Parse(month) > 12 && int.Parse(month) <= 32)
                {
                    year = "20" + person.Pesel.Substring(0, 2);
                }
                else if (int.Parse(month) > 32 && int.Parse(month) <= 52)
                {
                    year = "21" + person.Pesel.Substring(0, 2);
                }
                else if (int.Parse(month) > 52 && int.Parse(month) <= 72)
                {
                    year = "22" + person.Pesel.Substring(0, 2);
                }
                else year = "19" + person.Pesel.Substring(0, 2);

                if (int.Parse(year) > yearsFromCount) peopleCount++;
            }
            return peopleCount;
        }

        public void ReadData()
        {
            if (File.Exists("people.json"))
            {
                using (var sr = new StreamReader("people.json"))
                {
                    var json = sr.ReadToEnd();
                    if (json == "") people = new List<Person>();
                    else people = JsonConvert.DeserializeObject<List<Person>>(json);
                }
            }
            else people = new List<Person>();
        }
        public void SaveData()
        {
            using (var sw = new StreamWriter("people.json"))
            {
                var json = JsonConvert.SerializeObject(people);

                sw.Write(json);
            }
        }
    }
    public class Person
    {
        public int Id { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Pesel { get; set; }
    }
}
