using ClassLibrary1.Manager;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class TaskSaleTransactionController : ControllerBase
    {
        private readonly TaskSaleTransactionManager _taskSaleTransactionManager;

        public TaskSaleTransactionController(TaskSaleTransactionManager _taskSaleTransactionManager)
        {
            this._taskSaleTransactionManager = _taskSaleTransactionManager;
        }

        [HttpPost("SubmitIntegration")]
        public async Task<object> SubmitIntegration()
        {
            try
            {
                var response = await _taskSaleTransactionManager.SubmitIntegration();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }

        [HttpGet]
        [Route("AddTaskByRequest")]
        public async Task<object> GETAddTaskByRequest([FromQuery] Guid saleId)
        {
            try
            {
                var response = await _taskSaleTransactionManager.PostTaskSaleTransaction(saleId);

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex.Message);
            }
        }
    }
}
