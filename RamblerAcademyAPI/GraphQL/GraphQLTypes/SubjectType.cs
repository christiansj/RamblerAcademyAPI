using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class SubjectType : ObjectGraphType<Subject>
    {
        public SubjectType(ICourseRepository courseRepository)
        {
            Field(s => s.Id, type: typeof(IdGraphType)).Description("ID property from the Subject object");
            Field(s => s.Name).Description("Name property from the Subject object. Unique Index");
            Field(s => s.Abbreviation).Description("Abbreviation property from the Subject object. MAXLENGTH of '3'. Unique Index");

            Field<ListGraphType<CourseType>>(
                "courses",
                resolve: context=>courseRepository.GetAllCoursesPerSubject(context.Source.Id)
            );
        }
    }
}
