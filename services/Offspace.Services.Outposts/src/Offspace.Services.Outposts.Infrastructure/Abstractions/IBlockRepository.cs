﻿using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Infrastructure.Abstractions;

/// <summary>
///     Represents a set of methods required for interacting with the <see cref="Block"/> entity table.
/// </summary>
public interface IBlockRepository
{
    public ValueTask<Block?> GetBlockAsync(int blockId);
    
    public Task<Block?> GetBlockAsync(Predicate<Block> predicate);
    
    public Task<List<Block>> GetBlocksAsync(Predicate<Block> predicate);
    
    public void UpdateBlockType(Block block, bool? isRoot);
    
    public void UpdateBlockOutpost(Block block, int? outpostId);
    
    public void UpdateBlockPosition(Block block, int? position);
    
    public Task<bool> PushChangesAsync();
}