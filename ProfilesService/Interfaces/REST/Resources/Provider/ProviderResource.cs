using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Interfaces.REST.Resources.Provider;

public record ProviderResource(int Id, string Name, string Address, string Email, int Phone, StateType State);