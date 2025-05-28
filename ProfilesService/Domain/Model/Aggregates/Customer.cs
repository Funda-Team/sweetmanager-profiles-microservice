using ProfilesService.Domain.Model.Commands.Customer;
using ProfilesService.Domain.Model.ValueObject;

namespace ProfilesService.Domain.Model.Aggregates;

public partial class Customer
{
    public int Id { get; set; }

    public string? Username { get; set; }

    public string? Name { get; set; }

    public string? Surname { get; set; }

    public string? Email { get; set; }

    public int Phone { get; set; }

    public StateType State { get; set; }

    public int? HotelsId { get; set; }

    public Customer()
    {
    }
    public Customer(int id, string username, string name, string surname, string email, int phone, StateType state)
    {
        Id = id;
        Username = username;
        Name = name;
        Surname = surname;
        Email = email;
        Phone = phone;
        State = state;
    }
    
    public Customer(CreateCustomerCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Username) || command.Username.Length < 3 || command.Username.Length > 50)
            throw new ArgumentException("Username is required, cannot be null or blank, it must be between 3 and 50 characters.");

        if (string.IsNullOrWhiteSpace(command.Name) || command.Name.Length < 2 || command.Name.Length > 50)
            throw new ArgumentException("Name is required, cannot be null or blank, it must be between 2 and 50 characters.");

        if (string.IsNullOrWhiteSpace(command.Surname) || command.Surname.Length < 2 || command.Surname.Length > 50)
            throw new ArgumentException("Surname is required, cannot be null or blank, it must be between 2 and 50 characters.");

        if (string.IsNullOrWhiteSpace(command.Email) || !command.Email.Contains("@"))
            throw new ArgumentException("A valid email is required and cannot be null or blank.");
        
        Username = command.Username;
        Name = command.Name.ToUpper();
        Surname = command.Surname.ToUpper();
        Email = command.Email;
        Phone = command.Phone;
        State = StateType.Active;
    }

    public Customer(UpdateCustomerCommand command)
    {
        if (string.IsNullOrWhiteSpace(command.Email) || !command.Email.Contains("@"))
            throw new ArgumentException("A valid email is required and cannot be null or blank.");

        if (command.Phone < 1000000000 || command.Phone > 999999999)
            throw new ArgumentException("Phone must be a 10-digit number.");

        if (string.IsNullOrWhiteSpace(command.State.ToString()) || command.State != StateType.Active || command.State != StateType.Inactive)
            throw new ArgumentException("State is required, cannot be null or blank, it must be Active or Inactive.");

        this.Email = command.Email;
        this.Phone = command.Phone;
        this.State = command.State;
    }
}
