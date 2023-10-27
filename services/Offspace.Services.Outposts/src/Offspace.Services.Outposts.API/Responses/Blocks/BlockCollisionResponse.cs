namespace Offspace.Services.Outposts.API.Responses.Blocks;

/// <summary>
///     Represents a response that indicates that the position is already occupied by another block in the outpost.
/// </summary>
public sealed record BlockCollisionResponse : Response
{
    /// <summary>
    ///     The singleton instance of the response.
    /// </summary>
    public static readonly BlockCollisionResponse Instance = new();
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="BlockCollisionResponse"/> class with desired message.
    /// </summary>
    private BlockCollisionResponse()
    {
        Message = "The position is already occupied by another block in the outpost.";
    }
}