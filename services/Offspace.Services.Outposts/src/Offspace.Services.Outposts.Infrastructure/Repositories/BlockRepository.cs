using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Offspace.Services.Outposts.Domain.Entities;
using Offspace.Services.Outposts.Infrastructure.Abstractions;
using Offspace.Services.Outposts.Infrastructure.Contexts;

namespace Offspace.Services.Outposts.Infrastructure.Repositories;

/// <summary>
///     Represents a repository that enables the services to interact with the <see cref="Block"/> table in the database.
/// </summary>
public sealed class BlockRepository : IBlockRepository
{
    /// <summary>
    ///     The logging service.
    /// </summary>
    private readonly ILogger _logger;
    
    /// <summary>
    ///     The database context for interacting with the <see cref="Block"/> entity table.
    /// </summary>
    private readonly BlockDatabaseContext _context;
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="BlockRepository"/> class with the specified database context.
    /// </summary>
    public BlockRepository(BlockDatabaseContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
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
    public ValueTask<Block?> GetBlockAsync(int blockId)
    {
        return _context.Blocks.FindAsync(blockId);
    }

    /// <summary>
    ///     Gets the block which satisfies the specified predicate.
    /// </summary>
    /// <param name="predicate">
    ///     The predicate which the requested block entity should satisfy.
    /// </param>
    /// <returns>
    ///     The <see cref="Block"/> entity which satisfies the specified predicate if it exists, otherwise null.
    /// </returns>
    public Task<Block?> GetBlockAsync(Predicate<Block> predicate)
    {
        return _context.Blocks.FirstOrDefaultAsync(block => predicate(block));
    }

    /// <summary>
    ///     Gets the list of blocks which satisfy the specified predicate.
    /// </summary>
    /// <param name="predicate">
    ///     The predicate which the requested block entities should satisfy.
    /// </param>
    /// <returns>
    ///     The list of <see cref="Block"/> entities which satisfy the specified predicate.
    /// </returns>
    public Task<List<Block>> GetBlocksAsync(Predicate<Block> predicate)
    {
        return _context.Blocks.Where(block => predicate(block)).ToListAsync();
    }

    /// <summary>
    ///     Gets the number of blocks which are attached to the outpost with the specified id.
    /// </summary>
    /// <param name="outpostId">
    ///     The id of the outpost which blocks should be counted.
    /// </param>
    /// <returns>
    ///     The number of blocks which are attached to the outpost with the specified id.
    /// </returns>
    public Task<int> GetBlockCountAsync(int outpostId)
    {
        return _context.Blocks.CountAsync(block => block.OutpostId == outpostId);
    }

    /// <summary>
    ///     Updates the type of the specified block.
    /// </summary>
    /// <param name="block">
    ///     The block which type should be updated.
    /// </param>
    /// <param name="isRoot">
    ///     The value indicating whether the block should be a root.
    /// </param>
    /// <remarks>
    ///     This method does not apply changes to the database.
    /// </remarks>
    public void UpdateBlockType(Block block, bool? isRoot)
    {
        if (isRoot.HasValue)
        {
            block.Type = isRoot.Value ? Block.RootBlockType : Block.RegularBlockType;
        }
        else
        {
            block.Type = null;
        }

        _context.Blocks.Update(block);
    }

    /// <summary>
    ///     Updates the outpost of the specified block.
    /// </summary>
    /// <param name="block">
    ///     The block which outpost should be updated.
    /// </param>
    /// <param name="outpostId">
    ///     The id of the outpost which should be set to the block.
    /// </param>
    /// <remarks>
    ///     This method does not apply changes to the database.
    /// </remarks>
    public void UpdateBlockOutpost(Block block, int? outpostId)
    {
        block.OutpostId = outpostId;

        _context.Blocks.Update(block);
    }

    /// <summary>
    ///     Updates the position of the specified block.
    /// </summary>
    /// <param name="block">
    ///     The block which position should be updated.
    /// </param>
    /// <param name="position">
    ///     The position which should be set to the block.
    /// </param>
    /// <remarks>
    ///     This method does not apply changes to the database.
    /// </remarks>
    public void UpdateBlockPosition(Block block, int? position)
    {
        block.Position = position;

        _context.Blocks.Update(block);
    }

    /// <summary>
    ///     Saves all changes made to the database.
    /// </summary>
    /// <returns>
    ///     The value indicating whether the changes were successfully saved.
    /// </returns>
    public async Task<bool> PushChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync() > 0;
        }
        catch (DbUpdateException exception)
        {
            _logger.Log(LogLevel.Critical, exception, "Operation failed due to database error.");
        }
        catch (OperationCanceledException exception)
        {
            _logger.Log(LogLevel.Trace, exception, "Operation was canceled.");
        }
        
        return false;
    }
}