using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ProfilesService.Domain.Model.Queries.Provider;
using ProfilesService.Domain.Services.Provider;
using ProfilesService.Interfaces.REST.Resources.Provider;
using ProfilesService.Interfaces.REST.Transform.Provider;

namespace ProfilesService.Interfaces.REST
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces(MediaTypeNames.Application.Json)]
    public class ProviderController : ControllerBase
    {
        private readonly IProviderCommandService _providerCommandService;
        private readonly IProviderQueryService _providerQueryService;

        public ProviderController(
            IProviderCommandService providerCommandService,
            IProviderQueryService providerQueryService)
        {
            _providerCommandService = providerCommandService;
            _providerQueryService = providerQueryService;
        }

        [HttpPost("create")]
        public async Task<IActionResult> CreateProvider([FromBody] CreateProviderResource resource)
        {
            try
            {
                var result = await _providerCommandService
                    .Handle(CreateProviderCommandFromResourceAssembler
                        .ToCommandFromResource(resource));
                
                return Ok(result);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpPut("update/{id:int}")]
        public async Task<IActionResult> UpdateProvider([FromBody] UpdateProviderResource resource, [FromRoute] int id)
        {
            var result = await _providerCommandService
                .Handle(UpdateProviderCommandFromResourceAssembler
                    .ToCommandFromResource(id, resource));
            if (result is false)
                return BadRequest();
            return Ok(result);
        }
        
        [HttpGet("get-all/{hotelId:int}")]
        public async Task<IActionResult> AllProviders(int hotelId)
        {
            var providers = await _providerQueryService
                .Handle(new GetAllProvidersQuery(hotelId));

            var providerResource = providers.Select
                (ProviderResourceFromEntityAssembler
                    .ToResourceFromEntity);

            return Ok(providerResource);
        }
    }
}
