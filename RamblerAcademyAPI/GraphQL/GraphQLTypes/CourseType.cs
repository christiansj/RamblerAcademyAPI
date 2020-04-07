using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class CourseType : ObjectGraphType<Course>
    {
        public CourseType(ISubjectRepository subjectRepository, ICourseSectionRepository courseSectionRepository)
        {
            Field(c => c.Id, type: typeof(IdGraphType))
                .Description("Id property of the Course object. Primary Key");

            Field(c => c.Name, type: typeof(StringGraphType))
                .Description("Name property of the Course object. Unique Index");

            Field(c => c.CourseNumber, type: typeof(IntGraphType))
                .Description("CourseNumber property of the Course object. Unique Index (CourseNumber, SubjectId)");

            Field(c => c.SubjectId, type: typeof(IntGraphType))
                .Description("SubjectId property of the Course object. References the Id property of a Subject object.");

            Field<SubjectType>(
                "subject",
                resolve: context => subjectRepository.GetSubjectById(context.Source.SubjectId)
            );

            Field<ListGraphType<CourseSectionType>>(
                "courseSections",
                resolve: context => courseSectionRepository.GetAllCourseSectionsPerCourse(context.Source.Id)
            );
        }
    }
}
