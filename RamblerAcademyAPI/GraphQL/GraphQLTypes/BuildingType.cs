using GraphQL.Types;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class BuildingType : ObjectGraphType<Building>
    {
        public BuildingType()
        {
            Field(b => b.Id, type: typeof(IdGraphType)).Description("Id property from the building object");
            Field(b => b.Name).Description("Name property from the building object");
        }
    }
}
