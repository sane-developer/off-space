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
}