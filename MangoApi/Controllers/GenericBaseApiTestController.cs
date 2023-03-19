using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MangoApi;

//[NonController] controllerı gizler, yokmuş gibi davranır, erişilemez
[Route("mangoapi/v1.0/[controller]/[action]")]
[ApiController]
public class GenericBaseApiTestController : GenericBaseApiController
{
	public GenericBaseApiTestController()
	{

	}

	//[NonAction] //methodu gizler, yokmuş gibi davranır, erişilemez
	[HttpGet]
	public string Get(string id)
	{
		return $"Generic {id}";
	}
}
