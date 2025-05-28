using ProfilesService.Domain.Model.Commands.Customer;
using ProfilesService.Domain.Repositories;
using ProfilesService.Domain.Services.Customer;
using ProfilesService.Shared.Domain.Repositories;

namespace ProfilesService.Application.Internal.CommandService;

public class CustomerCommandService(ICustomerRepository customerRepository, IUnitOfWork unitOfWork):ICustomerCommandService
{
    public async Task<bool> Handle(CreateCustomerCommand command)
    {
        try
        {
            await customerRepository.AddAsync(new(command));
            await unitOfWork.CommitAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    public async Task<bool> Handle
        (UpdateCustomerCommand command) => 
        await customerRepository.UpdateCustomerStateAsync
        (command.Id,command.Email, command.Phone,command.State);
}