using Offspace.Services.Outposts.Domain.Entities;
using Offspace.Services.Outposts.Infrastructure.Abstractions;

namespace Offspace.Services.Outposts.Infrastructure.Services;

/// <summary>
///     Represents a service responsible for allowing easier interacting with <see cref="Outpost"/> entity table.
/// </summary>
public sealed class OutpostService
{
    /// <summary>
    ///     The repository responsible for interacting with the <see cref="Outpost"/> entity table.
    /// </summary>
    private readonly IOutpostRepository _repository;

    /// <summary>
    ///     Initializes a new instance of the <see cref="OutpostService"/> class with the specified repository.
    /// </summary>
    public OutpostService(IOutpostRepository repository)
    {
        _repository = repository;
    }
    
    /// <summary>
    ///     Gets the outpost with the specified id.
    /// </summary>
    /// <param name="outpostId">
    ///     The id of requested outpost entity.
    /// </param>
    /// <returns>
    ///     The <see cref="Outpost"/> entity with the specified id if it exists, otherwise null.
    /// </returns>
    public async ValueTask<Outpost?> GetOutpostAsync(int outpostId)
    {
        return await _repository.GetOutpostAsync(outpostId);
    }
    
    /// <summary>
    ///     Gets the list of existing outposts.
    /// </summary>
    /// <returns>
    ///     The list of existing <see cref="Outpost"/> entities.
    /// </returns>
    public async Task<List<Outpost>> GetOutpostsAsync()
    {
        return await _repository.GetOutpostsAsync();
    }
    
    /// <summary>
    ///     Creates the specified outpost.
    /// </summary>
    /// <param name="outpost">
    ///     The outpost which should be created.
    /// </param>
    /// <returns>
    ///     True if the outpost was successfully created, otherwise false.
    /// </returns>
    public async Task<bool> CreateOutpostAsync(Outpost outpost)
    {
        _repository.CreateOutpostAsync(outpost);
        
        return await _repository.PushChangesAsync();
    }
    
    /// <summary>
    ///     Updates the name of the specified outpost.
    /// </summary>
    /// <param name="outpost">
    ///     The outpost which name should be updated.
    /// </param>
    /// <param name="newName">
    ///     The new name of the outpost.
    /// </param>
    /// <returns>
    ///     True if the outpost was successfully updated, otherwise false.
    /// </returns>
    public async Task<bool> UpdateOutpostNameAsync(Outpost outpost, string newName)
    {
        _repository.UpdateOutpostNameAsync(outpost, newName);
        
        return await _repository.PushChangesAsync();
    }
    
    /// <summary>
    ///     Deletes the specified outpost.
    /// </summary>
    /// <param name="outpost">
    ///     The outpost which should be deleted.
    /// </param>
    /// <returns>
    ///     True if the outpost was successfully deleted, otherwise false.
    /// </returns>
    public async Task<bool> DeleteOutpostAsync(Outpost outpost)
    {
        _repository.DeleteOutpostAsync(outpost);
        
        return await _repository.PushChangesAsync();
    }
}