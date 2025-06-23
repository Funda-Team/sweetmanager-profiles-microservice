using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Interfaces.REST.Resources.Customer;

public record CustomerResource(int Id,string Username, string Name, string Surname,string Email, int Phone, StateType State, int HotelId);