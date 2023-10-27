namespace Offspace.Services.Outposts.API.Responses.Outposts;

/// <summary>
///     Represents a response indicating that the outpost has reached the total block capacity.
/// </summary>
public sealed record OutpostReachedCapacityResponse : Response
{
    /// <summary>
    ///     The singleton instance of the response.
    /// </summary>
    public static readonly OutpostReachedCapacityResponse Instance = new();
    
    /// <summary>
    ///     Initializes a new instance of the <see cref="OutpostReachedCapacityResponse"/> class with desired message.
    /// </summary>
    private OutpostReachedCapacityResponse()
    {
        Message = "The outpost has already reached the total block capacity.";
    }
}