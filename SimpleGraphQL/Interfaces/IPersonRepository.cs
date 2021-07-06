using System.Collections.Generic;
using SimpleGraphQL.Models;

namespace SimpleGraphQL.Interfaces
{
    public interface IPersonRepository
    {
        IEnumerable<Person> GetAll();

        Person GetById(int id);
    }
}