using ProfilesService.Domain.Model.Commands.Hotel;
using ProfilesService.Domain.Repositories;
using ProfilesService.Domain.Services.Hotel;
using ProfilesService.Shared.Domain.Repositories;

namespace ProfilesService.Application.Internal.CommandService;

public class HotelCommandService(IHotelRepository hotelRepository,IUnitOfWork unitOfWork):IHotelCommandService
{
    public async Task<bool> Handle(CreateHotelCommand command)
    {
        try
        {
            await hotelRepository.AddAsync(new(command));
            await unitOfWork.CommitAsync();
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }
    
    public async Task<bool> Handle(UpdateHotelCommand command)=> 
    await hotelRepository.UpdateHotelStateAsync(command.Id,command.Name,command.Phone,command.Email);
}