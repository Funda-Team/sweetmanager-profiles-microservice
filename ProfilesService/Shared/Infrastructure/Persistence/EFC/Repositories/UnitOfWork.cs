using ProfilesService.Shared.Domain.Repositories;
using ProfilesService.Shared.Infrastructure.Persistence.EFC.Configuration;

namespace ProfilesService.Shared.Infrastructure.Persistence.EFC.Repositories
{
    public class UnitOfWork(ProfilesContext context) : IUnitOfWork
    {
        public async Task CommitAsync() => await context.SaveChangesAsync();
    }
}