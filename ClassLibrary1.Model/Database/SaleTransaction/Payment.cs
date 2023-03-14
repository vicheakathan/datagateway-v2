using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class Payment : BaseEntity<Payment>
    {
        public Guid Id { get; set; }

        public string? PaymentCd { get; set; }

        public string? PaymentName { get; set; }

        public string? PaymentKey { get; set; }

        public string? PaymentTypeCd { get; set; }

        public string? PaymentTypeName { get; set; }

        public string? CurrencyCd { get; set; }

        public string? CurrencyName { get; set; }

        public string? CurrencyAbv { get; set; }

        public string? CurrencySign { get; set; }

        public decimal ExchangeRate { get; set; }

        public bool IsCash { get; set; }

        public decimal Amount { get; set; }

        public decimal Variance { get; set; }

        public decimal Rounding { get; set; }

        [ForeignKey(nameof(SaleTransaction))]
        public Guid SaleTransactionId { get; set; }

        public SaleTransaction? SaleTransaction { get; set; }

        public Payment()
        {
        }
    }
}
