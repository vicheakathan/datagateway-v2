using Microsoft.AspNetCore.Mvc;
using System.Data.SqlTypes;

namespace WebApplication1.Controllers.DataGateway
{
    [ApiController]
    [Route("api/[controller]")]
    public class SaleTransactionController : ControllerBase
    {
        private readonly SaleTransactionManager _saleTransactionManager;

        public SaleTransactionController(SaleTransactionManager _saleTransactionManager)
        {
            this._saleTransactionManager = _saleTransactionManager;
        }

        [HttpPost]
        public async Task<object> PostSaleTransaction([FromBody] ClientDataGateway entity)
        {
            try
            {
                var response = await _saleTransactionManager.SubmitSaleTransaction(entity);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
