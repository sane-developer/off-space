namespace Offspace.Services.Outposts.API.Responses.Outposts;

/// <summary>
///     Represents a response indicating that the outpost still has at least one block attached.
/// </summary>
public sealed record OutpostNotEmptyResponse : Response
{
    /// <summary>
    ///     The singleton instance of the response.
    /// </summary>
    public static readonly OutpostNotEmptyResponse Instance = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="OutpostNotEmptyResponse"/> class with desired message.
    /// </summary>
    private OutpostNotEmptyResponse()
    {
        Message = "The outpost still has at least one block attached.";
    }
}