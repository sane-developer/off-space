using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Infrastructure.Abstractions;

/// <summary>
///     Represents a service which enables the user to manipulate the state of the verven blocks.
/// </summary>
public interface IBlockService
{
    public ValueTask<Block?> GetBlockAsync(int blockId);
    
    public Task<Block?> GetRootBlockInOutpostAsync(int outpostId);
    
    public Task<List<Block>> GetBlocksInOutpostAsync(int outpostId);
    
    public Task<bool> AttachBlockToOutpostAsync(Block block, bool isRoot, int newPosition, int outpostId);
    
    public Task<bool> DetachBlockFromOutpostAsync(Block block);
    
    public Task<bool> MoveBlockWithinOutpostAsync(Block block, int newPosition);
}