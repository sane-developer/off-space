namespace Offspace.Services.Outposts.API.Responses.Blocks;

/// <summary>
///     Represents a response indicating that the block is already attached to an outpost.
/// </summary>
public sealed record BlockAlreadyAttachedResponse : Response
{
    /// <summary>
    ///     The singleton instance of the response.
    /// </summary>
    public static readonly BlockAlreadyAttachedResponse Instance = new();
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="BlockAlreadyAttachedResponse"/> class with desired message.
    /// </summary>
    private BlockAlreadyAttachedResponse()
    {
        Message = "The block is already attached to an outpost.";
    }
}