using Offspace.Services.Outposts.API.Requests.Outposts;

namespace Offspace.Services.Outposts.API.Endpoints.Outposts;

/// <summary>
///     Represents an endpoint that enables the user to delete an outpost.
/// </summary>
[HttpDelete("/api/outposts/{outpostId:int}")]
public sealed class DeleteOutpostEndpoint : Endpoint<DeleteOutpostRequest>
{
    
}