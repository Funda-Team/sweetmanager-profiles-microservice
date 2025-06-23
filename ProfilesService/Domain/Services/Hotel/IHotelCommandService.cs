using ProfilesService.Domain.Model.Commands.Hotel;

namespace ProfilesService.Domain.Services.Hotel;

public interface IHotelCommandService
{
    Task<bool> Handle(CreateHotelCommand command);
    
    Task<bool> Handle(UpdateHotelCommand command);
}