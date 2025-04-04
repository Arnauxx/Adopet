﻿using Microsoft.Extensions.Configuration;

namespace Alura.Adopet.Console.Settings
{
    public static class Configurations
    {
        private static IConfiguration BuildConfiguration()
        {
            return new ConfigurationBuilder()
                .SetBasePath(Directory.GetCurrentDirectory())
                .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
                .AddUserSecrets("c99257e1-aeab-4798-8c8e-113f9cef3893")
                .Build();
        }

        public static ApiSettings ApiSetting
        {
            get
            {
                var _config = BuildConfiguration();
                return _config
                    .GetSection(ApiSettings.Section)
                    .Get<ApiSettings>() ??
                    throw new ArgumentException("Seção para configuração da API não encontrada!");
            }
        }

        public static MailSettings MailSetting
        {
            get
            {
                var _config = BuildConfiguration();
                return _config
                    .GetSection(MailSettings.EmailSection)
                    .Get<MailSettings>() ??
                    throw new ArgumentException("Seção para configuração do e-mail não encontrada!");
            }
        }
    }
}
