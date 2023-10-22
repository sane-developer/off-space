using Offspace.Services.Outposts.API.Requests.Outposts;

namespace Offspace.Services.Outposts.API.Endpoints.Outposts;

/// <summary>
///     Represents an endpoint that enables the user to update the name of an outpost.
/// </summary>
[HttpPatch("/api/outposts/{outpostId:int}/rename")]
public sealed class RenameOutpostEndpoint : Endpoint<RenameOutpostRequest>
{
    
}