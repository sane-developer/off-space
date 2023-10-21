using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Offspace.Services.Outposts.Domain.Entities;
using Offspace.Services.Outposts.Infrastructure.Abstractions;
using Offspace.Services.Outposts.Infrastructure.Contexts;

namespace Offspace.Services.Outposts.Infrastructure.Repositories;

/// <summary>
///     Represents a repository responsible for interacting with the <see cref="Block"/> entity table.
/// </summary>
public sealed class OutpostRepository : IOutpostRepository
{
    /// <summary>
    ///     The logging service.
    /// </summary>
    private readonly ILogger _logger;
    
    /// <summary>
    ///     The database context for interacting with the <see cref="Block"/> entity table.
    /// </summary>
    private readonly OutpostDatabaseContext _context;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BlockRepository"/> class with the specified database context.
    /// </summary>
    public OutpostRepository(OutpostDatabaseContext context, ILogger logger)
    {
        _context = context;
        _logger = logger;
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
    public ValueTask<Outpost?> GetOutpostAsync(int outpostId)
    {
        return _context.Outposts.FindAsync(outpostId);
    }

    /// <summary>
    ///     Gets the existing outposts.
    /// </summary>
    /// <returns>
    ///     The list of existing <see cref="Outpost"/> entities.
    /// </returns>
    public Task<List<Outpost>> GetOutpostsAsync()
    {
        return _context.Outposts.ToListAsync();
    }

    /// <summary>
    ///     Creates the specified outpost.
    /// </summary>
    /// <param name="outpost">
    ///     The outpost which should be created.
    /// </param>
    /// <remarks>
    ///     The creation will only be applied when <see cref="PushChangesAsync"/> is called.
    /// </remarks>
    public void CreateOutpostAsync(Outpost outpost)
    {
        _context.Outposts.Add(outpost);
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
    public void UpdateOutpostNameAsync(Outpost outpost, string newName)
    {
        outpost.Name = newName;
        
        _context.Outposts.Update(outpost);
    }

    /// <summary>
    ///     Deletes the specified outpost.
    /// </summary>
    /// <param name="outpost">
    ///     The outpost which should be deleted.
    /// </param>
    /// <remarks>
    ///     The deletion will only be applied when <see cref="PushChangesAsync"/> is called.
    /// </remarks>
    public void DeleteOutpostAsync(Outpost outpost)
    {
        _context.Remove(outpost);
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