using Offspace.Services.Outposts.API.Requests.Outposts;
using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.API.Endpoints.Outposts;

/// <summary>
///     Represents an endpoint that enables the user to get details of requested outpost.
/// </summary>
[HttpGet("/api/outposts/{outpostId:int}")]
public sealed class GetOutpostEndpoint : Endpoint<GetOutpostRequest, Outpost>
{
    
}