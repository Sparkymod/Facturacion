using Blazorise;
using Blazorise.Bootstrap;
using Facturacion;
using Serilog;
using Facturacion.Data.Extensions;
using Facturacion.Data.Service;

var builder = WebApplication.CreateBuilder(args);

// Extension
builder.Services.AddAplicationDbContext();

// Add services to the container.
builder.Services.AddRazorPages();
builder.Services.AddServerSideBlazor();
builder.Services.AddBlazorise().AddBootstrapProviders();
builder.Services.AddScoped<ClientService>();
builder.Services.AddScoped<TiposFiscalService>();
builder.Services.AddScoped<MonedaService>();
builder.Services.AddScoped<FacturableService>();
builder.Services.AddScoped<DiasCreditoService>();
builder.Services.AddScoped<FacturaHService>();
builder.Services.AddScoped<FacturaDService>();

builder.Host.UseSerilog(Settings.InitializeSerilog());

if (!Settings.IsDevelopingMode())
{
    builder.WebHost.UseUrls(Settings.GetURL());
}

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Error");
}


app.UseStaticFiles();
app.UseSerilogRequestLogging();

app.UseRouting();
app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers();
    endpoints.MapBlazorHub();
    endpoints.MapFallbackToPage("/_Host");
});

app.Run();