using ClassLibrary1.Core;
using ClassLibrary1.Core.Client.Authorize;
using ClassLibrary1.Model;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClassLibrary1.Manager
{
    public class TestIntegrationManager
    {
        private readonly IHttpClientFactory _factory;

        private readonly ApplicationDbContext _context;

        private readonly SecurityManager _securityManager;

        public TestIntegrationManager(IHttpClientFactory _factory, ApplicationDbContext context, SecurityManager securityManager)
        {
            this._factory = _factory;
            this._context = context;
            this._securityManager = securityManager;
        }
        public async Task<bool> Test()
        {
            try
            {
                Tenant tenant = new Tenant();
                //AeonIntegration data = new AeonIntegration();
                //SaleTransaction sale = new SaleTransaction();
                var sale = _context.Set<SaleTransaction>().Where(x => x.Id.ToString() == "cc48c936-ab6a-4ad8-f0d8-08db2696465e").FirstOrDefault();

                var credential = new BaseCredential("atech", "Admin@123");

                var client = _factory.CreateClient("test");

                await Login(client, credential);

                var data = AeonIntegrationBuilder(sale);

                var j = JsonConvert.SerializeObject(data);

                var submit = await SubmitData(client, data, tenant);

                if (submit == true)
                    await InertSaleIntegration(sale);

                return submit;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> SubmitData(HttpClient client, AeonIntegration data, Tenant tenant)
        {
            StringContent stringContent = new StringContent(JObject.FromObject(data).ToString(), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/saletransaction", stringContent);
            var stringResponse = await response.Content.ReadAsStringAsync();

            return response.IsSuccessStatusCode;
        }

        public async Task<object> Login(HttpClient client, BaseCredential credential)
        {
            StringContent stringContent = new StringContent(JObject.FromObject(credential).ToString(), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/auth", stringContent);

            var token = JObject.Parse(await response.Content.ReadAsStringAsync());

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token["access_token"]?.ToString());

            return token;
        }

        public async Task InertSaleIntegration(SaleTransaction saleTran)
        {
            SaleIntegration saleIntegration = new SaleIntegration();
            saleIntegration.SaleTransactionId = saleTran.Id;
            saleIntegration.CreateDate = DateTime.Now;

            _context.Add(saleIntegration);
            await _context.SaveChangesAsync();
        }

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
            aeonSale.PaymentAmount1= 10;
            aeonSale.PaymentMethod1 = "Cash";
            aeonSale.PaymentAmount2 = 0;
            aeonSale.PaymentMethod2 = null;
            aeonSale.PaymentMethod3 = null;
            aeonSale.PaymentAmount3 = 0;

            return aeonSale;
        }
        
    }
}
