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
    [HttpGet("/satellite/{city}")]
    public IActionResult GetSatelliteImage(string city)
    {
        var image = _context.SatelliteImages
            .FirstOrDefault(x => x.City != null && x.City.ToLower() == city.ToLower());

        if (image == null) return NotFound(new { message = "City not found" });

        return Ok(image);
    }

    // GET /api/satellite/all
    [HttpGet("satellite/all")]
    public IActionResult GetAllSatelliteImages()
    {
        return Ok(_context.SatelliteImages.ToList());
    }

    [HttpGet("{body}")]
    public async Task<IActionResult> GetBody(string body)
    {
        var normalized = body.ToLowerInvariant().Trim();

        var result = await _context.CelestialBodies
            .FirstOrDefaultAsync(b => b.ApiId == normalized || b.EnglishName.ToLower() == normalized);

        if (result == null)
        {
            return NotFound(new { error = $"Hittade inte '{body}'. Prova: earth, moon, jupiter, saturn, pluto, mars..." });
        }

        return Ok(result);
    }


    [HttpGet("weather")]
    public IActionResult GetWeatherFromSpace()
    {
        return Ok("Fint väder i rymden");
    }

    [HttpGet("location")]
    public IActionResult GetLocation()
    {
        return Ok("info om borås? Eller bara att vi valt borås?");
    }

    [HttpGet("facts")]
    public IActionResult GetLocationFunFact()
    {
        return Ok("5G strålningen är kraftig idag! Glöm ej foliehatten och paraply!");
    }

    // [HttpGet("norrsken")]
    // public async Task<IActionResult> GetListOfAurora()
    // {
    //    // var cities = await _db.Cities.Select(c => där det finns norrsken just nu ).Where
    // }
    
}




// /api/space/weather
// /api/space/location
// /api/space/facts
// /api/space/norrsken