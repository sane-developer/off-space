namespace Offspace.Services.Outposts.API.Requests.Blocks;

/// <summary>
///     Represents a request to detach a block from an outpost.
/// </summary>
public record DetachBlockRequest
{
    /// <summary>
    ///     The id of the block to detach.
    /// </summary>
    [BindFrom("blockId")]
    public required int BlockId { get; init; }
}