using Offspace.Services.Outposts.API.Requests.Blocks;

namespace Offspace.Services.Outposts.API.Endpoints.Blocks;

/// <summary>
///     Represents an endpoint that enables the user to attach a block to the requested outpost.
/// </summary>
[HttpPatch("/api/blocks/{blockId:int}/attach")]
public sealed class AttachBlockEndpoint : Endpoint<AttachBlockRequest>
{
    
}