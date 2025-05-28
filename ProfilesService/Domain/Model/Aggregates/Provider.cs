using ProfilesService.Domain.Model.Commands.Provider;
using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Domain.Model.Aggregates;

public partial class Provider
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public int Phone { get; set; }

    public StateType State { get; set; }

    public int? HotelsId { get; set; }

    public Provider()
    {
        
    }
    public Provider(int id, string name, string address, string email, int phone, StateType state, int hotelsId)
    {
        Id = id;
        Name = name;
        Address = address;
        Email = email;
        Phone = phone;
        State = state;
        HotelsId = hotelsId;
    }
    public Provider(CreateProviderCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Name) || command.Name.Length < 2 || command.Name.Length > 50)
            throw new ArgumentException("Name is required, cannot be null or blank, it must be between 2 and 50 characters.");

        if (string.IsNullOrWhiteSpace(command.Address) || command.Address.Length < 2 || command.Address.Length > 100)
            throw new ArgumentException("Address is required, cannot be null or blank, it must be between 2 and 100 characters.");

        if (string.IsNullOrWhiteSpace(command.Email) || !command.Email.Contains("@"))
            throw new ArgumentException("A valid email is required and cannot be null or blank.");
        
        Name = command.Name.ToUpper();
        Address = command.Address.ToUpper();
        Email = command.Email;
        Phone = command.Phone;
        State = StateType.Active;
    }
    public Provider(UpdateProviderCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Address) || command.Address.Length < 2 || command.Address.Length > 100)
            throw new ArgumentException("Address is required, cannot be null or blank, it must be between 2 and 100 characters.");

        if (string.IsNullOrWhiteSpace(command.Email) || !command.Email.Contains("@"))
            throw new ArgumentException("A valid email is required and cannot be null or blank.");
        
        Address = command.Address.ToUpper();
        Email = command.Email;
        Phone = command.Phone;
        State = StateType.Active;
    }
    
}
