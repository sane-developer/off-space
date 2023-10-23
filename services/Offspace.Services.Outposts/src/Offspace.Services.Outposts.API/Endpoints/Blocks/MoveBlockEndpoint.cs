using Offspace.Services.Outposts.API.Requests.Blocks;
using Offspace.Services.Outposts.Domain.Constraints;
using Offspace.Services.Outposts.Infrastructure.Services;

namespace Offspace.Services.Outposts.API.Endpoints.Blocks;

/// <summary>
///     Represents an endpoint that enables the user to move the block to a new position within the requested outpost.
/// </summary>
[HttpPatch("/api/blocks/{blockId:int}/move")]
public sealed class MoveBlockEndpoint : Endpoint<MoveBlockRequest>
{
    /// <summary>
    ///     The service which enables the user to manipulate the state of the verven blocks.
    /// </summary>
    private readonly BlockService _blockService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="MoveBlockEndpoint"/> class with the specified services.
    /// </summary>
    public MoveBlockEndpoint(BlockService blockService)
    {
        _blockService = blockService;
    }

    /// <summary>
    ///     Validates whether the block with the specified id can be moved to the requested position within the requested outpost.
    /// </summary>
    /// <remarks>
    ///     The block can only be moved to the requested position within the requested outpost when all of the conditions have been met:
    ///     <list type="bullet">
    ///         <item>The block position is between 0 and 49,</item>
    ///         <item>The block with requested id exists,</item>
    ///         <item>The block is attached to an outpost,</item>
    ///         <item>There is no block at the requested position.</item>
    ///     </list>
    /// </remarks>
    public override async Task HandleAsync(MoveBlockRequest req, CancellationToken ct)
    {
        if (req.NewPosition is < BlockConstraint.MinimumBlockPosition or > BlockConstraint.MaximumBlockPosition)
        {
            await SendErrorsAsync(StatusCodes.Status400BadRequest, ct);
            return;
        }
        
        var block = await _blockService.GetBlockAsync(req.BlockId);
        
        if (block is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        if (block.OutpostId is null)
        {
            await SendErrorsAsync(StatusCodes.Status409Conflict, ct);
            return;
        }
        
        var blockAtPosition = await _blockService.GetBlockAsync(req.NewPosition, block.OutpostId.Value);
        
        if (blockAtPosition is not null)
        {
            await SendErrorsAsync(StatusCodes.Status409Conflict, ct);
            return;
        }
        
        var hasMoved = await _blockService.MoveBlockWithinOutpostAsync(block, req.NewPosition);
        
        if (!hasMoved)
        {
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
            return;
        }
        
        await SendNoContentAsync(ct);
    }
}