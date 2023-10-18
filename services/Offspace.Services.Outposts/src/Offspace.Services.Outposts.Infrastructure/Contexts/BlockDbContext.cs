using Microsoft.EntityFrameworkCore;
using Offspace.Services.Outposts.Domain.Constraints;
using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Infrastructure.Contexts;

/// <summary>
///     Represents the database context for interacting with the <see cref="Block"/> entity table.
/// </summary>
public class BlockDbContext : DbContext
{
    /// <summary>
    ///     The container for <see cref="Block"/> entity table entries.
    /// </summary>
    public virtual DbSet<Block> Blocks => default!;

    /// <summary>
    ///     Initializes a new instance of the <see cref="BlockDbContext"/> class with the specified options.
    /// </summary>
    public BlockDbContext(DbContextOptions<BlockDbContext> options) : base(options) { }
    
    /// <summary>
    ///     Applies the <see cref="BlockConstraint"/> to the <see cref="BlockDbContext"/> instance.
    /// </summary>
    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        BlockConstraint.Apply(modelBuilder);
    }
}