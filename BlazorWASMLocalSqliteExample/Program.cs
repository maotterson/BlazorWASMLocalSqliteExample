using BlazorWASMLocalSqliteExample;
using BlazorWASMLocalSqliteExample.Data;
using BlazorWASMLocalSqliteExample.Services;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Components.WebAssembly.Hosting;
using Microsoft.EntityFrameworkCore;
using SqliteWasmHelper;

var builder = WebAssemblyHostBuilder.CreateDefault(args);
builder.RootComponents.Add<App>("#app");
builder.RootComponents.Add<HeadOutlet>("head::after");

builder.Services.AddScoped(sp => new HttpClient { BaseAddress = new Uri(builder.HostEnvironment.BaseAddress) });
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddSqliteWasmDbContextFactory<BPDbContext>(
    opts => opts.UseSqlite("Data Source=things.sqlite3"));
builder.Services.AddScoped<BPDataSeeder>();

var host = builder.Build();
var dbSeeder = host.Services.GetRequiredService<BPDataSeeder>();
dbSeeder.Seed();
await host.RunAsync();