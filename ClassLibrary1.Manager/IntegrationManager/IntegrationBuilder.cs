using ClassLibrary1.Core;
using ClassLibrary1.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Manager
{
    public class IntegrationBuilder
    {
        public IntegrationBuilder() { }

        public AeonIntegration AeonIntegrationBuilder(SaleTransaction source)
        {
            AeonIntegration aeonSale = new AeonIntegration();

            aeonSale.TransactionId = source.Id;
            aeonSale.ReceiptId = source.ReceiptId;
            aeonSale.InvoiceId = source.InvoiceId ?? source.OrderId.ToString();
            aeonSale.DocumentType = "CashSale";
            aeonSale.Datetime = source.OrderDateTime;
            aeonSale.CurrencyName = "Dollar";
            aeonSale.DiscountType = null;
            aeonSale.DiscountAmount = source.TotalDiscount;
            aeonSale.ReturnQty = 0;
            aeonSale.ReturnAmount = 0;
            aeonSale.RefundQty = 0;
            aeonSale.RefundAmount = 0;
            aeonSale.PaymentAmount1 = 10;
            aeonSale.PaymentMethod1 = "Cash";
            aeonSale.PaymentAmount2 = 0;
            aeonSale.PaymentMethod2 = null;
            aeonSale.PaymentAmount3 = 0;
            aeonSale.PaymentMethod3 = null;
            aeonSale.DeliveryService = null;
            aeonSale.ExchangeRateValue = 4100;
            aeonSale.Vat = 0;
            aeonSale.CashierId = source.ReceiptByName;
            aeonSale.AmountBeforeVatDiscount = source.Subtotal;

            return aeonSale;
        }
    }
}
