using Microsoft.EntityFrameworkCore;
using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Domain.Constraints;

/// <summary>
///     Represents a set of constraints for the <see cref="Outpost"/> entity.
/// </summary>
public static class OutpostConstraint
{
    /// <summary>
    ///     Applies the constraints of the <see cref="Outpost"/> entity to the specified model builder.
    /// </summary>
    public static void Apply(ModelBuilder modelBuilder)
    {
        const string tableName = "outpost";
        const string idColumnName = "id";
        const string nameColumnName = "name";
        
        modelBuilder
            .Entity<Outpost>()
            .ToTable(tableName);
        
        modelBuilder
            .Entity<Outpost>()
            .Property(outpost => outpost.Id)
            .HasColumnName(idColumnName)
            .HasColumnType("INTEGER")
            .IsRequired();
        
        modelBuilder
            .Entity<Outpost>()
            .Property(outpost => outpost.Name)
            .HasColumnName(nameColumnName)
            .HasColumnType("TEXT")
            .IsRequired();
        
        modelBuilder
            .Entity<Outpost>()
            .HasKey(outpost => outpost.Id);
        
        modelBuilder
            .Entity<Outpost>()
            .HasMany(outpost => outpost.Blocks)
            .WithOne(block => block.Outpost)
            .HasForeignKey(block => block.OutpostId)
            .IsRequired(false);
        
        modelBuilder
            .Entity<Outpost>()
            .HasIndex(outpost => outpost.Name)
            .IsUnique();
    }
}