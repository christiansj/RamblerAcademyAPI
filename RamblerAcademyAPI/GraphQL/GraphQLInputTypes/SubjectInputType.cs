using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class SubjectInputType : InputObjectGraphType
    {
        public SubjectInputType()
        {
            Name = "subjectInput";
            Field<NonNullGraphType<StringGraphType>>("name");
            Field<NonNullGraphType<StringGraphType>>("abbreviation");
        }
    }
}
