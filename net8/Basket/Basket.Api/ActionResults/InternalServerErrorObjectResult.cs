using Microsoft.AspNetCore.Mvc;

namespace Basket.Api.ActionResults;

// Mainly used when error handling to easily return an IActionResult.
public class InternalServerErrorObjectResult : ObjectResult
{
    public InternalServerErrorObjectResult(object error)
        : base(error)
    {
        StatusCode = StatusCodes.Status500InternalServerError;
    }
}
