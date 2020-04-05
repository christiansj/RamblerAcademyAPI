using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.GraphQL.GraphQLMutations;
using RamblerAcademyAPI.GraphQL.GraphQLQueries;

namespace RamblerAcademyAPI.GraphQL.GraphQlSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<CompositeQuery>();
            Mutation = resolver.Resolve<CompositeMutation>();
        }
    }
}
