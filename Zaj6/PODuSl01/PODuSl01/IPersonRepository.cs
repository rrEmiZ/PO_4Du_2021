using System;
using System.Collections.Generic;
using System.Text;

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
}
