using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Infrastructure.Abstractions;

/// <summary>
///     Represents a set of methods required for interacting with the <see cref="Outpost"/> entity table.
/// </summary>
public interface IOutpostRepository
{
    public ValueTask<Outpost?> GetOutpostAsync(int outpostId);
    
    public Task<List<Outpost>> GetOutpostsAsync();
    
    public void CreateOutpostAsync(Outpost outpost);
    
    public void UpdateOutpostNameAsync(Outpost outpost, string newName);
    
    public void DeleteOutpostAsync(Outpost outpost);
    
    public Task<bool> PushChangesAsync();
}