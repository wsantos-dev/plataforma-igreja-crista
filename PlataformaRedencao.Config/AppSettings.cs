using Microsoft.Extensions.Configuration;
using System;

namespace PlataformaRedencao.Config
{
    /// <summary>
    /// Marker class to identify the assembly for User Secrets.
    /// </summary>
    public class SecretsMarker { }

    public static class AppSettings
    {
        private static IConfiguration? _configuration;

        /// <summary>
        /// Returns the configuration loaded from User Secrets and Environment Variables.
        /// </summary>
        public static IConfiguration Configuration
        {
            get
            {
                if (_configuration == null)
                {
                    _configuration = new ConfigurationBuilder()
                        // Load User Secrets based on the assembly of this class
                        .AddUserSecrets<SecretsMarker>(optional: true)
                        .Build();
                }

                return _configuration;
            }
        }

        /// <summary>
        /// Example of how to access the connection string.
        /// </summary>
        public static string PostgreSqlConnectionString =>
            Configuration.GetConnectionString("PostgreSql")
            ?? throw new InvalidOperationException("The connection string 'PostgreSql' was not found.");

        /// <summary>
        /// Example of how to access JWT settings.
        /// </summary>
        public static string JwtKey =>
            Configuration["Jwt:Key"]
            ?? throw new InvalidOperationException("The configuration 'Jwt:Key' was not found.");

        public static string JwtIssuer =>
            Configuration["Jwt:Issuer"]
            ?? throw new InvalidOperationException("The configuration 'Jwt:Issuer' was not found.");

        public static int JwtExpirationInMinutes =>
            int.TryParse(Configuration["Jwt:ExpirationInMinutes"], out var minutes) ? minutes : 60;

        public static string JwtAudience =>
            Configuration["Jwt:Audience"]
            ?? throw new InvalidOperationException("The configuration 'Jwt:Audience' was not found.");
    }
}
