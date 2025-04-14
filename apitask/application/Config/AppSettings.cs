using application.DTOs.Others;

namespace application.Config
{
    public abstract class AppSettings
    {
        private static DtoAppSettings? _dtoAppSettings;

        public static void Init()
        {
            _dtoAppSettings = new DtoAppSettings();

            IConfigurationBuilder builder = new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.Development.json", optional: true, reloadOnChange: true)
                .AddEnvironmentVariables();
            IConfigurationRoot configuration = builder.Build();

            _dtoAppSettings.ConnetionStringSQLite = configuration["ConnectionStrings:ConnectionStringSQLite"];
        }

        public static string? GetConnetionStringSqLite()
        {
            return _dtoAppSettings!.ConnetionStringSQLite;
        }
    }
}
