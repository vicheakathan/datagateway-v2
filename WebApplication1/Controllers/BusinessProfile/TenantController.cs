using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.BusinessProfile
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
                return BadRequest(ex);
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
                return BadRequest(ex);
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
                return BadRequest(ex);
            }
        }
    }
}
