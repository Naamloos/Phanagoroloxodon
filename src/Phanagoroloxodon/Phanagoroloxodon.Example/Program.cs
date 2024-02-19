using Phanagoroloxodon.Entities;
using Phanagoroloxodon.Entities.RequestBody;
using System.Text.Json;

namespace Phanagoroloxodon.Example
{
    internal class Program
    {
        static Mastodon mastodon;

        static async Task Main(string[] args)
        {
            if(!File.Exists("settings.json"))
            {
                var newConfig = File.Create("settings.json");
                JsonSerializer.Serialize<Settings>(newConfig, new Settings());
                newConfig.Flush();
                newConfig.Close();
                Console.WriteLine("Created a settings.json. Please fill it out.");
                Console.ReadKey();
                return;
            }

            var file = File.OpenRead("settings.json");
            var settings = JsonSerializer.Deserialize<Settings>(file)!;
            file.Close();

            mastodon = new Mastodon(config =>
            {
                config.AccessToken = settings.AccessToken;
                config.Instance = settings.Instance;
                config.OAuthScopes = Scopes.Read | Scopes.Write | Scopes.AdminRead | Scopes.AdminWrite | Scopes.Push;
            });

            var publicTimeline = await mastodon.GetPublicTimelineAsync();

            if(publicTimeline.Success)
            {
                foreach(var status in publicTimeline.Value!)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"{status.Account.Acct}:");
                    Console.ResetColor();
                    Console.WriteLine($"{status.SanitizedContent}\n{status.Url}\n\n");
                }
            }
            else
            {
                Console.WriteLine(publicTimeline.Error);
            }

            Console.ReadKey();
        }
    }
}
