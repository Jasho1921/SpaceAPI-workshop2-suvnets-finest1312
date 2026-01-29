using Microsoft.EntityFrameworkCore;

public class SpaceDbContext : DbContext
{
    public SpaceDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Space> Spaces { get; set; }
    public DbSet<SatelliteImage> SatelliteImages { get; set; }
}

public class Space
{
    public int Id { get; set; }
    public string? Title { get; set; }
    public string? Category { get; set; }
    public string? Fact { get; set; }
}

public class SatelliteImage
{
    public int Id { get; set; }
    public string? City { get; set; }
    public string? ImageUrl { get; set; }
}