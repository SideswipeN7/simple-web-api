using Microsoft.Extensions.Logging;
using SimpleApp.Interfaces;
using System.Reflection;

namespace SimpleApp.Services
{
    public class VersionService : IVersionService
    {
        public string Version => Assembly.GetExecutingAssembly().GetName().Version.ToString();

        public VersionService(ILogger<VersionService> logger) => logger.LogInformation($"Version: {Version}");
    }
}