
using DashboardApi.Context;
using DashboardApi.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
//using Microsoft.AspNet.SignalR;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.ChangeTracking;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.IdentityModel.Tokens;
using Pomelo.EntityFrameworkCore.MySql.Internal;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

var MyAllowSpecificOrigins = "_myAllowSpecificOrigins";
// Add services to the container.


builder.Services.AddControllers().AddJsonOptions(options =>
{
    options.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
});
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddDbContext<pcgroups_mantisContext>(options =>
{
    options.UseMySQL(builder.Configuration.GetConnectionString("connectionDb"));
});

builder.Services.AddCors(options =>
{
    options.AddPolicy(name: MyAllowSpecificOrigins,
                      policy =>
                      {
                          policy.WithOrigins("http://localhost:4200")
                          .AllowAnyHeader()
                          .AllowAnyMethod()
                          .AllowCredentials();
                      });
});

builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options => options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = "localhost",
        ValidAudience = "localhost",
        IssuerSigningKey = new SymmetricSecurityKey(
                Encoding.UTF8.GetBytes(builder.Configuration["LlaveJwt"])),
        ClockSkew = TimeSpan.Zero
    });

builder.Services.AddSignalR();
builder.Services.AddScoped<ITicketsStatusService, TicketsService>();
builder.Services.AddScoped<IChartServices, ChartServices>();
builder.Services.AddScoped<ILoginServices, LoginServices>();

builder.Services.AddHostedService<ChangeTrackerJob>();
builder.Services.AddScoped<IScopedProcessingService, DefaultScopedProcessingService>();

//var hubContext = builder.Services.BuildServiceProvider().GetRequiredService<IHubContext<HubMessageService>>();
//AlertMessageService.start(builder.Configuration.GetConnectionString("connectionDb"), hubContext);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment() || app.Environment.IsProduction())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}


app.UseHttpsRedirection();

app.UseCors(MyAllowSpecificOrigins);

app.UseAuthorization();

app.MapControllers();

app.MapHub<HubMessageService>("hub/notify");

app.Run();
