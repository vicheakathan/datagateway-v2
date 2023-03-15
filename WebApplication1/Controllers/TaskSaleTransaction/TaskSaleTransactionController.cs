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
                var response = _taskSaleTransactionManager.SubmitError();

                return Ok(response);
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }
    }
}
