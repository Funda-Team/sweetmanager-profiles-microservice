using ProfilesService.Domain.Model.Commands.Customer;
using ProfilesService.Interfaces.REST.Resources.Customer;

namespace ProfilesService.Interfaces.REST.Transform.Customer;

public class CreateCustomerCommandFromResourceAssembler
{
    public static CreateCustomerCommand ToCommandFromResource(CreateCustomerResource resource)=>
    new(resource.Username, resource.Name, resource.Username, resource.Email, resource.Phone, resource.HotelId);
    
}

