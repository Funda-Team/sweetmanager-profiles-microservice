using System.Net.Mime;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ProfilesService.Domain.Model.Queries.Hotel;
using ProfilesService.Domain.Services.Hotel;
using ProfilesService.Interfaces.REST.Resources.Hotel;
using ProfilesService.Interfaces.REST.Transform.Hotel;

namespace ProfilesService.Interfaces.REST
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class HotelController : ControllerBase
    {
        private readonly IHotelCommandService _hotelCommandService;
        private readonly IHotelQueryService _hotelQueryService;

        public HotelController(IHotelCommandService hotelCommandService, IHotelQueryService hotelQueryService)
        {
            _hotelCommandService = hotelCommandService;
            _hotelQueryService = hotelQueryService;
        }
        
        [HttpPost("create")]
        public async Task<IActionResult> CreateHotel([FromBody] CreateHotelResource resource)
        {
            try
            {
                var result = await _hotelCommandService
                    .Handle(CreateHotelCommandFromResourceAssembler
                        .ToCommandFromResource(resource));
                if(result is false)
                    return BadRequest("Failed to create hotel");

                return Ok(result);
            }
            catch (Exception e)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error");
            }
        }

        [HttpPut("update")]
        public async Task<IActionResult> UpdateHotel([FromBody] UpdateHotelResource resource)
        {
            var result = await _hotelCommandService
                .Handle(UpdateHotelCommandFromResourceAssembler
                    .ToCommandFromResource(resource));
            if (result is false)
                return BadRequest();

            return Ok(result);
        }

        [HttpGet("all")]
        public async Task<IActionResult> AllHotels()
        {
            var hotels = await _hotelQueryService
                .handle(new GetAllHotelsQuery());
            
            var hotelsResource = hotels.Select(HotelResourceFromEntityAssembler.ToResourceFromEntity);
            
            return Ok(hotelsResource);
        }

        [HttpGet("by-owner")]
        public async Task<IActionResult> HotelsByOwnersId([FromQuery] int ownersId)
        {
            var hotel = await _hotelQueryService
                .handle(new GetHotelByOwnersIdQuery(ownersId));

            if (hotel is null)
                return BadRequest();

            var hotelResource = HotelResourceFromEntityAssembler
                .ToResourceFromEntity(hotel);

            return Ok(hotelResource);
        }
    }
}
