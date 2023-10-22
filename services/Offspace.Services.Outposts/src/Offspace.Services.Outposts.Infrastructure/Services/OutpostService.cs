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
}