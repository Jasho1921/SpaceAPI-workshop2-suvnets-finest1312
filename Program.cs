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
            new SatelliteImage { City = "Boras", ImageUrl = "/borran.jpg" },
            new SatelliteImage { City = "Stockholm", ImageUrl = "/sthlm.jpg" },
            new SatelliteImage { City = "Goteborg", ImageUrl = "/gbg.jpg" }
        );
        context.SaveChanges();
    }

    if (!context.CelestialBodies.Any())
    {
        context.CelestialBodies.AddRange(
            new CelestialBody { ApiId = "earth", EnglishName = "Earth", IsPlanet = true, BodyType = "Planet", MeanRadius = 6371, Mass = "5.972 × 10²⁴ kg", Density = 5.51, Gravity = 9.807, SideralOrbit = 365.25, SideralRotation = 23.93, MoonsCount = 1, Description = "Our home planet." },
            new CelestialBody { ApiId = "moon", EnglishName = "Moon", IsPlanet = false, BodyType = "Moon", MeanRadius = 1737, Mass = "7.342 × 10²² kg", Density = 3.34, Gravity = 1.62, SideralOrbit = 27.32, SideralRotation = 655.72, MoonsCount = 0, AroundPlanet = "earth", Description = "Earth's only natural satellite." },
            new CelestialBody { ApiId = "jupiter", EnglishName = "Jupiter", IsPlanet = true, BodyType = "Planet", MeanRadius = 69911, Mass = "1.898 × 10²⁷ kg", Density = 1.33, Gravity = 24.79, SideralOrbit = 4332.59, SideralRotation = 9.93, MoonsCount = 79, Description = "The largest planet in our solar system." },
            new CelestialBody { ApiId = "saturn", EnglishName = "Saturn", IsPlanet = true, BodyType = "Planet", MeanRadius = 58232, Mass = "5.683 × 10²⁶ kg", Density = 0.69, Gravity = 10.44, SideralOrbit = 10759, SideralRotation = 10.7, MoonsCount = 82, Description = "Known for its prominent ring system." },
            new CelestialBody { ApiId = "pluto", EnglishName = "Pluto", IsPlanet = false, BodyType = "Dwarf Planet", MeanRadius = 1188, Mass = "1.309 × 10²² kg", Density = 1.88, Gravity = 0.62, SideralOrbit = 90560, SideralRotation = 153.3, MoonsCount = 5, Description = "A dwarf planet in the Kuiper belt." },
            new CelestialBody { ApiId = "mars", EnglishName = "Mars", IsPlanet = true, BodyType = "Planet", MeanRadius = 3389, Mass = "6.417 × 10²³ kg", Density = 3.93, Gravity = 3.71, SideralOrbit = 687, SideralRotation = 24.6, MoonsCount = 2, Description = "The red planet." }
        );
    }
    context.SaveChanges();

    if (!context.WeatherForecasts.Any())
    {
        context.WeatherForecasts.AddRange(
            new WeatherForecast { City = "Boras", Message = "Molnigt över Borås... Som vanligt, tyvärr ingen stjärnskådning den här gången!" },
            new WeatherForecast { City = "Goteborg", Message = "Stor chans att se norrsken över hela Göteborg ikväll!" },
            new WeatherForecast { City = "Stockholm", Message = "Solstormar ikväll, hoppas hela Stockholm brinner ner!" }
        );
        context.SaveChanges();
    }

    if (!context.FunFacts.Any())
    {
        context.FunFacts.AddRange(
            new LocationFunFact { Planet = "Earth", Fact = "Jorden är den enda kända planeten med flytande vatten på ytan" },
            new LocationFunFact { Planet = "Moon", Fact = "Månen är ingen planet! HAHA men kul att du sökte på det!" },
            new LocationFunFact { Planet = "Jupiter", Fact = "Jupiter har en storm som kört på i över 300 år." },
            new LocationFunFact { Planet = "Saturn", Fact = "Saturnus är så lätt att den teoretiskt skulle kunna flyta i vatten. Till skillnad från din...." },
            new LocationFunFact { Planet = "Pluto", Fact = "Pluto räknas inte som en planet längre, igen! OBS! Kommer säkert ändras snart när någon snowflake lipar." },
            new LocationFunFact { Planet = "Mars", Fact = "Mars har den största vulkanen i solsystemet – Olympus Mons." },
            new LocationFunFact { Planet = "Uranus", Fact = "Visste du att ett år på uranus är 84 jordår!" }
        );
        context.SaveChanges();
    }
}

//Ni ska inte skriva era endpoints här i Program.cs utan i separata controllers, så använd denna:
app.MapControllers();

app.Run();