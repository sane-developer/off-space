using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Infrastructure.Abstractions;

/// <summary>
///     Represents a set of methods required for interacting with the <see cref="Block"/> entity table.
/// </summary>
public interface IBlockRepository
{
    /// <summary>
    ///     Gets a <see cref="Block"/> entity by its id.
    /// </summary>
    /// <param name="blockId">The id of the requested block entity.</param>
    /// <returns><i>The requested block entity</i> if it has been found in the database; else <i>null</i>.</returns>
    ValueTask<Block?> GetBlockAsync(int blockId);
    
    /// <summary>
    ///     Updates the <see cref="Block.OutpostId"/> property of a <see cref="Block"/> entity.
    /// </summary>
    /// <param name="block">The block entity to be updated.</param>
    /// <param name="newOutpostId">The id of the outpost the block will be moved to.</param>
    /// <returns>
    ///     TODO: Fill this once decided how to handle the return value.
    /// </returns>
    Task<bool> UpdateBlockOutpostAsync(Block block, int? newOutpostId);
    
    /// <summary>
    ///     Updates the <see cref="Block.Position"/> property of a <see cref="Block"/> entity.
    /// </summary>
    /// <param name="block">The block entity to be updated.</param>
    /// <param name="newPosition">The new position of the block within the outpost.</param>
    /// <returns>
    ///     TODO: Fill this once decided how to handle the return value.
    /// </returns>
    Task<bool> UpdateBlockPositionAsync(Block block, int newPosition);
}