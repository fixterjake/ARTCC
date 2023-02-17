using ARTCC.Core.Shared.Responses;
using Microsoft.AspNetCore.Mvc;
using Sentry;

namespace ARTCC.Core.API.Extensions;

public static class SentryExtensions
{
    public static ActionResult ReturnActionResult(this SentryId id)
    {
        return new BadRequestObjectResult(new Response<string?>
        {
            StatusCode = 500,
            Message = "An error has occurred",
            Data = id.ToString()
        });
    }
}