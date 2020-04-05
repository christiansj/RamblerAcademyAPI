using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;


namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class SubjectQuery: ObjectGraphType, IGraphQLQuery
    {
        public SubjectQuery(ISubjectRepository repository)
        {
            Field<ListGraphType<SubjectType>>(
                "subjects",
               resolve: context => repository.GetAll()
            );

            Field<SubjectType>(
                "subject",
                arguments: new QueryArguments(new
                    QueryArgument<IdGraphType>
                { Name = "id" }),
                resolve:
                    context => repository.GetSubjectById(context.GetArgument<int>("id"))
            );
        }
    }
}
