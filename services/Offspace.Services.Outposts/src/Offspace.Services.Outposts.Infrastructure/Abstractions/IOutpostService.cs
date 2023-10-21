using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Infrastructure.Abstractions;

/// <summary>
///     Represents a set of methods required for interacting with the <see cref="Outpost"/> entity table.
/// </summary>
public interface IOutpostService
{
    public ValueTask<Outpost?> GetOutpostAsync(int outpostId);
    
    public Task<List<Outpost>> GetOutpostsAsync();
        
    public Task<bool> CreateOutpostAsync(Outpost outpost);
    
    public Task<bool> UpdateOutpostNameAsync(Outpost outpost, string newName);
    
    public Task<bool> DeleteOutpostAsync(Outpost outpost);
}