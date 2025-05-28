using System.ComponentModel.DataAnnotations;
using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Domain.Model.Commands.Provider;

public record CreateProviderCommand(
    [Required]
    [StringLength(50, MinimumLength = 3)]
    string Name,
    [Required]
    [StringLength(100, MinimumLength = 10)]
    string Address,
    [Required]
    [EmailAddress]
    string Email,
    [Required]
    [Range(1000000000, 9999999999)]
    int Phone
    );