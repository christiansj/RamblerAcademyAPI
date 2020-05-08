using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class CourseSectionDayTimeSlotType : ObjectGraphType<CourseSectionDayTimeSlot>
    {
        public CourseSectionDayTimeSlotType(ICourseSectionRepository courseSectionRepository, IDayRepository dayRepository, ITimeSlotRepository timeSlotRepository, IDayTimeSlotRepository dayTimeSlotRepository)
        {
            Field(csdt => csdt.CourseReferenceNumber, type: typeof(IdGraphType))
                .Description(fieldDescription("CourseReferenceNumber", "CourseSection"));

            Field<CourseSectionType>(
                "courseSection",
                resolve: context=>courseSectionRepository.GetCourseSectionByCrn(context.Source.CourseReferenceNumber)
            );

            Field(csdt => csdt.DayId, type: typeof(IdGraphType))
                .Description(fieldDescription("DayId", "Day"));

            Field(csdt => csdt.TimeSlotId, type: typeof(IdGraphType))
                .Description(fieldDescription("TimeSlotId", "TimeSlot"));

            
            Field<DayTimeSlotType>(
                "dayTimeSlot",
                resolve: context => dayTimeSlotRepository.GetDayTimeSlotByIds(context.Source.DayId, context.Source.TimeSlotId)
            );
        }

        private string fieldDescription(string propertyName, string foreignTableName)
        {
            return $"{propertyName} property of the CourseSectionDayTimeSlot object. References the Id property of a ${foreignTableName} object. "
                + "Part of composite Primary Key: courseReferenceNumber, dayId and timeSlotId";
        }
    }
}
