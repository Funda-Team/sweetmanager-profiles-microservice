using System.ComponentModel.DataAnnotations;

namespace ProfilesService.Domain.Model.Commands.Hotel;

public record CreateHotelCommand(
    [Required]
    [Range(1, int.MaxValue)]
    int OwnersId,
    [Required]
    [StringLength(50, MinimumLength = 3)]
    string Name,
    [Required]
    [StringLength(500, MinimumLength = 10)]
    string Description,
    [Required]
    [StringLength(100, MinimumLength = 10)]
    string Address,
    [Required]
    [Range(1000000000, 9999999999)]
    int Phone,
    [Required]
    [EmailAddress]
    string Email);