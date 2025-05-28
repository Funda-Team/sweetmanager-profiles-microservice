using System.ComponentModel.DataAnnotations;
using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Domain.Model.Commands.Customer;

public record CreateCustomerCommand(
    [Required]
    [StringLength(50, MinimumLength = 3)]
    string Username,

    [Required]
    [StringLength(50, MinimumLength = 2)]
    string Name,

    [Required]
    [StringLength(50, MinimumLength = 2)]
    string Surname,

    [Required]
    [EmailAddress]
    string Email,

    [Range(1000000000, 9999999999)]
    int Phone
);