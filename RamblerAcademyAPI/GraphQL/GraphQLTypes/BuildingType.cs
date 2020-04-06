using GraphQL.Types;
using RamblerAcademyAPI.Models;


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
