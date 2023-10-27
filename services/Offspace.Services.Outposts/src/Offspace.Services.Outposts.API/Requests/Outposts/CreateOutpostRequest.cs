namespace Offspace.Services.Outposts.API.Requests.Outposts;

/// <summary>
///     Represents a request to create an outpost.
/// </summary>
public sealed record CreateOutpostRequest
{
    /// <summary>
    ///     The name of the outpost.
    /// </summary>
    [FromQueryParams]
    [BindFrom("name")]
    public required string Name { get; init; } = default!;
}