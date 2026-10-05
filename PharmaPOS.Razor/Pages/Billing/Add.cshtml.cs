using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Billings.Commands.CreateBill;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.PaymentMethods.Queries.ListPaymentMethodsLookup;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Pages.Billing;

[Authorize(Policy = Permissions.Billing.Add)]
public class AddModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public BillingFormModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(CancellationToken ct)
    {
        Input.PaymentMethods = (await sender.Send(new ListPaymentMethodsLookupQuery(), ct)).ToSelectList();
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(CancellationToken ct)
    {
        Input.PaymentMethods = (await sender.Send(new ListPaymentMethodsLookupQuery(), ct)).ToSelectList();
        
        if (!ModelState.IsValid)
        {
            NotifyError("Please check your inputs.");
            return Page();
        }
        
        var request = Input.Adapt<BillingRequest>();

        var result = await sender.Send(new CreateBillCommand(request), ct);

        if (result.IsError)
            return HandleErrors(result.Errors);

        NotifySuccess("Bill created successfully.");
        return RedirectToPage("/Billing/View", new { id = result.Value });
    }
}
