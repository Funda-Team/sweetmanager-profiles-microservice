using ProfilesService.Domain.Model.Commands.Customer;
using ProfilesService.Interfaces.REST.Resources.Customer;

namespace ProfilesService.Interfaces.REST.Transform.Customer;

public class UpdateCustomerCommandFromResourceAssembler
{
    public static UpdateCustomerCommand ToCommandFromResource(UpdateCustomerResource resource) =>
        new(resource.Id,resource.Email, resource.Phone, resource.State);
}