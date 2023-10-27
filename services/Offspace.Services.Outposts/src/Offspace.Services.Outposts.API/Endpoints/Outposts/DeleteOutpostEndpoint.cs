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
///     Represents an endpoint that enables the user to delete an outpost.
/// </summary>
[HttpDelete("/api/outposts/{outpostId:int}")]
public sealed class DeleteOutpostEndpoint : Endpoint<DeleteOutpostRequest, Responses>
{
    /// <summary>
    ///     The service which enables the user to manipulate the state of the blocks.
    /// </summary>
    private readonly IBlockService _blockService;
    
    /// <summary>
    ///     The service which enables the user to manipulate the state of the outposts.
    /// </summary>
    private readonly IOutpostService _outpostService;
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="DeleteOutpostEndpoint"/> class with the specified services.
    /// </summary>
    public DeleteOutpostEndpoint(IOutpostService outpostService, IBlockService blockService)
    {
        _outpostService = outpostService;
        _blockService = blockService;
    }

    /// <summary>
    ///     Validates whether the outpost with the specified id can be deleted.
    /// </summary>
    public override async Task<Responses> ExecuteAsync(DeleteOutpostRequest req, CancellationToken ct)
    {
        var outpost = await _outpostService.GetOutpostAsync(req.OutpostId);
        
        if (outpost is null)
        {
            return TypedResults.NotFound<Response>(OutpostNotFoundResponse.Instance);
        }

        var hasAnyBlocksAttached = await _blockService.GetBlockCountInOutpostAsync(req.OutpostId) > 0;
        
        if (hasAnyBlocksAttached)
        {
            return TypedResults.Conflict<Response>(OutpostNotEmptyResponse.Instance);
        }
        
        var hasDeleted = await _outpostService.DeleteOutpostAsync(outpost);
        
        if (!hasDeleted)
        {
            return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
        }
        
        return TypedResults.NoContent();
    }
}