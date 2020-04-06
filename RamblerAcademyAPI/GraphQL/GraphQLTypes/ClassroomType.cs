using GraphQL.Types;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class ClassroomType : ObjectGraphType<Classroom>
    {
        public ClassroomType()
        {
            Field(c => c.Id, type: typeof(IdGraphType))
                .Description("Id property of the Classroom object");

            Field(c => c.Floor, type: typeof(IntGraphType))
                .Description("Floor property of the Classroom object");

            Field(c => c.HallwayNumber, type: typeof(IntGraphType))
                .Description("HallwayNumber property of the Classroom object");

            Field(c => c.RoomNumber, type: typeof(IntGraphType))
                .Description("RoomNumber property of the Classroom object");

            Field(c => c.BuildingId, type: typeof(IntGraphType))
                .Description("BuildingId property of the Classroom object. References the Id property of a Building object");
        }
    }
}
