using Microsoft.AspNetCore.Http.HttpResults;
using Offspace.Services.Outposts.API.Requests.Blocks;
using Offspace.Services.Outposts.API.Responses;
using Offspace.Services.Outposts.API.Responses.Blocks;
using Offspace.Services.Outposts.API.Responses.Outposts;
using Offspace.Services.Outposts.Domain.Constraints;
using Offspace.Services.Outposts.Infrastructure.Abstractions;

namespace Offspace.Services.Outposts.API.Endpoints.Blocks;

using ResponsePool = Results<
    NoContent, 
    BadRequest<Response>, 
    NotFound<Response>, 
    Conflict<Response>, 
    StatusCodeHttpResult
>;

/// <summary>
///     Represents an endpoint that enables the user to attach a block to the requested outpost.
/// </summary>
[HttpPatch("/api/blocks/{blockId:int}/attach")]
public sealed class AttachBlockEndpoint : Endpoint<AttachBlockRequest, ResponsePool>
{
    /// <summary>
    ///     The service which enables the user to manipulate the state of the verven blocks.
    /// </summary>
    private readonly IBlockService _blockService;

    /// <summary>
    ///     The service which enables the user to manipulate the state of the outposts.
    /// </summary>
    private readonly IOutpostService _outpostService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="AttachBlockEndpoint"/> class with the specified services.
    /// </summary>
    public AttachBlockEndpoint(IBlockService blockService, IOutpostService outpostService)
    {
        _blockService = blockService;
        _outpostService = outpostService;
    }

    /// <summary>
    ///     Validates whether the block with the requested specification can be attached to the outpost.
    /// </summary>
    public override async Task<ResponsePool> ExecuteAsync(AttachBlockRequest req, CancellationToken ct)
    {
        if (req.Position is < BlockConstraint.MinimumBlockPosition or > BlockConstraint.MaximumBlockPosition)
        {
            return TypedResults.BadRequest<Response>(BlockOutOfGridResponse.Instance);
        }
        
        var block = await _blockService.GetBlockAsync(req.BlockId);
        
        if (block is null)
        {
            return TypedResults.NotFound<Response>(BlockNotFoundResponse.Instance);
        }
        
        if (block.OutpostId is not null)
        {
            return TypedResults.Conflict<Response>(BlockAlreadyAttachedResponse.Instance);
        }
        
        var outpost = await _outpostService.GetOutpostAsync(req.OutpostId);
        
        if (outpost is null)
        {
            return TypedResults.NotFound<Response>(OutpostNotFoundResponse.Instance);
        }

        if (req.IsRoot)
        {
            var root = await _blockService.GetRootBlockInOutpostAsync(req.OutpostId);
        
            if (root is not null)
            {
                return TypedResults.Conflict<Response>(OutpostHasRootResponse.Instance);
            }
        }
        
        var blockAtPosition = await _blockService.GetBlockAsync(req.Position, req.OutpostId);
        
        if (blockAtPosition is not null)
        {
            return TypedResults.Conflict<Response>(BlockCollisionResponse.Instance);
        }
        
        var countOfBlocksInOutpost = await _blockService.GetBlockCountInOutpostAsync(req.OutpostId);
        
        if (countOfBlocksInOutpost is BlockConstraint.AvailableBlocksPerOutpost)
        {
            return TypedResults.Conflict<Response>(OutpostReachedCapacityResponse.Instance);
        }
        
        var hasAttached = await _blockService.AttachBlockToOutpostAsync(block, req.IsRoot, req.Position, req.OutpostId);
        
        if (!hasAttached)
        {
            return TypedResults.StatusCode(StatusCodes.Status500InternalServerError);
        }
        
        return TypedResults.NoContent();
    }
}