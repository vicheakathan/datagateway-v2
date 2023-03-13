using AutoMapper;
using ClassLibrary1.Core;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Manager
{
    public class TenantManager
    {
        private readonly IMapper _mapper;

        private readonly ApplicationDbContext _context;

        public TenantManager(IMapper _mapper, ApplicationDbContext _context) 
        { 
            this._mapper = _mapper;
            this._context = _context;
        }

        public async Task<object> GetTenantAsync()
        {
            return await _context.Set<Tenant>().ToListAsync();
        }

        public async Task<object> AddTenantAsync(ClientTenant entity)
        {
            var tenant = _mapper.Map<ClientTenant, Tenant>(entity);

            _context.Add(tenant);
            await _context.SaveChangesAsync();

            return tenant;
        }

        public async Task<object> UpdateTenantAsync(ClientTenant entity)
        {
            var tenant = _context.Find<Tenant>(entity.Id);

            if (tenant == null)
            {
                throw new InvalidOperationException("Not Found.");
            }

            _mapper.Map<ClientTenant, Tenant>(entity, tenant);

            _context.Update(tenant);
            await _context.SaveChangesAsync();

            return tenant;
        }
    }
}
