using Offspace.Services.Outposts.API.Requests.Blocks;

namespace Offspace.Services.Outposts.API.Endpoints.Blocks;

/// <summary>
///     Represents an endpoint that enables the user to detach a block from the requested outpost.
/// </summary>
[HttpPatch("/api/blocks/{blockId:int}/detach")]
public sealed class DetachBlockEndpoint : Endpoint<DetachBlockRequest>
{
    
}