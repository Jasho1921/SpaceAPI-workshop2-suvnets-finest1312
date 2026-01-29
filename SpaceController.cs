using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("/api/space")]
public class SpaceController : ControllerBase
{
    [HttpGet("hello")]
    public IActionResult GetHello()
    {
        return Ok("Hello from SpaceController!");
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