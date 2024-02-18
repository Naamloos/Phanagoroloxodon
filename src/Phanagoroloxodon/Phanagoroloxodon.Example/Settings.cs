using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Phanagoroloxodon.Example
{
    public class Settings
    {
        [JsonPropertyName("instance")]
        public string Instance { get; set; } = "";

        [JsonPropertyName("access_token")]
        public string AccessToken { get; set; } = "";
    }
}
