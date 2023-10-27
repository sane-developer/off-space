namespace Offspace.Services.Outposts.API.Requests.Outposts;

/// <summary>
///     Represents a request to rename an outpost.
/// </summary>
public sealed record RenameOutpostRequest
{
    /// <summary>
    ///     The id of the outpost to be renamed.
    /// </summary>
    [FromQueryParams]
    [BindFrom("outpostId")]
    public required int OutpostId { get; init; }

    /// <summary>
    ///     The new name of the outpost.
    /// </summary>
    [FromQueryParams]
    [BindFrom("newName")]
    public required string NewName { get; init; } = default!;
}