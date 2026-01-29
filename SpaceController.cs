using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/satellite")]
public class SpaceImageController : ControllerBase
{
    private readonly SpaceDbContext _context;

    public SpaceImageController(SpaceDbContext context)
    {
        _context = context;

        // Seed data – bara första gången
        if (!_context.SatelliteImages.Any())
        {
            _context.SatelliteImages.AddRange(
                new SatelliteImage { City = "Borås", ImageUrl = "/images/boras.jpg" },
                new SatelliteImage { City = "Stockholm", ImageUrl = "/images/stockholm.jpg" },
                new SatelliteImage { City = "Göteborg", ImageUrl = "/images/goteborg.jpg" }
            );
            _context.SaveChanges();
        }
    }

    // GET /api/satellite/boras
    [HttpGet("{city}")]
    public IActionResult GetSatelliteImage(string city)
    {
        var image = _context.SatelliteImages
            .FirstOrDefault(x => x.City.ToLower() == city.ToLower());

        if (image == null) return NotFound(new { message = "City not found" });

        return Ok(image);
    }

    // GET /api/satellite/all
    [HttpGet("all")]
    public IActionResult GetAllSatelliteImages()
    {
        return Ok(_context.SatelliteImages.ToList());
    }


    [HttpGet("weather")]
    public IActionResult GetWeatherFromSpace()
    {
        return Ok("Fint väder");
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