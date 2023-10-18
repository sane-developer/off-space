using Microsoft.EntityFrameworkCore;
using Offspace.Services.Outposts.Domain.Abstractions;
using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Domain.Constraints;

/// <summary>
///     Represents a set of constraints for the <see cref="Outpost"/> entity.
/// </summary>
public sealed class OutpostConstraint : IEntityConstraint
{
    private const string TableName = "outpost";
    
    private const string IdColumnName = "id";
    
    private const string NameColumnName = "name";
    
    public static void Apply(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Outpost>()
            .ToTable(TableName);
        
        modelBuilder
            .Entity<Outpost>()
            .Property(outpost => outpost.Id)
            .HasColumnName(IdColumnName)
            .HasColumnType("INTEGER")
            .IsRequired();
        
        modelBuilder
            .Entity<Outpost>()
            .Property(outpost => outpost.Name)
            .HasColumnName(NameColumnName)
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