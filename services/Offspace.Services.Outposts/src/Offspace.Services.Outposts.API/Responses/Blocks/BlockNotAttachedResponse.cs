namespace Offspace.Services.Outposts.API.Responses.Blocks;

/// <summary>
///     Represents a response which indicates that the block is not attached to any outpost.
/// </summary>
public sealed record BlockNotAttachedResponse : Response
{
    /// <summary>
    ///     The singleton instance of the response.
    /// </summary>
    public static readonly BlockNotAttachedResponse Instance = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="BlockNotAttachedResponse"/> class with desired message.
    /// </summary>
    private BlockNotAttachedResponse()
    {
        Message = "The block is not attached to any outpost.";
    }
}