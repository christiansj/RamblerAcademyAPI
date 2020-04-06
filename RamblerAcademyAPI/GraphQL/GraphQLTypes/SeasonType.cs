﻿using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLTypes
{
    public class SeasonType : ObjectGraphType<Season>
    {
        public SeasonType()
        {
            Field(s => s.Id, type: typeof(IdGraphType))
                .Description("Id property of the Season object. Primary Key");

            Field(s => s.Name, type: typeof(StringGraphType))
                .Description("Name property of the Season object. Unique Index");
        }
    }
}
