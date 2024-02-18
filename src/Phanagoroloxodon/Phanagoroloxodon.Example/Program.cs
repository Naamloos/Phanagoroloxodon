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

            mastodon = new Mastodon((ref MastodonClientConfig config) =>
            {
                config.AccessToken = settings.AccessToken;
                config.Instance = settings.Instance;
            });

            var postedStatus = await mastodon.PostStatusAsync("Aaaaaand it works! (?)");
            Console.ReadKey();
        }
    }
}
