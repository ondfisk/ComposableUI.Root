﻿using Microsoft.AspNetCore.Components;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

namespace ComposableUI.Root;

public class DownstreamApiAuthorizationMessageHandler : AuthorizationMessageHandler
{
    public DownstreamApiAuthorizationMessageHandler(IAccessTokenProvider provider,
        NavigationManager navigation, IConfiguration config)
        : base(provider, navigation)
    {
        ConfigureHandler(
            authorizedUrls: [ config.GetSection("DownstreamApi")["BaseUrl"]! ],
            scopes: config.GetSection("DownstreamApi:Scopes").Get<List<string>>());
    }
}
