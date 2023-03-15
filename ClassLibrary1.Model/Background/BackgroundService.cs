using Microsoft.Extensions.Logging;

namespace ClassLibrary1.Model
{
    public class RunBackground
    {
        private readonly ILogger<RunBackground> logger;

        public RunBackground(ILogger<RunBackground> logger)
        {
            this.logger = logger;
        }

        public void RunAction(Action? action, string label = "NONE")
        {
            try
            {
                Thread thread = new Thread(() => action?.Invoke());

                thread.Start();
            }
            catch (Exception ex)
            {
                logger.LogError(ex, "Background process begin interupted", label);
            }
        }
    }
}
