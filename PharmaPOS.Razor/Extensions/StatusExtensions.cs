
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Razor.Extensions;

public static class StatusExtensions
{
	public static string GetCssClass(this Status status)
	{
		return status == Status.Active ? "label-success" : "label-danger";
	}
}
