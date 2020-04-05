using GraphQL.Types;
using System.Collections.Generic;


namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class CompositeMutation : ObjectGraphType<object>
    {
        public CompositeMutation(IEnumerable<IGraphQLMutation> graphMutations)
        {
            Name = "CompositeMutation";
            foreach (var mutation in graphMutations)
            {
                var m = mutation as ObjectGraphType<object>;
                foreach (var f in m.Fields)
                {
                    AddField(f);
                }
            }
        }
    }
}
