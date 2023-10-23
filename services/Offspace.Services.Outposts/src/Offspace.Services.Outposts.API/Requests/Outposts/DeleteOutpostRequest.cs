﻿namespace Offspace.Services.Outposts.API.Requests.Outposts;

/// <summary>
///     Represents a request to delete an outpost.
/// </summary>
public record DeleteOutpostRequest
{
    /// <summary>
    ///     The id of the outpost to be deleted.
    /// </summary>
    [FromQueryParams]
    [BindFrom("outpostId")]
    public required int OutpostId { get; init; }
}