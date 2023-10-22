using Microsoft.EntityFrameworkCore;
using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.Domain.Constraints;

/// <summary>
///     Represents a set of constraints for the <see cref="Block"/> entity.
/// </summary>
public static class BlockConstraint
{
    /// <summary>
    ///     The maximum number of blocks that can be attached to all outposts.
    /// </summary>
    public const int AvailableBlocks = 100;
    
    /// <summary>
    ///     The maximum number of blocks that can be attached to a single outpost.
    /// </summary>
    public const int AvailableBlocksPerOutpost = 24;
    
    /// <summary>
    ///     Applies the constraints of the <see cref="Block"/> entity to the specified model builder.
    /// </summary>
    public static void Apply(ModelBuilder modelBuilder)
    {
        const string tableName = "block";
        const string idColumnName = "id";
        const string typeColumnName = "type";
        const string positionColumnName = "position";
        const string outpostIdColumnName = "outpost_id";
        
        modelBuilder
            .Entity<Block>()
            .ToTable(tableName);
        
        modelBuilder
            .Entity<Block>()
            .Property(block => block.Id)
            .HasColumnName(idColumnName)
            .HasColumnType("INTEGER")
            .IsRequired();
        
        modelBuilder
            .Entity<Block>()
            .Property(block => block.Type)
            .HasColumnName(typeColumnName)
            .HasColumnType("TEXT")
            .IsRequired(false);

        modelBuilder
            .Entity<Block>()
            .Property(block => block.Position)
            .HasColumnName(positionColumnName)
            .HasColumnType("INT")
            .IsRequired(false);

        modelBuilder
            .Entity<Block>()
            .Property(block => block.OutpostId)
            .HasColumnName(outpostIdColumnName)
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