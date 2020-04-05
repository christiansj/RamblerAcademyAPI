using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RamblerAcademyAPI.GraphQL.GraphQLQueries
{
    public class BuildingQuery : ObjectGraphType
    {
        public BuildingQuery(IBuildingRepository repository)
        {
            // buildings()
            Field<ListGraphType<BuildingType>>(
                "buildings",
                resolve: context => repository.GetAll()
            );

            // building(id)
            Field<BuildingType>
                ("building",
                arguments: new QueryArguments(new
                    QueryArgument<IntGraphType>
                { Name = "id" }),
                resolve:
                    context => repository.GetBuildingById(context.GetArgument<int>("id"))
                );
        }     
    }
}
