using System.ComponentModel.DataAnnotations.Schema;

namespace Offspace.Services.Outposts.Domain.Entities;

/// <summary>
///     Represents a verven block entity in the database.
/// </summary>
public class Block
{
    /// <summary>
    ///     The id of the block.
    /// </summary>
    public int Id { get; set; }

    /// <summary>
    ///     The type of the block.
    /// </summary>
    public string? Type { get; set; }
    
    /// <summary>
    ///     The position of the block in the outpost grid.
    /// </summary>
    public int? Position { get; set; }
    
    /// <summary>
    ///     The id of the outpost the block belongs to.
    /// </summary>
    public int? OutpostId { get; set; }
    
    /// <summary>
    ///     The outpost the block belongs to.
    /// </summary>
    public Outpost? Outpost { get; set; }
    
    /// <summary>
    ///     The value indicating whether the block is a root.
    /// </summary>
    [NotMapped]
    public bool IsRoot => Type is RootBlockType;
    
    /// <summary>
    ///     The type string corresponding to block which is a root.
    /// </summary>
    [NotMapped]
    public const string RootBlockType = "root";
    
    /// <summary>
    ///     The type string corresponding to block which is not a root.
    /// </summary>
    [NotMapped]
    public const string RegularBlockType = "regular";
}