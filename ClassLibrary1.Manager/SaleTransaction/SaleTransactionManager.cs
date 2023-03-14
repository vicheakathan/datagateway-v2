using AutoMapper;
using ClassLibrary1.Core;
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

        public SaleTransactionManager(ApplicationDbContext _context, IMapper _mapper) 
        { 
            this._context = _context;
            this._mapper = _mapper;
        }

        public async Task<object> SubmitSaleTransaction(ClientDataGateway entity)
        {
            SaleRequest saleRequest = _mapper.Map<ClientDataGateway, SaleRequest>(entity);

            _context.Add(saleRequest);
            await _context.SaveChangesAsync();

            return saleRequest;
        }
    }
}
