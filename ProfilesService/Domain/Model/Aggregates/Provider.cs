namespace ProfilesService.Domain.Model.Aggregates;

public partial class Provider
{
    public int Id { get; set; }

    public string? Name { get; set; }

    public string? Address { get; set; }

    public string? Email { get; set; }

    public int? Phone { get; set; }

    public string? State { get; set; }

    public int? HotelsId { get; set; }
}
