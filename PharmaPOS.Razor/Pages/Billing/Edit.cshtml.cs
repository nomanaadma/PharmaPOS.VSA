using Mapster;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PharmaPOS.Application.Billings.Commands.UpdateBill;
using PharmaPOS.Application.Billings.Queries.GetBillForEdit;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.PaymentMethods.Queries.ListPaymentMethodsLookup;
using PharmaPOS.Contracts.Requests;
using PharmaPOS.Razor.Extensions;
using PharmaPOS.Razor.Models;

namespace PharmaPOS.Razor.Pages.Billing;

[Authorize(Policy = Permissions.Billing.Edit)]
public class EditModel(ISender sender) : BasePageModel
{
    [BindProperty]
    public BillingFormModel Input { get; set; } = new();

    public async Task<IActionResult> OnGetAsync(int id, CancellationToken ct)
    {
        var result = await sender.Send(new GetBillForEditQuery(id), ct);

        if (result.IsError)
            return HandleErrors(result.Errors);

        var paymentMethods = (await sender.Send(new ListPaymentMethodsLookupQuery(), ct)).ToSelectList();
        
        Input = result.Value.Adapt<BillingFormModel>();
        Input.PaymentMethods = paymentMethods;

        Console.WriteLine("working");
        
        return Page();
    }

    public async Task<IActionResult> OnPostAsync(int id, CancellationToken ct)
    {
        if (id != Input.Id)
        {
            NotifyError("Bad Request: ID mismatch.");
            return BadRequest();
        }
        
        Input.PaymentMethods = (await sender.Send(new ListPaymentMethodsLookupQuery(), ct)).ToSelectList();

        if (!ModelState.IsValid)
        {
            NotifyError("Please check your inputs.");
            return Page();
        }
        
        var request = Input.Adapt<BillingRequest>();

        var result = await sender.Send(new UpdateBillCommand(id, request), ct);

        if (result.IsError)
            return HandleErrors(result.Errors);

        NotifySuccess("Bill updated successfully.");
        return RedirectToPage("/Billing/View", new { id });
    }
}
