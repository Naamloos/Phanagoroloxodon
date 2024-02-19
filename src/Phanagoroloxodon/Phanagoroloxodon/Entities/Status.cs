using HtmlAgilityPack;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Phanagoroloxodon.Entities
{
    public class Status
    {
        [JsonPropertyName("id")]
        public string Id { get; set; }

        [JsonPropertyName("uri")]
        public string Uri { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        [JsonPropertyName("account")]
        public Account Account { get; set; }

        [JsonPropertyName("content")]
        public string Content { get; set; }

        public string SanitizedContent
        {
            get
            {
                var document = new HtmlDocument();
                document.LoadHtml(Content);
                return string.Join(" ", document.DocumentNode.ChildNodes.Select(x => x.InnerText));
            }
        }

        /// <summary>
        /// public, unlisted, private or direct
        /// </summary>
        [JsonPropertyName("visibility")]
        public string Visibility { get; set; }

        [JsonPropertyName("sensitive")]
        public bool Sensitive { get; set; }

        [JsonPropertyName("spoiler_text")]
        public string SpoilerText { get; set; }

        [JsonPropertyName("media_attachments")]
        public MediaAttachment[] MediaAttachments { get; set; }

        /// <summary>
        /// Contains a hash of what application was used. Optional.
        /// </summary>
        //[JsonPropertyName("application")]
        //public string Application {  get; set; }

        [JsonPropertyName("mentions")]
        public StatusMention[] Mentions { get; set; }

        [JsonPropertyName("tags")]
        public StatusTag[] Tags { get; set; }

        [JsonPropertyName("emojis")]
        public CustomEmoji[] Emojis { get; set; }

        [JsonPropertyName("reblogs_count")]
        public ulong ReblogsCount { get; set; }

        [JsonPropertyName("favourites_count")]
        public ulong FavouritesCount { get; set; }

        [JsonPropertyName("replies_count")]
        public ulong RepliesCount { get; set; }

        [JsonPropertyName("url")]
        public string Url { get; set; }

        [JsonPropertyName("in_reply_to_id")]
        public string InReplyToId { get; set; }

        [JsonPropertyName("in_reply_to_account_id")]
        public string InReplyToAccountId { get; set; }

        [JsonPropertyName("reblog")]
        public Status? Reblog { get; set; }

        [JsonPropertyName("poll")]
        public Poll? Poll { get; set; }

        [JsonPropertyName("card")]
        public PreviewCard? Card { get; set; }

        [JsonPropertyName("language")]
        public string Language { get; set; }

        /// <summary>
        /// Returned instead of <see cref="Content"/> when this status is deleted, so a user may redraft from source text.
        /// </summary>
        [JsonPropertyName("text")]
        public string Text { get; set; }

        [JsonPropertyName("edited_at")]
        public DateTimeOffset? EditedAt { get; set; }

        [JsonPropertyName("favourited")]
        public bool Favourited { get; set; }

        [JsonPropertyName("reblogged")]
        public bool Rebloged { get; set; }

        [JsonPropertyName("muted")]
        public bool Muted { get; set; }

        [JsonPropertyName("bookmarked")]
        public bool Bookmarked { get; set; }

        [JsonPropertyName("pinned")]
        public bool Pinned { get; set; }

        [JsonPropertyName("filtered")]
        public FilterResult[] Filtered { get; set; }
    }
}
