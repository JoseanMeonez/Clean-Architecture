using Microsoft.Extensions.DependencyInjection;

namespace Application.Mediator;

public class Mediator(IServiceProvider serviceProvider) : IMediator
{
	public async Task<TResponse> Send<TResponse>(
		IRequest<TResponse> request,
		CancellationToken cancellationToken = default)
	{
		Type handlerType = typeof(IRequestHandler<,>).MakeGenericType(request.GetType(), typeof(TResponse));

		dynamic handler = serviceProvider.GetRequiredService(handlerType);

		return await handler.Handle((dynamic)request, cancellationToken);
	}
}