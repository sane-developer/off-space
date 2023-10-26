using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Infrastructure.Abstractions;

/// <summary>
///     Represents a contract for a service which enables the user to manipulate the state of the outposts.
/// </summary>
public interface IOutpostService
{
    public ValueTask<Outpost?> GetOutpostAsync(int outpostId);
    
    public Task<Outpost?> CreateOutpostAsync(string outpostName);

    public Task<bool> IsOutpostNameTaken(string outpostName);
    
    public Task<bool> DeleteOutpostAsync(Outpost outpost);
}