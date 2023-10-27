namespace Offspace.Services.Outposts.API.Responses.Outposts;

/// <summary>
///     Represents a response to a request to create an outpost.
/// </summary>
public sealed record CreateOutpostResponse
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