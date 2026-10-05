using System.Text;
using Mapster;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Mappers;

public static class BillingMapper
{
	
	public static void Register(TypeAdapterConfig config)
	{
		config.NewConfig<BillEditResponse, BillingFormModel>()
			.Map(dest => dest.Method, src => src.MethodId);

		config.NewConfig<BillEditItemDto, BillingItemFormModel>()
			.Map(dest => dest.Name, src => src.MedicineName)
			.Map(dest => dest.Batch, src => src.BatchId);

		config.NewConfig<BillEditBatchDto, BillingItemBatchesFormModel>()
			.Map(dest => dest.Batch, src => src.BatchName);
	}
	
	
	public static IEnumerable<object> MapToBills(IEnumerable<BillingListResponse> bills, bool canView, bool canEdit, bool canDelete)
    {
        var canAction = canView || canEdit || canDelete;
        
        var actionTemplateBuilder = new StringBuilder();

        if (canAction)
        {
	        if (canView || canEdit)
	        {
		        actionTemplateBuilder.Append("""
                 <div class="dropdown d-inline-block">
                     <a class="text-primary edit dropdown-toggle" data-toggle="dropdown">
                         <i class="las la-ellipsis-h"></i>
                     </a>
                     <ul class="dropdown-menu dropdown-menu-right">
                 """);

		        if (canView)
		        {
			        actionTemplateBuilder.Append("""
                     <li>
                         <a href="/Medicines/Billing/View/{0}">
                             <i class="las la-laptop pr-2"></i>View
                         </a>
                     </li>
                     """);
		        }

		        if (canEdit)
		        {
			        actionTemplateBuilder.Append("""
                     <li>
                         <a href="/Medicines/Billing/Edit/{0}">
                             <i class="las la-edit pr-2"></i>Edit
                         </a>
                     </li>
                     """);
		        }

		        actionTemplateBuilder.Append("""
                     </ul>
                 </div>
                 """);
	        }

	        if (canDelete)
	        {
		        actionTemplateBuilder.Append("""
                 <a class="table-delete text-danger delete" data-toggle="tooltip" title="Delete">
                                     <i class="las la-trash-alt"></i>
                                     <input type="hidden" value="{0}">
                 </a>
                 """);
	        }
        }
        
        // 2. Convert the builder to a final template string ONCE.
        var actionTemplate = actionTemplateBuilder.ToString();

        return bills.Select(mb =>
        {
	        
	        // Simply replace the placeholder with the actual ID.
	        // If there are no actions, string.Replace is never called on an empty string anyway.
	        var actionHtml = canAction 
		        ? actionTemplate.Replace("{0}", mb.Id.ToString()) 
		        : string.Empty;

            return new
            {
                id = mb.Id,
                name = mb.Name,
                subtotal = mb.SubTotal.ToCrF2(),
                tax = mb.Tax.ToCrF2(),
                discount = mb.Discount.ToCrF2(),
                amount = mb.Amount.ToCrF2(),
                date = mb.Date.Format(),
                action = actionHtml
            };
        }).ToList();
    }

    
    
}
