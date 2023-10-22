using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.DependencyInjection;
using Offspace.Services.Outposts.Infrastructure.Abstractions;
using Offspace.Services.Outposts.Infrastructure.Contexts;
using Offspace.Services.Outposts.Infrastructure.Repositories;
using Offspace.Services.Outposts.Infrastructure.Services;

namespace Offspace.Services.Outposts.Infrastructure.Extensions;

/// <summary>
///     Represents a set of extension methods responsible for registering the infrastructure services.
/// </summary>
public static class RegistrationExtensions
{
    /// <summary>
    ///     Registers the services used by the infrastructure layer.
    /// </summary>
    public static void AddServices(this IServiceCollection services)
    {
        services.AddSingleton<IBlockService, BlockService>();
        services.AddSingleton<IOutpostService, OutpostService>();
    }
    
    /// <summary>
    ///     Registers the repositories used by the infrastructure layer.
    /// </summary>
    public static void AddRepositories(this IServiceCollection services)
    {
        services.AddSingleton<IBlockRepository, BlockRepository>();
        services.AddSingleton<IOutpostRepository, OutpostRepository>();
    }
    
    /// <summary>
    ///     Registers the database contexts used by the infrastructure layer.
    /// </summary>
    public static void AddDatabaseContexts(this IServiceCollection services, string connectionString)
    {
        services.AddDbContext<BlockDatabaseContext>(options => options.UseSqlite(connectionString));
        services.AddDbContext<OutpostDatabaseContext>(options => options.UseSqlite(connectionString));
    }
}