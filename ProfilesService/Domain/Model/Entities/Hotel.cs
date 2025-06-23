using ProfilesService.Domain.Model.Commands.Hotel;

namespace ProfilesService.Domain.Model.Entities;

public partial class Hotel
{
    public int Id { get; set; }

    public int OwnersId { get; set; }

    public string? Name { get; set; }

    public string? Description { get; set; }

    public string? Address { get; set; }

    public int Phone { get; set; }

    public string? Email { get; set; }

    public Hotel()
    {
        
    }
    
    public Hotel(int ownersId, string name, string description, string address, int phone, string email)
    {
        OwnersId = ownersId;
        Name = name;
        Description = description;
        Address = address;
        Phone = phone;
        Email = email;
    }
    
    public Hotel(CreateHotelCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Name) || command.Name.Length < 2 || command.Name.Length > 50)
            throw new ArgumentException("Name is required, cannot be null or blank, it must be between 2 and 50 characters.");

        if (string.IsNullOrWhiteSpace(command.Description) || command.Description.Length < 2 || command.Description.Length > 100)
            throw new ArgumentException("Description is required, cannot be null or blank, it must be between 2 and 100 characters.");

        if (string.IsNullOrWhiteSpace(command.Address) || command.Address.Length < 2 || command.Address.Length > 100)
            throw new ArgumentException("Address is required, cannot be null or blank, it must be between 2 and 100 characters.");

        if (string.IsNullOrWhiteSpace(command.Email) || !command.Email.Contains("@"))
            throw new ArgumentException("A valid email is required and cannot be null or blank.");
        
        if (command.Phone < 100000000 || command.Phone > 9999999999)
            throw new ArgumentException("Phone is required, cannot be null or blank, it must be between 2 and 50 characters.");
        
        OwnersId = command.OwnersId;
        Name = command.Name.ToUpper();
        Description = command.Description.ToUpper();
        Address = command.Address.ToUpper();
        Phone = command.Phone;
        Email = command.Email;
    }
    
    public Hotel(UpdateHotelCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Email) || !command.Email.Contains("@"))
            throw new ArgumentException("A valid email is required and cannot be null or blank.");
        
        if (string.IsNullOrWhiteSpace(command.Name) || command.Name.Length < 2 || command.Name.Length > 50)
            throw new ArgumentException("Name is required, cannot be null or blank, it must be between 2 and 50 characters.");

        if (command.Phone < 100000000 || command.Phone > 9999999999)
            throw new ArgumentException("Phone is required, cannot be null or blank, it must be between 2 and 50 characters.");
        Name= command.Name.ToUpper();
        Phone = command.Phone;
        Email = command.Email;
    }
}
