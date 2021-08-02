using Microsoft.AspNetCore.Mvc;

namespace BasisTheory.net.AcceptanceTests.Encryption.Azure.Helpers
{
    [Route("encryption/azure")]
    [ApiController]
    public class AzureEncryptionController : ControllerBase
    {
        [HttpGet]
        public IActionResult Version()
        {
            return Ok();
        }
    }
}
