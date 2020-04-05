using GraphQL.Types;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.GraphQL.GraphQLInputTypes
{
    public class BuildingInputType : InputObjectGraphType
    {
        public BuildingInputType()
        {
            Name = "buildingInput";
            Field<NonNullGraphType<StringGraphType>>("name");
        }
    }
}
