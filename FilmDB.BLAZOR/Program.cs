using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FilmDB.BLAZOR;
using FilmDB.BLAZOR.Components;
using FilmDB.BLAZOR.Services;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

// Explizit den Port 5000 für die API festlegen
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("http://localhost:5000/") });
builder.Services.AddScoped<FilmDBService>();

await builder.Build().RunAsync();
