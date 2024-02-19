using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Phanagoroloxodon.Entities.RequestBody
{
    public class CreateStatusPoll
    {
        [JsonPropertyName("options")]
        public string[]? Options { get; set; } = null;

        [JsonPropertyName("expires_in")]
        public int? ExpiresIn { get; set; } = null;

        [JsonPropertyName("multiple")]
        public bool? Multiple { get; set; } = null;

        [JsonPropertyName("hide_totals")]
        public bool? HideTotals { get; set; } = null;
    }
}
