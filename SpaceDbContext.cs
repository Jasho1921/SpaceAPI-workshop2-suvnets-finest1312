using Microsoft.EntityFrameworkCore;

public class SpaceDbContext : DbContext
{
    public SpaceDbContext(DbContextOptions options) : base(options)
    { }

    public DbSet<Space> Spaces { get; set; }
    public DbSet<SatelliteImage> SatelliteImages { get; set; }
    public DbSet<CelestialBody> CelestialBodies { get; set; }
    public DbSet<WeatherForecast> WeatherForecasts { get; set; }
    public DbSet<LocationFunFact> FunFacts { get; set; }


}

public class LocationFunFact
{
    public int ID { get; set; }
    public string Planet { get; set; } = string.Empty;
    public string Fact { get; set; } = string.Empty;
}

public class Space
{
    public int ID { get; set; }
    public string? Title { get; set; }
    public string? Category { get; set; }
    public string? Fact { get; set; }
}

public class SatelliteImage
{
    public int ID { get; set; }
    public string? City { get; set; }
    public string ImageUrl { get; set; } = string.Empty;
}

public class CelestialBody
{
    public int ID { get; set; }
    public string ApiId { get; set; } = string.Empty; // lowercase engelska för enkel sökning t.ex. "earth", "pluto"
    public string EnglishName { get; set; } = string.Empty;
    public bool IsPlanet { get; set; }     // true för de 8, false för moon/pluto
    public string BodyType { get; set; } = string.Empty; // "Planet", "Moon", "Dwarf Planet"
    public double? SemiMajorAxis { get; set; } // miljoner km
    public double MeanRadius { get; set; } // km
    public string Mass { get; set; } = string.Empty; // t.ex. "5.972 × 10²⁴ kg"
    public double Density { get; set; } // g/cm³
    public double Gravity { get; set; } // m/s²
    public double SideralOrbit { get; set; } // dagar runt solen (eller runt planet för moon)
    public double SideralRotation { get; set; } // timmar
    public int? MoonsCount { get; set; }
    public string? AroundPlanet { get; set; } // bara för månar
    public string Description { get; set; } = string.Empty;
}

public class WeatherForecast
{
    public int ID { get; set; }
    public string City { get; set; } = string.Empty;
    public string Message { get; set; } = string.Empty;
}

