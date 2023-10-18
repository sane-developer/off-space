namespace Offspace.Services.Outposts.Domain.Requests;

/// <summary>
///     Represents the data required to perform a request to detach a block from an outpost.
/// </summary>
/// <param name="BlockId">The id of the block to be detached.</param>
public readonly record struct BlockDetachRequest(int BlockId);