using System.IdentityModel.Tokens.Jwt;
using Azure.Extensions.AspNetCore.Configuration.Secrets;
using DataAccess.DataContext.Data;
using DataAccess.Repositories;
using DataAccess.Repositories.Interfaces;
using DataAccess.UnitOfWork;
using GamesCorner.Server.Data;
using GamesCorner.Server.Extensions;
using Microsoft.AspNetCore.Authentication;
using Microsoft.AspNetCore.ResponseCompression;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Azure.Identity;
using Azure.Security.KeyVault.Secrets;
using DataAccess.Models;
using GamesCorner.Server.Services.PaymentService;

var builder = WebApplication.CreateBuilder(args);



// Add services to the container.
var connectionString = builder.Configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string 'DefaultConnection' not found.");
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddDbContext<StoreContext>(options =>
    options.UseSqlServer(connectionString));
builder.Services.AddDatabaseDeveloperPageExceptionFilter();



builder.Services.AddDefaultIdentity<ApplicationUser>(options => options.SignIn.RequireConfirmedAccount = true).AddRoles<IdentityRole>()
    .AddEntityFrameworkStores<ApplicationDbContext>().AddDefaultTokenProviders();

builder.Services.AddIdentityServer()
    .AddApiAuthorization<ApplicationUser, ApplicationDbContext>(opt =>
    {
        opt.IdentityResources["openid"].UserClaims.Add("role");
        opt.ApiResources.Single().UserClaims.Add("role");
    });
JwtSecurityTokenHandler.DefaultInboundClaimTypeMap.Remove("role");

builder.Services.AddAuthentication().AddGoogle(googleOptions =>
	{
		googleOptions.ClientId = builder.Configuration["Authentication:Google:ClientId"];
		googleOptions.ClientSecret = builder.Configuration["Authentication:Google:ClientSecret"];
	})
	.AddIdentityServerJwt();

builder.Services.AddAuthorization(op =>
{
    op.AddPolicy("admin", pb =>
    {
        pb.RequireAssertion(context => context.User.IsInRole("Administrator"));
    });
});

builder.Services.AddMediatR(x => x.RegisterServicesFromAssemblyContaining<Program>());

builder.Services.AddScoped<IProductRepository, ProductRepository>();
builder.Services.AddScoped<IOrderRepository, OrderRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
builder.Services.AddScoped<IPaymentService, PaymentService>();
builder.Services.AddScoped<IEventRepository, EventRepository>();



builder.Services.AddRazorPages();

//var keyVaultEndpoint = new Uri(Environment.GetEnvironmentVariable("VaultUri"));
//builder.Configuration.AddAzureKeyVault(keyVaultEndpoint, new DefaultAzureCredential());

//IHostBuilder CreateHostBuilder(string[] args) =>
//	Host.CreateDefaultBuilder(args)
//		.ConfigureAppConfiguration((context, config) =>
//		{
//			var builtConfiguration = config.Build();

//			string KuURl = builtConfiguration["KeyVaulConfig:KVUrl"];
//			string tenantId = builtConfiguration["KeyVaulConfig:TenantId"];
//			string clientId = builtConfiguration["KeyVaulConfig:ClientId"];
//			string clientSecret = builtConfiguration["KeyVaulConfig:ClientSecretId"];

//			var credential = new ClientSecretCredential(tenantId, clientId, clientSecret);
//			var client = new SecretClient(new Uri(KuURl), credential);
//			config.AddAzureKeyVault(client, new AzureKeyVaultConfigurationOptions());
//		})
//		.ConfigureWebHostDefaults(webBuilder =>
//		{
//			webBuilder.UseStartup<StartupBase>();
//		});


var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseMigrationsEndPoint();
    app.UseWebAssemblyDebugging();
}
else
{
    app.UseExceptionHandler("/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}
await app.SeedDatabase();

app.UseHttpsRedirection();

app.UseBlazorFrameworkFiles();
app.UseStaticFiles();

app.UseRouting();

app.UseIdentityServer();
app.UseAuthentication();
app.UseAuthorization();

app.MapRazorPages();
app.MapEndpoints();

app.MapFallbackToFile("index.html");

app.Run();
