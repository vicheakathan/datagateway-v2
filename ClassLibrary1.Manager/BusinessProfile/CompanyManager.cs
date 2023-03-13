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
    public class CompanyManager
    {
        private readonly ApplicationDbContext _context;

        private readonly IMapper _mapper;

        public CompanyManager(ApplicationDbContext _context, IMapper _mapper) 
        { 
            this._context = _context;
            this._mapper = _mapper;
        }

        public async Task<object> GetCompanies()
        {
            var c = await _context.Set<Company>().ToListAsync();

            return c;
        }

        public async Task<object> AddCompanies(ClientCompany entity)
        {
            var company = _mapper.Map<ClientCompany, Company>(entity);

            _context.Add(company);
            await _context.SaveChangesAsync();

            return company;
        }

        public async Task<object> UpdateCompanies(ClientCompany entity)
        {
            var company = _context.Find<Company>(entity.Id);

            if (company == null)
            {
                throw new InvalidOperationException("Not Found.");
            }

            //company.PhoneNumber = c.PhoneNumber;
            //company.IsActive = c.IsActive;
            //company.Name = c.Name;
            //company.Address = c.Address;

            _mapper.Map<Company, ClientCompany>(company, entity);

            _context.Update(company);
            await _context.SaveChangesAsync();

            return company;
        }
    }
}
