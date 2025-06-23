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
            if (await customerRepository.EmailExistsAsync(command.Email))
                throw new InvalidOperationException("Email already exists");
                
            if (await customerRepository.UsernameExistsAsync(command.Username))
                throw new InvalidOperationException("Username already exists");
            await customerRepository.AddAsync(new(command));
            await unitOfWork.CommitAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    public async Task<bool> Handle(UpdateCustomerCommand command)
    {
        var customer = await customerRepository.FindByIdAsync(command.Id);
        if (customer == null)
            throw new InvalidOperationException("Customer not found");

        if (command.Email != customer.Email && await customerRepository.EmailExistsAsync(command.Email))
            throw new InvalidOperationException("Email already exists");

        return await customerRepository.UpdateCustomerStateAsync
            (command.Id, command.Email, command.Phone, command.State);
    }
}