using AutoMapper;
using ClassLibrary1.Core;
using ClassLibrary1.Model;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Manager
{
    public class SaleTransactionManager
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        private readonly RunBackground _runBackground;

        public SaleTransactionManager(ApplicationDbContext _context, IMapper _mapper, RunBackground _runBackground) 
        { 
            this._context = _context;
            this._mapper = _mapper;
            this._runBackground = _runBackground;
        }

        public async Task<object> PostSaleTransactionAsync(ClientDataGateway entity)
        {
            SaleRequest saleRequest = _mapper.Map<ClientDataGateway, SaleRequest>(entity);

            _context.Add(saleRequest);
            await _context.SaveChangesAsync();

            _runBackground.RunAction(() => CloundSystemEvent.Instand.OnTaskCreate(saleRequest.Id));

            return saleRequest;
        }

        public async Task<object> GetSaleTransactionAsync()
        {
            return await _context.Set<SaleTransaction>().ToListAsync();
        }

        public async Task<object> GetSaleTransactionById(Guid id)
        {
            var sale = await _context.Set<SaleTransaction>()
                .Where(x => x.Id == id).Include(x => x.Items)
                .Include(x => x.Payment)
                .Include(x => x.SaleTransactionDetails)
                .Include(x => x.SaleRequest)
                .ThenInclude(x => x.Tenant)
                .ToListAsync();

            return sale;
        }

        public async Task<object> Add(Guid saleRequestId)
        {
            TaskSaleTransaction task = new TaskSaleTransaction();
            
            var requestSaleTrans = await _context.Set<SaleTransaction>().Where(x => x.RequestId == saleRequestId).Select(x => x.Id).ToListAsync();

            foreach (var saleTran in requestSaleTrans)
            {
                task.SaleTransactionId = saleTran;
                task.CreatedDate = DateTime.Now;
                task.IsSuccess = false;
                task.IsFail = false;
            }

            _context.Add(task);
            await _context.SaveChangesAsync();

            //await Process(task.Id, true);

            return task;
        }
    }
}
