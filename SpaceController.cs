using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("api/v1")]
public class SpaceController : ControllerBase
{
    [HttpGet("hello")]
    public IActionResult GetHello()
    {
        return Ok("Hello from SpaceController!");
    }
}