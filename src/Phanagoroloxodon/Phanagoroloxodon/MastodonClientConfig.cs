﻿using Phanagoroloxodon.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Phanagoroloxodon
{
    public class MastodonClientConfig
    {
        public string ClientId { get; set; } = "";
        public string ClientSecret { get; set; } = "";
        public string AccessToken { get; set; } = "";
        public string RedirectUri { get; set; } = "";
        public string Scope { get; set; } = "";
        public string Instance { get; set; } = "";
        public Scopes OAuthScopes { get; set; }
    }
}
