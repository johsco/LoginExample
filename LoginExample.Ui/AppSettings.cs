using LoginExample.Interfaces;
using Microsoft.Extensions.Configuration;

namespace LoginExample
{
    public class AppSettings : IAppSettings
    {
        private IConfiguration _configuration;

        public AppSettings(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public string LoginDb => _configuration.GetConnectionString("LoginExample");
    }
}