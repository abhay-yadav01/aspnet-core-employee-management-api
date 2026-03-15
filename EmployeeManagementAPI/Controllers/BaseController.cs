using Microsoft.AspNetCore.Mvc;

namespace EmployeeManagementAPI.Controllers
{
    [ApiController]
    public abstract class BaseController : ControllerBase
    {
        // Method02 : OkResponse (200)
        protected IActionResult OkResponse(string message, object? data = null)
        {
            return StatusCode(StatusCodes.Status200OK, new
            {
                statusCode = StatusCodes.Status200OK,
                success = true,
                message = message,
                data = data
            });
        }

        // Method03 : CreateResponse (201)
        protected IActionResult CreateResponse(string message, object? data = null)
        {
            return StatusCode(StatusCodes.Status201Created, new
            {
                statusCode = StatusCodes.Status201Created,
                success = true,
                message = message,
                data = data
            });
        }

        // Method04 : NotModifiedResponse (304)
        protected IActionResult NotModifiedResponse(string message)
        {
            return StatusCode(StatusCodes.Status304NotModified, new
            {
                statusCode = StatusCodes.Status304NotModified,
                success = true,
                message = message
            });
        }

        // Method05 : BadRequestResponse (400)
        protected IActionResult BadRequestResponse(string message)
        {
            return StatusCode(StatusCodes.Status400BadRequest, new
            {
                statusCode = StatusCodes.Status400BadRequest,
                success = false,
                message = message
            });
        }

        // Method06 : UnauthorizedResponse (401)
        protected IActionResult UnauthorizedResponse(string message)
        {
            return StatusCode(StatusCodes.Status401Unauthorized, new
            {
                statusCode = StatusCodes.Status401Unauthorized,
                success = false,
                message = message
            });
        }

        // Method07 : ForbiddenResponse (403)
        protected IActionResult ForbiddenResponse(string message)
        {
            return StatusCode(StatusCodes.Status403Forbidden, new
            {
                statusCode = StatusCodes.Status403Forbidden,
                success = false,
                message = message
            });
        }

        // Method08 : NotFoundResponse (404)
        protected IActionResult NotFoundResponse(string message)
        {
            return StatusCode(StatusCodes.Status404NotFound, new
            {
                statusCode = StatusCodes.Status404NotFound,
                success = false,
                message = message
            });
        }

        // Method09 : RequestTimeoutResponse (408)
        protected IActionResult RequestTimeoutResponse(string message)
        {
            return StatusCode(StatusCodes.Status408RequestTimeout, new
            {
                statusCode = StatusCodes.Status408RequestTimeout,
                success = false,
                message = message
            });
        }

        // Method10 : ConflictResponse (409)
        protected IActionResult ConflictResponse(string message)
        {
            return StatusCode(StatusCodes.Status409Conflict, new
            {
                statusCode = StatusCodes.Status409Conflict,
                success = false,
                message = message
            });
        }

        // Method11 : InternalServerResponse (500)
        protected IActionResult InternalServerResponse(string message)
        {
            return StatusCode(StatusCodes.Status500InternalServerError, new
            {
                statusCode = StatusCodes.Status500InternalServerError,
                success = false,
                message = message
            });
        }
    }
}

