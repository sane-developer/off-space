namespace Offspace.Services.Outposts.Domain.Requests;

/// <summary>
///     Represents the data required to perform a request to attach a block to an outpost.
/// </summary>
/// <param name="BlockId">The id of the block to be attached.</param>
/// <param name="Position">The location of the block within the outpost.</param>
/// <param name="OutpostId">The id of the outpost that the block will be attached to.</param>
public readonly record struct BlockAttachRequest(int BlockId, int Position, int OutpostId);