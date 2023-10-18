namespace Offspace.Services.Outposts.Domain.Requests;

/// <summary>
///     Represents the data required to perform a request to update the position of a block.
/// </summary>
/// <param name="BlockId">The id of the block to be moved.</param>
/// <param name="NewPosition">The position for the block to be moved onto.</param>
public readonly record struct BlockPositionUpdateRequest(int BlockId, int NewPosition);