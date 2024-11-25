using Application.Features.Customers.Requests;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;

[Route("api/[controller]")]
[ApiController]
public class CustomerController : ControllerBase
{
	// GET: api/<CustomerController>
	[HttpGet]
	public async Task<IActionResult> GetAll(GetAllCustomersRequest request) => Ok(await Mediator.Send(request));

	// GET api/<CustomerController>/5
	[HttpGet("{id:int}")]
	public async Task<IActionResult> Get(Guid id) => Ok(await Mediator.Send(new GetCustomerByIdRequest(id)));

	// POST api/<CustomerController>
	[HttpPost]
	public void Post([FromBody] string value)
	{
		throw new NotImplementedException();
	}

	// PUT api/<CustomerController>/5
	[HttpPut("{id:int}")]
	public void Put(int id, [FromBody] string value)
	{
		throw new NotImplementedException();
	}

	// DELETE api/<CustomerController>/5
	[HttpDelete("{id}")]
	public void Delete(int id)
	{
		throw new NotImplementedException();
	}
}
