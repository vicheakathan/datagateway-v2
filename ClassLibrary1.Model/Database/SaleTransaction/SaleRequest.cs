using ClassLibrary1.Core;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations.Schema;

namespace ClassLibrary1.Model
{
    public class SaleRequest : BaseEntity<SaleRequest>
    {
        public Guid Id { get; set; }

        [ForeignKey(nameof(Tenant))]
        public Guid TenantId { get; set; }

        public Tenant? Tenant { get; set; }

        public string? CallBackUrl { get; set; }

        public ICollection<SaleTransaction>? SaleTransactions { get; set; }

        public SaleRequest()
        {
            SaleTransactions = new Collection<SaleTransaction>();
        }
    }
}
