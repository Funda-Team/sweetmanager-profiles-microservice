using System.ComponentModel.DataAnnotations;

namespace ProfilesService.Domain.Model.Commands.Hotel;

public record UpdateHotelCommand(
    [Required]
    [Range(1, int.MaxValue)]
    int Id,
    [Required]
    [StringLength(50, MinimumLength = 3)]
    string Name, 
    [Required]
    [StringLength(500, MinimumLength = 10)]
    int Phone, 
    [Required]
    [EmailAddress]
    string Email);