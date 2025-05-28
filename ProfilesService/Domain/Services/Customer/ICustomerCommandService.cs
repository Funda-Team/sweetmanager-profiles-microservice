using ProfilesService.Domain.Model.Commands.Customer;

namespace ProfilesService.Domain.Services.Customer;

public interface ICustomerCommandService
{
    Task<bool> Handle(CreateCustomerCommand command);
    
    Task<bool> Handle(UpdateCustomerCommand command);
}