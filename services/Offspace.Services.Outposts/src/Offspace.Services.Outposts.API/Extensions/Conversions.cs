using Offspace.Services.Outposts.API.Responses;
using Offspace.Services.Outposts.API.Responses.Outposts;
using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.API.Extensions;

/// <summary>
///     Contains extension methods for converting between domain and DTO models.
/// </summary>
public static class Conversions
{
    /// <summary>
    ///     Converts the specified <see cref="Outpost"/> entity to a <see cref="CreateOutpostResponse"/>.
    /// </summary>
    /// <param name="outpost">
    ///     The <see cref="Outpost"/> entity to be converted.
    /// </param>
    /// <returns>
    ///     The <see cref="CreateOutpostResponse"/> that represents the specified <see cref="Outpost"/> entity.
    /// </returns>
    public static CreateOutpostResponse ToCreateOutpostResponse(this Outpost outpost) => new()
    {
        Id = outpost.Id,
        Name = outpost.Name
    };
}