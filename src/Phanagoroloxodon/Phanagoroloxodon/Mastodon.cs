using Phanagoroloxodon.Entities;
using Phanagoroloxodon.Entities.RequestBody;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;

namespace Phanagoroloxodon
{
    public class Mastodon
    {
        private const string BASE_API_PATH = "api/v1/";

        private MastodonClientConfig config;
        private HttpClient http;
        private JsonSerializerOptions jsonSerializerOptions;

        public Mastodon(MastodonClientConfig config)
        {
            setup(config);
        }

        public Mastodon(Action<MastodonClientConfig> configure)
        {
            var config = new MastodonClientConfig();
            configure(config);
            setup(config);
        }

        private void setup(MastodonClientConfig config)
        {
            this.config = config;

            http = new HttpClient();
            http.BaseAddress = new Uri($"https://{config.Instance}/");
            http.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", config.AccessToken);
            http.DefaultRequestHeaders.Accept.Clear();
            http.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

            jsonSerializerOptions = new JsonSerializerOptions()
            {
                DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingNull,
                WriteIndented = true,
                AllowTrailingCommas = true
            };
        }

        public async ValueTask AuthorizeAsync()
        {
        }

        public async ValueTask<ApiResponse<List<Status>>> GetPublicTimelineAsync()
            => await makeRequest<List<Status>>(HttpMethod.Get, BASE_API_PATH + "timelines/public");

        public async ValueTask<ApiResponse<Status>> PostStatusAsync(Action<CreateStatus> build)
            => await makeRequest<Status, CreateStatus>(HttpMethod.Post, BASE_API_PATH + "statuses", build);

        private async ValueTask<ApiResponse<TResponse>> makeRequest<TResponse, TRequest>(HttpMethod method, string endpoint, Action<TRequest> build)
        {
            var bodyObject = (TRequest)Activator.CreateInstance(typeof(TRequest))!;
            build(bodyObject);

            var request = new HttpRequestMessage(method, endpoint);
            request.Content = getJsonContentAsStream(bodyObject);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await http.SendAsync(request);

            return new ApiResponse<TResponse>(request, response);
        }

        private async ValueTask<ApiResponse> makeRequest<TRequest>(HttpMethod method, string endpoint, Action<TRequest> build)
        {
            var bodyObject = (TRequest)Activator.CreateInstance(typeof(TRequest))!;
            build(bodyObject);

            var request = new HttpRequestMessage(method, endpoint);
            request.Content = getJsonContentAsStream(bodyObject);
            request.Content.Headers.ContentType = new MediaTypeHeaderValue("application/json");
            var response = await http.SendAsync(request);

            return new ApiResponse(request, response);
        }

        private async ValueTask<ApiResponse<TResponse>> makeRequest<TResponse>(HttpMethod method, string endpoint)
        {
            var request = new HttpRequestMessage(method, endpoint);
            var response = await http.SendAsync(request);

            return new ApiResponse<TResponse>(request, response);
        }

        private StreamContent getJsonContentAsStream<T>(T content)
        {
            var stream = new MemoryStream();
            JsonSerializer.Serialize(stream, content, options: jsonSerializerOptions);
            stream.Seek(0, SeekOrigin.Begin);
            return new StreamContent(stream);
        }
    }
}
