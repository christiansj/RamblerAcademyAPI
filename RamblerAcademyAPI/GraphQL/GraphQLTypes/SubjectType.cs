using GraphQL.Types;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class SubjectType : ObjectGraphType<Subject>
    {
        public SubjectType()
        {
            Field(s => s.Id, type: typeof(IdGraphType)).Description("ID property from the Subject object");
            Field(s => s.Name).Description("Name property from the Subject object");
        }
    }
}
