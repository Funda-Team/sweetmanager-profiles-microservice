using ProfilesService.Domain.Model.Commands.Provider;
using ProfilesService.Domain.Repositories;
using ProfilesService.Domain.Services.Provider;
using ProfilesService.Shared.Domain.Repositories;

namespace ProfilesService.Application.Internal.CommandService;

public class ProviderCommandService(IProviderRepository providerRepository, IUnitOfWork unitOfWork): IProviderCommandService
{
    public async Task<bool> Handle(CreateProviderCommand command)
    {
        try
        {
            
            if (await providerRepository.EmailExistsAsync(command.Email))
                throw new InvalidOperationException("Email already exists");

            
            if (await providerRepository.NameExistsAsync(command.Name))
                throw new InvalidOperationException("Name already exists");

            await providerRepository.AddAsync(new(command));
            await unitOfWork.CommitAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    public async Task<bool> Handle(UpdateProviderCommand command)
    {
        var provider = await providerRepository.FindByIdAsync(command.Id);
        if (provider == null)
            throw new InvalidOperationException("Provider not found");

        if (command.Email != provider.Email && await providerRepository.EmailExistsAsync(command.Email))
            throw new InvalidOperationException("Email already exists");

        return await providerRepository.UpdateProviderStateAsync
            (command.Id, command.Address, command.Email, command.Phone, command.State);
    }
}