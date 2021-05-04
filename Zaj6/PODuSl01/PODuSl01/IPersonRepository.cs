using System;
using System.Collections.Generic;
using System.Text;

namespace PODuSl01
{
    interface IPersonRepository
    {
        List<Person> GetAll();
        Person GetById(int id);
        void Add(Person personToAdd);
        void Update(Person personToUpdate);
        void Remove(int id);
        void RemoveAll();
        void ConsoleWriteAll();
        int CountPersonOverYrs(int yearsFromCount);
    }
}
