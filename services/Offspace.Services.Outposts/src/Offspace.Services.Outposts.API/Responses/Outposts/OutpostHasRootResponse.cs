namespace Offspace.Services.Outposts.API.Responses.Outposts;

/// <summary>
///     Represents a response indicating that the outpost already has a root block attached.
/// </summary>
public sealed record OutpostHasRootResponse : Response
{
    /// <summary>
    ///     The singleton instance of the response.
    /// </summary>
    public static readonly OutpostHasRootResponse Instance = new();
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="OutpostHasRootResponse"/> class with desired message.
    /// </summary>
    private OutpostHasRootResponse()
    {
        Message = "The outpost already has a root block attached.";
    }
}