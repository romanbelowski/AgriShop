using Serilog;
using WSLab.Services;

var builder = WebApplication.CreateBuilder(args);

// Add email sender service
builder.Services.AddTransient<IEmailSender, EmailSender>();

// Configure Serilog first
Log.Logger = new LoggerConfiguration()
    .Enrich.FromLogContext()
    .WriteTo.File("Logs/log.log", rollingInterval: RollingInterval.Minute)
    .CreateLogger();

// Add services to the container.
builder.Services.AddControllersWithViews();

builder.Logging.ClearProviders();

// Add Serilog logger to the logging providers
builder.Logging.AddSerilog();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.Use((context, next) =>
{
    var request = context.Request;
    var ipAddress = context.Connection.RemoteIpAddress;
    var requestTime = DateTime.Now;
    var logMessage = $"{request.Scheme}://{request.Host}{request.Path}{request.QueryString} [:] " +
                     $"T:{requestTime}, " +
                     $"IP:{ipAddress}";
    Log.Information(logMessage);
    return next();
});

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();
