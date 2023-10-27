using Microsoft.AspNetCore.Http.HttpResults;
using Offspace.Services.Outposts.API.Extensions;
using Offspace.Services.Outposts.API.Requests.Outposts;
using Offspace.Services.Outposts.API.Responses;
using Offspace.Services.Outposts.API.Responses.Outposts;
using Offspace.Services.Outposts.Infrastructure.Abstractions;

namespace Offspace.Services.Outposts.API.Endpoints.Outposts;

using Responses = Results<
    Created<OutpostCreatedResponse>,
    Conflict<Response>,
    StatusCodeHttpResult
>;

/// <summary>
///     Represents an endpoint that enables the user to create an outpost.
/// </summary>
[HttpPost("/api/outposts")]
public sealed class CreateOutpostEndpoint : Endpoint<CreateOutpostRequest, Responses>
{
    /// <summary>
    ///     The service which enables the user to manipulate the state of the outposts.
    /// </summary>
    private readonly IOutpostService _outpostService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CreateOutpostEndpoint"/> class with the specified services.
    /// </summary>
    public CreateOutpostEndpoint(IOutpostService outpostService)
    {
        _outpostService = outpostService;
    }

    /// <summary>
    ///     Validates whether the outpost with the requested specification can be created.
    /// </summary>
    public override async Task<Responses> ExecuteAsync(CreateOutpostRequest req, CancellationToken ct)
    {
        var isNameTaken = await _outpostService.IsOutpostNameTaken(req.Name);

        if (isNameTaken)
        {
            return TypedResults.Conflict<Response>(OutpostNameTakenResponse.Instance);
        }

        var createdOutpost = await _outpostService.CreateOutpostAsync(req.Name);

        if (createdOutpost is null)
        {
            return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
        }

        var response = createdOutpost.ToOutpostCreatedResponse();
        
        return TypedResults.Created("api/outposts", response);
    }
}