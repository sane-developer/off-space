using Offspace.Services.Outposts.API.Requests.Blocks;
using Offspace.Services.Outposts.Infrastructure.Services;

namespace Offspace.Services.Outposts.API.Endpoints.Blocks;

/// <summary>
///     Represents an endpoint that enables the user to detach a block from the requested outpost.
/// </summary>
[HttpPatch("/api/blocks/{blockId:int}/detach")]
public sealed class DetachBlockEndpoint : Endpoint<DetachBlockRequest>
{
    /// <summary>
    ///     The service which enables the user to manipulate the state of the verven blocks.
    /// </summary>
    private readonly BlockService _blockService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="DetachBlockEndpoint"/> class with the specified services.
    /// </summary>
    public DetachBlockEndpoint(BlockService blockService)
    {
        _blockService = blockService;
    }

    /// <summary>
    ///     Validates whether the block with the requested specification can be detached from the outpost.
    /// </summary>
    public override async Task HandleAsync(DetachBlockRequest req, CancellationToken ct)
    {
        var block = await _blockService.GetBlockAsync(req.BlockId);
        
        if (block is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        if (block.OutpostId is null)
        {
            await SendErrorsAsync(StatusCodes.Status400BadRequest, ct);
            return;
        }
        
        var hasDetached = await _blockService.DetachBlockFromOutpostAsync(block);
        
        if (!hasDetached)
        {
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
            return;
        }
        
        await SendNoContentAsync(ct);
    }
}