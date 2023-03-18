using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class SaleTransactionHistory : BaseEntity<SaleTransactionHistory>
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        public string? Data { get; set; }

        public string? Response { get; set; }

        public string? Tenant { get; set; }

        public SaleTransactionHistory()
        {

        }
    }
}
