namespace Offspace.Services.Outposts.API.Responses.Blocks;

/// <summary>
///     Represents a response indicating that the block position is out of grid.
/// </summary>
public sealed record BlockOutOfGridResponse : Response
{
    /// <summary>
    ///     The singleton instance of the response.
    /// </summary>
    public static readonly BlockOutOfGridResponse Instance = new();
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="BlockOutOfGridResponse"/> class with desired message.
    /// </summary>
    private BlockOutOfGridResponse()
    {
        Message = "The block position is out of grid.";
    }
}