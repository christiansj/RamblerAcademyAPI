﻿using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.Models;
using System;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class BuildingMutation : ObjectGraphType
    {
        public BuildingMutation(IBuildingRepository repository)
        {
            // updateBuilding(id, name)
            Field<BuildingType>(
                    "updateBuilding",
                    arguments: new QueryArguments(
                        new QueryArgument<NonNullGraphType<BuildingInputType>> { Name = "building" },
                        new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "buildingId" }),
                    resolve: context =>
                    {
                        var building = context.GetArgument<Building>("building");
                        var buildingId = context.GetArgument<int>("buildingId");

                        var dbBuilding = repository.GetBuildingById(buildingId);
                        if(dbBuilding == null)
                        {
                            context.Errors.Add(new ExecutionError("Couldn't find building in db"));
                            return null;
                        }
                        return repository.UpdateBuilding(dbBuilding, building);
                    }
             );

            // createBuilding(building, buildingId)
            Field<BuildingType>(
                "createBuilding",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<BuildingInputType>> { Name = "building" }),
                resolve: context =>
                {
                    var building = context.GetArgument<Building>("building");
                    return repository.CreateBuilding(building);
                }
            );

            // deleteBuilding(buildingId)
            Field<StringGraphType>(
                "delteBuilding",
                arguments: new QueryArguments(new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "buildingId"}),
                resolve: context =>
                {
                    var buildingId = context.GetArgument<int>("buildingId");
                    var building = repository.GetBuildingById(buildingId);
                    if(building == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find building in db."));
                        return null;
                    }
                    repository.DeleteBuilding(building);
                    return $"The building with id: {buildingId} has been successfully deleted";
                }
            );
        }
    }
}