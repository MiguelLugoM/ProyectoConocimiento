using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using FrontBlazor;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");
builder.Services.AddScoped<WeatherForecastService>();

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });

// Configurar HttpClient para que apunte a la URL base de la API
builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri("https://localhost:5003/") });

await builder.Build().RunAsync();
