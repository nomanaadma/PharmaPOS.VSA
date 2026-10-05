using System.Reflection;
using ErrorOr;
using MediatR;
using PharmaPOS.Application.Common.Authorization;
using PharmaPOS.Application.Common.Interfaces;

namespace PharmaPOS.Application.Common.Behaviors;

public class AuthorizationBehavior<TRequest, TResponse>(ICurrentUserProvider currentUserProvider)
	: IPipelineBehavior<TRequest, TResponse>
		where TRequest : IRequest<TResponse>
{
	public async Task<TResponse> Handle(
		TRequest request,
		RequestHandlerDelegate<TResponse> next,
		CancellationToken cancellationToken)
	{
		var authorizationAttributes = request.GetType()
			.GetCustomAttributes<AuthorizeCommandAttribute>()
			.ToList();

		if (authorizationAttributes.Count == 0)
		{
			return await next(cancellationToken);
		}

		var currentUser = currentUserProvider.GetCurrentUser();

		// Check Permissions (claims-based)
		var requiredPermissions = authorizationAttributes
			.SelectMany(attr => attr.Permissions?.Split(',') ?? [])
			.ToList();

		if (requiredPermissions.Count > 0 && requiredPermissions.Except(currentUser.Permissions).Any())
		{
			return Forbid("You do not have permission to perform this action.");
		}

		// Check Roles
		var requiredRoles = authorizationAttributes
			.SelectMany(attr => attr.Roles?.Split(',') ?? [])
			.ToList();

		if (requiredRoles.Count > 0 && requiredRoles.Except(currentUser.Roles).Any())
		{
			return Forbid("You do not have the required role to perform this action.");
		}

		return await next(cancellationToken);
	}

	private static TResponse Forbid(string message)
	{
		// If TResponse implements IErrorOr (commands), return a Forbidden error
		if (typeof(IErrorOr).IsAssignableFrom(typeof(TResponse)))
		{
			return (dynamic)Error.Forbidden(description: message);
		}

		// For queries returning plain types, throw so the middleware/exception handler catches it
		throw new UnauthorizedAccessException(message);
	}
}
