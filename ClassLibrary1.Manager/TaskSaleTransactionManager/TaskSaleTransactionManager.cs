using ClassLibrary1.Model;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.SignalR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
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

        public async Task<object> SubmitIntegration()
        {
            var saleTransacton = await _context.Set<TaskSaleTransaction>().Where(x => x.IsFail == true).Select(x => x.SaleTransactionId).ToListAsync();

            if (saleTransacton.Count() == 0)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            foreach (var transaction in saleTransacton)
            {
                var saleTransaction = await _saleTransactionManager.GetSaleTransactionById(transaction);

                if (saleTransaction == null) return null;

                var result = await _integrationManager.CheckSubmitData(saleTransaction, saleTransaction?.SaleRequest?.Tenant);

                var taskSaleTransaction = await _context.Set<TaskSaleTransaction>().Where(x => x.SaleTransactionId == transaction).ToListAsync();

                foreach (var task in taskSaleTransaction)
                {
                    if (result == true)
                    {
                        task.IsSuccess = true;
                        task.IsFail = false;
                        task.CompleteDate = DateTime.Now;
                    }
                    else
                    {
                        task.IsSuccess = false;
                        task.IsFail = true;
                        task.FailDate= DateTime.Now;
                    }

                    _context.Update(task);
                }

                await _context.SaveChangesAsync();
            }

            return new HttpResponseMessage();
        }

        public async Task<object> PostTaskSaleTransaction(Guid saleRequestId)
        {
            var requestSaleTrans = await _context.Set<SaleTransaction>().Where(x => x.RequestId == saleRequestId).Select(x => x.Id).ToListAsync();

            if (requestSaleTrans == null)
            {
                return new HttpResponseMessage(HttpStatusCode.NotFound);
            }

            var tenant = _context.Set<SaleRequest>().Where(x => x.Id == saleRequestId).Include(x => x.Tenant).FirstOrDefault();

            foreach (var saleTran in requestSaleTrans)
            {
                TaskSaleTransaction task = new TaskSaleTransaction();

                var existingTaskSaleTransaction = await _context.Set<TaskSaleTransaction>().Where(x => x.SaleTransactionId == saleTran).FirstOrDefaultAsync();

                if (existingTaskSaleTransaction != null)
                    break;

                task.SaleTransactionId = saleTran;
                task.CreatedDate = DateTime.Now;
                task.IsSuccess = false;
                task.IsFail = true;
                task.Tenant = tenant.Tenant.Name;

                _context.Add(task);
            }

            await _context.SaveChangesAsync();

            return requestSaleTrans;
        }
    }
}
