using System.ComponentModel.DataAnnotations;
using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Domain.Model.Commands.Provider;

public record UpdateProviderCommand(
    [Required]
    [Range(1, int.MaxValue)]
    int Id,
    [Required]
    [StringLength(100, MinimumLength = 10)]
    string Address,
    [Required]
    [EmailAddress]
    string Email,
    [Required]
    [Range(1000000000, 9999999999)]
    int Phone,
    [Required]
    StateType State);