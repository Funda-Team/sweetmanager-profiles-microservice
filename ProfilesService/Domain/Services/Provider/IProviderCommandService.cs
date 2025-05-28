using ProfilesService.Domain.Model.Commands.Provider;

namespace ProfilesService.Domain.Services.Provider;

public interface IProviderCommandService
{
    Task<bool> Handle (CreateProviderCommand command);
    
    Task<bool> Handle (UpdateProviderCommand command);
}