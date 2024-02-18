using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Phanagoroloxodon.Entities.RequestBody
{
    /// <summary>
    /// Represents a new status to be posted to Mastodon. TODO: complete fields
    /// </summary>
    public struct CreateStatus
    {
        [JsonPropertyName("status")]
        public string Status {  get; set; }
    }
}
