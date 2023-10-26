using Offspace.Services.Outposts.Domain.Entities;
using Offspace.Services.Outposts.Infrastructure.Abstractions;

namespace Offspace.Services.Outposts.Infrastructure.Services;

/// <summary>
///     Represents a contract for a service which enables the user to manipulate the state of the <see cref="Outpost"/> entities.
/// </summary>
public sealed class OutpostService : IOutpostService
{
    /// <summary>
    ///     The repository that enables the services to interact with the <see cref="Outpost"/> table in the database.
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
    ///     Gets the outpost with the specified identifier.
    /// </summary>
    /// <param name="outpostId">
    ///     The identifier of the requested outpost.
    /// </param>
    /// <returns>
    ///     The requested outpost if it exists; otherwise, <see langword="null"/>.
    /// </returns>
    public async ValueTask<Outpost?> GetOutpostAsync(int outpostId)
    {
        return await _repository.GetOutpostAsync(outpostId);
    }

    /// <summary>
    ///     Creates an outpost with the specified name.
    /// </summary>
    /// <param name="outpostName">
    ///     The name of the outpost to be created.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the outpost was created successfully; otherwise, <see langword="false"/>.
    /// </returns>
    public async Task<Outpost?> CreateOutpostAsync(string outpostName)
    {
        var newOutpost = new Outpost
        {
            Name = outpostName
        };
        
        _repository.InsertOutpost(newOutpost);
        
        var hasCreated = await _repository.PushChangesAsync();

        if (!hasCreated)
        {
            return null;
        }
        
        return await _repository.GetOutpostAsync(outpost => outpost.Name == newOutpost.Name);
    }

    /// <summary>
    ///     Determines whether the specified outpost name is taken.
    /// </summary>
    /// <param name="outpostName">
    ///     The name of the outpost to be checked.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the specified outpost name is taken; otherwise, <see langword="false"/>.
    /// </returns>
    public async Task<bool> IsOutpostNameTaken(string outpostName)
    {
        return await _repository.GetOutpostAsync(outpost => outpost.Name == outpostName) is not null;
    }

    /// <summary>
    ///     Deletes the specified outpost.
    /// </summary>
    /// <param name="outpost">
    ///     The outpost to be deleted.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the outpost was deleted successfully; otherwise, <see langword="false"/>.
    /// </returns>
    public async Task<bool> DeleteOutpostAsync(Outpost outpost)
    {
        _repository.DeleteOutpost(outpost);
        
        return await _repository.PushChangesAsync();
    }

    /// <summary>
    ///     Renames the specified outpost.
    /// </summary>
    /// <param name="outpost">
    ///     The outpost to be renamed.
    /// </param>
    /// <param name="newName">
    ///     The new name of the outpost.
    /// </param>
    /// <returns>
    ///     <see langword="true"/> if the outpost was renamed successfully; otherwise, <see langword="false"/>.
    /// </returns>
    public async Task<bool> RenameOutpostAsync(Outpost outpost, string newName)
    {
        _repository.UpdateOutpostName(outpost, newName);
        
        return await _repository.PushChangesAsync();
    }
}