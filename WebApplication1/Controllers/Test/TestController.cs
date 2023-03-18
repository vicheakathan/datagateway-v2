using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TestController : ControllerBase
    {
        private readonly TestIntegrationManager _test;

        public TestController(TestIntegrationManager _test)
        {
            this._test = _test;
        }

        [HttpGet]
        public async Task<object> Test()
        {
            try
            {
                var response = await _test.Test();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
