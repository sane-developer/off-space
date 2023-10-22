namespace Offspace.Services.Outposts.API.Requests.Outposts;

/// <summary>
///     Represents a request to rename an outpost.
/// </summary>
public record RenameOutpostRequest
{
    /// <summary>
    ///     The id of the outpost.
    /// </summary>
    [BindFrom("outpostId")]
    public required int OutpostId { get; init; }

    /// <summary>
    ///     The name of the outpost.
    /// </summary>
    [FromQueryParams]
    [BindFrom("name")]
    public required string NewName { get; init; }
}