using Offspace.Services.Outposts.API.Requests.Outposts;
using Offspace.Services.Outposts.Infrastructure.Abstractions;

namespace Offspace.Services.Outposts.API.Endpoints.Outposts;

/// <summary>
///     Represents an endpoint that enables the user to rename an outpost.
/// </summary>
[HttpPatch("/api/outposts/{outpostId:int}/rename")]
public sealed class RenameOutpostEndpoint : Endpoint<RenameOutpostRequest>
{
    /// <summary>
    ///     The service which enables the user to manipulate the state of the outposts.
    /// </summary>
    private readonly IOutpostService _outpostService;

    /// <summary>
    ///     Initializes a new instance of the <see cref="RenameOutpostEndpoint"/> class with the specified services.
    /// </summary>
    public RenameOutpostEndpoint(IOutpostService outpostService)
    {
        _outpostService = outpostService;
    }

    /// <summary>
    ///     Validates whether the outpost with the requested specification can be renamed.
    /// </summary>
    public override async Task HandleAsync(RenameOutpostRequest req, CancellationToken ct)
    {
        var outpost = await _outpostService.GetOutpostAsync(req.OutpostId);
        
        if (outpost is null)
        {
            await SendNotFoundAsync(ct);
            return;
        }
        
        var isNameTaken = await _outpostService.IsOutpostNameTaken(req.Name);
        
        if (isNameTaken)
        {
            await SendErrorsAsync(StatusCodes.Status409Conflict, ct);
            return;
        }
        
        var hasRenamed = await _outpostService.RenameOutpostAsync(outpost, req.Name);
        
        if (!hasRenamed)
        {
            await SendErrorsAsync(StatusCodes.Status500InternalServerError, ct);
            return;
        }
        
        await SendNoContentAsync(ct);
    }
}