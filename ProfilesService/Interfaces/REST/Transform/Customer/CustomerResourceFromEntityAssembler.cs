using ProfilesService.Interfaces.REST.Resources.Customer;

namespace ProfilesService.Interfaces.REST.Transform.Customer;

public class CustomerResourceFromEntityAssembler
{
    public static CustomerResource ToResourceFromEntity(Domain.Model.Aggregates.Customer entity) =>
    new(entity.Id, entity.Username, entity.Name, entity.Surname,entity.Email,entity.Phone, entity.State);

}