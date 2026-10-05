using System.Text;
using PharmaPOS.Contracts.Responses;
using PharmaPOS.Razor.Extensions;

namespace PharmaPOS.Razor.Mappers;

public static class PurchaseMapper
{
    public static IEnumerable<object> MapToPurchases(IEnumerable<PurchaseListResponse> purchases, bool canView, bool canEdit, bool canDelete)
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
                         <a href="/Medicines/Purchase/View/{0}">
                             <i class="las la-laptop pr-2"></i>View
                         </a>
                     </li>
                     """);
		        }

		        if (canEdit)
		        {
			        actionTemplateBuilder.Append("""
                     <li>
                         <a href="/Medicines/Purchase/Edit/{0}">
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
        

        return purchases.Select(mp =>
        {
	        var actionHtml = canAction 
		        ? actionTemplate.Replace("{0}", mp.Id.ToString()) 
		        : string.Empty;
            
            return new
            {
                id = mp.Id,
                name = mp.SupplierName,
                subtotal = mp.SubTotal.ToCrF2(),
                tax = mp.Tax.ToCrF2(),
                discount = mp.Discount.ToCrF2(),
                amount = mp.Amount.ToCrF2(),
                date = mp.Date.Format(),
                action = actionHtml
            };
        }).ToList();
    }
    
}
