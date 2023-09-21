using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using ComposableUI.Root;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

var downstreamApi = builder.Configuration.GetSection("DownstreamApi").Get<DownstreamApiConfiguration>() ?? throw new InvalidOperationException("DownstreamApi configuration is missing");

builder.Services.AddScoped<DownstreamApiAuthorizationMessageHandler>();
builder.Services.AddHttpClient("ComposableUI.DownstreamApi", client => client.BaseAddress = downstreamApi.BaseUrl)
    .AddHttpMessageHandler<DownstreamApiAuthorizationMessageHandler>();

// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("ComposableUI.DownstreamApi"));

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    foreach (var scope in downstreamApi.Scopes)
    {
        options.ProviderOptions.DefaultAccessTokenScopes.Add(scope);
    }
});

await builder.Build().RunAsync();
