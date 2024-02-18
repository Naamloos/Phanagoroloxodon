# Phanagoroloxodon
More dead elephants. (.NET 8 library for Mastodon)

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
mastodon.PostStatusAsync("Hello world!");
```

It's really that simple. I hated how other libs did it so I decided to build my own.