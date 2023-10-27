using Offspace.Services.Outposts.API.Extensions;
using Offspace.Services.Outposts.API.Requests.Outposts;
using Offspace.Services.Outposts.API.Responses;
using Offspace.Services.Outposts.API.Responses.Outposts;
using Offspace.Services.Outposts.Infrastructure.Abstractions;

namespace Offspace.Services.Outposts.API.Endpoints.Outposts;

/// <summary>
///     Represents an endpoint that enables the user to create an outpost.
/// </summary>
[HttpPost("/api/outposts")]
public sealed class CreateOutpostEndpoint : Endpoint<CreateOutpostRequest, CreateOutpostResponse>
{
    /// <summary>
    ///     The service which enables the user to manipulate the state of the outposts.
    /// </summary>
    private readonly IOutpostService _outpostService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="CreateOutpostEndpoint"/> class with the specified services.
    /// </summary>
    public CreateOutpostEndpoint(IOutpostService outpostService)
    {
        _outpostService = outpostService;
    }

    /// <summary>
    ///     Validates whether the outpost with the requested specification can be created.
    /// </summary>
    public override async Task HandleAsync(CreateOutpostRequest req, CancellationToken ct)
    {
        var isNameTaken = await _outpostService.IsOutpostNameTaken(req.Name);

        if (isNameTaken)
        {
            await SendErrorsAsync(StatusCodes.Status409Conflict, ct);
            return;
        }

        var createdOutpost = await _outpostService.CreateOutpostAsync(req.Name);

        if (createdOutpost is null)
        {
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
            return;
        }

        var response = createdOutpost.ToCreateOutpostResponse();
        
        await SendCreatedAtAsync<CreateOutpostEndpoint>("/api/outposts", response, cancellation: ct);
    }
}