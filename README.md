# Phanagoroloxodon
More dead elephants. (.NET 8 library for Mastodon)

Phanagoroloxodon was made because all the existing libraries for .NET either are ancient or suck ass. As of right now, the focus is on the REST api, but support for websocket-based streaming API is planned.

## Namesake
As Mastodon is named after an extinct species of elephants, I decided to name my library after an extinct elephant genus. Hence "more dead elephants". [Wikipedia: Phanagoroloxodon](https://en.wikipedia.org/wiki/Phanagoroloxodon).

## Getting started
The library is still very much in development, and thus is not available on Nuget yet.

```cs
// Authenticating a Mastodon client using a pre-generated access token.
var mastodon = new Mastodon(new MastodonClientConfig()
{
    AccessToken = "your-token",
    Instance = "yourinstance.social"
});

// Posting a simple text status
var tootResponse = await mastodon.PostStatusAsync("Hello world!");
if(!tootResponse.Success)
{
    // Leave error handling to the end user!
    Console.WriteLine(tootResponse.Error);
}

// Fetching timeline
var timelineResponse = await mastodon.GetPublicTimelineAsync();
if(publicTimeline.Success)
{
    foreach(Status toot in timelineResponse.Value)
    {
        // Prints out last public toots to the console.
        Console.WriteLine($"{toot.Account.Acct}:\n{toot.SanitizedContent}\n\n");
    }
}
```

It's really that simple. I hated how other libs did it so I decided to build my own. SanitizedContent may be somewhat inaccurate due to lack of testing, but it uses [HTML Agility Pack](https://html-agility-pack.net/) for getting a plaintext version of status content.
