namespace SpaceAPI.Endpoints;

public interface IEndpoint
{
    void MapEndpoint(IEndpointRouteBuilder app);
}

// används ej men låter vara kvar för framtiden.