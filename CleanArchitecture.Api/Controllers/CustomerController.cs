using Application.Features.Customers.Requests;
using Application.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController(IMediator mediator) : ControllerBase
{
	// GET: api/<CustomerController>
	[HttpGet]
	public async Task<IActionResult> GetAll([FromQuery] GetAllCustomersRequest request)
		=> Ok(await mediator.Send(request));

	// GET api/<CustomerController>/5
	[HttpGet("{id:guid}")]
	public async Task<IActionResult> Get(Guid id)
		=> Ok(await mediator.Send(new GetCustomerByIdRequest(id)));

	// POST api/<CustomerController>
	[HttpPost]
	public void Post([FromBody] string value)
	{
		throw new NotImplementedException();
	}

	// PUT api/<CustomerController>/5
	[HttpPut("{id:guid}")]
	public void Put(Guid id, [FromBody] string value)
	{
		throw new NotImplementedException();
	}

	// DELETE api/<CustomerController>/5
	[HttpDelete("{id:guid}")]
	public void Delete(Guid id)
	{
		throw new NotImplementedException();
	}
}
