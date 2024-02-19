using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.Json;
using System.Text.Json.Nodes;
using System.Threading.Tasks;

namespace Phanagoroloxodon
{
    public class ApiResponse
    {
        public HttpRequestMessage Request { get; private set; }
        public HttpResponseMessage Response { get; private set; }
        public HttpStatusCode StatusCode { get; private set; }
        public bool Success { get; private set; }
        public string? Error { get; private set; }

        public ApiResponse(HttpRequestMessage request, HttpResponseMessage response)
        {
            Request = request;
            Response = response;
            StatusCode = response.StatusCode;
            Success = response.IsSuccessStatusCode;

            if(!Success)
            {
                Error = JsonSerializer.Deserialize<JsonObject>(response.Content.ReadAsStream())["error"].ToString();
            }
        }
    }

    public class ApiResponse<T> : ApiResponse
    {
        public T? Value { get; private set; } = default;

        public ApiResponse(HttpRequestMessage request, HttpResponseMessage response) : base(request, response)
        {
            if(Success)
            {
                Value = JsonSerializer.Deserialize<T>(response.Content.ReadAsStream());
            }
        }
    }
}
