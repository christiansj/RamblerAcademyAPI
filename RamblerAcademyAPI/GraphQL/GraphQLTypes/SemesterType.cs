using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Models;


namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class SemesterType : ObjectGraphType<Semester>
    {
        public SemesterType(ISeasonRepository seasonRepository) 
        {
            Field(s => s.Id, type: typeof(IdGraphType))
                .Description("Id property of the Semster object. Primary Key");

            Field(s => s.Year, type: typeof(IntGraphType))
                .Description("Year property of the Semester object");

            Field(s => s.StartDate, type: typeof(DateTimeGraphType))
                .Description("StartDate property of the Semester object");

            Field(s => s.EndDate, type: typeof(DateTimeGraphType))
                .Description("EndDate property of the Semester object");

            Field(s => s.SeasonId, type: typeof(IntGraphType))
                .Description("SeasonId property of the Semester object");

            Field<SeasonType>(
                "season",
                resolve: context=> seasonRepository.GetSeasonById(context.Source.SeasonId)
            );
        }
    }
}
