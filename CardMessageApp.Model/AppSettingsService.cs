
using Microsoft.Extensions.Configuration;

namespace CardMessageApp.Model
{
    public class AppSetting
    {
        public string ChatGptKey { get; set; }
    }

    public enum EAppSetting
    {
        ChatGptToken
    }

    public interface IAppSettingsService
    {
        string GetSetting(EAppSetting settingName);
    }

    public class AppSettingsService: IAppSettingsService
    {
        private AppSetting AppSetting;

        public AppSettingsService()
        {
            var builder = new ConfigurationBuilder()
                .AddJsonFile("appsettings.json")
                .AddJsonFile(
                    $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json",
                    optional: true);

            // Apply any configuration file transformations based on the current environment
            builder.AddJsonFile(
                $"appsettings.{Environment.GetEnvironmentVariable("ASPNETCORE_ENVIRONMENT") ?? "Development"}.json",
                optional: true, reloadOnChange: true);

            var configuration = builder.Build();

            // Get the connection string from the configuration
            string ChatGptToken = configuration.GetConnectionString("ChatGptToken");

            AppSetting = new AppSetting();
            AppSetting.ChatGptKey = ChatGptToken;

        }

        public string GetSetting(EAppSetting settingName)
        {

            switch (settingName)
            {
                case EAppSetting.ChatGptToken:
                    return AppSetting.ChatGptKey;

                default:
                    throw new ArgumentOutOfRangeException(nameof(settingName), settingName, null);
            }

        }
    }
}
