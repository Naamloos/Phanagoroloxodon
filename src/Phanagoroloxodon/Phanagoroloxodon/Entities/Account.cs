using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Phanagoroloxodon.Entities
{
    public class Account
    {
        /// <summary>
        /// The account ID
        /// </summary>
        [JsonPropertyName("id")]
        public string Id { get; set; }

        /// <summary>
        /// The username of the account, not including domain.
        /// </summary>
        [JsonPropertyName("username")]
        public string Username { get; set; }

        /// <summary>
        /// The Webfinger account URI, equal to <see cref="Username"/> for local users, <see cref="Username"/>@domain for remote users.
        /// </summary>
        [JsonPropertyName("acct")]
        public string Acct {  get; set; }

        /// <summary>
        /// The location of the user's profile page.
        /// </summary>
        [JsonPropertyName("url")]
        public Uri Url { get; set; }

        /// <summary>
        /// The profile's display name.
        /// </summary>
        [JsonPropertyName("display_name")]
        public string DisplayName { get; set; }

        /// <summary>
        /// The profile's bio or description (HTML).
        /// </summary>
        [JsonPropertyName("note")]
        public string Note { get; set; }

        /// <summary>
        /// An image icon that is shown next to statuses and in the profile.
        /// </summary>
        [JsonPropertyName("avatar")]
        public Uri Avatar { get; set; }

        /// <summary>
        /// A static version of the avatar. Equal to <see cref="Avatar"/> if it's value is a static image; different in <see cref="Avatar"/> is an animated GIF.
        /// </summary>
        [JsonPropertyName("avatar_static")]
        public Uri AvatarStatic { get; set; }

        /// <summary>
        /// An image banner that is shown above the profile and in profile cards.
        /// </summary>
        [JsonPropertyName("header")]
        public Uri Header { get; set; }

        /// <summary>
        /// A static version of the header. Equal to <see cref="Header"/> if its value is a static image; different if <see cref="Header"/> is an animated GIF.
        /// </summary>
        [JsonPropertyName("header_static")]
        public Uri HeaderStatic { get; set; }

        /// <summary>
        /// Whether the account manually approves follow requests.
        /// </summary>
        [JsonPropertyName("locked")]
        public bool Locked { get; set; }

        /// <summary>
        /// Additional metadata attached to a profile as name-value pairs.
        /// </summary>
        [JsonPropertyName("fields")]
        public AccountField[] Fields { get; set; }

        /// <summary>
        /// Custom emoji entities to be used whenm rendering the profile.
        /// </summary>
        [JsonPropertyName("emojis")]
        public CustomEmoji[] Emojis { get; set; }

        /// <summary>
        /// Indicates that the account may perform automated actions, may not be monitored, or identifies as a robot.
        /// </summary>
        [JsonPropertyName("bot")]
        public bool Bot {  get; set; }

        /// <summary>
        /// Indicates that the account represents a Group actor.
        /// </summary>
        [JsonPropertyName("group")]
        public bool Group { get; set; }

        /// <summary>
        /// Whether the account has opted into discovery features such as the profile directory.
        /// </summary>
        [JsonPropertyName("discoverable")]
        public bool? Discoverable { get; set; }

        /// <summary>
        /// Whether the local user has opted out of being indexed by search engines.
        /// </summary>
        [JsonPropertyName("noindex")]
        public bool? NoIndex { get; set; }

        /// <summary>
        /// Indicates that the profile is currently inactive and that its user has moved to a new account. See also: <seealso cref="Suspended"/>
        /// </summary>
        [JsonPropertyName("moved")]
        public Account? Moved { get; set; }

        /// <summary>
        /// An extra attribute returned only when an account is suspended.
        /// </summary>
        [JsonPropertyName("suspended")]
        public bool? Suspended { get; set; }

        /// <summary>
        /// An extra attribute returned only when an account is silenced. If true, indicates that the account should be hidden behind a warning screen.
        /// </summary>
        [JsonPropertyName("limited")]
        public bool? Limited { get; set; }

        [JsonPropertyName("created_at")]
        public DateTimeOffset CreatedAt { get; set; }

        /// <summary>
        /// When the most recent status was posted.
        /// </summary>
        [JsonPropertyName("last_status_at")]
        public DateTimeOffset? LastStatusAs {  get; set; }

        /// <summary>
        /// How many statuses are attached to this account.
        /// </summary>
        [JsonPropertyName("statuses_count")]
        public long StatusesCount { get; set; }

        /// <summary>
        /// The reported followers of this profile.
        /// </summary>
        [JsonPropertyName("followers_count")]
        public long FollowersCount { get; set; }

        /// <summary>
        /// The reported follows of this profile.
        /// </summary>
        [JsonPropertyName("following_count")]
        public long FollowingCount { get; set; }
    }
}
