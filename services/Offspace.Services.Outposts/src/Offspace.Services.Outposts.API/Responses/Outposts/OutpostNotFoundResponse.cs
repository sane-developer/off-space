namespace Offspace.Services.Outposts.API.Responses.Outposts;

/// <summary>
///     Represents a response indicating that the outpost with specified id does not exist.
/// </summary>
public sealed record OutpostNotFoundResponse : Response
{
    /// <summary>
    ///     The singleton instance of the response.
    /// </summary>
    public static readonly OutpostNotFoundResponse Instance = new();
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="OutpostNotFoundResponse"/> class with desired message.
    /// </summary>
    private OutpostNotFoundResponse()
    {
        Message = "The outpost with specified id does not exist.";
    }
}