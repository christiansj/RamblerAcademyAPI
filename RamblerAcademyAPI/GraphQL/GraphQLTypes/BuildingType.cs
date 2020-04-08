using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class BuildingType : ObjectGraphType<Building>
    {
        public BuildingType(IClassroomRepository classroomRepository)
        {
            Field(b => b.Id, type: typeof(IdGraphType)).Description("Id property from the building object");
            Field(b => b.Name).Description("Name property from the building object");

            Field<ListGraphType<ClassroomType>>(
                "classrooms",
                resolve: context=>classroomRepository.GetAllClassroomsPerBuilding(context.Source.Id)
            );
        }
    }
}
