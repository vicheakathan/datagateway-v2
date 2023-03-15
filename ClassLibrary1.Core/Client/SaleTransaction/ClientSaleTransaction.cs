using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core
{
    public class ClientSaleTransaction
    {
        [IgnoreMapping]
        public Guid Id { get; set; }

        #region items

        public DateTime OrderDateTime { get; set; }

        public long? OrderId { get; set; }

        public string? InvoiceId { get; set; }

        public string? InvoiceById { get; set; }

        public string? InvoiceByName { get; set; }

        public string? SectionId { get; set; }

        public string? SectionName { get; set; }

        public string? SectionEnglishName { get; set; }

        public string? SectionKhmerName { get; set; }

        public string? SectionAbv { get; set; }

        public string? TableCd { get; set; }

        public string? TableName { get; set; }

        public string? TableEnglishName { get; set; }

        public string? TableKhmerName { get; set; }

        public string? TableAbv { get; set; }

        public string? FloorId { get; set; }

        public string? FloorName { get; set; }

        public string? FloorEnglishName { get; set; }

        public string? FloorKhmerName { get; set; }

        public string? FloorAbv { get; set; }

        public string? ChanncelAbv { get; set; }

        public string? ChannelName { get; set; }

        public string? SourceCd { get; set; }

        public string? SourceName { get; set; }

        public string? Pax { get; set; }

        public string? DeliveryId { get; set; }

        public DateTime ScheduleDate { get; set; }

        public string? CustomerName { get; set; }

        public string? CustomerPhone { get; set; }

        public string? CustomerType { get; set; }

        public string? CustomerAddress { get; set; }

        public string? CustomerNote { get; set; }

        public string? CardNumber { get; set; }

        public string? CardCd { get; set; }

        public decimal TotalQty { get; set; }

        public decimal Subtotal { get; set; }

        public decimal ServiceCharge { get; set; }

        public decimal OtherCharge { get; set; }

        public decimal TotalDiscount { get; set; }

        public decimal Vat { get; set; }

        public decimal VatPercentage { get; set; }

        public decimal Plt { get; set; }

        public decimal PltPercentage { get; set; }

        public decimal GrandTotal { get; set; }

        public decimal Paid { get; set; }

        public string? Note { get; set; }

        public string? ReasonCode { get; set; }

        public string? ReasonName { get; set; }

        public string? ReferenceCode { get; set; }

        public string? Status { get; set; }

        public string? Type { get; set; }

        public string? OrderById { get; set; }

        public string? OrderByName { get; set; }

        public Guid OrderByTerminalId { get; set; }

        public string? OrderByTerminalName { get; set; }

        public string? ReceiptId { get; set; }

        public DateTime TenderDate { get; set; }

        public string? ReceiptNote { get; set; }

        public string? ReceptById { get; set; }

        public string? ReceiptByName { get; set; }

        public Guid ReceiptByTerminalId { get; set; }

        public string? ReceiptByTernialName { get; set; }

        public string? ReceiptRef { get; set; }

        public string? CouponName { get; set; }

        public string? CouponCode { get; set; }

        public string? CouponPromotionCd { get; set; }

        #endregion

        [IgnoreMapping]
        public List<ClientPayment> Payment { get; set; }

        [IgnoreMapping]
        public List<ClientSaleItems> Items { get; set; }

        [IgnoreMapping]
        public List<ClientSaleTransactionDetails> SaleTransactionDetails { get; set; }

        [IgnoreMapping]
        public List<ClientTaskSaleTransaction> TaskSaleTransactions { get; set; }

        public ClientSaleTransaction()
        {
            Payment= new List<ClientPayment>();

            Items= new List<ClientSaleItems>();

            SaleTransactionDetails = new List<ClientSaleTransactionDetails>();

            TaskSaleTransactions = new List<ClientTaskSaleTransaction>();
        }
    }
}
