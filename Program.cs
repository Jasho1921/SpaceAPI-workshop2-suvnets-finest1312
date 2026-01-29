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


var app = builder.Build();

// Denna hör ihop med CORS-inställningen ovan
app.UseCors();

//Ni ska inte skriva era endpoints här i Program.cs utan i separata controllers, så använd denna:
app.MapControllers();

app.Run();

public class SpaceDbContext : DbContext
{
    public SpaceDbContext(DbContextOptions options) : base(options) { }

    public DbSet<Space> Spaces { get; set; }
}


public class Space
{
    public int ID { get; set; }
    public string Title { get; set; } = string.Empty;
    public string Category { get; set; } = string.Empty;
    public string Fact { get; set; } = string.Empty;

}