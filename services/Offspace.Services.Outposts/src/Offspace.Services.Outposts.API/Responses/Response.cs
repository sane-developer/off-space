namespace Offspace.Services.Outposts.API.Responses;

/// <summary>
///     Represents a basic response to a request.
/// </summary>
public record Response
{
    /// <summary>
    ///     The message of the response.
    /// </summary>
    public string Message { get; init; } = string.Empty;
}