namespace Offspace.Services.Outposts.API.Responses.Outposts;

/// <summary>
///     Represents a response indicating that the outpost name is already taken.
/// </summary>
public sealed record OutpostNameTakenResponse : Response
{
    /// <summary>
    ///     The singleton instance of the response.
    /// </summary>
    public static readonly OutpostNameTakenResponse Instance = new();

    /// <summary>
    ///     Initializes a new instance of the <see cref="OutpostNameTakenResponse"/> class with desired message.
    /// </summary>
    private OutpostNameTakenResponse()
    {
        Message = "The outpost name is already taken.";
    }
}