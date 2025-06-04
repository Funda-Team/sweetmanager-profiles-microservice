using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Interfaces.REST.Resources.Provider;

public record UpdateProviderResource(int Id,string Address, string Email, int Phone, StateType State, int HotelId);