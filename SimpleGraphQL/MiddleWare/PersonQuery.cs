using GraphQL;
using GraphQL.Types;
using SimpleGraphQL.Interfaces;

namespace SimpleGraphQL.MiddleWare
{
    public class PersonQuery : ObjectGraphType
    {
        public PersonQuery(IPersonRepository personRepository)
        {
            Field<PersonType>("person", arguments: new QueryArguments(new QueryArgument<IntGraphType> {Name = "id"}),
                resolve: context =>
                {
                    var id = context.GetArgument<int>("id");
                    return personRepository.GetById(id);
                });
            Field<ListGraphType<PersonType>>("persons", resolve: _ => personRepository.GetAll());
        }
    }
}