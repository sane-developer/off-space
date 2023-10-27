namespace Offspace.Services.Outposts.API.Responses.Outposts;

/// <summary>
///     Represents a response indicating that the outpost was created.
/// </summary>
public sealed record OutpostCreatedResponse
{
    /// <summary>
    ///     The id of the created outpost.
    /// </summary>
    public required int Id { get; init; }
    
    /// <summary>
    ///     The name of the created outpost.
    /// </summary>
    public required string Name { get; init; } = default!;
}