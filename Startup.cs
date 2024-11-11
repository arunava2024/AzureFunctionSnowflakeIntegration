using Microsoft.Azure.Functions.Extensions.DependencyInjection;
using Microsoft.Extensions.DependencyInjection;
using AzureFunctionSnowflakeIntegration.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[assembly: FunctionsStartup(typeof(AzureFunctionSnowflakeIntegration.Startup))]

namespace AzureFunctionSnowflakeIntegration
{
    public class Startup : FunctionsStartup
    {
        public override void Configure(IFunctionsHostBuilder builder)
        {

            builder.Services.AddTransient<ISnowflakeService, SnowflakeService>();
        }
    }
}
