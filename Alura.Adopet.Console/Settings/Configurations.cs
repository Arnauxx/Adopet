using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings
{
    public static class Configurations
    {
        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .Build();
        }

        public static AppSettings ApiSetting
        {
            get
            {
                var _config = BuildConfiguration();
                return _config
                    .GetSection(AppSettings.Section)
                    .Get<AppSettings>() ??
                    throw new ArgumentException("Seção para configuração da API não encontrada!");
            }
        }
    }
}
