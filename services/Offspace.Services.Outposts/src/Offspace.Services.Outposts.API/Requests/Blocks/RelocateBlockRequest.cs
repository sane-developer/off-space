namespace Offspace.Services.Outposts.API.Requests.Blocks;

/// <summary>
///     Represents a request to move a block to a new position.
/// </summary>
public record RelocateBlockRequest
{
    /// <summary>
    ///     The id of the block to move.
    /// </summary>
    [BindFrom("blockId")]
    public required int BlockId { get; init; }
    
    /// <summary>
    ///     The new position of the block.
    /// </summary>
    [FromQueryParams]
    [BindFrom("newPosition")]
    public required int NewPosition { get; init; }
}