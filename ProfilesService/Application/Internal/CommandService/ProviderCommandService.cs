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
            await providerRepository.AddAsync(new(command));
            
            await unitOfWork.CommitAsync();
            
            return true;
        }
        catch (Exception ex)
        {
            throw new Exception(ex.Message);
        }
    }
    public async Task<bool> 
        Handle(UpdateProviderCommand command)=> 
        await providerRepository.UpdateProviderStateAsync
        (command.Id,command.Address,command.Email,command.Phone,command.State);
    
}