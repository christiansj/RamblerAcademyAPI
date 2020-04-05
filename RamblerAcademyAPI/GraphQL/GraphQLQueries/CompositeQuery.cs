using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class CompositeQuery : ObjectGraphType<object>
    {
        public CompositeQuery(IEnumerable<IGraphQLQuery> graphQueries)
        {
            Name = "CompositeQuery";
            foreach(var query in graphQueries)
            {
                var q = query as ObjectGraphType<object>;
                foreach(var f in q.Fields)
                {
                    AddField(f);
                }
            }
        }
    }
}
