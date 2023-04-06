using Blazored.LocalStorage;
using GamesCorner.Client;
using GamesCorner.Client.Services.CartService;
using Microsoft.AspNetCore.Components.Authorization;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Authentication;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddHttpClient("GamesCorner.ServerAPI", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress))
	.AddHttpMessageHandler<BaseAddressAuthorizationMessageHandler>();
builder.Services.AddHttpClient("public", client => client.BaseAddress = new Uri(builder.HostEnvironment.BaseAddress));




// Supply HttpClient instances that include access tokens when making requests to the server project
builder.Services.AddScoped(sp => sp.GetRequiredService<IHttpClientFactory>().CreateClient("GamesCorner.ServerAPI"));

builder.Services.AddBlazoredLocalStorage();
builder.Services.AddScoped<ICartService, CartService>();

builder.Services.AddApiAuthorization();

await builder.Build().RunAsync();
