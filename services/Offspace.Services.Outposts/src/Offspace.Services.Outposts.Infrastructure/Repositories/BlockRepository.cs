using Offspace.Services.Outposts.Domain.Entities;
using Offspace.Services.Outposts.Infrastructure.Abstractions;
using Offspace.Services.Outposts.Infrastructure.Contexts;

namespace Offspace.Services.Outposts.Infrastructure.Repositories;

/// <summary>
///     Represents a repository responsible for interacting with the <see cref="Block"/> entity table.
/// </summary>
public sealed class BlockRepository : IBlockRepository
{
    /// <summary>
    ///     The database context for interacting with the <see cref="Block"/> entity table.
    /// </summary>
    private readonly BlockDbContext _context;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BlockRepository"/> class with the specified database context.
    /// </summary>
    public BlockRepository(BlockDbContext context)
    {
        _context = context;
    }

    public async ValueTask<Block?> GetBlockAsync(int blockId)
    {
        return await _context.Blocks.FindAsync(blockId);
    }
    
    public async Task<bool> UpdateBlockOutpostAsync(Block block, int? newOutpostId)
    {
        block.OutpostId = newOutpostId;
        
        _context.Blocks.Update(block);

        await _context.SaveChangesAsync();

        return true;
    }
    
    public async Task<bool> UpdateBlockPositionAsync(Block block, int newPosition)
    {
        block.Position = newPosition;
        
        _context.Blocks.Update(block);

        await _context.SaveChangesAsync();

        return true;
    }
}