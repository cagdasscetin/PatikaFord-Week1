using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MangoApi.Controllers;

public class Employee
{
	[Required] //zaten alt satırda minimum sınır belirtildiği için required yazmasına gerek yok
	[StringLength(maximumLength: 250, MinimumLength = 10, ErrorMessage = "Invalid name.")]
	public string Name { get; set; }

	[EmailAddress(ErrorMessage = "Email adress is not valid.")]
	public string Email { get; set; }
	
	[Phone(ErrorMessage = "Phone is not valid.")]
	public string Phone { get; set; }
	
	[Range(minimum:30, maximum:400, ErrorMessage = "Hourly salary does not fall within allowed range.")]
	public double HourlySalary { get; set; }
}

[Route("mangoapi/v1.0/[controller]")]
[ApiController]
public class EmployeeController : ControllerBase
{
	public EmployeeController()
	{

	}

	[HttpPost]
	public string Post([FromBody] Employee request)
	{
		return DateTime.UtcNow.ToString();
	}
}
