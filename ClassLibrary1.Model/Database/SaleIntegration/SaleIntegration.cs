using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class SaleIntegration : BaseEntity<SaleIntegration>
    {
        public Guid Id { get; set; }

        public DateTime CreateDate { get; set; }

        [ForeignKey(nameof(SaleTransaction))]
        public Guid SaleTransactionId { get; set; }

        public SaleTransaction? SaleTransaction { get; set; }

        public SaleIntegration()
        {

        }
    }
}
