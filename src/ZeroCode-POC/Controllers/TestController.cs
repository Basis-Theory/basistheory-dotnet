using Microsoft.AspNetCore.Mvc;
using ZeroCode_POC.Models;

namespace ZeroCode_POC.Controllers;

[ApiController]
[Route("")]
public class TestController : ControllerBase
{
    [HttpPost("/")]
    public ActionResult Post([FromBody] CreatePersonDto model)
    {
        // response should have a token id instead of ssn
        return Ok(model);
    }
}
