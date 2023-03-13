using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core
{
    public class ClientTenant : BaseClientInfo
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string? Name { get; set; }

        public string? Username { get; set; }

        public string? Password { get; set; }

        public bool? IsActive { get; set; }

        public Guid CompanyId { get; set; }

        public ClientTenant() 
        {
            CreateDate = DateTime.Now;
        }
    }
}
