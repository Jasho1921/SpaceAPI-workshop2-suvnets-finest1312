using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<SpaceDbContext>(options =>
            options.UseInMemoryDatabase("SpaceDb"));


builder.Services.AddControllers();

//Låt detta vara kvar! Utan denna inställning kommer inte websidan att få access till API:et.
// Läs mer här: https://developer.mozilla.org/en-US/docs/Web/HTTP/Guides/CORS
builder.Services.AddCors(options =>
{
    options.AddDefaultPolicy(policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyMethod()
              .AllowAnyHeader();
    });
});

builder.Services.AddControllers();

var app = builder.Build();

// Denna hör ihop med CORS-inställningen ovan
app.UseCors();

app.UseStaticFiles();

using (var scope = app.Services.CreateScope())
{
    var context = scope.ServiceProvider.GetRequiredService<SpaceDbContext>();

    if (!context.SatelliteImages.Any())
    {
        context.SatelliteImages.AddRange(
            new SatelliteImage { City = "Borås", ImageUrl = "/boras.jpg" },
            new SatelliteImage { City = "Stockholm", ImageUrl = "/stockholm.jpg" },
            new SatelliteImage { City = "Göteborg", ImageUrl = " /goteborg.jpg" }
        );
        context.SaveChanges();
    }
}

//Ni ska inte skriva era endpoints här i Program.cs utan i separata controllers, så använd denna:
app.MapControllers();

app.Run();