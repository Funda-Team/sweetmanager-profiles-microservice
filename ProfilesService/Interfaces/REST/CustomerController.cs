using System.Net.Mime;
using Microsoft.AspNetCore.Mvc;
using ProfilesService.Domain.Model.Queries;
using ProfilesService.Domain.Services.Customer;
using ProfilesService.Interfaces.REST.Resources.Customer;
using ProfilesService.Interfaces.REST.Transform.Customer;

namespace ProfilesService.Interfaces.REST;


[Route("api/[controller]")]
[ApiController]
[Produces(MediaTypeNames.Application.Json)]
public class CustomerController : ControllerBase
{
    private readonly ICustomerCommandService _customerCommandService;
    private readonly ICustomerQueryService _customerQueryService;

    public CustomerController(ICustomerCommandService customerCommandService, ICustomerQueryService customerQueryService)
    {
        _customerCommandService = customerCommandService;
        _customerQueryService = customerQueryService;
    }

    [HttpPost("create")]
    public async Task<IActionResult> CreateCustomer([FromBody] CreateCustomerResource resource)
    {
        try 
        {
            var result = await _customerCommandService
                .Handle(CreateCustomerCommandFromResourceAssembler
                    .ToCommandFromResource(resource));
            return StatusCode(StatusCodes.Status201Created, result);
         }
         catch (Exception ex)
         {
             return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error.");
         }
    }


    [HttpPut("update/{id:int}")]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerResource resource, [FromRoute] int id)
    {
        var result = await _customerCommandService
            .Handle(UpdateCustomerCommandFromResourceAssembler
                .ToCommandFromResource(id, resource));
        if (result is false)
            return BadRequest();
        return StatusCode(StatusCodes.Status200OK,result);
    }
    
    [HttpGet("get-all-customers/{hotelId:int}")]
    public async Task<IActionResult> AllCustomers(int hotelId)
    {
        var customer = await _customerQueryService
            .Handle(new GetAllCustomersQuery(hotelId));

        var customerResource = customer.Select
        (CustomerResourceFromEntityAssembler
            .ToResourceFromEntity);

        return StatusCode(StatusCodes.Status200OK,customerResource);
    }
}
