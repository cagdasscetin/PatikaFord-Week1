using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangoApi.Controllers;


public class GeoLocation
{
    public int Id { get; set; }
    public int Lat { get; set; }
    public int Long { get; set; }
}

[Route("mangoapi/v1.0/[controller]")]
[ApiController]
public class GeoLocationController : ControllerBase
{
    private List<GeoLocation> list;

    public GeoLocationController()
    {
        list = new List<GeoLocation>();
        var rng = new Random();

        GeoLocation location1 = new GeoLocation()
        {
            Id = 1,
            Lat = rng.Next(100, 500),
            Long = rng.Next(100, 500)
        };

        list.Add(location1);
        list.Add(new GeoLocation { Id = 2, Lat = rng.Next(900, 1400), Long = rng.Next(900, 1400) });
        list.Add(new GeoLocation { Id = 3, Lat = rng.Next(900, 1400), Long = rng.Next(1500, 3400) });
    }

    [HttpGet("GetByIdQuery")]
    public GeoLocation GetByIdQuery([FromQuery] int id)
    {
        var location = list.FirstOrDefault(x => x.Id == id);
        return location;
    }

    [HttpGet("GetByIdRoute/{id}")]
    public GeoLocation GetByIdRoute(int id)
    {
        var location = list.FirstOrDefault(x => x.Id == id);
        return location;
    }

    [HttpGet("GetByIdRoute/{id}/{lat}/{lng}")]
    public string GetByIdRoute2(int id, int lat, int lng)
    {
        return $"?id={id}&lat={lat}&lng={lng}";
    }

    [HttpGet("GetByIdQuery2")]
    public string GetByIdQuery([FromQuery] int id, int lat, int lng)
    {
        var location = list.FirstOrDefault(x => x.Id == id);
        return $"?id={id}&lat={lat}&lng={lng}";
    }


    [HttpGet("GetByIdQuery3/{id}")]
    public string GetByIdQuery3([FromRoute] int id, [FromQuery] int lat, int lng)
    {
        var location = list.FirstOrDefault(x => x.Id == id);
        return $"?id={id}&lat={lat}&lng={lng}";
    }

}
