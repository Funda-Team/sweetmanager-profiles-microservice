using System.ComponentModel.DataAnnotations.Schema;
using EntityFrameworkCore.CreatedUpdatedDate.Contracts;

namespace ProfilesService.Domain.Model.Aggregates;

public partial class Customer : IEntityWithCreatedUpdatedDate
{
    [Column("CreatedAt")] public DateTimeOffset? CreatedDate { get; set; } = DateTimeOffset.Now;
    [Column("UpdatedAt")] public DateTimeOffset? UpdatedDate { get; set; } = DateTimeOffset.Now;
}