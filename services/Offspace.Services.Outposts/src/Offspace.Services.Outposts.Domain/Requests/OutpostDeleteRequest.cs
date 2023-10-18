namespace Offspace.Services.Outposts.Domain.Requests;

/// <summary>
///     Represents the data required to perform a request to delete an outpost.
/// </summary>
/// <param name="OutpostId">The id of the outpost to dispose.</param>
public readonly record struct OutpostDeleteRequest(int OutpostId);