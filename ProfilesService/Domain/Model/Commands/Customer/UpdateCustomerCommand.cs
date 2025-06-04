using System.ComponentModel.DataAnnotations;
using System.Configuration;
using Microsoft.EntityFrameworkCore.Query;
using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Domain.Model.Commands.Customer;

public record UpdateCustomerCommand(
    [Required]
    int Id,
    
    [Required]
    [EmailAddress] string Email,
    
    [Required]
    [Range(1000000000, 9999999999)]
    int Phone,
    [Required]
    StateType State
    );
    