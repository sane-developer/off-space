namespace Offspace.Services.Outposts.Domain.Responses;

/// <summary>
///     Represents the data returned from a request to create an outpost.
/// </summary>
/// <param name="OutpostId">The id of the newly created outpost.</param>
/// <param name="Name">The name of the newly created outpost.</param>
public readonly record struct OutpostCreateResponse(int OutpostId, string Name);