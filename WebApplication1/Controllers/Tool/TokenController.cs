using ClassLibrary1.Core.Client.Authorize;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.Tool
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly SystemUserManager systemUserManager;
        public TokenController(SystemUserManager systemUserManager)
        {
            this.systemUserManager = systemUserManager;
        }

        [HttpPost]
        public async Task<object> Post([FromBody] BaseCredential credential)
        {
            try
            {
                var token = await systemUserManager.Authorize(credential);

                return Ok(token);
            }
            catch (UnauthorizedAccessException)
            {
                return Unauthorized();
            }
            catch (Exception e)
            {
                return StatusCode(500, e);
            }
        }
    }
}
