using GraphQL;
using GraphQL.Types;
using RamblerAcademyAPI.Contracts;
using RamblerAcademyAPI.GraphQL.GraphQLInputTypes;
using RamblerAcademyAPI.GraphQL.GraphQLTypes;
using RamblerAcademyAPI.Models;

namespace RamblerAcademyAPI.GraphQL.GraphQLMutations
{
    public class SeasonMutation : ObjectGraphType, IGraphQLMutation
    {
        public SeasonMutation(ISeasonRepository repository)
        {
            // createSeason(season)
            Field<SeasonType>(
                "createSeason",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SeasonInputType>> { Name = "season" }
                ),
                resolve: context =>
                {
                    var season = context.GetArgument<Season>("season");
                    return repository.CreateSeason(season);
                }
            );

            // updateSeason(season, seasonId)
            Field<SeasonType>(
                "updateSeason",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<SeasonInputType>> { Name = "season" },
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "seasonId" }
                ),
                resolve: context =>
                {
                    var seasonId = context.GetArgument<int>("seasonId");
                    var season = context.GetArgument<Season>("season");

                    var dbSeason = repository.GetSeasonById(seasonId);
                    if (dbSeason == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find season in db"));
                        return null;
                    }

                    return repository.UpdateSeason(dbSeason, season);
                }
            );

            // deleteSeason(seasonId)
            Field<StringGraphType>(
                "deleteSeason",
                arguments: new QueryArguments(
                    new QueryArgument<NonNullGraphType<IdGraphType>> { Name = "seasonId" }
                ),
                resolve: context =>
                {
                    int seasonId = context.GetArgument<int>("seasonId");
                    var season = repository.GetSeasonById(seasonId);

                    if(season == null)
                    {
                        context.Errors.Add(new ExecutionError("Couldn't find season in db"));
                        return null;
                    }

                    repository.DeleteSeason(season);
                    return $"The season with the id {seasonId} has been successfully deleted";
                }
            );
        }
    }
}
