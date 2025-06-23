using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Interfaces.REST.Resources.Provider;

public record CreateProviderResource(string Name, string Address, string Email, int Phone, int HotelId);

