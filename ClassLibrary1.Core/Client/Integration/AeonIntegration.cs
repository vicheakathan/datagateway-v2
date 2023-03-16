using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Core
{
    public class AeonIntegration
    {
        [JsonProperty("transaction_oid")]
        public Guid TransactionId { get; set; }

        [JsonProperty("receipt_id")]
        public string? ReceiptId { get; set; }

        [JsonProperty("invoice_id")]
        public string? InvoiceId { get; set; }

        [JsonProperty("document_type")]
        public string? DocumentType { get; set; }

        [JsonProperty("date_time")]
        public DateTime Datetime { get; set; }

        [JsonProperty("currency_name")]
        public string? CurrencyName { get; set; }

        [JsonProperty("discount_type")]
        public string? DiscountType { get; set; }

        [JsonProperty("discount_amount")]
        public decimal DiscountAmount { get; set; }

        [JsonProperty("return_qty")]
        public int ReturnQty { get; set; }

        [JsonProperty("return_amount")]
        public decimal ReturnAmount { get; set; }

        [JsonProperty("refund_qty")]
        public int RefundQty { get; set; }

        [JsonProperty("refund_amount")]
        public decimal RefundAmount { get; set; }

        [JsonProperty("payment_method_1")]
        public string? PaymentMethod1 { get; set; }

        [JsonProperty("payment_amount_1")]
        public decimal PaymentAmount1 { get; set; }

        [JsonProperty("payment_method_2")]
        public string? PaymentMethod2 { get; set; }

        [JsonProperty("payment_amount_2")]
        public decimal PaymentAmount2 { get; set; }

        [JsonProperty("payment_method_3")]
        public string? PaymentMethod3 { get; set; }

        [JsonProperty("payment_amount_3")]
        public decimal PaymentAmount3 { get; set; }

        [JsonProperty("delivery_service")]
        public string? DeliveryService { get; set; }

        [JsonProperty("exchange_rate_value")]
        public decimal ExchangeRateValue { get; set; }

        [JsonProperty("vat")]
        public decimal Vat { get; set; }

        [JsonProperty("cashier_id")]
        public string? CashierId { get; set; }

        [JsonProperty("amount_before_vat_discount")]
        public decimal AmountBeforeVatDiscount { get; set; }

        public AeonIntegration()
        {
        }

        public AeonIntegration(Guid transactionId, string receiptId, string invoiceId, string documentType, DateTime datetime, string currencyName, string discountType, decimal discountAmount, int returnQty, int refundQty, int refundAmount, string paymentMethod1, decimal paymentAmount1, string paymentMethod2, decimal paymentAmount2, string paymentMethod3, decimal paymentAmount3, string deliveryService, decimal exchangeRateValue, decimal vat, string cashierId, decimal amountBeforeVatDiscount) : this()
        {
            TransactionId = transactionId;
            ReceiptId = receiptId;
            InvoiceId = invoiceId;
            DocumentType = documentType;
            Datetime = datetime;
            CurrencyName = currencyName;
            DiscountType = discountType;
            DiscountAmount = discountAmount;
            ReturnQty = returnQty;
            RefundQty = refundQty;
            RefundAmount = refundAmount;
            PaymentMethod1 = paymentMethod1;
            PaymentAmount1 = paymentAmount1;
            PaymentMethod2 = paymentMethod2;
            PaymentAmount2 = paymentAmount2;
            PaymentMethod3 = paymentMethod3;
            PaymentAmount3 = paymentAmount3;
            DeliveryService = deliveryService;
            ExchangeRateValue = exchangeRateValue;
            Vat = vat;
            CashierId = cashierId;
            AmountBeforeVatDiscount = amountBeforeVatDiscount;
        }
    }
}
