using ClassLibrary1.Core;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Model
{
    public class SaleTransaction : BaseEntity<SaleTransaction>
    {
        public Guid Id { get; set; }

        #region items
        
        public DateTime OrderDateTime { get; set; }

        [StringLength(128)]
        public long? OrderId { get; set; }

        [StringLength(128)]
        public string? InvoiceId { get; set; }

        [StringLength(128)]
        public string? InvoiceById { get; set; }

        [StringLength(128)]
        public string? InvoiceByName { get; set; }

        [StringLength(128)]
        public string? SectionId { get; set; }

        [StringLength(128)]
        public string? SectionName { get; set; }

        [StringLength(128)]
        public string? SectionEnglishName { get; set; }

        [StringLength(128)]
        public string? SectionKhmerName { get; set; }

        [StringLength(128)]
        public string? SectionAbv { get; set; }

        [StringLength(128)]
        public string? TableCd { get; set; }

        [StringLength(128)]
        public string? TableName { get; set; }

        [StringLength(128)]
        public string? TableEnglishName { get; set; }

        [StringLength(128)]
        public string? TableKhmerName { get; set; }

        [StringLength(128)]
        public string? TableAbv { get; set; }

        [StringLength(128)]
        public string? FloorId { get; set; }

        [StringLength(128)]
        public string? FloorName { get; set; }

        [StringLength(128)]
        public string? FloorEnglishName { get; set; }

        [StringLength(128)]
        public string? FloorKhmerName { get; set; }

        [StringLength(128)]
        public string? FloorAbv { get; set; }

        [StringLength(128)]
        public string? ChanncelAbv { get; set; }

        [StringLength(128)]
        public string? ChannelName { get; set; }

        [StringLength(128)]
        public string? SourceCd { get; set; }

        [StringLength(128)]
        public string? SourceName { get; set; }

        [StringLength(128)]
        public string? Pax { get; set; }

        [StringLength(128)]
        public string? DeliveryId { get; set; }

        public DateTime ScheduleDate { get; set; }

        [StringLength(128)]
        public string? CustomerName { get; set; }

        [StringLength(128)]
        public string? CustomerPhone { get; set; }

        [StringLength(128)]
        public string? CustomerType { get; set; }

        [StringLength(128)]
        public string? CustomerAddress { get; set; }

        [StringLength(128)]
        public string? CustomerNote { get; set; }

        [StringLength(128)]
        public string? CardNumber { get; set; }

        [StringLength(128)]
        public string? CardCd { get; set; }

        [Column(TypeName = "Money")]
        public decimal TotalQty { get; set; }

        [Column(TypeName = "Money")]
        public decimal Subtotal { get; set; }

        [Column(TypeName = "Money")]
        public decimal ServiceCharge { get; set; }

        [Column(TypeName = "Money")]
        public decimal OtherCharge { get; set; }

        [Column(TypeName = "Money")]
        public decimal TotalDiscount { get; set; }

        [Column(TypeName = "Money")]
        public decimal Vat { get; set; }

        [Column(TypeName = "Money")]
        public decimal VatPercentage { get; set; }

        [Column(TypeName = "Money")]
        public decimal Plt { get; set; }

        [Column(TypeName = "Money")]
        public decimal PltPercentage { get; set; }

        [Column(TypeName = "Money")]
        public decimal GrandTotal { get; set; }

        [Column(TypeName = "Money")]
        public decimal Paid { get; set; }

        [StringLength(128)]
        public string? Note { get; set; }

        [StringLength(128)]
        public string? ReasonCode { get; set; }

        [StringLength(128)]
        public string? ReasonName { get; set; }

        [StringLength(128)]
        public string? ReferenceCode { get; set; }

        [StringLength(128)]
        public string? Status { get; set; }

        [StringLength(128)]
        public string? Type { get; set; }

        [StringLength(128)]
        public string? OrderById { get; set; }

        [StringLength(128)]
        public string? OrderByName { get; set; }

        public Guid OrderByTerminalId { get; set; }

        [StringLength(128)]
        public string? OrderByTerminalName { get; set; }

        [StringLength(128)]
        public string? ReceiptId { get; set; }

        public DateTime TenderDate { get; set; }

        [StringLength(128)]
        public string? ReceiptNote { get; set; }

        [StringLength(128)]
        public string? ReceptById { get; set; }

        [StringLength(128)]
        public string? ReceiptByName { get; set; }

        public Guid ReceiptByTerminalId { get; set; }

        [StringLength(128)]
        public string? ReceiptByTernialName { get; set; }

        [StringLength(128)]
        public string? ReceiptRef { get; set; }

        [StringLength(128)]
        public string? CouponName { get; set; }

        [StringLength(128)]
        public string? CouponCode { get; set; }

        [StringLength(128)]
        public string? CouponPromotionCd { get; set; }

        #endregion

        [ForeignKey(nameof(SaleRequest))]
        public Guid RequestId { get; set; }

        public SaleRequest? SaleRequest { get; set; }

        public ICollection<Payment> Payment { get; set; }

        public ICollection<SaleItems> Items { get; set; }

        public ICollection<SaleTransactionDetails> SaleTransactionDetails { get; set; }

        public ICollection<TaskSaleTransaction> TaskSaleTransaction { get; set; }

        public ICollection<SaleIntegration>? SaleIntegration { get; set; }

        public SaleTransaction()
        {
            Payment = new Collection<Payment>();

            Items = new Collection<SaleItems>();

            SaleTransactionDetails = new Collection<SaleTransactionDetails>();

            TaskSaleTransaction = new Collection<TaskSaleTransaction>();

            SaleIntegration = new Collection<SaleIntegration>();
        }
    }
}
