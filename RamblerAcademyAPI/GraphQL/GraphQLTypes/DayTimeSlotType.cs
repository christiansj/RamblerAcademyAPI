using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class DayTimeSlotType : ObjectGraphType<DayTimeSlot>
    {
        public DayTimeSlotType(IDayRepository dayRepository, ITimeSlotRepository timeSlotRepository)
        {
            Field(dts => dts.DayId, type: typeof(IdGraphType))
                .Description("DayId property of the DayTimeSlot object. References Id property of a Day object. Part of composite primary key: DayId and TimeSlotId");

            Field<DayType>(
                "day",
                resolve: context=>dayRepository.GetDayById(context.Source.DayId)
            );

            Field(dts => dts.TimeSlotId, type: typeof(IdGraphType))
                .Description("TimeSlotId property of the DayTimeSlot object. References Id property of a TimeSlot object. Part of composite primary key: DayId and TimeSlotId");

            Field<TimeSlotType>(
                "timeSlot",
                resolve: context=>timeSlotRepository.GetTimeSlotById(context.Source.TimeSlotId)
            );
        }
    }
}
