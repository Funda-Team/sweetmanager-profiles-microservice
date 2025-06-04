using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Interfaces.REST.Resources.Customer;

public record CreateCustomerResource(string Username, string Name, string Surname,string Email, int Phone, int HotelId);

