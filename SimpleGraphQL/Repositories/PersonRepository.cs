using System.Collections.Generic;
using System.Linq;
using SimpleGraphQL.Interfaces;
using SimpleGraphQL.Models;

namespace SimpleGraphQL.Repositories
{
    public class PersonRepository : IPersonRepository
    {
        public IEnumerable<Person> GetAll()
        {
            var zhang = new Person {Id = 1, Name = "张三", Email = "zhang@example.com"};
            var li = new Person {Id = 2, Name = "李四", Email = "li@example.com"};
            var wang = new Person
            {
                Id = 3, Name = "王五", Email = "wang@example.com", Parents = new List<Person>
                {
                    zhang, li
                }
            };
            return new[]
            {
                zhang, li, wang
            };
        }

        public Person GetById(int id)
        {
            return GetAll().SingleOrDefault(x => x.Id.Equals(id));
        }
    }
}