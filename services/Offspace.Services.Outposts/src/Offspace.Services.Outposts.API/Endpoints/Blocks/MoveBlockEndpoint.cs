using Offspace.Services.Outposts.API.Requests.Blocks;

namespace Offspace.Services.Outposts.API.Endpoints.Blocks;

/// <summary>
///     Represents an endpoint that enables the user to move the block to a new position within the requested outpost.
/// </summary>
[HttpPatch("/api/blocks/{blockId:int}/move")]
public sealed class MoveBlockEndpoint : Endpoint<MoveBlockRequest>
{
    
}