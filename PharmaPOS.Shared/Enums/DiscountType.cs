using System.ComponentModel.DataAnnotations;

namespace PharmaPOS.Shared.Enums;

public enum DiscountType
{
	[Display(Name = "%")]
	Percentage = 1,
	
	[Display(Name = "Flat")]
	Flat = 2,
}