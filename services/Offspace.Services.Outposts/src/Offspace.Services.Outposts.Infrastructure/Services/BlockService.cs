using Offspace.Services.Outposts.Domain.Entities;
using Offspace.Services.Outposts.Infrastructure.Abstractions;

namespace Offspace.Services.Outposts.Infrastructure.Services;

/// <summary>
///     Represents a service responsible for allowing easier interacting with <see cref="Block"/> entity table.
/// </summary>
public sealed class BlockService : IBlockService
{
    /// <summary>
    ///     The repository responsible for interacting with the <see cref="Block"/> entity table.
    /// </summary>
    private readonly IBlockRepository _repository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BlockService"/> class with the specified repository.
    /// </summary>
    public BlockService(IBlockRepository repository)
    {
        _repository = repository;
    }

    /// <summary>
    ///     Gets the block with the specified id.
    /// </summary>
    /// <param name="blockId">
    ///     The id of requested block entity.
    /// </param>
    /// <returns>
    ///     The <see cref="Block"/> entity with the specified id if it exists, otherwise null.
    /// </returns>
    public async ValueTask<Block?> GetBlockAsync(int blockId)
    {
        return await _repository.GetBlockAsync(blockId);
    }

    /// <summary>
    ///     Gets the root block of the outpost with the specified id.
    /// </summary>
    /// <param name="outpostId">
    ///     The id of the outpost which root block should be returned.
    /// </param>
    /// <returns>
    ///     The root <see cref="Block"/> entity of the outpost with the specified id if it exists, otherwise null.
    /// </returns>
    public async Task<Block?> GetRootBlockInOutpostAsync(int outpostId)
    {
        return await _repository.GetBlockAsync(block => block.OutpostId == outpostId && block.IsRoot);
    }

    /// <summary>
    ///     Gets the list of blocks which are attached to the outpost with the specified id.
    /// </summary>
    /// <param name="outpostId">
    ///     The id of the outpost which blocks should be returned.
    /// </param>
    /// <returns>
    ///     The list of <see cref="Block"/> entities which are attached to the outpost with the specified id.
    /// </returns>
    public async Task<List<Block>> GetBlocksInOutpostAsync(int outpostId)
    {
        return await _repository.GetBlocksAsync(block => block.OutpostId == outpostId);
    }

    /// <summary>
    ///     Attaches the specified block to the outpost with the specified id.
    /// </summary>
    /// <param name="block">
    ///     The block to attach to the outpost.
    /// </param>
    /// <param name="isRoot">
    ///     The value indicating whether the block is a root.
    /// </param>
    /// <param name="newPosition">
    ///     The position to attach the block to.
    /// </param>
    /// <param name="outpostId">
    ///     The id of the outpost to attach the block to.
    /// </param>
    /// <returns>
    ///     The value indicating whether the block was successfully attached to the outpost.
    /// </returns>
    public async Task<bool> AttachBlockToOutpostAsync(Block block, bool isRoot, int newPosition, int outpostId)
    {
        _repository.UpdateBlockType(block, isRoot);
        _repository.UpdateBlockOutpost(block, outpostId);
        _repository.UpdateBlockPosition(block, newPosition);
        
        return await _repository.PushChangesAsync();
    }

    /// <summary>
    ///     Detaches the specified block from the outpost it belongs to.
    /// </summary>
    /// <param name="block">
    ///     The block to detach from the outpost.
    /// </param>
    /// <returns>
    ///     The value indicating whether the block was successfully detached from the outpost.
    /// </returns>
    public async Task<bool> DetachBlockFromOutpostAsync(Block block)
    {
        _repository.UpdateBlockType(block, isRoot: null);
        _repository.UpdateBlockOutpost(block, outpostId: null);
        _repository.UpdateBlockPosition(block, position: null);
        
        return await _repository.PushChangesAsync();
    }

    /// <summary>
    ///     Moves the specified block to the specified position in the outpost it belongs to.
    /// </summary>
    /// <param name="block">
    ///     The block to move.
    /// </param>
    /// <param name="newPosition">
    ///     The position to move the block to.
    /// </param>
    /// <returns>
    ///     The value indicating whether the block was successfully moved to the specified position.
    /// </returns>
    public async Task<bool> MoveBlockWithinOutpostAsync(Block block, int newPosition)
    {
        _repository.UpdateBlockPosition(block, position: newPosition);
        
        return await _repository.PushChangesAsync();
    }
}