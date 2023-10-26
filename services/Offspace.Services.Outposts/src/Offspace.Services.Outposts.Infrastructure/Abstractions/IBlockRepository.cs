using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Infrastructure.Abstractions;

/// <summary>
///     Represents a contract for a repository that enables the services to interact with the <see cref="Block"/> table in the database.
/// </summary>
public interface IBlockRepository
{
    public ValueTask<Block?> GetBlockAsync(int blockId);
    
    public Task<Block?> GetBlockAsync(Predicate<Block> predicate);
    
    public Task<List<Block>> GetBlocksAsync(Predicate<Block> predicate);
    
    public Task<int> GetBlockCountAsync(int outpostId);
    
    public void UpdateBlockType(Block block, bool? isRoot);
    
    public void UpdateBlockOutpost(Block block, int? outpostId);
    
    public void UpdateBlockPosition(Block block, int? position);
    
    public Task<bool> PushChangesAsync();
}