using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers.BusinessProfile
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
        public async Task<object> GetCompanies()
        {
            try
            {
                var response = await _companyManager.GetCompanies();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPost]
        public async Task<object> AddCompanies([FromBody] ClientCompany compnay)
        {
            try
            {
                var response = await _companyManager.AddCompanies(compnay);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpPut]
        public async Task<object> UpdateCompanies([FromBody] ClientCompany compnay)
        {
            try
            {
                var response = await _companyManager.UpdateCompanies(compnay);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
