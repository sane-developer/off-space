using Offspace.Services.Outposts.API.Responses.Outposts;
using Offspace.Services.Outposts.Domain.Entities;

namespace Offspace.Services.Outposts.API.Extensions;

/// <summary>
///     Contains extension methods for converting between domain and DTO models.
/// </summary>
public static class Conversions
{
    /// <summary>
    ///     Converts the specified <see cref="Outpost"/> entity to a <see cref="OutpostCreatedResponse"/>.
    /// </summary>
    /// <param name="outpost">
    ///     The <see cref="Outpost"/> entity to be converted.
    /// </param>
    /// <returns>
    ///     The <see cref="OutpostCreatedResponse"/> that represents the specified <see cref="Outpost"/> entity.
    /// </returns>
    public static OutpostCreatedResponse ToOutpostCreatedResponse(this Outpost outpost) => new()
    {
        Id = outpost.Id,
        Name = outpost.Name
    };
}