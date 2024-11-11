using System;
using System.IO;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Azure.WebJobs;
using Microsoft.Azure.WebJobs.Extensions.Http;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Logging;
using Newtonsoft.Json;
using System.Collections.Generic;
using AzureFunctionSnowflakeIntegration.Services;

namespace AzureFunctionSnowflakeIntegration
{
    public class SFFunction
    {
        public readonly ISnowflakeService _snowflakeService;
        public SFFunction(ISnowflakeService snowflakeService)
        {
            _snowflakeService = snowflakeService;
        }
        [FunctionName("SF-Function-GetAll")]
        public async Task<IActionResult> GetAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var sfQuery = req.Query["sfquery"];

            List<Dictionary<string, object>> employeeList = new List<Dictionary<string, object>>();

            employeeList = await _snowflakeService.GetAllContactsFromSnowflake(sfQuery);
            var responseData = JsonConvert.SerializeObject(employeeList);


            return new OkObjectResult(responseData);
        }
        //http://localhost:7071/api/SF-Function-GetAll?sfquery=select * from MYSCHEMA.EMPLOYEE LIMIT 10 OFFSET 5

        [FunctionName("SF-Function-Insert")]
        public async Task<IActionResult> InserAll(
            [HttpTrigger(AuthorizationLevel.Function, "get", Route = null)] HttpRequest req,
            ILogger log)
        {
            log.LogInformation("C# HTTP trigger function processed a request.");

            var result = await _snowflakeService.InsertContactIntoSnowflake();

            return new OkObjectResult(result);
        }
    }
}
