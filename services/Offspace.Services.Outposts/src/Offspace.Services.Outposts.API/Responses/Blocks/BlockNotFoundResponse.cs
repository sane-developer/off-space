namespace Offspace.Services.Outposts.API.Responses.Blocks;

/// <summary>
///     Represents a response indicating that the block with specified id does not exist.
/// </summary>
public sealed record BlockNotFoundResponse : Response
{
    /// <summary>
    ///     The singleton instance of the response.
    /// </summary>
    public static readonly BlockNotFoundResponse Instance = new();
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="BlockNotFoundResponse"/> class with desired message.
    /// </summary>
    private BlockNotFoundResponse()
    {
        Message = "The block with specified id does not exist.";
    }
}