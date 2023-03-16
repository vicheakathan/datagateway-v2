using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace ClassLibrary1.Model
{
    public class IntegrationMonitor : IHostedService, IDisposable
    {
        private readonly IHostEnvironment _environment;

        private readonly IConfiguration _configuration;

        private readonly ILogger<IntegrationMonitor> _logger;

        private Timer? _timer;

        public IntegrationMonitor(IHostEnvironment _environment, IConfiguration _configuration, ILogger<IntegrationMonitor> _logger)
        {
            this._environment = _environment;
            this._configuration = _configuration;
            this._logger = _logger;
        }

        public void Dispose()
        {
            _timer?.Dispose();
        }

        public Task StartAsync(CancellationToken cancellationToken)
        {
            CloundSystemEvent.Instand.TaskCreated += Instand_TaskCreated;

            //_timer = new Timer(CallOnResubmitAll, null, TimeSpan.Zero, TimeSpan.FromMinutes(2));

            return Task.CompletedTask;
        }

        public Task StopAsync(CancellationToken cancellationToken)
        {
            return Task.CompletedTask;
        }

        private void CallOnResubmitAll(object? state)
        {
            var host = _configuration.GetSection("IntegrationSetting").GetValue<string>(_environment.IsDevelopment() ? "LocalHostUrl" : "ProductionUrl");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(host);

            client.PostAsync($"/api/TaskSaleTransaction/SubmitIntegration", null);

            _logger.LogWarning($"Submit integration have been called...");
        }

        private void Instand_TaskCreated(Guid taskId)
        {
            var host = _configuration.GetSection("IntegrationSetting").GetValue<string>(_environment.IsDevelopment() ? "LocalHostUrl" : "ProductionUrl");

            HttpClient client = new HttpClient();
            client.BaseAddress = new Uri(host);

            client.GetAsync($"/api/TaskSaleTransaction/AddTaskByRequest?saleId={taskId}");

            _logger.LogWarning($"Event have been invoked by task id:{taskId}.");

        }
    }
}
