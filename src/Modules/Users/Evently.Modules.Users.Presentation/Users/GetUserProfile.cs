﻿using System.Security.Claims;
using Evently.Common.Domain;
using Evently.Common.Infrastructure.Authentication;
using Evently.Common.Presentation.ApiResults;
using Evently.Common.Presentation.Endpoints;
using Evently.Modules.Users.Application.Users.GetUser;
using MediatR;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Routing;

namespace Evently.Modules.Users.Presentation.Users;

internal sealed class GetUserProfile : IEndpoint
{
    public void Map(IEndpointRouteBuilder app)
    {
        app.MapGet(UseCases.Users.BasePath + "/profile", async (ClaimsPrincipal claims, ISender sender) =>
        {
            Result<UserResponse> result = await sender.Send(new GetUserQuery(claims.GetUserId()));

            return result.Match(Results.Ok, ApiResults.Problem);
        })
        .RequireAuthorization("users:read")
        .WithTags(UseCases.Users.Tag);
    }
}
