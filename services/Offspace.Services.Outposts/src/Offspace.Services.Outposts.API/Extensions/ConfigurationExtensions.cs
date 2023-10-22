using dotenv.net;

namespace Offspace.Services.Outposts.API.Extensions;

/// <summary>
///     Represents a set of extensions methods for configuring the application.
/// </summary>
public static class ConfigurationExtensions
{
    /// <summary>
    ///     The name of the application settings file.
    /// </summary>
    private const string ApplicationSettingsJson = "appsettings.json";
    
    /// <summary>
    ///     The name of the application settings file while in development mode.
    /// </summary>
    private const string ApplicationSettingsDevelopmentJson = "appsettings.Development.json";
    
    /// <summary>
    ///     Updates the configuration with the path to current directory.
    /// </summary>
    public static void UpdatePath(this IConfigurationBuilder builder)
    {
        var path = Directory.GetCurrentDirectory();
        
        builder.SetBasePath(path);
    }
    
    /// <summary>
    ///     Updates the configuration with registered application settings.
    /// </summary>
    public static void UpdateApplicationSettings(this IConfigurationBuilder builder)
    {
        builder.AddJsonFile(ApplicationSettingsJson, optional: false, reloadOnChange: true);
        builder.AddJsonFile(ApplicationSettingsDevelopmentJson, optional: true, reloadOnChange: true);
    }
    
    /// <summary>
    ///     Updates the configuration with registered environment variables.
    /// </summary>
    /// <remarks>
    ///     <b>This method must be the last one to be called in the configuration pipeline.</b>
    /// </remarks>
    public static void UpdateEnvironmentVariables(this IConfigurationBuilder builder)
    {
        DotEnv.Load();
        
        builder.AddEnvironmentVariables();
    }
}