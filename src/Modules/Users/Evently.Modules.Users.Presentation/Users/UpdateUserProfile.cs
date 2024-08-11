﻿using System.Security.Claims;
using Evently.Common.Domain;
using Evently.Common.Infrastructure.Authentication;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Users.Application.Users.UpdateUser;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Users.Presentation.Users;

internal sealed class UpdateUserProfile : IEndpoint
{
	public void Map(IEndpointRouteBuilder app)
	{
		app.MapPut(UseCases.Users.BasePath + "/profile", async (Request request, ClaimsPrincipal claims, ISender sender) =>
			{
				Result result = await sender.Send(new UpdateUserCommand(
					claims.GetUserId(),
					request.FirstName,
					request.LastName));

				return result.Match(Results.NoContent, ApiResults.Problem);
			})
			.RequireAuthorization(Permissions.ModifyUser)
			.WithTags(UseCases.Users.Tag);
	}

	internal sealed class Request
	{
		public string FirstName { get; init; }

		public string LastName { get; init; }
	}
}
