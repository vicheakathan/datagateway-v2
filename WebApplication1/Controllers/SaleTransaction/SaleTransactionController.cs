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
        public async Task<object> PostSaleTransactionAsync([FromBody] ClientDataGateway entity)
        {
            try
            {
                var response = await _saleTransactionManager.PostSaleTransactionAsync(entity);

                return Ok(response);
            }
            catch(Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        public async Task<object> GetSaleTransactionAsync()
        {
            try
            {
                var response = await _saleTransactionManager.GetSaleTransactionAsync();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

        [HttpGet]
        [Route("AddTaskByRequest")]
        public async Task<object> GETAddTaskByRequest([FromQuery] Guid saleId)
        {
            try
            {
                var response = await _saleTransactionManager.Add(saleId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
