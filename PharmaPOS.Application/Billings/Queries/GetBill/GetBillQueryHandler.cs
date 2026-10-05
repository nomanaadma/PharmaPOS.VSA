using PharmaPOS.Domain.Common.Errors;
using ErrorOr;
using Mapster;
using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Domain.BillingAggregate;

namespace PharmaPOS.Application.Billings.Queries.GetBill;

public class GetBillQueryHandler(
	IBillRepository billRepo,
	IBatchRepository batchRepo,
	IMedicineRepository medicineRepo,
	IPaymentMethodRepository paymentMethodRepo) : IRequestHandler<GetBillQuery, ErrorOr<BillResponse>>
{
	public async Task<ErrorOr<BillResponse>> Handle(GetBillQuery query, CancellationToken ct)
	{
		var bill = await billRepo.GetBillWithItemsAsync(query.Id, ct);
		
		if (bill == null)
			return CommonErrors<Bill>.NotFound(query.Id);
		
		var batchIds = bill.Items.Select(i => i.BatchId).Distinct().ToList();
		var batchesById = await batchRepo.GetBatchByIdsAsync(batchIds, ct); 

		var medicineIds = bill.Items.Select(b => b.MedicineId).Distinct().ToList();
		var medicineNames = await medicineRepo.GetMedicineNamesByIdsAsync(medicineIds, ct);

		var paymentMethodName = await paymentMethodRepo.GetMethodNameByIdAsync(bill.MethodId, ct);
		
		var billResponse = bill.Adapt<BillResponse>();
		
		billResponse.PaymentMethodName = paymentMethodName;
		
		foreach (var item in billResponse.Items)
		{
			item.MedicineName = medicineNames.GetValueOrDefault(item.MedicineId, "");

			batchesById.TryGetValue(item.BatchId, out var batch);

			item.BatchName = batch?.BatchName ?? "";
			item.Expiry = batch?.Expiry ?? "";
		}
		
		return billResponse;
	}
}

