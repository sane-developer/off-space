using Microsoft.AspNetCore.Http.HttpResults;
using Offspace.Services.Outposts.API.Requests.Outposts;
using Offspace.Services.Outposts.API.Responses;
using Offspace.Services.Outposts.API.Responses.Outposts;
using Offspace.Services.Outposts.Infrastructure.Abstractions;

namespace Offspace.Services.Outposts.API.Endpoints.Outposts;

using Responses = Results<
    NoContent,
    NotFound<Response>,
    Conflict<Response>,
    StatusCodeHttpResult
>;

/// <summary>
///     Represents an endpoint that enables the user to rename an outpost.
/// </summary>
[HttpPatch("/api/outposts/{outpostId:int}/rename")]
public sealed class RenameOutpostEndpoint : Endpoint<RenameOutpostRequest, Responses>
{
    /// <summary>
    ///     The service which enables the user to manipulate the state of the outposts.
    /// </summary>
    private readonly IOutpostService _outpostService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RenameOutpostEndpoint"/> class with the specified services.
    /// </summary>
    public RenameOutpostEndpoint(IOutpostService outpostService)
    {
        _outpostService = outpostService;
    }

    /// <summary>
    ///     Validates whether the outpost with the requested specification can be renamed.
    /// </summary>
    public override async Task<Responses> ExecuteAsync(RenameOutpostRequest req, CancellationToken ct)
    {
        var outpost = await _outpostService.GetOutpostAsync(req.OutpostId);
        
        if (outpost is null)
        {
            return TypedResults.NotFound<Response>(OutpostNotFoundResponse.Instance);
        }
        
        var isNameTaken = await _outpostService.IsOutpostNameTaken(req.Name);
        
        if (isNameTaken)
        {
            return TypedResults.Conflict<Response>(OutpostNameTakenResponse.Instance);
        }
        
        var hasRenamed = await _outpostService.RenameOutpostAsync(outpost, req.Name);
        
        if (!hasRenamed)
        {
            return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
        }
        
        return TypedResults.NoContent();
    }
}