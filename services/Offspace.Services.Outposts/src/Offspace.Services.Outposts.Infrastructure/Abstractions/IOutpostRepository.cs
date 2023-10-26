using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Infrastructure.Abstractions;

/// <summary>
///     Represents a contract for a repository that enables the services to interact with the <see cref="Outpost"/> table in the database.
/// </summary>
public interface IOutpostRepository
{
    public ValueTask<Outpost?> GetOutpostAsync(int outpostId);
    
    public Task<Outpost?> GetOutpostAsync(Predicate<Outpost> predicate);
    
    public void InsertOutpost(Outpost outpost);
    
    public Task<bool> PushChangesAsync();
}