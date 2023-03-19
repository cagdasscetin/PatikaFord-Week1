using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangoApi;


[Route("mangoapi/v1.0/[controller]/[action]")]
[ApiController]
public class GenericBaseApiController : ControllerBase
{
    [HttpGet]
    public string HeartBeat()
    {
        return DateTime.UtcNow.ToLongDateString();
    }
}
