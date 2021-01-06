using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AX2012AIFProxySample.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirPersonController : ControllerBase
    {

        readonly Approval.DirPersonInfoServiceClient aifClient;

        public DirPersonController()
        {

            Approval.DirPersonInfoServiceClient.EndpointConfiguration endpointConfiguration = Approval.DirPersonInfoServiceClient.EndpointConfiguration.NetTcpBinding_DirPersonInfoService;
            aifClient = new Approval.DirPersonInfoServiceClient(endpointConfiguration);
        }

        // GET: api/<DirPersonController>
        [HttpGet]
        public async Task<Approval.DirPersonInfoData> Get()
        {
            Approval.DirPersonInfoServiceGetPersonInfoFromUserIdResponse response;

            Approval.CallContext callContext = new Approval.CallContext();
            callContext.Company = "USMF";
            response = await aifClient.getPersonInfoFromUserIdAsync(callContext, "ANNIE");

            return response.response;
        }

        // GET: api/<DirPersonController>/<userid>
        [HttpGet("{userid}")]
        public async Task<Approval.DirPersonInfoData> Get(string userId)
        {
            Approval.DirPersonInfoServiceGetPersonInfoFromUserIdResponse response;

            Approval.CallContext callContext = new Approval.CallContext();
            callContext.Company = "USMF";
            response = await aifClient.getPersonInfoFromUserIdAsync(callContext, userId);

            return response.response;
        }

    }
}
