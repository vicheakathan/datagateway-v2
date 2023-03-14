using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class SaleTransactionDetails : BaseEntity<SaleTransactionDetails>
    {
        public Guid Id { get; set; }

        public DateTime ? CreatedDate { get; set; }

        public string? Type { get; set; }

        public string? Key { get; set; }

        public string? Description { get; set; }

        public decimal Percentage { get; set; }

        public decimal Amount { get; set; }

        public string? ReasonCode { get; set; }

        public string? ReasonCodeName { get; set; }

        public string? PromotionName { get; set; }

        public string? PromotionCode { get; set; }

        public string? CreateByName { get; set; }

        public string? CreateById { get; set; }


        public Guid CreateByTerminalId { get; set; }

        public string? CreateByTerminalName { get; set; }

        public string? Note { get; set; }

        [ForeignKey(nameof(SaleTransaction))]
        public Guid SaleTransactionId { get; set; }

        public SaleTransaction? SaleTransaction { get; set; }

        public SaleTransactionDetails()
        {
        }
    }
}
