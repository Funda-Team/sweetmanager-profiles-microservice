using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Interfaces.REST.Resources.Customer;

public record UpdateCustomerResource(int Id, string Email, int Phone, StateType State);