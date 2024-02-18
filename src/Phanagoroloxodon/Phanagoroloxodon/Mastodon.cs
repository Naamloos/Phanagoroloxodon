using Phanagoroloxodon.Entities;
using Phanagoroloxodon.Entities.RequestBody;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Phanagoroloxodon
{
    public class Mastodon
    {
        private MastodonClientConfig config;
        private HttpClient http;
        private JsonSerializerOptions jsonSerializerOptions;

        public delegate void ConfigurationDelegate<T>(ref T client);

        public Mastodon(MastodonClientConfig config)
        {
            setup(config);
        }

        public Mastodon(ConfigurationDelegate<MastodonClientConfig> configure)
        {
            var config = new MastodonClientConfig();
            configure(ref config);
            setup(config);
        }

        private void setup(MastodonClientConfig config)
        {
            this.config = config;

            http = new HttpClient();
            http.BaseAddress = new Uri($"https://{config.Instance}/api/v1/");
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.AccessToken);
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            jsonSerializerOptions = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault,
                WriteIndented = true,
                AllowTrailingCommas = true
            };
        }

        public async ValueTask AuthenticateAsync()
        {
        }

        public async ValueTask<IEnumerable<Status>> GetPublicTimelineAsync()
        {
            var request = new HttpRequestMessage(HttpMethod.Get, "timelines/public");
            var response = await http.SendAsync(request);

            var resp = await response.Content.ReadAsStringAsync();

            return await JsonSerializer.DeserializeAsync<List<Status>>(await response.Content.ReadAsStreamAsync(), jsonSerializerOptions);
        }

        public async ValueTask<Status> PostStatusAsync(string status)
        {
            var request = new HttpRequestMessage(HttpMethod.Post, "statuses");
            request.Content = JsonContent.Create(new CreateStatus()
            {
                Status = status
            });
            var response = await http.SendAsync(request);
            return await JsonSerializer.DeserializeAsync<Status>(await response.Content.ReadAsStreamAsync(), jsonSerializerOptions);
        }
    }
}
