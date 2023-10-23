using Offspace.Services.Outposts.API.Requests.Blocks;
using Offspace.Services.Outposts.Domain.Constraints;
using Offspace.Services.Outposts.Infrastructure.Abstractions;

namespace Offspace.Services.Outposts.API.Endpoints.Blocks;

/// <summary>
///     Represents an endpoint that enables the user to attach a block to the requested outpost.
/// </summary>
[HttpPatch("/api/blocks/{blockId:int}/attach")]
public sealed class AttachBlockEndpoint : Endpoint<AttachBlockRequest>
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
    ///     Validates whether the block with the specified specification can be attached to the requested outpost.
    /// </summary>
    /// <remarks>
    ///     The block can only be attached to the requested outpost when all of the conditions have been met:
    ///     <list type="bullet">
    ///         <item>The block position is between 0 and 49,</item>
    ///         <item>The block with requested id exists,</item>
    ///         <item>The block is not attached to any outpost,</item>
    ///         <item>The outpost with requested id exists,</item>
    ///         <item>There is no block at the requested position,</item>
    ///         <item>The overall block count in the outpost is less than the maximum allowed,</item>
    ///         <item>In case the block is labeled as root; the outpost does not have already have a root block.</item>
    ///     </list>
    /// </remarks>
    public override async Task HandleAsync(AttachBlockRequest req, CancellationToken ct)
    {
        if (req.Position is < BlockConstraint.MinimumBlockPosition or > BlockConstraint.MaximumBlockPosition)
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
        
        if (block.OutpostId is not null)
        {
            await SendErrorsAsync(StatusCodes.Status409Conflict, ct);
            return;
        }
        
        var outpost = await _outpostService.GetOutpostAsync(req.OutpostId);
        
        if (outpost is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }

        if (req.IsRoot)
        {
            var root = await _blockService.GetRootBlockInOutpostAsync(req.OutpostId);
        
            if (root is null)
            {
                await SendErrorsAsync(StatusCodes.Status409Conflict, ct);
                return;
            }   
        }
        
        var blockAtPosition = await _blockService.GetBlockAsync(req.Position, req.OutpostId);
        
        if (blockAtPosition is not null)
        {
            await SendErrorsAsync(StatusCodes.Status409Conflict, ct);
            return;
        }
        
        var countOfBlocksInOutpost = await _blockService.GetBlockCountInOutpostAsync(req.OutpostId);
        
        if (countOfBlocksInOutpost is BlockConstraint.AvailableBlocksPerOutpost)
        {
            await SendErrorsAsync(StatusCodes.Status409Conflict, ct);
            return;
        }
        
        var hasAttached = await _blockService.AttachBlockToOutpostAsync(block, req.IsRoot, req.Position, req.OutpostId);
        
        if (!hasAttached)
        {
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
            return;
        }
        
        await SendNoContentAsync(ct);
    }
}