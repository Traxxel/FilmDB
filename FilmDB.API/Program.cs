using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.EntityFrameworkCore;
using Microsoft.Identity.Web;
using FilmDB.DAL;
using Microsoft.IdentityModel.Logging;

var builder = WebApplication.CreateBuilder(args);

// Aktiviere detaillierte Authentifizierungsprotokollierung im Development-Modus
if (builder.Environment.IsDevelopment())
{
    IdentityModelEventSource.ShowPII = true;
}

// Add services to the container.
builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddMicrosoftIdentityWebApi(options =>
    {
        builder.Configuration.Bind("AzureAd", options);
        options.TokenValidationParameters.ValidateIssuer = true;
        options.TokenValidationParameters.ValidateAudience = true;
        options.TokenValidationParameters.ValidateLifetime = true;
        options.TokenValidationParameters.ValidAudiences = new[] 
        { 
            builder.Configuration["AzureAd:ClientId"],
            $"api://{builder.Configuration["AzureAd:ClientId"]}",
            builder.Configuration["AzureAd:Audience"]
        };
        options.TokenValidationParameters.ValidIssuer = $"https://sts.windows.net/{builder.Configuration["AzureAd:TenantId"]}/";
    }, options => { builder.Configuration.Bind("AzureAd", options); });

builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.WithOrigins("http://localhost:5002")
              .AllowAnyMethod()
              .AllowAnyHeader()
              .AllowCredentials()
              .WithExposedHeaders("WWW-Authenticate");
    });
});

// Add services to the container.
// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddControllers();

// Configure DbContext
builder.Services.AddDbContext<FilmDBContext>(options =>
    options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
app.UseCors();

app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
