using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
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

        [StringLength(128)]
        public string? Type { get; set; }

        [StringLength(128)]
        public string? Key { get; set; }

        [StringLength(128)]
        public string? Description { get; set; }

        [Column(TypeName = "Money")]
        public decimal Percentage { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        [StringLength(128)]
        public string? ReasonCode { get; set; }

        [StringLength(128)]
        public string? ReasonCodeName { get; set; }

        [StringLength(128)]
        public string? PromotionName { get; set; }

        [StringLength(128)]
        public string? PromotionCode { get; set; }

        [StringLength(128)]
        public string? CreateByName { get; set; }

        [StringLength(128)]
        public string? CreateById { get; set; }

        public Guid CreateByTerminalId { get; set; }

        [StringLength(128)]
        public string? CreateByTerminalName { get; set; }

        [StringLength(128)]
        public string? Note { get; set; }

        [ForeignKey(nameof(SaleTransaction))]
        public Guid SaleTransactionId { get; set; }

        public SaleTransaction? SaleTransaction { get; set; }

        public SaleTransactionDetails()
        {
        }
    }
}
