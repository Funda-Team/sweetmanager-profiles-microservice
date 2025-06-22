using ProfilesService.Domain.Model.Commands.Hotel;
using ProfilesService.Interfaces.REST.Resources.Hotel;

namespace ProfilesService.Interfaces.REST.Transform.Hotel;

public class UpdateHotelCommandFromResourceAssembler
{
    public static UpdateHotelCommand ToCommandFromResource(int id, UpdateHotelResource resource)=>
    new(id,resource.Name,resource.Phone,resource.Email);
}