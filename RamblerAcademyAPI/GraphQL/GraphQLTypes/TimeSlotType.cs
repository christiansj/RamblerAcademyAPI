using GraphQL.Types;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class TimeSlotType : ObjectGraphType<TimeSlot>
    {
        public TimeSlotType()
        {
            Field(ts => ts.Id, type: typeof(IdGraphType))
                .Description("Id property of the TimeSlot object. Primary Key");

            Field(ts => ts.StartTime, type: typeof(TimeSpanSecondsGraphType))
                .Description("StartTime property of the TimeSlot object. Respresents a point in time in SECONDS. Part of composite Unique Index: StartTime and EndTime");

            Field(ts => ts.EndTime, type: typeof(TimeSpanSecondsGraphType))
                .Description("EndTime property of the TimeSlot object. Respresents a point in time in SECONDS. Part of composite Unique Index: StartTime and EndTime");
        }
    }
}
