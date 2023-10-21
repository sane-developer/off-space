using Microsoft.EntityFrameworkCore;
using Offspace.Services.Outposts.Domain.Constraints;
using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Infrastructure.Contexts;

/// <summary>
///     Represents the database context for interacting with the <see cref="Outpost"/> entity table.
/// </summary>
public class OutpostDatabaseContext : DbContext
{
    /// <summary>
    ///     The container for <see cref="Outpost"/> entity table entries.
    /// </summary>
    public virtual DbSet<Outpost> Outposts => default!;
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="OutpostDatabaseContext"/> class with the specified options.
    /// </summary>
    public OutpostDatabaseContext(DbContextOptions<OutpostDatabaseContext> options) : base(options) { }

    /// <summary>
    ///     Applies the <see cref="OutpostConstraint"/> to the <see cref="OutpostDatabaseContext"/> instance.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        OutpostConstraint.Apply(modelBuilder);
    }
}