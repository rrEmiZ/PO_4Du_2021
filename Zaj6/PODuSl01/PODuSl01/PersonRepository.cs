using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.Json.Serialization;

namespace PODuSl01
{
    public interface IPersonRepository
    {
        List<Person> GetAll();
        Person GetById(int id);
        void Add(Person personToAdd);
        void Update(Person personToUpdate);
        void Remove(int id);

        int CountPersonOverYrs(int yearsFromCount);
    }
    public class PersonRepository: IPersonRepository
    {
        string DbFile { get; }
        public PersonRepository(string dbFileName)
        {
            DbFile = dbFileName;
        }
        public List<Person> GetAll()
        {
            List<Person> persons;
            using (var sr = new StreamReader(DbFile))
            {
                var json = sr.ReadToEnd();

                persons = JsonConvert.DeserializeObject<List<Person>>(json);
            }
            return persons;
        }

        public Person GetById(int id)
        {
            foreach(var person in GetAll())
            {
                if (person.Id == id)
                    return person;
            }
            return null;
        }
        public void Add(Person personToAdd)
        {
            using (var sw = new StreamWriter(DbFile))
            {
                sw.WriteLine(System.Text.Json.JsonSerializer.Serialize(personToAdd));
            }
        }

        public int CountPersonOverYrs(int yearsFromCount)
        {
            int personsCount = 0;
            foreach(var person in GetAll())
            {
                if (person.GetYearOfBirth() == yearsFromCount)
                    personsCount++;
            }
            return personsCount;
        }

        public void Remove(int id)
        {
            var persons = GetAll();
            foreach(var person in persons)
            {
                if (person.Id == id)
                    persons.Remove(person);
            }
            using (var sw = new StreamWriter(DbFile))
            {
                sw.Write(System.Text.Json.JsonSerializer.Serialize(persons));
            }
        }

        public void Update(Person personToUpdate)
        {
            Remove(personToUpdate.Id);
            Add(personToUpdate);
        }
    }
}
