using BlazorWASM_SignalR.Server.Models;
using BlazorWASM_SignalR.Server.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BlazorWASM_SignalR.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class MySqlPNAController : ControllerBase
    {
        readonly IMySqlPNA imySql;

        public MySqlPNAController(IMySqlPNA mySql)
        {
            imySql = mySql;
        }

        [HttpGet("[action]")]
        public async Task<List<ServerModelMySqlPNA>> PNAModelList()
        {
            var model = await imySql.PNAModelList();
            return model;
        }
    }
}
