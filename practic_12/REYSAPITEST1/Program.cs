using Microsoft.AspNetCore.Authentication.JwtBearer;
using NLog;
using NLog.Web;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using REYSAPITEST1.Models;

var logger = NLog.LogManager.Setup().LoadConfigurationFromAppSettings().GetCurrentClassLogger();
logger.Info("My API Start");

try
{

    var builder = WebApplication.CreateBuilder(args);

    builder.Logging.ClearProviders();
    builder.Logging.SetMinimumLevel(Microsoft.Extensions.Logging.LogLevel.Trace);
    builder.Host.UseNLog();


    builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidIssuer = AuthOptions.ISSUER,
                ValidateAudience = true,
                ValidAudience = AuthOptions.AUDIENCE,
                ValidateLifetime = true,
                IssuerSigningKey = AuthOptions.GetSymmetricSecurityKey(),
                ValidateIssuerSigningKey = true,
            };
        });

    builder.Services.AddControllers();

    builder.Services.AddControllersWithViews();
    builder.Services.AddDbContext<REYSAPITEST1.Models.ReysContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("Conn"))
                  .LogTo(Console.WriteLine,
                        new[] { DbLoggerCategory.Database.Command.Name },
                        Microsoft.Extensions.Logging.LogLevel.Information)
                  .EnableSensitiveDataLogging());

    builder.Services.AddEndpointsApiExplorer();
    builder.Services.AddSwaggerGen();

    var app = builder.Build();

    // Configure the HTTP request pipeline.
    if (app.Environment.IsDevelopment())
    {
        app.UseSwagger();
        app.UseSwaggerUI();
    }

    app.UseHttpsRedirection();
    //app.UseCookiePolicy();
    app.UseAuthentication();
    app.UseAuthorization();

    app.MapControllers();

    app.Run();
}
catch (Exception ex)
{
    logger.Error("My API Stop");
    logger.Error(ex);
    throw;
}
finally
{
    NLog.LogManager.Shutdown();
}