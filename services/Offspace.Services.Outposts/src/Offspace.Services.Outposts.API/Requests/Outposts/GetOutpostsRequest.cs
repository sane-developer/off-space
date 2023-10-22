using System.Text.Json.Serialization;

namespace Offspace.Services.Outposts.API.Requests.Outposts;

/// <summary>
///     Represents a request to get the outposts.
/// </summary>
public record GetOutpostsRequest
{
    /// <summary>
    ///     The ids of the outposts.
    /// </summary>
    [FromBody]
    [JsonPropertyName("outpostIds")]
    public required IEnumerable<int> OutpostIds { get; init; }
}