using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.GraphQL.GraphQLUserErrors
{
    public class GraphQLUserError
    {
        public static string NotFoundString(string entityName)
        {
            return $"Couldn't find {entityName} in db.";
        }
    }
}
