using ClassLibrary1.Core;
using ClassLibrary1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Bson;
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
            aeonSale.Datetime = source.OrderDateTime;
            aeonSale.CashierId = source.ReceiptByName;
            aeonSale.AmountBeforeVatDiscount = source.Subtotal;
            aeonSale.DiscountAmount = source.TotalDiscount;
            aeonSale.ReturnQty = 0;
            aeonSale.ReturnAmount = 0;
            aeonSale.RefundQty = 0;
            aeonSale.RefundAmount = 0;
            aeonSale.DeliveryService = null;
            aeonSale.Vat = 0;
            aeonSale.DocumentType = "CashSale";
            aeonSale.CurrencyName = "Dollar";
            aeonSale.DiscountType = null;

            PaymentMethod(aeonSale, source);

            return aeonSale;
        }

        public void PaymentMethod(AeonIntegration aeon ,SaleTransaction sale)
        {
            var NonOtherPayment = sale.Payment.Where(x => x.PaymentName != "Other").ToList();
            if (NonOtherPayment.Count() > 0)
            {
                var payment1 = NonOtherPayment.ElementAtOrDefault(0);
                var payment2 = NonOtherPayment.ElementAtOrDefault(1);

                aeon.PaymentMethod1 = payment1?.PaymentName;
                aeon.PaymentAmount1 = payment1?.Amount ?? 0;

                aeon.PaymentMethod2 = payment2?.PaymentName;
                aeon.PaymentAmount2 = payment2?.Amount ?? 0;

                aeon.ExchangeRateValue = NonOtherPayment.FirstOrDefault().ExchangeRate;
            }

            //var OtherPayment = sale.Payment.Where(x => x.PaymentName == "Other").ToList();
            //if (OtherPayment.Count() > 0)
            //{

            //}
        }
    }
}
