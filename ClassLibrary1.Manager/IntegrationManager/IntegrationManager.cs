using AutoMapper;
using ClassLibrary1.Core;
using ClassLibrary1.Core.Client.Authorize;
using ClassLibrary1.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Logging;
using Microsoft.Identity.Client.Platforms.Features.DesktopOs.Kerberos;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary1.Manager
{
    public class IntegrationManager
    {
        private readonly ApplicationDbContext _context;

        private readonly IHttpClientFactory _factory;

        private readonly SecurityManager _securityManager;

        private readonly ILogger<IntegrationManager> _logger;

        private readonly IMapper _mapper;

        private readonly IntegrationBuilder _integrationBuilder;

        public IntegrationManager(ApplicationDbContext _context, IHttpClientFactory _factory, SecurityManager _securityManager, ILogger<IntegrationManager> logger, IMapper _mapper, IntegrationBuilder _integrationBuilder)
        {
            this._context = _context;
            this._factory = _factory;
            this._securityManager = _securityManager;
            this._logger = logger;
            this._mapper = _mapper;
            this._integrationBuilder = _integrationBuilder;
        }

        public async Task<bool> CheckSubmitData(SaleTransaction saleTransaction, Tenant tenant)
        {
            try
            {
                var existingIntegration = await _context.Set<SaleIntegration>().Where(x => x.SaleTransactionId == saleTransaction.Id).FirstOrDefaultAsync();

                if (existingIntegration != null) return true;

                var aeonSale = _integrationBuilder.AeonIntegrationBuilder(saleTransaction);

                var credential = new BaseCredential(tenant.Username, _securityManager.DecryptPassword(tenant.Password));

                var client = _factory.CreateClient("aeon");

                await Login(client, credential);

                var submitResult = await FinalSubmitDataToMall(client, aeonSale);

                if (submitResult)
                    await InertSaleIntegration(saleTransaction);

                return submitResult;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public async Task<bool> FinalSubmitDataToMall(HttpClient client, AeonIntegration data)
        {
            StringContent stringContent = new StringContent(JObject.FromObject(data).ToString(), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/tenantsale", stringContent);
            var stringResponse = await response.Content.ReadAsStringAsync();

            _logger.LogInformation("Monitor response data from intergration.", JObject.Parse(stringResponse));

            return response.IsSuccessStatusCode;
        }

        public async Task<object> Login(HttpClient client, BaseCredential credential)
        {
            StringContent stringContent = new StringContent(JObject.FromObject(credential).ToString(), System.Text.Encoding.UTF8, "application/json");

            var response = await client.PostAsync("api/token", stringContent);

            var token = JObject.Parse(await response.Content.ReadAsStringAsync());

            client.DefaultRequestHeaders.Authorization = new System.Net.Http.Headers.AuthenticationHeaderValue("Bearer", token["Token"]?.ToString());

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
        
    }
}
