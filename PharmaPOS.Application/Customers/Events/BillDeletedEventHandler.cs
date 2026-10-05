using MediatR;
using PharmaPOS.Application.Common.Interfaces;
using PharmaPOS.Domain.BillingAggregate.Events;
using PharmaPOS.Shared.Enums;

namespace PharmaPOS.Application.Customers.Events;

public class BillDeletedEventHandler(
    ICustomerRepository customerRepo,
    IBillRepository billRepo,
    IUnitOfWork unitOfWork
) : INotificationHandler<BillDeletedEvent>
{
    public async Task Handle(BillDeletedEvent notification, CancellationToken ct)
    {
        
        var customer = await customerRepo.GetByIdAsync(notification.CustomerId, ct);
        
        if (customer == null) return;
     
        if (customer.Gender != Gender.NotSpecified) return; 
        
        var hasBills = await billRepo.HasBillsByCustomerAsync(notification.CustomerId, ct);
        
        if (hasBills) return; 
        
        customerRepo.Remove(customer);
        await unitOfWork.SaveChangesAsync(ct);
        
    }
}
