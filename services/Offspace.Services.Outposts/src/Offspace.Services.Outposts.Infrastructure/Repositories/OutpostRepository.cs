using Offspace.Services.Outposts.Domain.Entities;
using Offspace.Services.Outposts.Infrastructure.Abstractions;
using Offspace.Services.Outposts.Infrastructure.Contexts;

namespace Offspace.Services.Outposts.Infrastructure.Repositories;

/// <summary>
///     Represents a repository that enables the services to interact with the <see cref="Outpost"/> table in the database.
/// </summary>
public sealed class OutpostRepository : IOutpostRepository
{
    /// <summary>
    ///     The database context that enables the repository to interact with the <see cref="Outpost"/> table.
    /// </summary>
    private readonly OutpostDatabaseContext _context;

    /// <summary>
    ///     Initializes a new instance of the <see cref="OutpostRepository"/> class with the specified database context.
    /// </summary>
    public OutpostRepository(OutpostDatabaseContext context)
    {
        _context = context;
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
    public ValueTask<Outpost?> GetOutpostAsync(int outpostId)
    {
        return _context.Outposts.FindAsync(outpostId);
    }
}