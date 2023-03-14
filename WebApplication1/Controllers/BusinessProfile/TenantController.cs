using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    [Authorize]
    public class TenantController : ControllerBase
    {
        private readonly TenantManager tenantManager;

        public TenantController(TenantManager tenantManager)
        {
            this.tenantManager = tenantManager;
        }

        [HttpGet]
        public async Task<object> GetTenantAsync()
        {
            try
            {
                var reponse = await tenantManager.GetTenantAsync();

                return Ok(reponse);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<object> AddTenantAsync([FromBody] ClientTenant entity)
        {
            try
            {
                var reponse = await tenantManager.AddTenantAsync(entity);

                return Ok(reponse);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<object> UpdateTenantAsync([FromBody] ClientTenant entity)
        {
            try
            {
                var reponse = await tenantManager.UpdateTenantAsync(entity);

                return Ok(reponse);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpGet("DecryptPassword")]
        public object DecryptPassword(Guid id)
        {
            try
            {
                var response = tenantManager.DecryptPassword(id);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
