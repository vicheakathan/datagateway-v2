using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CompanyController : ControllerBase
    {
        private readonly CompanyManager _companyManager;
        public CompanyController(CompanyManager _companyManager) 
        {
            this._companyManager = _companyManager;
        }

        [HttpGet]
        public async Task<object> GetCompaniesAsync()
        {
            try
            {
                var response = await _companyManager.GetCompaniesAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPost]
        public async Task<object> AddCompaniesAsync([FromBody] ClientCompany compnay)
        {
            try
            {
                var response = await _companyManager.AddCompaniesAsync(compnay);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }

        [HttpPut]
        public async Task<object> UpdateCompaniesAsync([FromBody] ClientCompany compnay)
        {
            try
            {
                var response = await _companyManager.UpdateCompaniesAsync(compnay);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest();
            }
        }
    }
}
