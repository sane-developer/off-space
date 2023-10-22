﻿using Offspace.Services.Outposts.API.Requests.Outposts;
using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.API.Endpoints.Outposts;

/// <summary>
///     Represents an endpoint that enables the user to create an outpost.
/// </summary>
[HttpPost("/api/outposts")]
public sealed class CreateOutpostEndpoint : Endpoint<CreateOutpostRequest, Outpost>
{
    
}