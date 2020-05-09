using GraphQL.Types;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class DayType : ObjectGraphType<Day>
    {
        public DayType()
        {
            Field(d => d.Id, type: typeof(IdGraphType))
                .Description("Id property of the day object. Primary key");

            Field(d => d.Name, type: typeof(StringGraphType))
                .Description("Name property of the day object. Unique index");

            Field(d=>d.Abbreviation, type: typeof(StringGraphType))
                 .Description("Abbreviation property of the day object. Unique index");
        }
    }
}
