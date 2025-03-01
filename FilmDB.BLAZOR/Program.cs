using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FilmDB.BLAZOR;
using FilmDB.BLAZOR.Components;
using FilmDB.BLAZOR.Services;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Konfiguriere den HTTP-Client für die API mit Auth
builder.Services.AddHttpClient("FilmDB.API", 
    client => client.BaseAddress = new Uri("http://localhost:5000"))
    .AddHttpMessageHandler(sp => sp.GetRequiredService<AuthorizationMessageHandler>()
        .ConfigureHandler(
            authorizedUrls: new[] { "http://localhost:5000" },
            scopes: new[] { "api://741b4042-3d73-463c-9719-176aa55f8da2/API.Access" }
        ));

builder.Services.AddScoped<FilmDBService>();

builder.Services.AddMsalAuthentication(options =>
{
    builder.Configuration.Bind("AzureAd", options.ProviderOptions.Authentication);
    options.ProviderOptions.DefaultAccessTokenScopes.Add("api://741b4042-3d73-463c-9719-176aa55f8da2/API.Access");
    options.ProviderOptions.LoginMode = "redirect";
});

await builder.Build().RunAsync();
