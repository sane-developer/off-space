namespace Offspace.Services.Outposts.API.Requests.Outposts;

/// <summary>
///     Represents a request to get an outpost.
/// </summary>
public record GetOutpostRequest
{
    /// <summary>
    ///     The id of the outpost.
    /// </summary>
    [BindFrom("outpostId")]
    public required int OutpostId { get; init; }
}