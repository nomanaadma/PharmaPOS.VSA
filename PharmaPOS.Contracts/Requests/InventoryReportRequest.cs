namespace PharmaPOS.Contracts.Requests;

public class InventoryReportRequest
{
	public DateTime? Start { get; set; }
	public DateTime? End { get; set; }
	public int? MedicineId { get; set; }
	public string? MedicineName { get; set; }
}