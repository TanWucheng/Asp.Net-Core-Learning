using GraphQL.Types;
using SimpleGraphQL.Models;

namespace SimpleGraphQL.MiddleWare
{
    public sealed class PersonType : ObjectGraphType<Person>
    {
        public PersonType()
        {
            Field(x => x.Id);
            Field(x => x.Name);
            Field(x => x.Email);
            Field<ListGraphType<PersonType>>("Parents");
        }
    }
}