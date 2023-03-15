using ClassLibrary1.Model;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Manager
{
    public class TaskSaleTransactionManager
    {
        private readonly ApplicationDbContext _context;

        private readonly IntegrationManager _integrationManager;

        private readonly ILogger<TaskSaleTransactionManager> _logger;

        private readonly SaleTransactionManager _saleTransactionManager;

        public TaskSaleTransactionManager(ApplicationDbContext _context, ILogger<TaskSaleTransactionManager> _logger, SaleTransactionManager saleTransactionManager, IntegrationManager _integrationManager)
        {
            this._context = _context;
            this._integrationManager = _integrationManager;
            this._logger = _logger;
            this._saleTransactionManager = saleTransactionManager;
        }

        public async Task SubmitError()
        {
            var task = await _context.Set<TaskSaleTransaction>().Where(x => x.IsFail == false).Select(x => x.SaleTransactionId).Distinct().ToListAsync();

            foreach (var transaction in task)
            {
                await SubmitIntegrationAsync(transaction);
            }
        }

        public async Task SubmitIntegrationAsync(Guid saleId)
        {
            _logger.LogInformation(message: "Preparing data for submit sale transaction to aeon", saleId);

            var saleTransaction = await _saleTransactionManager.GetSaleTransactionById(saleId);

            if (saleTransaction == null) return;

            //var result = await _integrationManager.SubmitAeonSale(saleTransaction, saleTransaction);

            //if (result) await UpdateTransactionRelatedWith(saleTransactionId);
        }
    }
}
