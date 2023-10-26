using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
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
    ///     The logging service.
    /// </summary>
    private readonly ILogger _logger;
    
    /// <summary>
    ///     The database context that enables the repository to interact with the <see cref="Outpost"/> table.
    /// </summary>
    private readonly OutpostDatabaseContext _context;

    /// <summary>
    ///     Initializes a new instance of the <see cref="OutpostRepository"/> class with the specified database context.
    /// </summary>
    public OutpostRepository(OutpostDatabaseContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
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

    /// <summary>
    ///     Gets the outpost that satisfies the specified predicate.
    /// </summary>
    /// <param name="predicate">
    ///     The predicate that the requested outpost should satisfy.
    /// </param>
    /// <returns>
    ///     The requested outpost if it exists; otherwise, <see langword="null"/>.
    /// </returns>
    public Task<Outpost?> GetOutpostAsync(Predicate<Outpost> predicate)
    {
        return _context.Outposts.FirstOrDefaultAsync(outpost => predicate(outpost));
    }

    /// <summary>
    ///     Inserts the specified outpost into the database.
    /// </summary>
    /// <param name="outpost">
    ///     The outpost to be inserted into the database.
    /// </param>
    /// <remarks>
    ///     This method does not apply changes to the database.
    /// </remarks>
    public void InsertOutpost(Outpost outpost)
    {
        _context.Outposts.Add(outpost);
    }

    /// <summary>
    ///     Deletes the specified outpost from the database.
    /// </summary>
    /// <param name="outpost">
    ///     The outpost to be deleted from the database.
    /// </param>
    /// <remarks>
    ///     This method does not apply changes to the database.
    /// </remarks>
    public void DeleteOutpost(Outpost outpost)
    {
        _context.Outposts.Remove(outpost);
    }

    /// <summary>
    ///     Updates the name of the specified outpost.
    /// </summary>
    /// <param name="outpost">
    ///     The outpost whose name should be updated.
    /// </param>
    /// <param name="newName">
    ///     The new name of the outpost.
    /// </param>
    /// <remarks>
    ///     This method does not apply changes to the database.
    /// </remarks>
    public void UpdateOutpostName(Outpost outpost, string newName)
    {
        outpost.Name = newName;
        
        _context.Outposts.Update(outpost);
    }

    /// <summary>
    ///     Saves all changes made to the database.
    /// </summary>
    /// <returns>
    ///     The value indicating whether the changes were successfully saved.
    /// </returns>
    public async Task<bool> PushChangesAsync()
    {
        try
        {
            return await _context.SaveChangesAsync() > 0;
        }
        catch (DbUpdateException exception)
        {
            _logger.Log(LogLevel.Critical, exception, "Operation failed due to database error.");
        }
        catch (OperationCanceledException exception)
        {
            _logger.Log(LogLevel.Trace, exception, "Operation was canceled.");
        }
        
        return false;
    }
}