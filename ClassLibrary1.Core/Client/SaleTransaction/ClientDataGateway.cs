using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core
{
    public class ClientDataGateway
    {
        [IgnoreMapping]
        public Guid Id { get; set; }

        public Guid TenantId { get; set; }

        public string? CallBackUrl { get; set; }

        [Required]
        public List<ClientSaleTransaction> SaleTransactions { get; set; }

        public ClientDataGateway()
        {
            SaleTransactions= new List<ClientSaleTransaction>();
        }
    }
}
