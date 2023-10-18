namespace Offspace.Services.Outposts.Domain.Requests;

/// <summary>
///     Represents the data required to perform a request to update an outpost.
/// </summary>
/// <param name="OutpostId">The id of the outpost.</param>
/// <param name="Name">The new name of the outpost.</param>
public readonly record struct OutpostNameUpdateRequest(int OutpostId, string Name);