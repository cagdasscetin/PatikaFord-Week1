using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace MangoApi.Controllers;


public class EmployeeAdvance
{
    [Required] //zaten alt satırda minimum sınır belirtildiği için required yazmasına gerek yok
    [StringLength(maximumLength: 250, MinimumLength = 10, ErrorMessage = "Invalid name.")]
    public string Name { get; set; }

    [Required]
    public DateTime DateOfBirth { get; set; }

    [EmailAddress(ErrorMessage = "Email adress is not valid.")]
    public string Email { get; set; }

    [Phone(ErrorMessage = "Phone is not valid.")]
    public string Phone { get; set; }

    [Range(minimum: 30, maximum: 400, ErrorMessage = "Hourly salary does not fall within allowed range.")]
    [MinLegalSalaryRequired(minJuniorSalary: 50, minSeniorSalary: 200)]

    public double HourlySalary { get; set; }
}

public class MinLegalSalaryRequiredAttribute : ValidationAttribute
{
    public MinLegalSalaryRequiredAttribute(double minJuniorSalary, double minSeniorSalary)
    {
        MinJuniorSalary = minJuniorSalary;
        MinSeniorSalary = minSeniorSalary;
    }

    public double MinJuniorSalary { get; }
    public double MinSeniorSalary { get; }
    public string GetErrorMessage() => $"Minimum hourly salary is not valid for Age.";

    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
    {
        var employee = (EmployeeAdvance)validationContext.ObjectInstance;
        var dateBeforeThirtyYears = DateTime.Today.AddYears(-30);
        var isOlderThanThirdyYears = employee.DateOfBirth <= dateBeforeThirtyYears;
        var hourlySalary = (double)value;

        var isValidSalary = isOlderThanThirdyYears ? hourlySalary >= MinSeniorSalary : hourlySalary >= MinJuniorSalary;

        return isValidSalary ? ValidationResult.Success : new ValidationResult(GetErrorMessage());
    }
}

[Route("mangoapi/v1.0/[controller]")]
[ApiController]
public class EmployeeAdvanceController : ControllerBase
{
	public EmployeeAdvanceController()
	{

	}

	[HttpPost]
	public string Post([FromBody] EmployeeAdvance requets)
	{
        return DateTime.UtcNow.ToString();
	}



}
