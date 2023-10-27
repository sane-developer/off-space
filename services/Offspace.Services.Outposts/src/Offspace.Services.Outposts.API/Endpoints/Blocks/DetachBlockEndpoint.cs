using Microsoft.AspNetCore.Http.HttpResults;
using Offspace.Services.Outposts.API.Requests.Blocks;
using Offspace.Services.Outposts.API.Responses;
using Offspace.Services.Outposts.API.Responses.Blocks;
using Offspace.Services.Outposts.Infrastructure.Abstractions;

namespace Offspace.Services.Outposts.API.Endpoints.Blocks;

using Responses = Results<
    NoContent,
    NotFound<Response>,
    BadRequest<Response>,
    StatusCodeHttpResult
>;

/// <summary>
///     Represents an endpoint that enables the user to detach a block from the requested outpost.
/// </summary>
[HttpPatch("/api/blocks/{blockId:int}/detach")]
public sealed class DetachBlockEndpoint : Endpoint<DetachBlockRequest, Responses>
{
    /// <summary>
    ///     The service which enables the user to manipulate the state of the verven blocks.
    /// </summary>
    private readonly IBlockService _blockService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DetachBlockEndpoint"/> class with the specified services.
    /// </summary>
    public DetachBlockEndpoint(IBlockService blockService)
    {
        _blockService = blockService;
    }

    /// <summary>
    ///     Validates whether the block with the requested specification can be detached from the outpost.
    /// </summary>
    public override async Task<Responses> ExecuteAsync(DetachBlockRequest req, CancellationToken ct)
    {
        var block = await _blockService.GetBlockAsync(req.BlockId);
        
        if (block is null)
        {
            return TypedResults.NotFound<Response>(BlockNotFoundResponse.Instance);
        }
        
        if (block.OutpostId is null)
        {
            return TypedResults.BadRequest<Response>(BlockNotAttachedResponse.Instance);
        }
        
        var hasDetached = await _blockService.DetachBlockFromOutpostAsync(block);
        
        if (!hasDetached)
        {
            return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
        }

        return TypedResults.NoContent();
    }
}