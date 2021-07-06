using System.Collections.Generic;

namespace SimpleGraphQL.Models
{
    public class Person
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public List<Person> Parents { get; set; }
    }
}