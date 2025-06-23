using ProfilesService.Domain.Model.Queries;

namespace ProfilesService.Domain.Services.Customer;

public interface ICustomerQueryService
{
    Task<IEnumerable<Model.Aggregates.Customer>> Handle(GetAllCustomersQuery query);
}