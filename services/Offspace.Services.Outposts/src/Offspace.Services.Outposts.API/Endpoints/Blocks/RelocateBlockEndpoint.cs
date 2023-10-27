using Microsoft.AspNetCore.Http.HttpResults;
using Offspace.Services.Outposts.API.Requests.Blocks;
using Offspace.Services.Outposts.API.Responses;
using Offspace.Services.Outposts.API.Responses.Blocks;
using Offspace.Services.Outposts.Domain.Constraints;
using Offspace.Services.Outposts.Infrastructure.Abstractions;

namespace Offspace.Services.Outposts.API.Endpoints.Blocks;

using Responses = Results<
    NoContent,
    NotFound<Response>,
    BadRequest<Response>,
    Conflict<Response>,
    StatusCodeHttpResult
>;

/// <summary>
///     Represents an endpoint that enables the user to move the block to a new position within the requested outpost.
/// </summary>
[HttpPatch("/api/blocks/{blockId:int}/relocate")]
public sealed class RelocateBlockEndpoint : Endpoint<RelocateBlockRequest, Responses>
{
    /// <summary>
    ///     The service which enables the user to manipulate the state of the verven blocks.
    /// </summary>
    private readonly IBlockService _blockService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RelocateBlockEndpoint"/> class with the specified services.
    /// </summary>
    public RelocateBlockEndpoint(IBlockService blockService)
    {
        _blockService = blockService;
    }

    /// <summary>
    ///     Validates whether the block with the specified id can be moved to the requested position within the requested outpost.
    /// </summary>
    public override async Task<Responses> ExecuteAsync(RelocateBlockRequest req, CancellationToken ct)
    {
        if (req.NewPosition is < BlockConstraint.MinimumBlockPosition or > BlockConstraint.MaximumBlockPosition)
        {
            return TypedResults.BadRequest<Response>(BlockOutOfGridResponse.Instance);
        }
        
        var block = await _blockService.GetBlockAsync(req.BlockId);
        
        if (block is null)
        {
            return TypedResults.NotFound<Response>(BlockNotFoundResponse.Instance);
        }
        
        if (block.OutpostId is null)
        {
            return TypedResults.BadRequest<Response>(BlockNotAttachedResponse.Instance);
        }
        
        var blockAtPosition = await _blockService.GetBlockAsync(req.NewPosition, block.OutpostId.Value);
        
        if (blockAtPosition is not null)
        {
            return TypedResults.Conflict<Response>(BlockCollisionResponse.Instance);
        }
        
        var hasMoved = await _blockService.MoveBlockWithinOutpostAsync(block, req.NewPosition);
        
        if (!hasMoved)
        {
            return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
        }
        
        return TypedResults.NoContent();
    }
}