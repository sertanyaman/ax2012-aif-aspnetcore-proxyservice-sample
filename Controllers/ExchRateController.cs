using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.ServiceModel;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace AX2012AIFProxySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ExchRateController : ControllerBase
    {
        readonly ExchangeRate.ExchangeRateForCurrenciesServiceClient aifClient;

        public ExchRateController()
        {
            ExchangeRate.ExchangeRateForCurrenciesServiceClient.EndpointConfiguration endpointConfiguration = ExchangeRate.ExchangeRateForCurrenciesServiceClient.EndpointConfiguration.NetTcpBinding_ExchangeRateForCurrenciesService;
            aifClient = new ExchangeRate.ExchangeRateForCurrenciesServiceClient(endpointConfiguration);
        }

        // GET: api/<ExchRateController>
        [HttpGet]
        public async Task<decimal> Get()
        {
            ExchangeRate.ExchangeRateForCurrenciesServiceGetExchangeRateForCurrenciesResponse response;

            ExchangeRate.CallContext callContext = new ExchangeRate.CallContext();
            callContext.Company = "USMF";
            response = await aifClient.getExchangeRateForCurrenciesAsync(callContext, "EUR", "USD", DateTime.UtcNow, "USMF");

            return response.response;
        }
    }
}
