using Microsoft.AspNetCore.Diagnostics;
using Microsoft.AspNetCore.Mvc;

namespace BuberDinner.Api.Controllers;

[ApiController]
public class ErrorsController : ControllerBase
{
    [HttpPost]
    [Route("/error")]
    public IActionResult Error()
    {
        return Problem();
    }
}