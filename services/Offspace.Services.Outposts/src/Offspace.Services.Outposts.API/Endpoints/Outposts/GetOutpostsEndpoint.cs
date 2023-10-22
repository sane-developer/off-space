using Offspace.Services.Outposts.API.Requests.Outposts;
using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.API.Endpoints.Outposts;

/// <summary>
///     Represents an endpoint that enables the user to get the existing outposts.
/// </summary>
[HttpGet("/api/outposts")]
public sealed class GetOutpostsEndpoint : Endpoint<GetOutpostsRequest, IEnumerable<Outpost>>
{
    
}