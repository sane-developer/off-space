namespace Offspace.Services.Outposts.Domain.Entities;

/// <summary>
///     Represents an outpost entity in the database.
/// </summary>
public class Outpost
{
    /// <summary>
    ///     The id of the outpost.
    /// </summary>
    public int Id { get; set; }
    
    /// <summary>
    ///     The name of the outpost.
    /// </summary>
    public string Name { get; set; } = default!;
    
    /// <summary>
    ///     The verven blocks which form the outpost.
    /// </summary>
    public ICollection<Block> Blocks { get; set; } = default!;
}