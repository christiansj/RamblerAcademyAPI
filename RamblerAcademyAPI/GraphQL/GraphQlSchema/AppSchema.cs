using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.GraphQL.GraphQLQueries;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.GraphQL.GraphQlSchema
{
    public class AppSchema : Schema
    {
        public AppSchema(IDependencyResolver resolver)
            : base(resolver)
        {
            Query = resolver.Resolve<BuildingQuery>();
        }
    }
}
