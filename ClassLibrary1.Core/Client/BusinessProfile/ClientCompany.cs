using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core
{
    public class ClientCompany : BaseClientInfo
    {
        [IgnoreMapping]
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string? Name { get; set; }

        public string? Address { get; set; }

        public string? PhoneNumber { get; set; }

        public string? Email { get; set; }

        public bool? IsActive { get; set; }

        public ClientCompany()
        {
            CreateDate = DateTime.Now;
        }
    }
}
