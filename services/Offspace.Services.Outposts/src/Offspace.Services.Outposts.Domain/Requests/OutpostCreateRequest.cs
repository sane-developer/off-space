namespace Offspace.Services.Outposts.Domain.Requests;

/// <summary>
///     Represents the data required to perform a request to create an outpost.
/// </summary>
/// <param name="Name">The name of the outpost.</param>
public readonly record struct OutpostCreateRequest(string Name);