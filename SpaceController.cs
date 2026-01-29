using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;


[ApiController]
[Route("/api/space")]
public class SpaceController : ControllerBase
{
    private readonly SpaceDbContext _context;

    public SpaceController(SpaceDbContext context)
    {
        _context = context;
    }

    // GET /api/satellite/boras
    [HttpGet("satellite/{city}.jpg")]
    public IActionResult GetSatelliteImage(string city)
    {
        var image = _context.SatelliteImages
            .FirstOrDefault(x => x.City != null && x.City.Equals(city, StringComparison.OrdinalIgnoreCase));

        if (image == null) return NotFound(new { message = "Staden hittades ej" });

        //returnerar bilden istället för JSON format
        var imagePath = Path.Combine(Directory.GetCurrentDirectory(), "wwwroot", image.ImageUrl.TrimStart('/'));

        if (!System.IO.File.Exists(imagePath))
            return NotFound(new { message = "Filen hittades ej"});

        return PhysicalFile(imagePath, "image/jpeg");
    }

    // GET /api/satellite/all, returnerar JSON data, orkar inte lära mig hur man hämtar alla tre bilder just nu.
    [HttpGet("satellite/all")]
    public async Task<IActionResult> GetAllSatelliteImages()
    {
        var images = await _context.SatelliteImages.ToListAsync();

        if (images == null || !images.Any()) return NotFound(new { message = "Bilderna hittades ej" });

        return Ok(images);
    }

    [HttpGet("solarsystem/{planet}")]
    public async Task<IActionResult> GetBody(string planet)
    {
        var normalized = planet.ToLowerInvariant().Trim();

        var result = await _context.CelestialBodies
            .FirstOrDefaultAsync(b => b.ApiId == normalized || b.EnglishName.ToLower() == normalized);

        if (result == null)
        {
            return NotFound(new { error = $"Hittade inte '{planet}'. Prova: earth, moon, jupiter, saturn, pluto, mars..." });
        }

        return Ok(result);
    }


    [HttpGet("weather/{city}")]
    public IActionResult GetWeatherFromSpace(string city)
    {
        var forecast = _context.WeatherForecasts
            .FirstOrDefault(w => w.City.Equals(city, StringComparison.OrdinalIgnoreCase));

        if (forecast != null) return Ok(forecast.Message);

        return Ok($"Ingen prognos för {city} idag... Men rymden ser fin ut härifrån iallafall!");
    }

    [HttpGet("funfact/{planet}")]
    public IActionResult GetLocationFunFact(string planet)
    {
        var funFact = _context.FunFacts
            .FirstOrDefault(f => f.Planet.Equals(planet, StringComparison.OrdinalIgnoreCase));

        if (funFact == null)
            return NotFound($"Ingen kul fakta hittades för {planet}");

        return Ok(funFact.Fact);
    }
}
