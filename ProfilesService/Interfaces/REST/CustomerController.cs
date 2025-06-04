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
        // try
        // {
        //     
        // }
        // catch (Exception ex)
        // {
        //     // Log the exception (ex) details here for debugging
        //     return StatusCode(StatusCodes.Status500InternalServerError, "Internal server error.");
        // }
        var result = await _customerCommandService
            .Handle(CreateCustomerCommandFromResourceAssembler
                .ToCommandFromResource(resource));
        return StatusCode(StatusCodes.Status201Created, result);
    }


    [HttpPut("{id}")]
    public async Task<IActionResult> UpdateCustomer([FromBody] UpdateCustomerResource resource)
    {
        var result = await _customerCommandService
            .Handle(UpdateCustomerCommandFromResourceAssembler
                .ToCommandFromResource(resource));
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
