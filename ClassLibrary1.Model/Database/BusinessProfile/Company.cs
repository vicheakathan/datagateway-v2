using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class Company : BaseEntity<Company>
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get;set; }

        public string? Email { get; set; }

        public bool? IsActive { get; set; }

        public ICollection<Tenant>? Tenants { get; set; }

        public Company() 
        {
            CreateDate = DateTime.Now;

            Tenants = new Collection<Tenant>();
        }
    }
}
