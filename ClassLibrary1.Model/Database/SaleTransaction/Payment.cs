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
    public class Payment : BaseEntity<Payment>
    {
        public Guid Id { get; set; }

        [StringLength(64)]
        public string? PaymentCd { get; set; }

        [StringLength(64)]
        public string? PaymentName { get; set; }

        [StringLength(64)]
        public string? PaymentKey { get; set; }

        [StringLength(64)]
        public string? PaymentTypeCd { get; set; }

        [StringLength(64)]
        public string? PaymentTypeName { get; set; }

        [StringLength(64)]
        public string? CurrencyCd { get; set; }

        [StringLength(64)]
        public string? CurrencyName { get; set; }

        [StringLength(64)]
        public string? CurrencyAbv { get; set; }

        [StringLength(64)]
        public string? CurrencySign { get; set; }

        [Column(TypeName = "Money")]
        public decimal ExchangeRate { get; set; }

        public bool IsCash { get; set; }

        [Column(TypeName = "Money")]
        public decimal Amount { get; set; }

        [Column(TypeName = "Money")]
        public decimal Variance { get; set; }

        [Column(TypeName = "Money")]
        public decimal Rounding { get; set; }

        [ForeignKey(nameof(SaleTransaction))]
        public Guid SaleTransactionId { get; set; }

        public SaleTransaction? SaleTransaction { get; set; }

        public Payment()
        {
        }
    }
}
