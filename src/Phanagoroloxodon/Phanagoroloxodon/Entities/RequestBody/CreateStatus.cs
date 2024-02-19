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
    public class CreateStatus
    {
        [JsonPropertyName("status")]
        public string? Status { get; set; } = null;

        [JsonPropertyName("media_ids")]
        public string[]? MediaIds { get; set; } = null;

        [JsonPropertyName("poll")]
        public CreateStatusPoll? Poll { get; set; } = null;

        [JsonPropertyName("in_reply_to_id")]
        public string? InReplyToId { get; set; } = null;

        [JsonPropertyName("sensitive")]
        public bool? Sensitive { get; set; } = null;

        [JsonPropertyName("spoiler_text")]
        public string? SpoilerText { get; set; } = null;

        /// <summary>
        /// Either public, unlisted, private or direct
        /// </summary>
        [JsonPropertyName("visibility")]
        public string? Visibility { get; set; } = null;

        [JsonPropertyName("language")]
        public string? Language { get; set; } = null;

        [JsonPropertyName("scheduled_at")]
        public DateTimeOffset? ScheduledAt { get; set; } = null;
    }
}
