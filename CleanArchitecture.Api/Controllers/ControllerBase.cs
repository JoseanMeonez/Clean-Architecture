using Application.Mediator;
using Microsoft.AspNetCore.Mvc;

namespace Api.Controllers;
[Route("api/[controller]")]
[ApiController]
public class ControllerBase : Microsoft.AspNetCore.Mvc.ControllerBase
{
	private IMediator? _mediator;
	protected IMediator Mediator => _mediator ??= HttpContext.RequestServices.GetService<IMediator>()!;
}
