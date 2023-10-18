using Microsoft.EntityFrameworkCore;

namespace Offspace.Services.Outposts.Domain.Abstractions;

/// <summary>
///     Represents a set of constraints for a database entity.
/// </summary>
public interface IEntityConstraint
{
    /// <summary>
    ///     Applies the constraints to the model.
    /// </summary>
    public static abstract void Apply(ModelBuilder modelBuilder);
}