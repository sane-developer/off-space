using Microsoft.EntityFrameworkCore;
using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Domain.Constraints;

/// <summary>
///     Represents a set of constraints for the <see cref="Block"/> entity.
/// </summary>
public static class BlockConstraint
{
    private const string TableName = "block";
    
    private const string IdColumnName = "id";
    
    private const string TypeColumnName = "type";
    
    private const string PositionColumnName = "position";
    
    private const string OutpostIdColumnName = "outpost_id";
    
    public static void Apply(ModelBuilder modelBuilder)
    {
        modelBuilder
            .Entity<Block>()
            .ToTable(TableName);
        
        modelBuilder
            .Entity<Block>()
            .Property(block => block.Id)
            .HasColumnName(IdColumnName)
            .HasColumnType("INTEGER")
            .IsRequired();
        
        modelBuilder
            .Entity<Block>()
            .Property(block => block.Type)
            .HasColumnName(TypeColumnName)
            .HasColumnType("TEXT")
            .IsRequired(false);

        modelBuilder
            .Entity<Block>()
            .Property(block => block.Position)
            .HasColumnName(PositionColumnName)
            .HasColumnType("INT")
            .IsRequired(false);

        modelBuilder
            .Entity<Block>()
            .Property(block => block.OutpostId)
            .HasColumnName(OutpostIdColumnName)
            .HasColumnType("INTEGER")
            .IsRequired(false);
        
        modelBuilder
            .Entity<Block>()
            .HasKey(block => block.Id);

        modelBuilder
            .Entity<Block>()
            .HasOne(block => block.Outpost)
            .WithMany(outpost => outpost.Blocks)
            .HasForeignKey(block => block.OutpostId);
    }
}