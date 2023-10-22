using System.Text.Json.Serialization;

namespace Offspace.Services.Outposts.API.Requests.Outposts;

/// <summary>
///     Represents a request to create an outpost.
/// </summary>
public record CreateOutpostRequest
{
    /// <summary>
    ///    The name of the outpost.
    /// </summary>
    [FromBody]
    [JsonPropertyName("name")]
    public required string Name { get; init; }
};